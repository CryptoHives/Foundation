| Description                                       | Iterations | cancellationType | Mean        | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|----------:|----------:|------:|----------:|
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    15.16 ns |  0.023 ns |  0.018 ns |  0.90 |         - | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    15.99 ns |  0.043 ns |  0.038 ns |  0.95 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    16.88 ns |  0.061 ns |  0.057 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,428.47 ns |  4.661 ns |  4.359 ns | 84.64 |     728 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    15.61 ns |  0.061 ns |  0.057 ns |  0.96 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.29 ns |  0.033 ns |  0.029 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,482.05 ns |  5.383 ns |  5.036 ns | 90.97 |     728 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    20.73 ns |  0.497 ns |  1.466 ns |  1.00 |         - | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    22.54 ns |  0.095 ns |  0.085 ns |  0.41 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    36.10 ns |  0.167 ns |  0.148 ns |  0.65 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    55.62 ns |  0.104 ns |  0.092 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,047.14 ns |  6.464 ns |  6.046 ns | 36.81 |     960 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    62.10 ns |  0.125 ns |  0.105 ns |  0.90 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    69.17 ns |  0.327 ns |  0.306 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,073.10 ns |  9.318 ns |  8.260 ns | 29.97 |     960 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |    92.24 ns |  0.242 ns |  0.214 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    27.86 ns |  0.071 ns |  0.067 ns |  0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    42.34 ns |  0.255 ns |  0.199 ns |  0.54 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |    78.06 ns |  0.157 ns |  0.147 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,652.09 ns |  7.052 ns |  6.596 ns | 33.98 |    1168 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    67.88 ns |  0.272 ns |  0.227 ns |  0.68 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    99.50 ns |  0.286 ns |  0.268 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,694.61 ns |  6.717 ns |  6.283 ns | 27.08 |    1168 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   113.81 ns |  0.232 ns |  0.206 ns |  1.00 |     152 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    44.75 ns |  0.089 ns |  0.074 ns |  0.29 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    56.52 ns |  0.249 ns |  0.233 ns |  0.36 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   156.05 ns |  0.408 ns |  0.362 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 4,451.96 ns |  6.742 ns |  5.977 ns | 28.53 |    1792 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    87.64 ns |  0.549 ns |  0.487 ns |  0.51 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   170.85 ns |  0.309 ns |  0.289 ns |  1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 4,444.85 ns | 14.791 ns | 12.351 ns | 26.02 |    1792 B | 
|                                                   |            |                  |             |           |           |       |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   187.33 ns |  0.766 ns |  0.640 ns |  1.00 |     152 B |