| Description                                            | WaiterCount | ParticipantCount | Mean       | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |-----------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |   144.1 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |   144.7 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |   266.4 ns |  1.84 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                |   921.5 ns |  6.37 |     240 B | 
|                                                        |             |                  |            |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |   146.4 ns |  0.62 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |   236.6 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |   354.1 ns |  1.50 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               |   977.8 ns |  4.13 |     240 B | 
|                                                        |             |                  |            |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                | 1,425.9 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                | 1,429.7 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                | 2,647.8 ns |  1.86 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 2,701.6 ns |  1.89 |    1392 B | 
|                                                        |             |                  |            |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               | 1,414.5 ns |  0.94 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               | 1,499.3 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               | 2,708.2 ns |  1.81 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 2,728.6 ns |  1.82 |    1392 B |