| Description                                            | WaiterCount | ParticipantCount | Mean        | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    38.09 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    38.18 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |    80.37 ns |  2.11 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                | 1,440.34 ns | 37.82 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    37.08 ns |  0.74 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    49.78 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |    98.01 ns |  1.97 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               | 1,330.26 ns | 26.72 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   359.54 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   368.05 ns |  1.02 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                |   770.73 ns |  2.14 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 4,973.42 ns | 13.83 |    1392 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   364.23 ns |  0.96 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   380.75 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               |   785.21 ns |  2.06 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 5,243.36 ns | 13.77 |    1392 B |