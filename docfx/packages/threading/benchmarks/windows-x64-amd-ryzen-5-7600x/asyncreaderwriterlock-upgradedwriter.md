| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    13.81 ns |  0.51 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    24.49 ns |  0.90 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    27.32 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,790.62 ns | 65.55 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    25.35 ns |  0.96 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    26.45 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,877.56 ns | 70.98 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    20.75 ns |  0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    44.76 ns |  0.79 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    56.92 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,420.83 ns | 42.53 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    68.34 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    71.15 ns |  1.04 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,440.16 ns | 35.71 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    26.17 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    54.62 ns |  0.68 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    80.23 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,941.33 ns | 36.67 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    87.43 ns |  0.85 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   102.32 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,940.13 ns | 28.74 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    42.76 ns |  0.31 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    94.24 ns |  0.69 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   136.68 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,541.72 ns | 33.23 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   117.59 ns |  0.79 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   149.63 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,354.79 ns | 29.11 |    1864 B |