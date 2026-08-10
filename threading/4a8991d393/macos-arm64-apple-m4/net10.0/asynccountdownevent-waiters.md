| Description                                            | WaiterCount | ParticipantCount | Mean        | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    37.83 ns |  0.98 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    38.69 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |    78.90 ns |  2.04 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                | 1,202.03 ns | 31.08 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    38.34 ns |  0.76 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    50.21 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |    99.07 ns |  1.97 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               | 1,165.85 ns | 23.23 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   357.37 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   358.06 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                |   763.41 ns |  2.14 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 5,215.07 ns | 14.60 |    1392 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   357.39 ns |  0.95 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   375.40 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               |   775.58 ns |  2.07 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 5,045.85 ns | 13.44 |    1392 B |