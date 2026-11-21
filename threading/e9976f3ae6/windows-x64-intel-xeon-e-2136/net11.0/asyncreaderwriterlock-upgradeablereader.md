| Description                                          | Iterations | cancellationType | Mean        | Error      | StdDev     | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |------------:|-----------:|-----------:|------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |    22.60 ns |   0.008 ns |   0.014 ns |  0.71 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |    31.82 ns |   0.021 ns |   0.040 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    36.11 ns |   0.021 ns |   0.040 ns |  1.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             | 1,569.05 ns |   6.800 ns |  12.604 ns | 49.31 |     520 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |    32.01 ns |   0.122 ns |   0.229 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    35.93 ns |   0.013 ns |   0.025 ns |  1.12 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     | 1,626.32 ns |   6.101 ns |  10.845 ns | 50.81 |     520 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |    22.61 ns |   0.008 ns |   0.014 ns |  0.34 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |    29.63 ns |   0.010 ns |   0.018 ns |  0.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    66.28 ns |   0.086 ns |   0.158 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             | 1,609.71 ns |  12.700 ns |  22.901 ns | 24.28 |     520 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    29.83 ns |   0.028 ns |   0.051 ns |  0.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    66.05 ns |   0.314 ns |   0.559 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,683.42 ns |   6.608 ns |  12.573 ns | 25.49 |     520 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |    22.60 ns |   0.008 ns |   0.015 ns |  0.34 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |    29.66 ns |   0.015 ns |   0.028 ns |  0.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    66.16 ns |   0.299 ns |   0.555 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,603.03 ns |   6.708 ns |  12.433 ns | 24.23 |     520 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    29.86 ns |   0.024 ns |   0.045 ns |  0.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    66.43 ns |   0.208 ns |   0.376 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,646.78 ns |  15.018 ns |  28.573 ns | 24.79 |     520 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    79.04 ns |   0.012 ns |   0.022 ns |  0.31 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    87.49 ns |   0.242 ns |   0.460 ns |  0.35 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   251.73 ns |   0.723 ns |   1.339 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 5,455.81 ns | 148.129 ns | 274.566 ns | 21.67 |    1160 B | 
|                                                      |            |                  |             |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    92.28 ns |   0.069 ns |   0.127 ns |  0.37 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   248.78 ns |   0.755 ns |   1.436 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 5,441.51 ns |  38.385 ns |  73.032 ns | 21.87 |    1160 B |