| Description                                        | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------- |----------------- |------------:|------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |    13.85 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |    38.50 ns |  2.78 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |   426.66 ns | 30.81 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |   861.12 ns | 62.18 |     240 B | 
|                                                    |                  |             |       |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |   297.71 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |   340.92 ns |  1.15 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |   689.39 ns |  2.32 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 7,815.38 ns | 26.25 |    1392 B |