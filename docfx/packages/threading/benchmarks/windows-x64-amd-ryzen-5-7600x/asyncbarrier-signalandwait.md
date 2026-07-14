| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    11.36 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |   445.15 ns | 39.19 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   969.05 ns | 85.32 |    8359 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   276.06 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,731.75 ns |  6.28 |   10085 B | 
| SignalAndWait · Barrier · System       | 10               | 5,801.36 ns | 21.03 |    1396 B |