| Description                                       | Iterations | cancellationType | Mean        | Error     | StdDev    | Ratio  | Allocated | 
|-------------------------------------------------- |----------- |----------------- |------------:|----------:|----------:|-------:|----------:|
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 0          | None             |    11.39 ns |  0.032 ns |  0.030 ns |   0.84 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | None             |    13.27 ns |  0.147 ns |  0.131 ns |   0.98 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | None             |    13.50 ns |  0.033 ns |  0.030 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,441.33 ns | 12.908 ns | 12.074 ns | 106.80 |     728 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    13.21 ns |  0.111 ns |  0.092 ns |   0.98 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    13.43 ns |  0.070 ns |  0.066 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,173.78 ns |  4.355 ns |  4.073 ns |  87.40 |     728 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 0          | Timed            |    13.50 ns |  0.030 ns |  0.028 ns |   1.00 |         - | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 1          | None             |    16.53 ns |  0.080 ns |  0.074 ns |   0.26 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | None             |    25.62 ns |  0.155 ns |  0.145 ns |   0.40 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | None             |    63.77 ns |  0.298 ns |  0.279 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,626.97 ns | 11.579 ns | 10.831 ns |  25.51 |     960 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    43.38 ns |  0.119 ns |  0.111 ns |   0.61 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    70.60 ns |  0.197 ns |  0.184 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,931.04 ns | 12.542 ns | 11.732 ns |  27.35 |     960 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 1          | Timed            |   116.58 ns |  0.437 ns |  0.409 ns |   1.00 |     152 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 2          | None             |    20.52 ns |  0.059 ns |  0.056 ns |   0.16 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | None             |    28.47 ns |  0.118 ns |  0.104 ns |   0.22 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | None             |   128.62 ns |  1.741 ns |  1.629 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,464.21 ns | 19.733 ns | 18.459 ns |  19.16 |    1168 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    47.02 ns |  0.146 ns |  0.136 ns |   0.33 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |   140.75 ns |  0.302 ns |  0.283 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,324.95 ns | 13.893 ns | 12.995 ns |  16.52 |    1168 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 2          | Timed            |   188.10 ns |  0.515 ns |  0.482 ns |   1.00 |     152 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · RWLockSlim     | 5          | None             |    33.78 ns |  0.113 ns |  0.100 ns |   0.10 |         - | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | None             |    37.44 ns |  0.481 ns |  0.450 ns |   0.11 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | None             |   331.48 ns |  1.024 ns |  0.958 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | None             | 3,793.71 ns | 12.622 ns | 11.806 ns |  11.44 |    1792 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    56.82 ns |  0.162 ns |  0.151 ns |   0.17 |         - | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   338.58 ns |  1.575 ns |  1.473 ns |   1.00 |         - | 
| UpgradedWriterLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 3,825.37 ns | 18.469 ns | 17.276 ns |  11.30 |    1792 B | 
|                                                   |            |                  |             |           |           |        |           | 
| UpgradedWriterLock · AsyncRWLock · Pooled         | 5          | Timed            |   386.15 ns |  1.829 ns |  1.711 ns |   1.00 |     152 B |