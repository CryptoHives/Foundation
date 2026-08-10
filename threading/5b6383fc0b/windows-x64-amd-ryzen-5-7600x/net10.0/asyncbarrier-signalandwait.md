| Description                            | ParticipantCount | Mean         | Ratio  | Allocated | 
|--------------------------------------- |----------------- |-------------:|-------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |     10.85 ns |   1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |    452.84 ns |  41.73 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |    936.26 ns |  86.29 |    8347 B | 
|                                        |                  |              |        |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    254.53 ns |   1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,667.41 ns |   6.55 |   10252 B | 
| SignalAndWait · Barrier · System       | 10               | 40,505.19 ns | 159.16 |    1446 B |