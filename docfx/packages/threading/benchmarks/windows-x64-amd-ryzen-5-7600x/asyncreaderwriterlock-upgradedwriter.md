| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · RWLockSlim · System          | 0          | None             |    13.44 ns |  0.54 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    23.01 ns |  0.92 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    25.05 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,732.83 ns | 69.17 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    23.89 ns |  0.95 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    25.03 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,802.17 ns | 72.01 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 1          | None             |    20.07 ns |  0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    43.41 ns |  0.77 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    56.06 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,191.05 ns | 39.08 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    68.10 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    68.86 ns |  1.01 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,312.79 ns | 33.96 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 2          | None             |    25.38 ns |  0.32 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    53.81 ns |  0.68 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    78.76 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,754.63 ns | 34.98 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    79.98 ns |  0.90 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    88.85 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,836.21 ns | 31.92 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · RWLockSlim · System          | 5          | None             |    41.53 ns |  0.31 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    91.27 ns |  0.68 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   134.92 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,306.13 ns | 31.92 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   115.50 ns |  0.67 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   171.84 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,427.90 ns | 25.78 |    1864 B |