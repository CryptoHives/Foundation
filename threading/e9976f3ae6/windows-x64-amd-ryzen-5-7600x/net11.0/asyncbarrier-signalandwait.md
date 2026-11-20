| Description                            | ParticipantCount | Mean          | Error        | StdDev       | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------------:|-------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      12.41 ns |     0.033 ns |     0.029 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |      30.73 ns |     0.037 ns |     0.028 ns |   2.48 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |     189.86 ns |     0.381 ns |     0.318 ns |  15.29 |     184 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |     919.44 ns |     3.231 ns |     2.698 ns |  74.06 |    5414 B | 
|                                        |                  |               |              |              |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |     303.50 ns |     3.146 ns |     2.627 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |   1,496.86 ns |     7.322 ns |     6.491 ns |   4.93 |    6818 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |   1,703.38 ns |    10.251 ns |     9.589 ns |   5.61 |    1144 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 130,298.60 ns | 2,179.247 ns | 2,038.469 ns | 429.34 |    1264 B |