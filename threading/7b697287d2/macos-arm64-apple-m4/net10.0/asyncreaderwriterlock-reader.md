| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      6.009 ns |  0.68 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      8.871 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |     11.184 ns |  1.26 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |     13.126 ns |  1.48 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |     13.860 ns |  1.56 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     41.326 ns |  4.66 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |    169.282 ns | 19.08 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      8.955 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |     11.438 ns |  1.28 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |     13.664 ns |  1.53 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     41.705 ns |  4.66 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |    169.764 ns | 18.96 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |     10.471 ns |  0.23 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |     16.007 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     23.209 ns |  0.52 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     25.757 ns |  0.57 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     44.977 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     82.207 ns |  1.83 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |    389.393 ns |  8.66 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |     17.803 ns |  0.40 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     25.549 ns |  0.57 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     44.951 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     85.071 ns |  1.89 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |    390.413 ns |  8.69 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     53.382 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     54.279 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |    113.161 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |    130.299 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |    348.018 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |    467.654 ns |  1.34 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |  2,883.510 ns |  8.29 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     56.242 ns |  0.16 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |    129.716 ns |  0.37 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |    346.090 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |    472.044 ns |  1.36 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |  2,861.320 ns |  8.27 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |    465.852 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |    477.267 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |    964.605 ns |  0.28 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |  1,170.647 ns |  0.34 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |  3,406.889 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  4,255.568 ns |  1.25 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 73,468.989 ns | 21.57 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |    455.841 ns |  0.14 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |  1,184.931 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |  3,376.530 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  4,233.277 ns |  1.25 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 72,617.909 ns | 21.51 |   21008 B |