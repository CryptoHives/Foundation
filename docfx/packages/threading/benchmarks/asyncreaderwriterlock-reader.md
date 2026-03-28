| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      6.800 ns |  0.40 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     16.867 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.174 ns |  1.08 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     19.318 ns |  1.15 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     40.387 ns |  2.39 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    225.585 ns | 13.37 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.988 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.014 ns |  1.06 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     40.282 ns |  2.37 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    226.048 ns | 13.31 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.387 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     29.325 ns |  0.86 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     33.699 ns |  0.99 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     34.127 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     84.006 ns |  2.46 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    522.893 ns | 15.32 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.669 ns |  0.82 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     34.782 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     86.581 ns |  2.49 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    532.275 ns | 15.30 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     61.879 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    141.070 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    142.681 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    195.850 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    460.532 ns |  2.35 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,685.355 ns | 18.82 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    145.449 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    195.787 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    454.584 ns |  2.32 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,659.978 ns | 18.69 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    560.227 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,224.584 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,248.803 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,699.640 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,373.784 ns |  2.57 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 87,165.879 ns | 51.29 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,249.120 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,698.662 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,366.415 ns |  2.57 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 86,288.797 ns | 50.80 |   21008 B |
