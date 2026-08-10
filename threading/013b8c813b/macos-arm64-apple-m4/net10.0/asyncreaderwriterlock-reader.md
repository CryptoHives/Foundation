| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      5.888 ns |  0.64 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      9.213 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     11.173 ns |  1.21 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     14.129 ns |  1.53 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     41.797 ns |  4.54 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    168.990 ns | 18.34 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      9.321 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     11.602 ns |  1.24 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     41.122 ns |  4.41 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    169.890 ns | 18.23 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     10.176 ns |  0.22 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     15.947 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     23.278 ns |  0.51 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     46.083 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     82.708 ns |  1.79 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    393.761 ns |  8.54 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     16.695 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     45.499 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     82.226 ns |  1.81 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    392.648 ns |  8.63 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     51.441 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     53.245 ns |  0.17 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    113.986 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    321.143 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    465.151 ns |  1.45 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  2,890.460 ns |  9.00 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     54.657 ns |  0.18 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    310.092 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    469.412 ns |  1.51 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  2,874.892 ns |  9.27 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    458.458 ns |  0.16 |         - | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    482.223 ns |  0.17 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |    985.528 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  2,828.670 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,126.229 ns |  1.46 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 74,059.595 ns | 26.20 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    450.691 ns |  0.17 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  2,713.733 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,114.507 ns |  1.52 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 74,958.026 ns | 27.62 |   21008 B |