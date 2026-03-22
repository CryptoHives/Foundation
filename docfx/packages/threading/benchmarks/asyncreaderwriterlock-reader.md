| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      6.930 ns |  0.40 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     17.265 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.030 ns |  1.04 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     18.866 ns |  1.09 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     39.323 ns |  2.28 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    225.977 ns | 13.09 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     17.416 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.186 ns |  1.04 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     40.191 ns |  2.31 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    224.386 ns | 12.88 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.239 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     27.409 ns |  0.70 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     33.541 ns |  0.86 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     39.051 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     86.193 ns |  2.21 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    523.001 ns | 13.39 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.918 ns |  0.77 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     37.550 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     88.282 ns |  2.35 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    550.179 ns | 14.65 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     62.026 ns |  0.28 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    140.937 ns |  0.63 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    142.715 ns |  0.64 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    223.871 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    457.495 ns |  2.04 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,622.214 ns | 16.18 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    141.631 ns |  0.64 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    222.928 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    454.650 ns |  2.04 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,624.729 ns | 16.26 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    564.599 ns |  0.28 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,215.162 ns |  0.61 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,217.169 ns |  0.61 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,990.188 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,471.914 ns |  2.25 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 85,617.678 ns | 43.02 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,222.696 ns |  0.62 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,984.665 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,340.383 ns |  2.19 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 86,115.151 ns | 43.39 |   21008 B |