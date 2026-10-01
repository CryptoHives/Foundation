| Description                                        | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------------------- |----------------- |--------------:|-------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |      9.907 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |     34.976 ns |   3.53 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    394.990 ns |  39.87 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |  1,416.751 ns | 143.01 |     240 B | 
|                                                    |                  |               |        |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    235.788 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |    274.885 ns |   1.17 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |    630.290 ns |   2.67 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 15,568.755 ns |  66.03 |    1392 B |