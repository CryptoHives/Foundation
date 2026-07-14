| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    10.52 ns |  0.62 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    16.94 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    21.61 ns |  1.28 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,552.73 ns | 91.69 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.89 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    18.75 ns |  1.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,651.64 ns | 97.78 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    16.72 ns |  0.23 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    30.60 ns |  0.41 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    74.10 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,779.19 ns | 24.01 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    42.98 ns |  0.62 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    68.81 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,945.10 ns | 28.27 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    21.38 ns |  0.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    34.28 ns |  0.25 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   135.45 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,147.03 ns | 15.85 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    48.11 ns |  0.37 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   129.10 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,360.20 ns | 18.28 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    34.02 ns |  0.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    47.45 ns |  0.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   311.51 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,378.35 ns | 10.85 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    58.82 ns |  0.19 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   304.04 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,474.43 ns | 11.43 |    1864 B |