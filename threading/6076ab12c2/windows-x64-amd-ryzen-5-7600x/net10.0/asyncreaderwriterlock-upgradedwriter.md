| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    15.23 ns |  0.55 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    26.74 ns |  0.96 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    27.88 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,639.65 ns | 58.81 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    27.89 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    28.52 ns |  1.02 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,676.77 ns | 60.11 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    27.52 ns |  1.00 |         - | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    22.90 ns |  0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    48.59 ns |  0.77 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    63.52 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,110.64 ns | 33.23 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    73.85 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    79.57 ns |  1.08 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,150.17 ns | 29.11 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |   102.92 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    28.76 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    60.38 ns |  0.70 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    86.82 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,532.68 ns | 29.17 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    92.63 ns |  0.94 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    98.13 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,760.96 ns | 28.13 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   125.36 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    47.11 ns |  0.30 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |   105.49 ns |  0.67 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   158.13 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,031.63 ns | 25.50 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   131.91 ns |  0.78 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   168.48 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,074.19 ns | 24.18 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   212.23 ns |  1.00 |     152 B |