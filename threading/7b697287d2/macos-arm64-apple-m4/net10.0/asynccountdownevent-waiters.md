| Description                                            | WaiterCount | ParticipantCount | Mean        | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    36.75 ns |  0.97 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    38.00 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |    77.45 ns |  2.04 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                | 1,129.18 ns | 29.72 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    36.85 ns |  0.76 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    48.66 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |    95.71 ns |  1.97 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               | 1,165.54 ns | 23.95 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   345.26 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   352.27 ns |  1.02 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                |   752.23 ns |  2.18 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 5,022.79 ns | 14.55 |    1392 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   355.44 ns |  0.98 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   362.32 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               |   760.15 ns |  2.10 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 5,153.90 ns | 14.22 |    1392 B |