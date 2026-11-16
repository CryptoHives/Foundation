| Description                                          | Iterations | cancellationType | Mean        | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |------------:|------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |    21.26 ns |  0.51 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    41.30 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    48.53 ns |  1.18 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 2,231.15 ns | 54.03 |     616 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    42.50 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    48.68 ns |  1.15 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 2,342.13 ns | 55.11 |     616 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |    21.31 ns |  0.32 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    41.80 ns |  0.63 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    66.53 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 2,243.49 ns | 33.72 |     616 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    41.94 ns |  0.64 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    65.53 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 2,359.17 ns | 36.00 |     616 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |    21.25 ns |  0.32 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    42.48 ns |  0.63 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    67.11 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 2,235.25 ns | 33.31 |     616 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    41.96 ns |  0.63 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    66.46 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 2,311.05 ns | 34.77 |     616 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    80.31 ns |  0.32 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |   129.80 ns |  0.52 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   250.86 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 5,316.10 ns | 21.19 |    1240 B | 
|                                                      |            |                  |             |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |   137.86 ns |  0.55 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   250.86 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 5,449.96 ns | 21.73 |    1240 B |