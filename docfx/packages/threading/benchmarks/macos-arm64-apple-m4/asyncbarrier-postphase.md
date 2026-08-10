| Description                                        | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------------------- |----------------- |--------------:|-------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |      9.294 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |     36.349 ns |   3.91 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |    402.668 ns |  43.34 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |  1,331.769 ns | 143.33 |     240 B | 
|                                                    |                  |               |        |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |    246.124 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |    279.401 ns |   1.14 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |    646.715 ns |   2.63 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 17,990.953 ns |  73.13 |    1392 B |