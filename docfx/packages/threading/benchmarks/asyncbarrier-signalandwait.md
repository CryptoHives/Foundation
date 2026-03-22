| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    11.08 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |   447.42 ns | 40.38 |     237 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   907.04 ns | 81.85 |    8331 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   258.38 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,599.96 ns |  6.19 |    9936 B | 
| SignalAndWait · Barrier · System       | 10               | 4,556.95 ns | 17.64 |    1392 B |