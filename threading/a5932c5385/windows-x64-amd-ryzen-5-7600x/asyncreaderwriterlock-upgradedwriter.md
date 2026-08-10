| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    13.46 ns |  0.60 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    22.39 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    23.22 ns |  1.04 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,752.55 ns | 78.28 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    22.58 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    24.85 ns |  1.10 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,853.92 ns | 82.11 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    20.14 ns |  0.42 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    43.41 ns |  0.91 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    47.75 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,243.33 ns | 46.99 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    61.09 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    69.98 ns |  1.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,365.77 ns | 38.73 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    25.64 ns |  0.41 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    53.39 ns |  0.84 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    63.32 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,764.66 ns | 43.66 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    76.78 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    80.58 ns |  1.05 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,838.88 ns | 36.97 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    41.79 ns |  0.34 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    92.84 ns |  0.75 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   124.00 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,526.63 ns | 36.50 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   116.05 ns |  0.89 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   130.90 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,501.15 ns | 34.39 |    1864 B |