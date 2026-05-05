| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     6.855 ns |  0.43 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    15.959 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    20.142 ns |  1.26 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,096.171 ns | 68.69 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.321 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    18.987 ns |  1.16 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,127.899 ns | 69.11 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     6.745 ns |  0.37 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    18.139 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    19.333 ns |  1.07 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,089.110 ns | 60.04 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    17.789 ns |  0.90 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    19.749 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,138.793 ns | 57.77 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     6.822 ns |  0.37 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    17.518 ns |  0.96 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    18.268 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,082.163 ns | 59.24 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    17.317 ns |  0.93 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    18.599 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,124.084 ns | 60.44 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    24.061 ns |  0.35 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    54.872 ns |  0.80 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    68.248 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,631.592 ns | 38.56 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    53.997 ns |  0.80 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    67.902 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,693.549 ns | 39.67 |    1240 B |