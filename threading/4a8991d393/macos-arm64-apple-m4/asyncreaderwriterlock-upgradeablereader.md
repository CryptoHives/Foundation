| Description                                          | Iterations | cancellationType | Mean         | Ratio  | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |     4.961 ns |   0.58 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     8.533 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    12.512 ns |   1.47 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,372.597 ns | 160.87 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     8.730 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    12.358 ns |   1.42 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,524.710 ns | 174.66 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     4.981 ns |   0.13 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    11.008 ns |   0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    38.110 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,461.630 ns |  38.36 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    11.002 ns |   0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    37.781 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,567.475 ns |  41.49 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |     4.973 ns |   0.13 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    11.095 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    37.360 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,500.156 ns |  40.15 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    11.085 ns |   0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    37.875 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,483.667 ns |  39.17 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    19.335 ns |   0.13 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    24.065 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   144.071 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,129.422 ns |  14.78 |    1240 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    24.967 ns |   0.18 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   141.994 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,320.848 ns |  16.34 |    1240 B |