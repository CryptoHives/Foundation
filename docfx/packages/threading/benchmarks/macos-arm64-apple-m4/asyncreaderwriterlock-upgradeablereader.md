| Description                                          | Iterations | cancellationType | Mean         | Ratio  | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     4.972 ns |   0.59 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     8.424 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    12.227 ns |   1.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,321.106 ns | 156.83 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     8.425 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    12.262 ns |   1.46 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,343.656 ns | 159.49 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     4.952 ns |   0.13 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    10.972 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    37.034 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,313.738 ns |  35.48 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    10.903 ns |   0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    37.528 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,434.630 ns |  38.23 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     4.975 ns |   0.13 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    11.050 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    36.944 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,398.213 ns |  37.85 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    10.832 ns |   0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    36.359 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,399.994 ns |  38.51 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    19.349 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    22.822 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   136.160 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,124.927 ns |  15.61 |    1240 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    23.717 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   136.708 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,215.944 ns |  16.21 |    1240 B |