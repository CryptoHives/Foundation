| Description                                  | Depth | Mean      | Error    | StdDev   | Allocated |
|--------------------------------------------- |------ |----------:|---------:|---------:|----------:|
| NestedDepth · AsyncReentrantLock · Leaf      | 1     |  12.18 ns | 0.085 ns | 0.080 ns |         - |
| NestedDepth · AsyncReentrantLock · Reentrant | 1     |  35.08 ns | 0.162 ns | 0.152 ns |     128 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 2     |  70.07 ns | 0.262 ns | 0.245 ns |     128 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 2     | 101.00 ns | 0.347 ns | 0.325 ns |     328 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 4     | 172.99 ns | 1.066 ns | 0.998 ns |     528 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 4     | 199.51 ns | 1.192 ns | 1.115 ns |     728 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 8     | 374.99 ns | 1.329 ns | 1.243 ns |    1328 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 8     | 411.03 ns | 0.904 ns | 0.846 ns |    1528 B |