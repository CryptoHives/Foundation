| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    13.53 ns |  0.51 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    23.35 ns |  0.88 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    26.46 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,471.29 ns | 55.61 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    24.88 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    24.89 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,508.54 ns | 60.60 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    24.61 ns |  1.00 |         - | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    20.33 ns |  0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    43.86 ns |  0.78 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    56.01 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,912.54 ns | 34.15 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    65.65 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    98.98 ns |  1.51 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,961.75 ns | 29.88 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |    90.73 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    25.66 ns |  0.34 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    53.98 ns |  0.72 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    75.35 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,330.82 ns | 30.93 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    80.47 ns |  0.94 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    85.75 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,402.48 ns | 28.02 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   110.15 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    41.48 ns |  0.30 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    92.50 ns |  0.67 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   137.46 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,654.91 ns | 26.59 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   115.86 ns |  0.78 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   148.86 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,717.40 ns | 24.97 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   172.35 ns |  1.00 |     152 B |