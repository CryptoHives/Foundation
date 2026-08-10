| Description                            | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------- |----------------- |------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |    12.51 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |   443.88 ns | 35.50 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |   964.90 ns | 77.16 |    8346 B | 
|                                        |                  |             |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |   273.94 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               | 1,662.65 ns |  6.07 |   10278 B | 
| SignalAndWait · Barrier · System       | 10               | 5,977.79 ns | 21.82 |    1392 B |