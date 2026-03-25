| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      7.034 ns |  0.41 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     17.014 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.349 ns |  1.08 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     19.330 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     41.011 ns |  2.41 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    234.362 ns | 13.77 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     16.997 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.436 ns |  1.08 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     41.448 ns |  2.44 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    240.412 ns | 14.14 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.696 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     28.267 ns |  0.82 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     34.485 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     34.547 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     80.712 ns |  2.34 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    552.783 ns | 16.03 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     32.864 ns |  0.98 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     33.447 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     83.309 ns |  2.49 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    533.087 ns | 15.94 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     63.420 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    142.383 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    143.221 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    197.945 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    460.051 ns |  2.32 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,721.678 ns | 18.80 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    146.791 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    197.232 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    459.158 ns |  2.33 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,713.029 ns | 18.83 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    582.753 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,233.887 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,237.060 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,703.933 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,484.624 ns |  2.63 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 89,471.079 ns | 52.51 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,257.754 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,708.802 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,507.142 ns |  2.64 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 88,797.032 ns | 51.96 |   21008 B |