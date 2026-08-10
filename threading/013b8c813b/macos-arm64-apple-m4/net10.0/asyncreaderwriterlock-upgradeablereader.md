| Description                                          | Iterations | cancellationType | Mean         | Ratio  | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     4.973 ns |   0.57 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     8.719 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    12.361 ns |   1.42 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,389.283 ns | 159.35 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     8.703 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    12.282 ns |   1.41 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,457.782 ns | 167.50 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     4.973 ns |   0.12 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    10.892 ns |   0.26 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    41.941 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,452.258 ns |  34.66 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    10.977 ns |   0.26 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    41.459 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,451.141 ns |  35.01 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     4.969 ns |   0.12 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    10.851 ns |   0.26 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    41.628 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,363.634 ns |  32.76 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    10.840 ns |   0.27 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    40.608 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,411.681 ns |  34.78 |     616 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    19.236 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    22.858 ns |   0.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   137.638 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,130.834 ns |  15.48 |    1240 B | 
|                                                      |            |                  |              |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    23.752 ns |   0.18 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   130.160 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,157.943 ns |  16.58 |    1240 B |