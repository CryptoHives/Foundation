| Description                                       | Iterations | cancellationType | Mean        | Ratio  | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|-------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    10.82 ns |   0.66 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    16.43 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    19.87 ns |   1.21 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 2,399.59 ns | 146.01 |     824 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.49 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    18.95 ns |   1.15 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 2,511.95 ns | 152.36 |     824 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    16.36 ns |   1.00 |         - | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    16.90 ns |   0.23 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    35.28 ns |   0.49 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    72.07 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,790.74 ns |  38.73 |    1032 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    45.73 ns |   0.66 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    69.54 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,910.00 ns |  41.85 |    1032 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |   111.66 ns |   1.00 |     152 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    21.66 ns |   0.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    38.44 ns |   0.28 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   138.54 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 3,479.75 ns |  25.12 |    1240 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    48.31 ns |   0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   135.47 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 3,574.14 ns |  26.38 |    1240 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   187.38 ns |   1.00 |     152 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    34.45 ns |   0.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    49.29 ns |   0.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   311.39 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,784.97 ns |  12.16 |    1864 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    59.72 ns |   0.18 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   326.26 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,847.52 ns |  11.79 |    1864 B | 
|                                                   |            |                  |             |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   362.38 ns |   1.00 |     152 B |