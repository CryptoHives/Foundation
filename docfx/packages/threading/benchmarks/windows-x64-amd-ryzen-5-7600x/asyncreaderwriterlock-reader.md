| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · RWLockSlim · System          | 0          | None             |      7.728 ns |  0.49 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |     15.803 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     18.267 ns |  1.16 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     18.839 ns |  1.19 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     40.865 ns |  2.59 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    224.367 ns | 14.20 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |     15.951 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     18.197 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     40.386 ns |  2.53 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    225.331 ns | 14.13 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 1          | None             |     12.326 ns |  0.30 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     28.524 ns |  0.69 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     33.435 ns |  0.80 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     41.565 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     83.736 ns |  2.01 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    531.027 ns | 12.78 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     28.778 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     40.399 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     81.648 ns |  2.02 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    532.178 ns | 13.17 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 10         | None             |     61.963 ns |  0.32 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |    141.332 ns |  0.73 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    143.397 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    194.403 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    467.103 ns |  2.40 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  3,642.898 ns | 18.74 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |    139.359 ns |  0.72 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    194.276 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    464.283 ns |  2.39 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  3,640.725 ns | 18.74 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · RWLockSlim · System          | 100        | None             |    570.326 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |  1,223.857 ns |  0.70 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |  1,249.889 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  1,748.960 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,435.991 ns |  2.54 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 86,096.879 ns | 49.23 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |  1,245.661 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  1,743.212 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,404.138 ns |  2.53 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 87,835.002 ns | 50.39 |   21008 B |