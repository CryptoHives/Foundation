| Description                                  | Depth | Mean        | Error    | StdDev    | Allocated |
|--------------------------------------------- |------ |------------:|---------:|----------:|----------:|
| NestedDepth · AsyncReentrantLock · Leaf      | 1     |    34.28 ns | 0.036 ns |  0.067 ns |         - |
| NestedDepth · AsyncReentrantLock · Reentrant | 1     |   106.30 ns | 0.565 ns |  1.062 ns |     128 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 2     |   172.99 ns | 5.478 ns | 10.154 ns |     128 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 2     |   287.65 ns | 3.482 ns |  6.454 ns |     328 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 4     |   495.31 ns | 3.897 ns |  7.415 ns |     528 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 4     |   597.26 ns | 4.004 ns |  7.221 ns |     728 B |
| NestedDepth · AsyncReentrantLock · Leaf      | 8     | 1,109.46 ns | 3.126 ns |  5.947 ns |    1328 B |
| NestedDepth · AsyncReentrantLock · Reentrant | 8     | 1,208.83 ns | 4.304 ns |  7.978 ns |    1528 B |