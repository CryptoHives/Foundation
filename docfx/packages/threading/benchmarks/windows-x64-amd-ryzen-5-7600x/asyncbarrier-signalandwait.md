| Description                            | ParticipantCount | Mean         | Ratio | Allocated | 
|--------------------------------------- |----------------- |-------------:|------:|----------:|
| SignalAndWait · AsyncBarrier · Pooled  | 1                |     11.25 ns |  1.00 |         - | 
| SignalAndWait · Barrier · System       | 1                |    447.16 ns | 39.74 |     238 B | 
| SignalAndWait · AsyncBarrier · RefImpl | 1                |  1,030.14 ns | 91.54 |    8370 B | 
|                                        |                  |              |       |           | 
| SignalAndWait · AsyncBarrier · Pooled  | 10               |    284.65 ns |  1.00 |         - | 
| SignalAndWait · AsyncBarrier · RefImpl | 10               |  1,747.11 ns |  6.14 |   10410 B | 
| SignalAndWait · Barrier · System       | 10               | 18,877.60 ns | 66.34 |    1396 B |