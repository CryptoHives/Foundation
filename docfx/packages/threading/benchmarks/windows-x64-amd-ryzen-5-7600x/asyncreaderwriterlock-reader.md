| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      6.776 ns |  0.43 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     15.792 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.095 ns |  1.15 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     18.708 ns |  1.18 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     40.187 ns |  2.54 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    224.333 ns | 14.21 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     15.912 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.079 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     40.637 ns |  2.55 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    225.241 ns | 14.16 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.777 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     28.390 ns |  0.79 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     34.031 ns |  0.95 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     35.716 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     82.918 ns |  2.32 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    532.492 ns | 14.91 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.406 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     37.165 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     81.648 ns |  2.20 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    520.631 ns | 14.01 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     61.652 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    140.880 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    142.346 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    196.585 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    453.748 ns |  2.31 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,630.727 ns | 18.47 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    144.637 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    200.182 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    455.557 ns |  2.28 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,647.471 ns | 18.23 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    569.459 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,221.558 ns |  0.70 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,248.272 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,739.552 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,365.760 ns |  2.51 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 85,980.826 ns | 49.52 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,243.124 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,685.894 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,402.503 ns |  2.61 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 89,799.755 ns | 53.27 |   21008 B |