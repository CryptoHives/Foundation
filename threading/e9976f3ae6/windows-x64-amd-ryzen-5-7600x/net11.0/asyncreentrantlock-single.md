| Description                             | Mean      | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------- |----------:|----------:|----------:|------:|----------:|
| Single · AsyncReentrantLock · AsyncLock |  4.380 ns | 0.0133 ns | 0.0124 ns |  1.00 |         - | 
| Single · AsyncReentrantLock · Leaf      | 11.207 ns | 0.0476 ns | 0.0445 ns |  2.56 |         - | 
| Single · AsyncReentrantLock · Reentrant | 42.468 ns | 0.1052 ns | 0.0879 ns |  9.70 |     128 B |