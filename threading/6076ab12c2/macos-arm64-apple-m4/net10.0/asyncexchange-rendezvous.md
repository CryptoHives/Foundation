| Description                                       | Iterations | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |  18.78 ns |  0.86 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |  21.77 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |  30.87 ns |  1.42 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |  32.97 ns |  1.51 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |  73.62 ns |  3.38 |     152 B | 
|                                                   |            |           |       |           | 
| Rendezvous · AsyncExchange · Pooled               | 10         | 177.89 ns |  0.86 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 10         | 205.81 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 287.97 ns |  1.40 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 313.58 ns |  1.52 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 706.10 ns |  3.43 |    1520 B |