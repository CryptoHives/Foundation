| Description                             | Mean      | Error    | StdDev   | Ratio | Allocated | 
|---------------------------------------- |----------:|---------:|---------:|------:|----------:|
| Single · AsyncReentrantLock · AsyncLock |  18.40 ns | 0.392 ns | 0.717 ns |  1.00 |         - | 
| Single · AsyncReentrantLock · Leaf      |  29.56 ns | 0.279 ns | 0.530 ns |  1.61 |         - | 
| Single · AsyncReentrantLock · Reentrant | 103.41 ns | 1.195 ns | 2.184 ns |  5.63 |     128 B |