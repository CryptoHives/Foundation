| Description                               | Iterations | cancellationType | Mean          | Error       | StdDev      | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------------:|------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      8.182 ns |   0.0315 ns |   0.0295 ns |  0.94 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      8.695 ns |   0.0158 ns |   0.0148 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |      8.936 ns |   0.0305 ns |   0.0255 ns |  1.03 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     20.346 ns |   0.0463 ns |   0.0387 ns |  2.34 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |     21.185 ns |   0.0202 ns |   0.0169 ns |  2.44 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     45.361 ns |   0.1861 ns |   0.1741 ns |  5.22 |     312 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    282.709 ns |   1.2629 ns |   1.1195 ns | 32.52 |     208 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      8.624 ns |   0.0292 ns |   0.0273 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |      9.817 ns |   0.0278 ns |   0.0260 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |     21.687 ns |   0.0530 ns |   0.0442 ns |  2.51 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     45.054 ns |   0.1812 ns |   0.1606 ns |  5.22 |     312 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    273.651 ns |   0.9273 ns |   0.8674 ns | 31.73 |     208 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     13.465 ns |   0.0271 ns |   0.0254 ns |  0.48 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     14.460 ns |   0.0489 ns |   0.0458 ns |  0.52 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     27.898 ns |   0.0373 ns |   0.0349 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     29.400 ns |   0.1182 ns |   0.1106 ns |  1.05 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     44.582 ns |   0.1402 ns |   0.1242 ns |  1.60 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     94.937 ns |   0.1657 ns |   0.1384 ns |  3.40 |     624 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    610.561 ns |   3.8758 ns |   3.4358 ns | 21.89 |     416 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     14.840 ns |   0.0445 ns |   0.0416 ns |  0.53 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     27.907 ns |   0.0680 ns |   0.0603 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     43.117 ns |   0.1160 ns |   0.1028 ns |  1.55 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     89.515 ns |   0.2456 ns |   0.2177 ns |  3.21 |     624 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    621.836 ns |   1.0389 ns |   0.8111 ns | 22.28 |     416 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     54.984 ns |   0.1703 ns |   0.1593 ns |  0.23 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     66.217 ns |   0.1520 ns |   0.1422 ns |  0.28 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    139.435 ns |   0.8368 ns |   0.7827 ns |  0.60 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |    224.175 ns |   0.4248 ns |   0.3766 ns |  0.96 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    234.324 ns |   0.3601 ns |   0.3368 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    487.731 ns |   2.7119 ns |   2.5367 ns |  2.08 |    3432 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  4,154.445 ns |  18.8022 ns |  17.5876 ns | 17.73 |    2288 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     66.216 ns |   0.2309 ns |   0.2047 ns |  0.28 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |    231.840 ns |   0.4715 ns |   0.4180 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    232.866 ns |   0.2378 ns |   0.1985 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    490.049 ns |   1.6274 ns |   1.5222 ns |  2.10 |    3432 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  4,109.488 ns |   8.8085 ns |   7.3555 ns | 17.65 |    2288 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    526.408 ns |   1.2905 ns |   1.2071 ns |  0.23 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    602.997 ns |   1.7748 ns |   1.5733 ns |  0.26 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,218.584 ns |   1.1817 ns |   0.9226 ns |  0.53 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |  1,918.228 ns |   1.9569 ns |   1.7348 ns |  0.84 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  2,287.991 ns |   3.1632 ns |   2.9589 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,709.687 ns |  38.0290 ns |  33.7117 ns |  2.06 |   31512 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 93,479.762 ns | 370.7762 ns | 328.6835 ns | 40.86 |   21008 B | 
|                                           |            |                  |               |             |             |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    585.673 ns |   2.6057 ns |   2.4373 ns |  0.26 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |  1,970.857 ns |   4.4064 ns |   3.9062 ns |  0.86 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  2,288.578 ns |   3.8592 ns |   3.6099 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,717.588 ns |  20.8086 ns |  19.4644 ns |  2.06 |   31512 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 93,558.506 ns | 236.2056 ns | 220.9469 ns | 40.88 |   21008 B |