| Description                            | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      6.663 ns |   1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |  1,080.414 ns | 162.15 |     239 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,664.424 ns | 249.80 |    8473 B | 
|                                        |                  |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    195.938 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,848.135 ns |   9.43 |    8691 B | 
| SignalAndWait · Barrier · System       | 10               | 14,392.134 ns |  73.46 |    1392 B |