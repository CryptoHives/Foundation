| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |     6.791 ns |  0.42 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    15.986 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    19.242 ns |  1.20 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |   934.232 ns | 58.44 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    15.833 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    17.758 ns |  1.12 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,023.598 ns | 64.65 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     6.930 ns |  0.34 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    18.011 ns |  0.89 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    20.150 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |   903.852 ns | 44.86 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    17.707 ns |  0.92 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    19.199 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |   991.525 ns | 51.65 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |     7.225 ns |  0.37 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    17.878 ns |  0.92 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    19.391 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             |   938.921 ns | 48.42 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    18.198 ns |  0.95 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    19.248 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,094.358 ns | 56.86 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    24.161 ns |  0.32 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    52.883 ns |  0.71 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    74.462 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,163.896 ns | 29.06 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    54.255 ns |  0.73 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    74.750 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,249.938 ns | 30.10 |    1240 B |