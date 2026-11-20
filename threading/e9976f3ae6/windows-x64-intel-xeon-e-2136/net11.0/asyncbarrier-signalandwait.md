| Description                            | ParticipantCount | Mean          | Error        | StdDev        | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------------:|--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      32.45 ns |     0.029 ns |      0.055 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |      61.70 ns |     0.047 ns |      0.083 ns |   1.90 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |     436.15 ns |     3.473 ns |      6.438 ns |  13.44 |     184 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   2,004.86 ns |    31.828 ns |    102.423 ns |  61.79 |    5368 B | 
|                                        |                  |               |              |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |     933.74 ns |     1.278 ns |      2.336 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |   3,084.93 ns |    12.088 ns |     22.704 ns |   3.30 |    6436 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |   3,962.84 ns |    50.865 ns |     91.720 ns |   4.24 |    1144 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 224,641.14 ns | 2,600.794 ns | 10,897.886 ns | 240.58 |    1264 B |