| Description                                       | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    43.86 ns |  0.57 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    76.54 ns |  0.99 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    77.09 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 3,363.31 ns | 43.63 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    76.56 ns |  0.99 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    77.03 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 3,531.10 ns | 45.84 |     824 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    77.34 ns |  1.00 |         - | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    65.51 ns |  0.34 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |   160.00 ns |  0.83 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |   192.89 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 4,456.48 ns | 23.10 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |   230.44 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |   231.49 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 4,463.70 ns | 19.28 |    1032 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |   301.83 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    85.97 ns |  0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |   187.39 ns |  0.72 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   261.72 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 5,585.50 ns | 21.34 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |   260.54 ns |  0.88 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   297.42 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 5,515.45 ns | 18.54 |    1240 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   371.36 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |   138.99 ns |  0.29 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |   276.25 ns |  0.58 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   477.44 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 8,852.21 ns | 18.54 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   353.60 ns |  0.69 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   514.75 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 8,755.15 ns | 17.01 |    1864 B | 
|                                                   |            |                  |             |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   581.80 ns |  1.00 |     152 B |