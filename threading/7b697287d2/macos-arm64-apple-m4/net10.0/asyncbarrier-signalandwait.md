| Description                            | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      8.907 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · DotNext | 1                |     18.074 ns |   2.03 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |  1,058.402 ns | 118.84 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,659.538 ns | 186.33 |    8471 B | 
|                                        |                  |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    238.635 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,801.695 ns |   7.55 |    8677 B | 
| SignalAndWait · AsyncBarrier · DotNext | 10               |  5,942.765 ns |  24.91 |    1192 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 14,675.612 ns |  61.51 |    1392 B |