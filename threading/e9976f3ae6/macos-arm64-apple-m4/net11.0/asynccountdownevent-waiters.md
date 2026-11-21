| Description                                            | WaiterCount | ParticipantCount | Mean        | Error     | StdDev    | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|----------:|----------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    38.20 ns |  0.235 ns |  0.220 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    38.67 ns |  0.078 ns |  0.073 ns |  1.01 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |    78.82 ns |  0.109 ns |  0.102 ns |  2.06 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                |   346.22 ns |  6.649 ns |  6.828 ns |  9.06 |     184 B | 
|                                                        |             |                  |             |           |           |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    38.92 ns |  0.065 ns |  0.058 ns |  0.76 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    51.43 ns |  0.149 ns |  0.139 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |    99.17 ns |  0.251 ns |  0.235 ns |  1.93 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               |   340.22 ns |  6.514 ns |  8.469 ns |  6.62 |     184 B | 
|                                                        |             |                  |             |           |           |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   400.72 ns |  0.540 ns |  0.505 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   401.99 ns |  0.760 ns |  0.673 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                |   793.28 ns |  1.861 ns |  1.554 ns |  1.97 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 3,044.39 ns | 11.942 ns | 11.170 ns |  7.57 |    1264 B | 
|                                                        |             |                  |             |           |           |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   399.06 ns |  1.006 ns |  0.941 ns |  0.97 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   411.01 ns |  0.982 ns |  0.918 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               |   803.37 ns |  1.114 ns |  1.042 ns |  1.95 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 3,034.13 ns |  8.060 ns |  7.145 ns |  7.38 |    1264 B |