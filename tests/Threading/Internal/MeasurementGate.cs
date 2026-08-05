// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Internal;

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

/// <summary>
/// A machine-wide gate that lets only one timing fixture measure at a time.
/// </summary>
/// <remarks>
/// <para>
/// The spin lock measurements need idle cores: they time nanosecond-scale operations, and
/// <see cref="SpinLockLatencyTests"/> additionally spins a thread per core so that every waiter is
/// resident when its round starts. Anything else competing for those cores is measured as lock latency.
/// </para>
/// <para>
/// <see cref="NonParallelizableAttribute"/> is not enough on its own, because it only orders fixtures
/// <em>within</em> one test assembly. The test projects multi-target, so <c>dotnet test</c> runs a
/// separate process per target framework and runs those processes concurrently - three copies of the
/// same measurement, each spinning a thread per core, on one machine. That oversubscription deschedules
/// waiters for whole scheduler quanta, which is precisely the signal these fixtures assert on, so they
/// fail while the lock itself is behaving correctly.
/// </para>
/// <para>
/// The gate is an exclusively-opened lock file rather than a named mutex or semaphore: a file handle has
/// no thread affinity, so NUnit is free to run <c>OneTimeSetUp</c> and <c>OneTimeTearDown</c> on
/// different threads, and it behaves the same on every supported platform, which named semaphores do not.
/// A crashed run cannot leave the gate stuck either - the operating system closes the handle with the
/// process.
/// </para>
/// </remarks>
internal sealed class MeasurementGate : IDisposable
{
    /// <summary>
    /// Shared across target frameworks on purpose: the point is to serialise the per-TFM test processes
    /// against each other.
    /// </summary>
    private const string LockFileName = "cryptohives-threading-measurement.lock";

    /// <summary>
    /// How long to wait for the gate before giving up and measuring anyway. Sized well above the time
    /// the whole matrix needs, so reaching it means the gate is not working rather than that the machine
    /// is busy - in which case running unserialised is more useful than blocking the suite.
    /// </summary>
    private static readonly TimeSpan AcquireTimeout = TimeSpan.FromMinutes(15);

    private static readonly TimeSpan RetryInterval = TimeSpan.FromMilliseconds(100);

    private readonly FileStream? _stream;

    private MeasurementGate(FileStream? stream)
        => _stream = stream;

    /// <summary>
    /// Blocks until no other test process is measuring, and returns the held gate.
    /// </summary>
    public static MeasurementGate Acquire()
    {
        string path = Path.Combine(Path.GetTempPath(), Path.GetFileName(LockFileName));
        long deadline = Stopwatch.GetTimestamp() + (long)(AcquireTimeout.TotalSeconds * Stopwatch.Frequency);
        bool waited = false;

        while (true)
        {
            try
            {
                var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

                if (waited)
                {
                    TestContext.Out.WriteLine(
                        "  Waited for another test process to finish measuring before starting.");
                }

                return new MeasurementGate(stream);
            }
            catch (IOException)
            {
                // Held by another target framework's test process. Wait for it.
                if (Stopwatch.GetTimestamp() >= deadline)
                {
                    TestContext.Out.WriteLine(
                        $"  NOTE: the measurement gate was still held after {AcquireTimeout.TotalMinutes:N0} " +
                        "minutes. Measuring anyway - results may be affected by concurrent load.");
                    return new MeasurementGate(null);
                }

                waited = true;
                Thread.Sleep(RetryInterval);
            }
            catch (UnauthorizedAccessException)
            {
                // No writable temp directory. Serialisation is an optimisation, not a correctness
                // requirement, so fall through and measure.
                TestContext.Out.WriteLine(
                    "  NOTE: no writable temp directory for the measurement gate. Measuring unserialised.");
                return new MeasurementGate(null);
            }
        }
    }

    public void Dispose()
        => _stream?.Dispose();
}
