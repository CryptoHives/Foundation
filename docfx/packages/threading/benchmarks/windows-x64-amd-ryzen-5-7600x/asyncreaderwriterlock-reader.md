| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      6.767 ns |  0.40 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     16.856 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.426 ns |  1.09 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     19.051 ns |  1.13 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     42.346 ns |  2.51 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    231.803 ns | 13.75 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.821 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.428 ns |  1.10 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     40.549 ns |  2.41 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    226.988 ns | 13.49 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     12.446 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     28.761 ns |  0.79 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     34.891 ns |  0.95 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     36.547 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     85.606 ns |  2.34 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    534.255 ns | 14.62 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.786 ns |  0.78 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     36.674 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     84.153 ns |  2.29 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    528.841 ns | 14.42 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     62.400 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    142.397 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    142.970 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    192.613 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    478.396 ns |  2.48 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,657.258 ns | 18.99 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    146.472 ns |  0.76 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    192.569 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    469.679 ns |  2.44 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,712.357 ns | 19.28 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    570.045 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,235.765 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,241.752 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,701.564 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,518.148 ns |  2.66 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 88,454.777 ns | 51.98 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,260.166 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,720.031 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,516.606 ns |  2.63 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 86,870.470 ns | 50.51 |   21008 B |