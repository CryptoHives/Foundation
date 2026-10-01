| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |     7.570 ns |  0.40 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    18.755 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    20.650 ns |  1.10 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,057.929 ns | 56.41 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    19.978 ns |  0.75 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    26.808 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,087.928 ns | 40.68 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     7.559 ns |  0.35 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    20.178 ns |  0.93 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    21.702 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,071.061 ns | 49.35 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    20.329 ns |  0.84 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    24.124 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,135.166 ns | 47.06 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |     7.550 ns |  0.35 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    20.264 ns |  0.93 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    21.742 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,045.758 ns | 48.10 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    20.342 ns |  0.92 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    22.126 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,131.887 ns | 51.16 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    27.179 ns |  0.32 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    60.798 ns |  0.71 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    86.170 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,399.529 ns | 27.85 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    62.937 ns |  0.73 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    86.119 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,440.491 ns | 28.34 |    1240 B |