| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     6.741 ns |  0.41 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    16.248 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    19.423 ns |  1.20 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,064.281 ns | 65.50 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.334 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    17.778 ns |  1.09 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,135.176 ns | 69.50 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     6.725 ns |  0.34 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    17.560 ns |  0.90 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    19.551 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,048.830 ns | 53.65 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    17.601 ns |  0.92 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    19.051 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,181.340 ns | 62.01 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     6.733 ns |  0.36 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    17.646 ns |  0.94 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    18.809 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,045.428 ns | 55.58 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    17.493 ns |  0.90 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    19.365 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,179.300 ns | 60.90 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    24.080 ns |  0.31 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    52.959 ns |  0.69 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    76.546 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,477.664 ns | 32.37 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    53.909 ns |  0.72 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    74.742 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,586.760 ns | 34.61 |    1240 B |