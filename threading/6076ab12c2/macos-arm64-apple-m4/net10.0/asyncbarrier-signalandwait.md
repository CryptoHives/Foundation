| Description                            | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      8.847 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |     18.213 ns |   2.06 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |  1,103.634 ns | 124.76 |     239 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,667.809 ns | 188.54 |    8468 B | 
|                                        |                  |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    232.841 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,872.799 ns |   8.04 |    8675 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |  6,034.907 ns |  25.92 |    1192 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 18,414.849 ns |  79.09 |    1392 B |