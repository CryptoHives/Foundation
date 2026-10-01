| Description                                       | Iterations | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |  30.49 ns |  0.91 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |  33.46 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |  48.59 ns |  1.45 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |  55.97 ns |  1.67 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |  97.82 ns |  2.92 |     152 B | 
|                                                   |            |           |       |           | 
| Rendezvous · AsyncExchange · Pooled               | 10         | 240.05 ns |  0.93 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 10         | 257.23 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 423.88 ns |  1.65 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 487.11 ns |  1.89 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 943.58 ns |  3.67 |    1520 B |