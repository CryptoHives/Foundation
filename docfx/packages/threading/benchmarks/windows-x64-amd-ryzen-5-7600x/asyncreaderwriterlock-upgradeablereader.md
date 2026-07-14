| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     6.917 ns |  0.41 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    16.976 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    19.890 ns |  1.17 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,106.654 ns | 65.21 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.486 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    18.141 ns |  1.10 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,191.877 ns | 72.30 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     6.983 ns |  0.35 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    18.062 ns |  0.91 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    19.929 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,123.839 ns | 56.42 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    18.155 ns |  0.91 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    19.889 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,219.631 ns | 61.34 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     7.005 ns |  0.36 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    17.830 ns |  0.91 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    19.646 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,111.678 ns | 56.60 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    18.088 ns |  0.93 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    19.481 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,161.092 ns | 59.61 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |    24.641 ns |  0.33 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    53.257 ns |  0.70 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    75.567 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,660.203 ns | 35.21 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    54.783 ns |  0.71 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    77.383 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,768.137 ns | 35.78 |    1240 B |