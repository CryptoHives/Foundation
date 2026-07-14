| Description                            | ParticipantCount | Mean          | Ratio  | Allocated | 
|--------------------------------------- |----------------- |--------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |      7.495 ns |   1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |  1,049.935 ns | 140.09 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,674.585 ns | 223.44 |    8470 B | 
|                                        |                  |               |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    201.242 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,852.928 ns |   9.21 |    8693 B | 
| SignalAndWait · Barrier · System       | 10               | 18,894.387 ns |  93.89 |    1392 B |