| Description                                        | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------------------- |----------------- |-------------:|------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |     34.71 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |    109.81 ns |  3.16 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    586.74 ns | 16.90 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |  1,390.17 ns | 40.05 |     240 B | 
|                                                    |                  |              |       |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    952.40 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |  1,046.64 ns |  1.10 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |  1,531.35 ns |  1.61 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 24,148.59 ns | 25.36 |    1392 B |