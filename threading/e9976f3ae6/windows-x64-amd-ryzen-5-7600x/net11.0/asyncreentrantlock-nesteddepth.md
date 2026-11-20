| Description                                  | Depth | Mean      | Error    | StdDev   | Allocated |
|--------------------------------------------- |------ |----------:|---------:|---------:|----------:|
| NestedDepth · AsyncReentrantLock · Leaf      | 1     |  14.52 ns | 0.022 ns | 0.020 ns |         - |
| NestedDepth · AsyncReentrantLock · Reentrant | 1     |  43.74 ns | 0.151 ns | 0.142 ns |     128 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 2     |  72.64 ns | 0.192 ns | 0.179 ns |     128 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 2     | 120.68 ns | 0.223 ns | 0.208 ns |     328 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 4     | 214.92 ns | 0.540 ns | 0.478 ns |     528 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 4     | 263.78 ns | 0.356 ns | 0.278 ns |     728 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 8     | 478.78 ns | 1.297 ns | 1.083 ns |    1328 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 8     | 526.41 ns | 1.789 ns | 1.674 ns |    1528 B |