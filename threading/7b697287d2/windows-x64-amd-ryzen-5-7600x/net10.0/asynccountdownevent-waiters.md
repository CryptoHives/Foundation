| Description                                            | WaiterCount | ParticipantCount | Mean        | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |------------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |    54.30 ns |  0.94 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |    57.62 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |   106.75 ns |  1.85 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                |   543.84 ns |  9.44 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |    53.56 ns |  0.74 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |    72.78 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |   122.20 ns |  1.68 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               |   527.65 ns |  7.25 |     240 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                |   537.44 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                |   539.60 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                | 1,072.10 ns |  1.99 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 1,594.85 ns |  2.97 |    1392 B | 
|                                                        |             |                  |             |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               |   537.19 ns |  0.97 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               |   555.28 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               | 1,079.77 ns |  1.94 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 1,689.66 ns |  3.04 |    1392 B |