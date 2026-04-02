| Description                                       | Iterations | cancellationType | Mean        | Ratio  | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|-------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    10.34 ns |   0.67 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    15.45 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    21.60 ns |   1.40 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,601.02 ns | 103.64 |     824 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    15.31 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    18.73 ns |   1.22 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,580.17 ns | 103.18 |     824 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    16.29 ns |   0.23 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    31.34 ns |   0.45 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    70.25 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,865.61 ns |  26.56 |    1032 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    42.41 ns |   0.60 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    70.82 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,903.70 ns |  26.89 |    1032 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    20.74 ns |   0.17 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    35.07 ns |   0.28 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   125.18 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,172.35 ns |  17.36 |    1240 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    46.73 ns |   0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   128.91 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,287.06 ns |  17.74 |    1240 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    33.92 ns |   0.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    46.46 ns |   0.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   305.75 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,287.80 ns |  10.75 |    1864 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    58.86 ns |   0.19 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   312.35 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,500.68 ns |  11.21 |    1864 B |