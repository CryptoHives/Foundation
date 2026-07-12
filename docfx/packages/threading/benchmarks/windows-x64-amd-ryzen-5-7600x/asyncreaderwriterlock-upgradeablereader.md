| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     6.801 ns |  0.42 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    16.276 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    19.128 ns |  1.18 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,110.997 ns | 68.26 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.212 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    17.665 ns |  1.09 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,140.921 ns | 70.37 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     6.707 ns |  0.36 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    17.605 ns |  0.93 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    18.890 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,119.338 ns | 59.26 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    17.600 ns |  0.93 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    18.836 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,137.456 ns | 60.39 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     6.725 ns |  0.36 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    17.429 ns |  0.92 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    18.897 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,060.637 ns | 56.13 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    17.648 ns |  0.94 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    18.816 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,173.198 ns | 62.35 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    23.912 ns |  0.30 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    52.034 ns |  0.66 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    79.277 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,490.130 ns | 31.41 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    53.707 ns |  0.73 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    73.348 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,575.779 ns | 35.12 |    1240 B |