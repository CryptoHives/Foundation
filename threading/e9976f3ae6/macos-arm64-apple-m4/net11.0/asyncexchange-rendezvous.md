| Description                                       | Iterations | Mean      | Error    | StdDev   | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------:|---------:|---------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |  17.13 ns | 0.312 ns | 0.291 ns |  0.71 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |  24.25 ns | 0.025 ns | 0.024 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |  30.47 ns | 0.241 ns | 0.226 ns |  1.26 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |  30.88 ns | 0.059 ns | 0.055 ns |  1.27 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |  73.18 ns | 0.083 ns | 0.077 ns |  3.02 |     152 B | 
|                                                   |            |           |          |          |       |           | 
| Rendezvous · AsyncExchange · Pooled               | 10         | 153.27 ns | 1.352 ns | 1.264 ns |  0.71 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 10         | 216.27 ns | 0.357 ns | 0.334 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 279.41 ns | 1.043 ns | 0.976 ns |  1.29 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 294.69 ns | 0.373 ns | 0.349 ns |  1.36 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 698.01 ns | 0.718 ns | 0.672 ns |  3.23 |    1520 B |