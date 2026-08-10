| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      6.774 ns |  0.40 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     17.075 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.400 ns |  1.08 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     18.917 ns |  1.11 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     40.428 ns |  2.37 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    224.937 ns | 13.17 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.943 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.193 ns |  1.07 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     39.961 ns |  2.36 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    224.973 ns | 13.28 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.461 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     28.467 ns |  0.82 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     34.709 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     34.977 ns |  1.01 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     84.985 ns |  2.45 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    518.755 ns | 14.95 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.772 ns |  0.84 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     34.054 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     81.086 ns |  2.38 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    518.476 ns | 15.23 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     61.761 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    142.806 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    144.870 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    197.022 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    481.419 ns |  2.44 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,703.521 ns | 18.80 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    147.119 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    197.696 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    473.137 ns |  2.39 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,614.872 ns | 18.29 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    559.414 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,220.891 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,236.741 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,700.744 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,495.417 ns |  2.64 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 87,591.125 ns | 51.50 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,256.133 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,698.319 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,403.054 ns |  2.59 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 86,857.592 ns | 51.14 |   21008 B |