| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      7.676 ns |  0.39 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     19.535 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     21.306 ns |  1.09 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     22.243 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |     24.626 ns |  1.26 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     51.538 ns |  2.64 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    251.166 ns | 12.86 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     19.520 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     20.641 ns |  1.06 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |     25.789 ns |  1.32 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     45.463 ns |  2.33 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    255.218 ns | 13.07 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     13.843 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     31.468 ns |  0.75 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     37.875 ns |  0.91 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     41.799 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     49.657 ns |  1.19 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     90.424 ns |  2.16 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    581.586 ns | 13.91 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     32.533 ns |  0.77 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     41.998 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     50.506 ns |  1.20 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     92.083 ns |  2.19 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    610.468 ns | 14.54 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     70.806 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    161.759 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    165.261 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    228.157 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |    231.980 ns |  1.02 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    510.180 ns |  2.24 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  4,121.981 ns | 18.07 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    170.252 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    233.096 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |    236.716 ns |  1.02 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    506.107 ns |  2.17 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  4,015.558 ns | 17.23 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    642.692 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,376.372 ns |  0.70 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,428.526 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,970.284 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |  2,007.023 ns |  1.02 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,925.246 ns |  2.50 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 97,980.187 ns | 49.73 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,458.315 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,985.580 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |  2,002.673 ns |  1.01 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,891.057 ns |  2.46 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 98,047.966 ns | 49.38 |   21008 B |