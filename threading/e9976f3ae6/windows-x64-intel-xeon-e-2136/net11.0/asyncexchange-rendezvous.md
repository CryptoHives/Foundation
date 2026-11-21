| Description                                       | Iterations | Mean        | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------------------- |----------- |------------:|----------:|----------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |    80.48 ns |  0.206 ns |  0.391 ns |  0.90 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |    89.41 ns |  2.518 ns |  4.605 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |   116.96 ns |  0.733 ns |  1.283 ns |  1.31 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |   153.67 ns |  0.395 ns |  0.722 ns |  1.72 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |   226.98 ns |  0.937 ns |  1.783 ns |  2.54 |     152 B | 
|                                                   |            |             |           |           |       |           | 
| Rendezvous · AsyncExchange · Pooled               | 10         |   763.02 ns | 19.460 ns | 37.492 ns |  0.98 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 10         |   780.64 ns |  5.222 ns |  9.679 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 1,130.42 ns |  4.798 ns |  8.894 ns |  1.45 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 1,501.36 ns | 14.178 ns | 26.279 ns |  1.92 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 2,206.03 ns |  4.638 ns |  8.480 ns |  2.83 |    1520 B |