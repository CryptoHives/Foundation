| Description                                            | WaiterCount | ParticipantCount | Mean        | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    48.86 ns |  0.97 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    50.46 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |    94.78 ns |  1.88 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                |   452.72 ns |  8.97 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    48.28 ns |  0.52 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    92.26 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |   110.67 ns |  1.20 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               |   462.86 ns |  5.02 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   486.44 ns |  0.99 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   491.41 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                |   963.45 ns |  1.96 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 1,971.51 ns |  4.01 |    1392 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   485.08 ns |  0.98 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   494.48 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               |   986.52 ns |  2.00 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 2,026.94 ns |  4.10 |    1392 B |