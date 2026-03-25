| Description                            | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------- |----------------- |-------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |     11.35 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |    449.92 ns | 39.65 |     239 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,133.18 ns | 99.86 |    8385 B | 
|                                        |                  |              |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    264.58 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,776.59 ns |  6.72 |    9857 B | 
| SignalAndWait · Barrier · System       | 10               | 13,639.13 ns | 51.56 |    1398 B |