| Description                                       | Iterations | Mean      | Error    | StdDev   | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------:|---------:|---------:|------:|----------:|
| Rendezvous · AsyncExchange · Pooled               | 1          |  22.06 ns | 0.056 ns | 0.047 ns |  0.79 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 1          |  27.84 ns | 0.069 ns | 0.054 ns |  1.00 |      96 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 1          |  39.41 ns | 0.224 ns | 0.187 ns |  1.42 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 1          |  44.87 ns | 0.036 ns | 0.028 ns |  1.61 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 1          |  78.44 ns | 0.594 ns | 0.556 ns |  2.82 |     152 B | 
|                                                   |            |           |          |          |       |           | 
| Rendezvous · AsyncExchange · Pooled               | 10         | 195.09 ns | 0.780 ns | 0.651 ns |  0.88 |         - | 
| Rendezvous · AsyncExchange · RefImpl              | 10         | 222.07 ns | 0.369 ns | 0.288 ns |  1.00 |    1032 B | 
| Rendezvous · AsyncExchange · Pooled (cancellable) | 10         | 371.41 ns | 2.550 ns | 2.385 ns |  1.67 |         - | 
| Rendezvous · AsyncExchange · DotNext              | 10         | 455.71 ns | 1.569 ns | 1.225 ns |  2.05 |         - | 
| Rendezvous · AsyncExchange · Pooled (timed)       | 10         | 762.92 ns | 4.336 ns | 4.056 ns |  3.44 |    1520 B |