| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      6.900 ns |  0.43 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     16.126 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.749 ns |  1.16 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     19.798 ns |  1.23 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     42.908 ns |  2.66 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    233.196 ns | 14.46 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.086 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.277 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     42.824 ns |  2.66 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    239.434 ns | 14.89 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.501 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     29.391 ns |  0.80 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     34.494 ns |  0.94 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     36.604 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     85.588 ns |  2.34 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    552.488 ns | 15.09 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     29.203 ns |  0.80 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     36.443 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     86.936 ns |  2.39 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    566.791 ns | 15.55 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     63.197 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    144.255 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    148.336 ns |  0.75 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    198.544 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    478.969 ns |  2.41 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,793.193 ns | 19.11 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    148.237 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    200.726 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    495.861 ns |  2.47 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,805.102 ns | 18.96 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    577.770 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,244.396 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,278.445 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,762.200 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,790.098 ns |  2.72 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 89,215.741 ns | 50.63 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,268.421 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,760.869 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,944.771 ns |  2.81 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 89,557.591 ns | 50.86 |   21008 B |