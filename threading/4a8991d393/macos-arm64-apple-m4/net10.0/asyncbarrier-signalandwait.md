| Description                            | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      8.904 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |  1,109.204 ns | 124.58 |     237 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,768.365 ns | 198.61 |    8472 B | 
|                                        |                  |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    237.907 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,997.185 ns |   8.40 |    8703 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 17,726.959 ns |  74.54 |    1392 B |