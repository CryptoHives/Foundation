| Description                                       | Iterations | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |------------:|------:|----------:|
| Rendezvous · AsyncExchange · RefImpl              | 1          |    85.29 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled               | 1          |    91.35 ns |  1.07 |         - | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |   130.56 ns |  1.53 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |   166.78 ns |  1.96 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |   251.85 ns |  2.95 |     152 B | 
|                                                   |            |             |       |           | 
| Rendezvous · AsyncExchange · RefImpl              | 10         |   798.89 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled               | 10         |   821.19 ns |  1.03 |         - | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 1,243.66 ns |  1.56 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 1,587.25 ns |  1.99 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 2,442.70 ns |  3.06 |    1520 B |