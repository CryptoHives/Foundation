| Description                                        | ParticipantCount | Mean          | Error         | StdDev        | Ratio  | Allocated | 
|--------------------------------------------------- |----------------- |--------------:|--------------:|--------------:|-------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |      34.25 ns |      0.035 ns |      0.065 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |      70.78 ns |      0.135 ns |      0.247 ns |   2.07 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |     554.00 ns |      1.343 ns |      2.422 ns |  16.17 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |     872.80 ns |      7.973 ns |     15.362 ns |  25.48 |     184 B | 
|                                                    |                  |               |               |               |        |           | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |     943.79 ns |      5.627 ns |     10.289 ns |   1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |   1,019.63 ns |      1.910 ns |      3.541 ns |   1.08 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |   1,497.36 ns |      1.535 ns |      2.768 ns |   1.59 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 264,495.20 ns | 16,414.402 ns | 79,204.390 ns | 280.28 |    1265 B |