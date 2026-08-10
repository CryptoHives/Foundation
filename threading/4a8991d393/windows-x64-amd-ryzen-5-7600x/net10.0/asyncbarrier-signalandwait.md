| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    13.84 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · Barrier | 1                |   451.43 ns | 32.61 |     237 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   922.86 ns | 66.67 |    8346 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   307.33 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,675.19 ns |  5.45 |   10065 B | 
| SignalAndWait · AsyncBarrier · Barrier | 10               | 4,258.30 ns | 13.86 |    1392 B |