| Description                            | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      6.420 ns |   1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |  1,050.481 ns | 163.62 |     237 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,623.236 ns | 252.84 |    8470 B | 
|                                        |                  |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    195.485 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,859.072 ns |   9.51 |    8699 B | 
| SignalAndWait · Barrier · System       | 10               | 17,190.529 ns |  87.94 |    1392 B |