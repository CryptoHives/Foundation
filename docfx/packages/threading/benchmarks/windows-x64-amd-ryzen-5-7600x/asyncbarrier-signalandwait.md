| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    11.34 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |   440.59 ns | 38.86 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   966.04 ns | 85.21 |    8356 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   268.81 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,598.64 ns |  5.95 |   10032 B | 
| SignalAndWait · Barrier · System       | 10               | 4,645.62 ns | 17.28 |    1392 B |