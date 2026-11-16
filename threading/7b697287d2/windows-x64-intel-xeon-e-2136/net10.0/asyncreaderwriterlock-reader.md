| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      22.85 ns |  0.54 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      42.36 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |      46.75 ns |  1.10 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |      53.47 ns |  1.26 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |      55.23 ns |  1.30 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     125.88 ns |  2.97 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |     682.85 ns | 16.12 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      42.81 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |      46.35 ns |  1.08 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |      55.83 ns |  1.30 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     125.90 ns |  2.94 |     320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |     679.66 ns | 15.87 |     208 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |      43.21 ns |  0.43 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |      75.35 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |     101.03 ns |  0.99 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |     101.65 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     105.64 ns |  1.04 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     253.96 ns |  2.50 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |   1,504.85 ns | 14.80 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |      77.89 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     104.96 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |     105.06 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     257.78 ns |  2.45 |     640 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |   1,503.48 ns | 14.31 |     416 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     211.05 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     345.37 ns |  0.51 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |     515.70 ns |  0.77 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |     548.12 ns |  0.81 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |     672.74 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |   1,414.05 ns |  2.10 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |   9,801.26 ns | 14.57 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     365.47 ns |  0.55 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |     545.13 ns |  0.81 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |     669.87 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |   1,425.99 ns |  2.13 |    3520 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |   9,765.16 ns | 14.58 |    2288 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |   1,915.96 ns |  0.30 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |   3,066.42 ns |  0.48 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |   4,703.92 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |   5,006.45 ns |  0.79 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |   6,370.05 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  13,700.31 ns |  2.15 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 193,247.05 ns | 30.34 |   21008 B | 
|                                           |            |                  |               |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |   3,263.15 ns |  0.52 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |   5,005.69 ns |  0.79 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |   6,311.54 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  13,256.54 ns |  2.10 |   32320 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 191,450.09 ns | 30.33 |   21008 B |