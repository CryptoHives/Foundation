| Description                                       | Iterations | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |  30.37 ns |  0.99 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |  30.71 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |  50.33 ns |  1.64 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |  54.57 ns |  1.78 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |  93.12 ns |  3.03 |     152 B | 
|                                                   |            |           |       |           | 
| Rendezvous · AsyncExchange · RefImpl              | 10         | 246.47 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled               | 10         | 257.78 ns |  1.05 |         - | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 412.66 ns |  1.67 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 559.94 ns |  2.27 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 916.04 ns |  3.72 |    1520 B |