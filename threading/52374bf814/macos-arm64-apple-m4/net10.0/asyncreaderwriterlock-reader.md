| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      6.172 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      8.639 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     11.373 ns |  1.32 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     13.955 ns |  1.62 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     42.188 ns |  4.89 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    169.288 ns | 19.60 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      8.813 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     11.912 ns |  1.35 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     41.956 ns |  4.77 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    173.597 ns | 19.72 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     10.560 ns |  0.23 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     16.098 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     23.725 ns |  0.52 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     45.892 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     84.073 ns |  1.83 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    403.626 ns |  8.80 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     16.784 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     45.025 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     93.791 ns |  2.08 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    405.231 ns |  9.00 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     53.209 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     54.324 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    114.815 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    341.559 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    480.115 ns |  1.41 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  2,924.869 ns |  8.56 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     54.705 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    348.494 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    466.506 ns |  1.34 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  2,913.725 ns |  8.36 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    452.161 ns |  0.13 |         - | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    489.782 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |    991.034 ns |  0.29 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  3,419.210 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,250.900 ns |  1.24 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 73,780.822 ns | 21.58 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    473.818 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  3,412.131 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,264.565 ns |  1.25 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 73,570.658 ns | 21.56 |   21008 B |