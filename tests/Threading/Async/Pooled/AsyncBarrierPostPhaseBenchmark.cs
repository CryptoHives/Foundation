// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring what a barrier's post-phase action costs the phase that runs it.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="AsyncBarrier"/> is the one primitive in this library that does not use
/// <c>Internal.SpinLock</c>, and the spin lock's own documentation gives the reason: a barrier runs a
/// user-supplied action as part of completing a phase, which is unbounded by definition, and a primitive
/// that must hold state across code it does not control wants a monitor whose waiters park rather than a
/// lock whose waiters spin. That is a deliberate and well-argued design decision which, until this class
/// existed, was never measured - the existing barrier benchmark only ever constructs a barrier without a
/// post-phase action, so the path the decision was made for is the one path not covered.
/// </para>
/// <para>
/// <b>Test scenario:</b> All <see cref="ParticipantCount"/> participants signal and wait, completing one
/// phase. The variants differ only in what the barrier has to do at the phase boundary.
/// </para>
/// <para>
/// <b>Compared variants:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (no action) (baseline):</b> the configuration the existing benchmarks measure.</description></item>
/// <item><description><b>Pooled (empty action):</b> an action that returns immediately, isolating the cost of
/// having one at all - the invocation and whatever the phase-completion path does differently - from the
/// cost of what it does.</description></item>
/// <item><description><b>Pooled (working action):</b> an action that spins briefly, standing in for real
/// per-phase work and showing how directly that work lands on the phase boundary.</description></item>
/// <item><description><b>Barrier (System):</b> the framework primitive with the same post-phase action, for
/// scale.</description></item>
/// </list>
/// <para>
/// The two implementations are not directly comparable on absolute time - the framework barrier blocks
/// its participants on threads started per operation - but the <em>delta</em> each one pays for adding an
/// action is comparable, and that delta is what this class is for.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures what a barrier's post-phase action costs the phase that runs it.")]
[NonParallelizable]
[BenchmarkCategory("AsyncBarrier")]
public class AsyncBarrierPostPhaseBenchmark
{
    /// <summary>
    /// Iterations the "working action" spins for, sized to stay a phase-boundary cost rather than
    /// dominating the measurement.
    /// </summary>
    /// <remarks>
    /// Deliberately small. <see cref="Thread.SpinWait"/> is far more expensive per iteration than its
    /// name suggests on modern x86: it issues <c>pause</c>, which costs on the order of 140 cycles on
    /// Skylake and later, not one. An earlier value of 200 therefore cost roughly 7.8 microseconds and
    /// swamped everything else in this class - the "working action" row measured <c>SpinWait</c> rather
    /// than the barrier. Ten iterations lands in the hundreds of nanoseconds, which is the same order as
    /// the phase itself and so actually comparable to it.
    /// </remarks>
    private const int PostPhaseWorkSpins = 10;

    private AsyncBarrier _barrierNoAction = null!;
    private AsyncBarrier _barrierEmptyAction = null!;
    private AsyncBarrier _barrierWorkingAction = null!;
    private Barrier _barrierStandardWithAction = null!;

    private ValueTask[] _valueTasks = Array.Empty<ValueTask>();
    private Task[] _tasks = Array.Empty<Task>();

    private volatile int _counter;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 10 },
    };

    [Params(1, 10)]
    public int ParticipantCount { get; set; } = 10;

    public AsyncBarrierPostPhaseBenchmark() { }

    public AsyncBarrierPostPhaseBenchmark(int participantCount)
    {
        ParticipantCount = participantCount;
    }

    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        _barrierNoAction = new AsyncBarrier(ParticipantCount);
        _barrierEmptyAction = new AsyncBarrier(ParticipantCount, static _ => { });
        _barrierWorkingAction = new AsyncBarrier(ParticipantCount, static _ => Thread.SpinWait(PostPhaseWorkSpins));
        _barrierStandardWithAction = new Barrier(ParticipantCount, static _ => Thread.SpinWait(PostPhaseWorkSpins));

        _valueTasks = new ValueTask[ParticipantCount];
        _tasks = new Task[ParticipantCount];
    }

    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _barrierStandardWithAction?.Dispose();
    }

    private async Task RunPhaseAsync(AsyncBarrier barrier)
    {
        for (int i = 0; i < ParticipantCount; i++)
        {
            _valueTasks[i] = barrier.SignalAndWaitAsync();
        }

        for (int i = 0; i < ParticipantCount; i++)
        {
            await _valueTasks[i].ConfigureAwait(false);
        }

        unchecked { _counter++; }
    }

    /// <summary>
    /// Baseline: one phase on a barrier with no post-phase action.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("PostPhase", "Pooled (no action)")]
    public Task SignalAndWaitPooledNoActionAsync() => RunPhaseAsync(_barrierNoAction);

    /// <summary>
    /// One phase on a barrier whose post-phase action returns immediately. The difference from the
    /// baseline is what merely having an action costs, independent of what it does.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("PostPhase", "Pooled (empty action)")]
    public Task SignalAndWaitPooledEmptyActionAsync() => RunPhaseAsync(_barrierEmptyAction);

    /// <summary>
    /// One phase on a barrier whose post-phase action does a fixed amount of work, standing in for a real
    /// per-phase computation.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("PostPhase", "Pooled (working action)")]
    public Task SignalAndWaitPooledWorkingActionAsync() => RunPhaseAsync(_barrierWorkingAction);

    /// <summary>
    /// The framework barrier with the same working post-phase action, for scale.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("PostPhase", "System", "Barrier")]
    public async Task SignalAndWaitStandardWorkingActionAsync()
    {
        for (int i = 0; i < ParticipantCount; i++)
        {
            _tasks[i] = Task.Run(_barrierStandardWithAction.SignalAndWait);
        }

        for (int i = 0; i < ParticipantCount; i++)
        {
            await _tasks[i].ConfigureAwait(false);
        }

        unchecked { _counter++; }
    }
}
