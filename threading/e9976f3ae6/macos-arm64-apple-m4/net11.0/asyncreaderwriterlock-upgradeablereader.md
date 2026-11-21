| Description                                          | Iterations | cancellationType | Mean         | Error      | StdDev     | Ratio  | Allocated | 
|----------------------------------------------------- |----------- |----------------- |-------------:|-----------:|-----------:|-------:|----------:|
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | None             |     5.574 ns |  0.0091 ns |  0.0085 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |     5.916 ns |  0.0063 ns |  0.0059 ns |   1.06 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     8.501 ns |  0.0190 ns |  0.0178 ns |   1.53 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |   973.701 ns |  8.3895 ns |  7.0056 ns | 174.68 |     520 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     5.628 ns |  0.0053 ns |  0.0041 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     8.797 ns |  0.0243 ns |  0.0227 ns |   1.56 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |   653.009 ns |  2.0557 ns |  1.9229 ns | 116.04 |     520 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     5.981 ns |  0.0125 ns |  0.0105 ns |   0.16 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     7.520 ns |  0.0138 ns |  0.0129 ns |   0.20 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | None             |    37.106 ns |  0.4037 ns |  0.3776 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |   896.838 ns | 14.5946 ns | 12.9377 ns |  24.17 |     520 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     7.956 ns |  0.0184 ns |  0.0172 ns |   0.22 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |    36.688 ns |  0.4086 ns |  0.3822 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     | 1,069.766 ns | 32.7572 ns | 96.5854 ns |  29.16 |     520 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 2          | None             |     5.963 ns |  0.0201 ns |  0.0188 ns |   0.16 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | None             |     7.563 ns |  0.0130 ns |  0.0121 ns |   0.20 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | None             |    38.125 ns |  0.2430 ns |  0.2273 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | None             | 1,025.068 ns | 23.3617 ns | 68.8827 ns |  26.89 |     520 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 2          | NotCancelled     |     7.853 ns |  0.0207 ns |  0.0194 ns |   0.21 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 2          | NotCancelled     |    36.996 ns |  0.5270 ns |  0.4929 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 2          | NotCancelled     | 1,110.622 ns | 20.7643 ns | 22.2176 ns |  30.03 |     520 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | None             |    15.050 ns |  0.0237 ns |  0.0210 ns |   0.11 |         - | 
| UpgradeableReaderLock · AsyncRWLock · RWLockSlim     | 5          | None             |    19.433 ns |  0.0214 ns |  0.0179 ns |   0.14 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | None             |   135.077 ns |  0.7607 ns |  0.7115 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | None             | 2,104.755 ns | 19.5141 ns | 17.2987 ns |  15.58 |    1160 B | 
|                                                      |            |                  |              |            |            |        |           | 
| UpgradeableReaderLock · AsyncRWLock · Proto.Promises | 5          | NotCancelled     |    15.851 ns |  0.0096 ns |  0.0085 ns |   0.12 |         - | 
| UpgradeableReaderLock · AsyncRWLock · Pooled         | 5          | NotCancelled     |   136.949 ns |  0.6555 ns |  0.5811 ns |   1.00 |         - | 
| UpgradeableReaderLock · AsyncRWLock · VS.Threading   | 5          | NotCancelled     | 2,405.822 ns | 46.8419 ns | 70.1107 ns |  17.57 |    1160 B |