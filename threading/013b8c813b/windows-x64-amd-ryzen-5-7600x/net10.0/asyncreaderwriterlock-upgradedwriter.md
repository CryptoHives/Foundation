| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    13.49 ns |  0.53 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    23.76 ns |  0.93 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    25.64 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,716.69 ns | 66.97 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    24.74 ns |  0.97 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    25.37 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,785.84 ns | 70.39 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    34.65 ns |  0.63 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    44.20 ns |  0.81 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    54.81 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,233.12 ns | 40.74 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    65.71 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    69.90 ns |  1.06 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,269.89 ns | 34.55 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    25.47 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    53.43 ns |  0.69 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    77.54 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,717.26 ns | 35.04 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    80.98 ns |  0.86 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    94.63 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,780.83 ns | 29.39 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    43.55 ns |  0.31 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    91.85 ns |  0.66 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   139.13 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,235.82 ns | 30.45 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   116.29 ns |  0.80 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   146.08 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,381.78 ns | 30.00 |    1864 B |