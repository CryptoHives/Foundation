// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.EventProcessors;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

static class Program
{
    /// <summary>
    /// Set by <c>scripts/run-benchmarks.ps1 -PowerPlan</c>. BenchmarkDotNet forces the
    /// High Performance plan for the duration of a run unless a job says otherwise, which
    /// defeats any plan the caller activated — including a custom one that caps the maximum
    /// processor state to stop the clock boosting into its thermal limit and then sagging.
    /// Accepts a <see cref="PowerPlan"/> name or a raw plan GUID.
    /// </summary>
    private const string PowerPlanVariable = "CRYPTOHIVES_BENCH_POWERPLAN";

    /// <summary>
    /// Set by <c>scripts/run-benchmarks.ps1 -CooldownSeconds</c>: seconds to idle before each
    /// benchmark case after the first, so a long run does not measure a CPU that is still
    /// heat-soaked from the previous case and clocking down.
    /// </summary>
    private const string CooldownVariable = "CRYPTOHIVES_BENCH_COOLDOWN";

    // Main Method
    public static void Main(string[] args)
    {
        // Diagnostic used by scripts/run-benchmarks.ps1 to verify an ISA mask
        // (DOTNET_EnableAVX512=0 and friends) actually took effect before committing to a
        // run that can take over an hour. A silently ineffective knob otherwise produces
        // results that look fine and measure the wrong target.
        if (args.Length == 1 && args[0] == "--print-isa")
        {
            PrintIsa();
            return;
        }

        // Create config without default exporters - benchmarks provide their own via [Config] attribute
        ManualConfig config = ManualConfig.CreateEmpty()
            // Need this option because of reference to nunit.framework
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            .WithOptions(ConfigOptions.DisableLogFile)
            .WithOptions(ConfigOptions.DisableParallelBuild)
            // Add minimal required components
            .AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray())
            .AddLogger(DefaultConfig.Instance.GetLoggers().ToArray())
            .AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray())
            .AddValidator(DefaultConfig.Instance.GetValidators().ToArray())
        ;

        Job? powerPlanJob = TryCreatePowerPlanMutator();
        if (powerPlanJob is not null)
        {
            // A mutator applies its characteristics to every other job rather than adding a
            // job of its own, so this does not disturb the jobs --runtimes creates.
            config = config.AddJob(powerPlanJob);
        }

        string? cooldown = Environment.GetEnvironmentVariable(CooldownVariable);
        if (!string.IsNullOrWhiteSpace(cooldown))
        {
            if (!int.TryParse(cooldown, NumberStyles.None, CultureInfo.InvariantCulture, out int seconds) || seconds > 3600)
            {
                Console.Error.WriteLine($"ERROR: {CooldownVariable}='{cooldown}' is not a whole number of seconds (0..3600).");
                Environment.Exit(2);
            }

            if (seconds > 0)
            {
                Console.WriteLine($"// Cooldown: {seconds} s before each benchmark case (requested via {CooldownVariable})");
                config = config.AddEventProcessor(new CooldownEventProcessor(TimeSpan.FromSeconds(seconds)));
            }
        }

        _ = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }

    /// <summary>
    /// Idles the host before every benchmark case except the first. The host launches each
    /// case in its own process, so the pause falls between cases, never inside a measurement.
    /// </summary>
    private sealed class CooldownEventProcessor : EventProcessor
    {
        private readonly TimeSpan _pause;
        private bool _first = true;

        public CooldownEventProcessor(TimeSpan pause) => _pause = pause;

        public override void OnStartRunBenchmark(BenchmarkCase benchmarkCase)
        {
            if (_first)
            {
                _first = false;
                return;
            }

            Thread.Sleep(_pause);
        }
    }

    private static Job? TryCreatePowerPlanMutator()
    {
        string? requested = Environment.GetEnvironmentVariable(PowerPlanVariable);
        if (string.IsNullOrWhiteSpace(requested))
        {
            return null;
        }

        if (Enum.TryParse(requested, ignoreCase: true, out PowerPlan named))
        {
            Console.WriteLine($"// Power plan: {named} (requested via {PowerPlanVariable})");
            return Job.Default.WithPowerPlan(named).AsMutator();
        }

        if (Guid.TryParse(requested, out Guid guid))
        {
            Console.WriteLine($"// Power plan: {guid} (requested via {PowerPlanVariable})");
            return Job.Default.WithPowerPlan(guid).AsMutator();
        }

        // Spelled out rather than reflected: Enum.GetNames<T>() does not exist on net48 and
        // the non-generic overload is neither AOT-safe nor allowed by the analyzers.
        Console.Error.WriteLine(
            $"ERROR: {PowerPlanVariable}='{requested}' is neither a PowerPlan name " +
            "(HighPerformance, UserPowerPlan, PowerSaver, Balanced, UltimatePerformance) " +
            "nor a GUID.");
        Environment.Exit(2);
        return null;
    }

    /// <summary>
    /// Prints the instruction sets the runtime actually resolved, one key=value pair per
    /// token, so a caller can assert on it. The BLAKE3 (and AES, and SHA-2) SIMD tier is a
    /// pure function of these, so masking one here is what collapses a tier downstream.
    /// </summary>
    private static void PrintIsa()
    {
#if NET8_0_OR_GREATER
        Console.WriteLine(
            "ISA" +
            $" AVX512={System.Runtime.Intrinsics.X86.Avx512F.IsSupported}" +
            $" AVX2={System.Runtime.Intrinsics.X86.Avx2.IsSupported}" +
            $" SSE42={System.Runtime.Intrinsics.X86.Sse42.IsSupported}" +
            $" SSSE3={System.Runtime.Intrinsics.X86.Ssse3.IsSupported}" +
            $" AES={System.Runtime.Intrinsics.X86.Aes.IsSupported}" +
            $" AdvSimd={System.Runtime.Intrinsics.Arm.AdvSimd.IsSupported}" +
            $" ArmAes={System.Runtime.Intrinsics.Arm.Aes.IsSupported}" +
            $" Vector512={System.Runtime.Intrinsics.Vector512.IsHardwareAccelerated}" +
            $" Vector256={System.Runtime.Intrinsics.Vector256.IsHardwareAccelerated}" +
            $" Vector128={System.Runtime.Intrinsics.Vector128.IsHardwareAccelerated}");
#else
        // The intrinsics APIs do not exist on .NET Framework; nothing here uses them either,
        // so there is no tier to mask and the caller has nothing to assert.
#pragma warning disable CA1303 // machine-read diagnostic output, deliberately not localized
        Console.WriteLine("ISA unavailable=TargetFrameworkHasNoIntrinsics");
#pragma warning restore CA1303
#endif
    }
}
