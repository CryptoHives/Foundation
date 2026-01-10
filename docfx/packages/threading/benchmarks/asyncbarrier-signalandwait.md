| Method                       | ParticipantCount | Mean         | Ratio  | Allocated | Alloc Ratio |
|----------------------------- |----------------- |-------------:|-------:|----------:|------------:|
| SignalAndWaitPooledAsync     | 1                |     13.77 ns |   1.00 |         - |          NA |
| SignalAndWaitBarrierStandard | 1                |    432.83 ns |  31.43 |     240 B |          NA |
| SignalAndWaitRefImplAsync    | 1                |  1,080.51 ns |  78.46 |    8326 B |          NA |
|                              |                  |              |        |           |             |
| SignalAndWaitPooledAsync     | 10               |    369.64 ns |   1.00 |         - |          NA |
| SignalAndWaitRefImplAsync    | 10               |  1,692.36 ns |   4.58 |    9567 B |          NA |
| SignalAndWaitBarrierStandard | 10               | 62,427.62 ns | 168.89 |    1456 B |          NA |
