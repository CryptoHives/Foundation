| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    13.46 ns |  0.60 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    21.66 ns |  0.97 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    22.44 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,823.37 ns | 81.24 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    22.76 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    24.61 ns |  1.08 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,910.35 ns | 83.95 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    20.15 ns |  0.41 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    43.06 ns |  0.87 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    49.25 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,325.23 ns | 47.21 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    60.90 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    70.48 ns |  1.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,406.80 ns | 39.52 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    25.36 ns |  0.37 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    54.15 ns |  0.80 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    68.01 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,823.31 ns | 41.56 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    76.14 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    86.37 ns |  1.13 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,948.51 ns | 38.73 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    41.38 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    92.94 ns |  0.75 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   123.96 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,468.96 ns | 36.05 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   116.85 ns |  0.90 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   130.50 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,578.74 ns | 35.09 |    1864 B |