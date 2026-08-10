| Description                                          | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| UpgradeableReaderLock · RWLockSlim · System          | 0          | None             |     6.720 ns |  0.41 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    16.237 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    18.677 ns |  1.15 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,114.737 ns | 68.65 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    16.364 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    17.959 ns |  1.10 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,126.715 ns | 68.85 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 1          | None             |     6.710 ns |  0.37 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    17.597 ns |  0.96 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    18.245 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,111.874 ns | 60.94 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    17.597 ns |  0.96 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    18.317 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,159.959 ns | 63.33 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 2          | None             |     6.764 ns |  0.37 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    18.080 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    18.644 ns |  1.03 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,076.556 ns | 59.55 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    17.586 ns |  0.96 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    18.241 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,168.589 ns | 64.07 |     616 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · RWLockSlim · System          | 5          | None             |           NA |     ? |        NA | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    52.123 ns |  0.77 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    67.764 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,495.261 ns | 36.82 |    1240 B | 
|                                                      |            |                  |              |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    54.339 ns |  0.79 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    68.793 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,606.119 ns | 37.88 |    1240 B | 

Benchmarks with issues:
  AsyncReaderWriterLockUpgradeableReaderBenchmark.ReadLockReaderWriterLockSlim: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [Iterations=5, cancellationType=None]