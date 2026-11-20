| Description                                          | Iterations | cancellationType | Mean         | Error      | StdDev     | Ratio | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-----------:|-----------:|------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |     7.906 ns |  0.0250 ns |  0.0234 ns |  0.88 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     9.012 ns |  0.0309 ns |  0.0289 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |    10.030 ns |  0.0495 ns |  0.0463 ns |  1.11 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |   772.283 ns |  1.7141 ns |  1.6033 ns | 85.69 |     520 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     8.968 ns |  0.0305 ns |  0.0285 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |    10.820 ns |  0.0339 ns |  0.0301 ns |  1.21 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |   794.196 ns |  3.2196 ns |  2.8541 ns | 88.55 |     520 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     8.151 ns |  0.0214 ns |  0.0200 ns |  0.36 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     9.198 ns |  0.0282 ns |  0.0264 ns |  0.41 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    22.470 ns |  0.0518 ns |  0.0484 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |   785.211 ns |  2.8789 ns |  2.6930 ns | 34.95 |     520 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |    10.106 ns |  0.0267 ns |  0.0237 ns |  0.45 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    22.456 ns |  0.0372 ns |  0.0348 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |   784.356 ns |  2.3145 ns |  2.1650 ns | 34.93 |     520 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |     7.912 ns |  0.0352 ns |  0.0329 ns |  0.35 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |     9.091 ns |  0.0200 ns |  0.0177 ns |  0.40 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    22.503 ns |  0.0515 ns |  0.0482 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             |   767.698 ns |  3.6876 ns |  3.4494 ns | 34.11 |     520 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |    10.332 ns |  0.0308 ns |  0.0288 ns |  0.46 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    22.434 ns |  0.0254 ns |  0.0225 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     |   805.934 ns |  1.7585 ns |  1.6449 ns | 35.92 |     520 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    22.988 ns |  0.1579 ns |  0.1400 ns |  0.26 |         - | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    25.920 ns |  0.0379 ns |  0.0336 ns |  0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |    87.894 ns |  0.0865 ns |  0.0722 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,411.180 ns | 11.8287 ns | 11.0646 ns | 27.43 |    1160 B | 
|                                                      |            |                  |              |            |            |       |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    25.607 ns |  0.0501 ns |  0.0444 ns |  0.29 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |    88.634 ns |  0.1958 ns |  0.1832 ns |  1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,492.279 ns | 12.8586 ns | 12.0279 ns | 28.12 |    1160 B |