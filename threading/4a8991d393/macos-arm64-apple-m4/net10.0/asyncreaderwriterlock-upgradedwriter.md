| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    10.52 ns |  0.65 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    16.15 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    18.52 ns |  1.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,444.76 ns | 89.48 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.36 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    19.76 ns |  1.21 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,592.02 ns | 97.30 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    16.32 ns |  1.00 |         - | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    17.07 ns |  0.24 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    32.86 ns |  0.47 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    70.14 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,857.39 ns | 26.48 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    44.15 ns |  0.65 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    68.28 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,897.22 ns | 27.79 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |   110.35 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    20.52 ns |  0.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    35.55 ns |  0.27 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   133.75 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,215.85 ns | 16.57 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    49.98 ns |  0.37 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   133.98 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,303.74 ns | 17.20 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   184.13 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    33.51 ns |  0.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    48.18 ns |  0.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   309.41 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,414.30 ns | 11.04 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    60.39 ns |  0.19 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   321.11 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,468.29 ns | 10.80 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   370.39 ns |  1.00 |     152 B |