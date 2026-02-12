| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    12.09 ns |  1.00 |         - | 
| SignalAndWait · Barrier · Standard     | 1                |   451.79 ns | 37.36 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   900.88 ns | 74.50 |    8334 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   279.76 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,659.14 ns |  5.93 |   10545 B | 
| SignalAndWait · Barrier · Standard     | 10               | 4,062.92 ns | 14.53 |    1392 B |