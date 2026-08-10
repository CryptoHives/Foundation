| Description                                          | Iterations | cancellationType | Mean         | Ratio  | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     4.970 ns |   0.59 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     8.437 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    12.288 ns |   1.46 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,509.803 ns | 178.98 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     8.484 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    12.314 ns |   1.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,552.237 ns | 182.97 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     4.977 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    11.034 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    36.772 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,431.211 ns |  38.93 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    11.031 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    36.280 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,497.189 ns |  41.27 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     4.963 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    11.068 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    36.723 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,524.603 ns |  41.52 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    11.024 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    36.582 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,537.993 ns |  42.04 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    19.204 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    22.802 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   136.771 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,051.705 ns |  15.00 |    1240 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    23.691 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   135.748 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,151.423 ns |  15.85 |    1240 B |