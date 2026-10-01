| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      6.063 ns |  0.68 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      8.888 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     11.202 ns |  1.26 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |     13.011 ns |  1.46 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     13.511 ns |  1.52 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     41.519 ns |  4.67 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    172.723 ns | 19.43 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      9.201 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     11.677 ns |  1.27 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |     13.728 ns |  1.49 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     41.921 ns |  4.56 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    173.838 ns | 18.89 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     10.636 ns |  0.23 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     16.103 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     24.276 ns |  0.52 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     25.839 ns |  0.56 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     46.517 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     84.623 ns |  1.82 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    403.813 ns |  8.68 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     19.170 ns |  0.41 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     25.345 ns |  0.54 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     46.786 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     83.166 ns |  1.78 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    407.555 ns |  8.71 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     53.986 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     54.222 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    115.777 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |    129.967 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    361.785 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    470.910 ns |  1.30 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,024.045 ns |  8.36 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     56.463 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |    130.299 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    363.229 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    467.761 ns |  1.29 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  2,977.767 ns |  8.20 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    459.854 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    487.065 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |    969.275 ns |  0.27 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |  1,197.265 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  3,574.375 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,435.103 ns |  1.24 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 75,868.210 ns | 21.23 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    454.767 ns |  0.13 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |  1,162.343 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  3,564.587 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,179.542 ns |  1.17 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 75,997.813 ns | 21.32 |   21008 B |