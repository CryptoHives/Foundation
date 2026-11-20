| Description                                            | WaiterCount | ParticipantCount | Mean        | Error     | StdDev   | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|----------:|---------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    53.49 ns |  0.191 ns | 0.169 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    54.21 ns |  0.100 ns | 0.078 ns |  1.01 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |    93.55 ns |  0.318 ns | 0.298 ns |  1.75 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                |   202.56 ns |  0.614 ns | 0.513 ns |  3.79 |     184 B | 
|                                                        |             |                  |             |           |          |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    52.88 ns |  0.231 ns | 0.180 ns |  0.76 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    69.42 ns |  0.144 ns | 0.128 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |   108.03 ns |  0.352 ns | 0.294 ns |  1.56 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               |   249.96 ns |  0.495 ns | 0.414 ns |  3.60 |     184 B | 
|                                                        |             |                  |             |           |          |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   513.43 ns |  7.168 ns | 6.705 ns |  0.98 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   526.26 ns |  6.637 ns | 5.884 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                |   962.22 ns |  7.860 ns | 6.967 ns |  1.83 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 1,218.92 ns |  4.772 ns | 4.464 ns |  2.32 |    1264 B | 
|                                                        |             |                  |             |           |          |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   516.94 ns |  5.361 ns | 5.015 ns |  0.95 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   546.20 ns |  8.376 ns | 7.835 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               |   985.43 ns | 10.419 ns | 9.746 ns |  1.80 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 1,295.38 ns |  8.203 ns | 7.272 ns |  2.37 |    1264 B |