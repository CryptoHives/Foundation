| Method                       | ParticipantCount | Mean         | Ratio | Allocated | 
|----------------------------- |----------------- |-------------:|------:|----------:|
| SignalAndWaitPooledAsync     | 1                |     12.70 ns |  1.00 |         - | 
| SignalAndWaitBarrierStandard | 1                |    452.33 ns | 35.61 |     238 B | 
| SignalAndWaitRefImplAsync    | 1                |  1,015.11 ns | 79.91 |    8349 B | 
|                              |                  |              |       |           | 
| SignalAndWaitPooledAsync     | 10               |    337.78 ns |  1.00 |         - | 
| SignalAndWaitRefImplAsync    | 10               |  1,644.82 ns |  4.87 |   10203 B | 
| SignalAndWaitBarrierStandard | 10               | 21,431.34 ns | 63.46 |    1405 B |