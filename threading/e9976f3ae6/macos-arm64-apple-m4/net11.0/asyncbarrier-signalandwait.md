| Description                            | ParticipantCount | Mean          | Error       | StdDev      | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|------------:|------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      9.777 ns |   0.0070 ns |   0.0066 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |     15.933 ns |   0.0358 ns |   0.0335 ns |   1.63 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |    278.550 ns |   5.1563 ns |   4.8232 ns |  28.49 |     184 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  2,873.216 ns |  62.3158 ns | 183.7397 ns | 293.86 |    8615 B | 
|                                        |                  |               |             |             |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    250.458 ns |   2.7853 ns |   2.6054 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  2,823.776 ns |  53.5849 ns |  50.1234 ns |  11.28 |    9185 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |  3,377.908 ns |  66.4151 ns |  86.3584 ns |  13.49 |    1144 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 47,155.289 ns | 916.0857 ns | 856.9072 ns | 188.30 |    1264 B |