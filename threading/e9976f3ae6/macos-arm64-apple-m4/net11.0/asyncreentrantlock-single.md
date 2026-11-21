| Description                             | Mean      | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------- |----------:|----------:|----------:|------:|----------:|
| Single · AsyncReentrantLock · AsyncLock |  3.522 ns | 0.0066 ns | 0.0062 ns |  1.00 |         - | 
| Single · AsyncReentrantLock · Leaf      |  9.043 ns | 0.0512 ns | 0.0479 ns |  2.57 |         - | 
| Single · AsyncReentrantLock · Reentrant | 32.571 ns | 0.1173 ns | 0.1097 ns |  9.25 |     128 B |