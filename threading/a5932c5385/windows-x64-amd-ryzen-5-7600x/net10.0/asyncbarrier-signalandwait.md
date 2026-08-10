| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    11.05 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |   447.08 ns | 40.47 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   945.56 ns | 85.60 |    8362 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   281.96 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,647.19 ns |  5.84 |    9991 B | 
| SignalAndWait · Barrier · System       | 10               | 4,273.74 ns | 15.16 |    1392 B |