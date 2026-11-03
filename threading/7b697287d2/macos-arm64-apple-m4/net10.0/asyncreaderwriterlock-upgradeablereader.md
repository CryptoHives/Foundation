| Description                                          | Iterations | cancellationType | Mean         | Ratio  | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |     5.038 ns |   0.59 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     8.544 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    12.076 ns |   1.41 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,430.739 ns | 167.46 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     8.580 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    12.240 ns |   1.43 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,462.459 ns | 170.45 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     5.033 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    10.963 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    36.806 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,460.346 ns |  39.68 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    10.838 ns |   0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    37.315 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,478.922 ns |  39.64 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |     4.997 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    10.945 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    36.645 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,439.291 ns |  39.28 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    10.836 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    36.624 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,570.021 ns |  42.87 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    19.344 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    22.996 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   135.151 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,151.760 ns |  15.92 |    1240 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    23.430 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   135.430 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,248.019 ns |  16.60 |    1240 B |