| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      5.725 ns |  0.67 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      8.505 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     11.240 ns |  1.32 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     13.643 ns |  1.60 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     41.931 ns |  4.93 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    171.572 ns | 20.17 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      8.608 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     11.580 ns |  1.35 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     41.251 ns |  4.79 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    170.510 ns | 19.81 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     10.355 ns |  0.24 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     16.032 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     24.067 ns |  0.56 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     43.314 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     82.420 ns |  1.90 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    399.563 ns |  9.23 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     16.672 ns |  0.39 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     42.907 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     83.548 ns |  1.95 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    405.096 ns |  9.44 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     53.361 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     53.528 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    119.993 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    339.794 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    467.264 ns |  1.38 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  2,937.107 ns |  8.64 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     55.023 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    345.169 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    467.684 ns |  1.35 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  2,868.913 ns |  8.31 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    457.906 ns |  0.14 |         - | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    483.165 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |    973.749 ns |  0.29 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  3,362.996 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,096.619 ns |  1.22 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 74,218.910 ns | 22.07 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    452.140 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  3,378.104 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,119.421 ns |  1.22 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 74,328.655 ns | 22.00 |   21008 B |