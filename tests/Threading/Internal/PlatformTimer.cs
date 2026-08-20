// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Internal;

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

/// <summary>
/// Shared timing primitives for the spin lock measurements.
/// </summary>
/// <remarks>
/// The spin lock's contention policy is a claim about two wall-clock quantities - what a park costs and
/// what a spin costs - so both fixtures that examine it need the same, calibrated, notion of each. They
/// share this helper rather than a constant so nothing is hard-coded to Windows' 15.6 ms scheduler
/// quantum: the platform's real numbers are measured at run time.
/// </remarks>
internal static class PlatformTimer
{
    /// <summary>
    /// Number of <c>Thread.Sleep(1)</c> samples taken to calibrate the platform's timer granularity.
    /// The median is used, so a single descheduled sample cannot move the result.
    /// </summary>
    public const int QuantumCalibrationSamples = 15;

    /// <summary>High performance counter ticks since <paramref name="start"/>, as a <see cref="TimeSpan"/>.</summary>
    public static TimeSpan Elapsed(long start)
        => TimeSpan.FromMilliseconds(ToMilliseconds(Stopwatch.GetTimestamp() - start));

    /// <summary>Converts high performance counter ticks to milliseconds.</summary>
    public static double ToMilliseconds(double ticks)
        => ticks * 1_000.0 / Stopwatch.Frequency;

    /// <summary>Converts high performance counter ticks to nanoseconds.</summary>
    public static double ToNanoseconds(double ticks)
        => ticks * 1_000_000_000.0 / Stopwatch.Frequency;

    /// <summary>
    /// Measures the platform's real <c>Thread.Sleep(1)</c> granularity - roughly 15.6 ms on Windows at the
    /// default timer resolution, closer to 1 ms elsewhere - as the median of several samples.
    /// </summary>
    /// <remarks>
    /// This is the cost the spin lock's contention policy exists to avoid, so every assertion about
    /// parking is expressed against it rather than against a hard-coded quantum.
    /// </remarks>
    public static double MeasureSleep1GranularityMilliseconds()
    {
        // Discard the first sleep: it can land anywhere inside the current tick.
        Thread.Sleep(1);

        double[] samples = new double[QuantumCalibrationSamples];
        for (int i = 0; i < samples.Length; i++)
        {
            long start = Stopwatch.GetTimestamp();
            Thread.Sleep(1);
            samples[i] = ToMilliseconds(Stopwatch.GetTimestamp() - start);
        }

        Array.Sort(samples);
        return samples[samples.Length / 2];
    }

    /// <summary>Reports the counter resolution and the measured park cost.</summary>
    /// <param name="granularityMs">Measured <c>Thread.Sleep(1)</c> granularity.</param>
    public static void ReportGranularity(double granularityMs)
    {
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine("Platform timer:");
        TestContext.Out.WriteLine($"{"  high performance counter",-34} {Stopwatch.Frequency,14:N0} Hz");
        TestContext.Out.WriteLine($"{"  counter resolution",-34} {ToNanoseconds(1),14:N1} ns per tick");
        TestContext.Out.WriteLine($"{"  Thread.Sleep(1) granularity",-34} {granularityMs,14:F3} ms (median of {QuantumCalibrationSamples})");
    }

    /// <summary>
    /// Reports the build configuration of the measurement, because an unoptimised build inflates every
    /// number below and a reader comparing two runs has to know which they are looking at.
    /// </summary>
    public static void ReportConfiguration()
    {
#if DEBUG
        TestContext.Out.WriteLine(
            "  NOTE: Debug build - measurements are inflated. Run with -c Release for representative figures.");
#else
        TestContext.Out.WriteLine("  Release build.");
#endif
    }
}
