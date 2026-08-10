| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      5.732 ns |  0.63 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      9.158 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     11.296 ns |  1.23 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     13.391 ns |  1.46 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     42.319 ns |  4.62 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    169.505 ns | 18.51 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      9.158 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     11.481 ns |  1.25 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     42.416 ns |  4.63 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    167.352 ns | 18.28 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     10.246 ns |  0.22 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     16.190 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     23.066 ns |  0.50 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     45.916 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     83.109 ns |  1.81 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    390.711 ns |  8.51 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     16.920 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     45.264 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     83.492 ns |  1.84 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    390.358 ns |  8.62 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     52.626 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     54.393 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    115.369 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    360.986 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    495.640 ns |  1.37 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  2,883.426 ns |  7.99 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     55.005 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    356.881 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    480.267 ns |  1.35 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  2,888.069 ns |  8.09 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    463.746 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    482.796 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |    971.291 ns |  0.27 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  3,596.379 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,273.221 ns |  1.19 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 75,246.509 ns | 20.92 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    452.047 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  3,480.707 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,113.939 ns |  1.18 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 74,366.562 ns | 21.37 |   21008 B |