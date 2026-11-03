| Description                                        | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------------------- |----------------- |--------------:|-------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |      9.254 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |     34.553 ns |   3.73 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    408.886 ns |  44.19 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |  1,309.083 ns | 141.46 |     240 B | 
|                                                    |                  |               |        |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    236.886 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |    271.663 ns |   1.15 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |    618.295 ns |   2.61 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 14,965.511 ns |  63.18 |    1392 B |