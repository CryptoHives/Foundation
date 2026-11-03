| Description                                       | Iterations | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |  18.82 ns |  0.82 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |  22.82 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |  30.32 ns |  1.33 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |  32.96 ns |  1.44 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |  72.15 ns |  3.16 |     152 B | 
|                                                   |            |           |       |           | 
| Rendezvous · AsyncExchange · Pooled               | 10         | 175.19 ns |  0.88 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 10         | 199.93 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 282.33 ns |  1.41 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 310.80 ns |  1.55 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 687.64 ns |  3.44 |    1520 B |