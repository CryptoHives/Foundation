| Description                                            | WaiterCount | ParticipantCount | Mean       | Error    | StdDev   | Ratio | Allocated | 
|------------------------------------------------------- |------------ |----------------- |-----------:|---------:|---------:|------:|----------:|
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 1                |   139.9 ns |  1.07 ns |  2.03 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 1                |   140.6 ns |  0.75 ns |  1.40 ns |  1.01 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 1                |   242.6 ns |  0.45 ns |  0.82 ns |  1.73 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 1                |   443.1 ns |  4.17 ns |  7.72 ns |  3.17 |     184 B | 
|                                                        |             |                  |            |          |          |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 1           | 10               |   139.7 ns |  0.34 ns |  0.64 ns |  0.64 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 1           | 10               |   217.8 ns |  0.24 ns |  0.46 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 1           | 10               |   320.2 ns |  1.40 ns |  2.67 ns |  1.47 |     152 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 1           | 10               |   634.5 ns |  9.56 ns | 17.24 ns |  2.91 |     184 B | 
|                                                        |             |                  |            |          |          |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 1                | 1,357.3 ns |  2.29 ns |  4.18 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 1                | 1,394.8 ns |  6.24 ns | 11.08 ns |  1.03 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 1                | 2,464.6 ns |  4.17 ns |  7.93 ns |  1.82 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 1                | 2,576.4 ns |  9.31 ns | 17.25 ns |  1.90 |    1264 B | 
|                                                        |             |                  |            |          |          |       |           | 
| Waiters · AsyncCountdownEvent · Pooled (signal bulk)   | 10          | 10               | 1,374.5 ns |  1.23 ns |  2.22 ns |  0.96 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (signal each)   | 10          | 10               | 1,435.1 ns |  2.91 ns |  5.54 ns |  1.00 |         - | 
| Waiters · AsyncCountdownEvent · Pooled (timed waiters) | 10          | 10               | 2,522.2 ns |  7.23 ns | 13.76 ns |  1.76 |    1520 B | 
| Waiters · AsyncCountdownEvent · CountdownEvent         | 10          | 10               | 2,724.3 ns | 18.60 ns | 34.48 ns |  1.90 |    1264 B |