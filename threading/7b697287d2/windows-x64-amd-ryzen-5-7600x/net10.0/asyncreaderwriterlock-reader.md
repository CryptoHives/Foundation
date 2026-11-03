| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      7.736 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     19.113 ns |  0.85 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     21.027 ns |  0.94 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     22.453 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |     24.674 ns |  1.10 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     46.585 ns |  2.07 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    251.948 ns | 11.22 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     19.465 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     20.874 ns |  1.07 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |     26.198 ns |  1.35 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     45.090 ns |  2.32 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    251.994 ns | 12.95 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     13.884 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     32.101 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     38.451 ns |  0.91 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     42.327 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     49.336 ns |  1.17 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     89.830 ns |  2.12 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    586.391 ns | 13.85 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     32.179 ns |  0.77 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     41.791 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     49.749 ns |  1.19 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     90.969 ns |  2.18 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    594.769 ns | 14.23 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     69.959 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    158.554 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    158.841 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    222.424 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |    238.850 ns |  1.07 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    504.029 ns |  2.27 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  4,113.491 ns | 18.49 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    163.180 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    221.688 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |    242.063 ns |  1.09 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    527.422 ns |  2.38 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  4,093.697 ns | 18.47 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    629.869 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,389.246 ns |  0.70 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,427.762 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,981.327 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |  2,005.000 ns |  1.01 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,995.162 ns |  2.52 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 97,914.736 ns | 49.42 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,453.940 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,962.568 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |  2,046.170 ns |  1.04 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,997.841 ns |  2.55 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 97,954.968 ns | 49.91 |   21008 B |