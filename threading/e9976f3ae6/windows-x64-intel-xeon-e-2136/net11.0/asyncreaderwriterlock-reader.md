| Description                               | Iterations | cancellationType | Mean          | Error      | StdDev     | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|-----------:|-----------:|------:|----------:|
| ReaderLock · AsyncRWLock · RWLockSlim     | 0          | None             |      22.88 ns |   0.010 ns |   0.019 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | None             |      31.07 ns |   0.002 ns |   0.005 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | None             |      32.29 ns |   0.132 ns |   0.241 ns |  1.04 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 0          | None             |      47.31 ns |   0.133 ns |   0.242 ns |  1.52 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | None             |      55.60 ns |   1.482 ns |   2.783 ns |  1.79 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | None             |     121.91 ns |   0.378 ns |   0.681 ns |  3.92 |     312 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | None             |     669.99 ns |   1.825 ns |   3.473 ns | 21.56 |     208 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · Pooled         | 0          | NotCancelled     |      31.18 ns |   0.083 ns |   0.149 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 0          | NotCancelled     |      32.68 ns |   0.552 ns |   0.996 ns |  1.05 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 0          | NotCancelled     |      53.95 ns |   0.012 ns |   0.023 ns |  1.73 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 0          | NotCancelled     |     123.30 ns |   1.594 ns |   2.954 ns |  3.95 |     312 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 0          | NotCancelled     |     678.51 ns |   2.130 ns |   4.052 ns | 21.76 |     208 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 1          | None             |      42.69 ns |   0.017 ns |   0.031 ns |  0.47 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | None             |      53.37 ns |   0.221 ns |   0.420 ns |  0.58 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | None             |      91.57 ns |   0.018 ns |   0.035 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 1          | None             |      91.59 ns |   0.160 ns |   0.304 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | None             |     103.97 ns |   0.240 ns |   0.427 ns |  1.14 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | None             |     248.50 ns |   0.837 ns |   1.531 ns |  2.71 |     624 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | None             |   1,507.56 ns |   5.909 ns |  11.242 ns | 16.46 |     416 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 1          | NotCancelled     |      53.79 ns |   0.081 ns |   0.150 ns |  0.58 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 1          | NotCancelled     |      93.07 ns |   0.435 ns |   0.828 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 1          | NotCancelled     |     103.08 ns |   0.453 ns |   0.851 ns |  1.11 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 1          | NotCancelled     |     250.82 ns |   1.050 ns |   1.946 ns |  2.70 |     624 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 1          | NotCancelled     |   1,471.18 ns |   2.598 ns |   4.751 ns | 15.81 |     416 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 10         | None             |     202.08 ns |   0.053 ns |   0.095 ns |  0.31 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | None             |     232.72 ns |   0.824 ns |   1.548 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 10         | None             |     477.79 ns |   0.865 ns |   1.581 ns |  0.74 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | None             |     528.57 ns |   1.775 ns |   3.333 ns |  0.82 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | None             |     648.01 ns |   1.671 ns |   3.179 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | None             |   1,423.22 ns |  24.003 ns |  44.490 ns |  2.20 |    3432 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | None             |   9,450.23 ns |  23.115 ns |  43.416 ns | 14.58 |    2288 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 10         | NotCancelled     |     254.15 ns |   0.652 ns |   1.209 ns |  0.40 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 10         | NotCancelled     |     526.55 ns |   1.587 ns |   2.981 ns |  0.82 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 10         | NotCancelled     |     642.02 ns |   1.522 ns |   2.820 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 10         | NotCancelled     |   1,406.79 ns |  10.240 ns |  18.980 ns |  2.19 |    3432 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 10         | NotCancelled     |   9,475.24 ns |  10.070 ns |  18.913 ns | 14.76 |    2288 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · RWLockSlim     | 100        | None             |   1,814.07 ns |   7.522 ns |  14.128 ns |  0.29 |         - | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | None             |   2,028.79 ns |   0.382 ns |   0.698 ns |  0.33 |         - | 
| ReaderLock · AsyncRWLock · RefImpl        | 100        | None             |   4,359.86 ns |   2.868 ns |   5.023 ns |  0.71 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | None             |   4,843.05 ns |  11.870 ns |  21.704 ns |  0.78 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | None             |   6,179.84 ns |  21.669 ns |  39.073 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | None             |  13,488.60 ns | 168.122 ns | 319.870 ns |  2.18 |   31512 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | None             | 178,311.29 ns | 176.115 ns | 313.044 ns | 28.85 |   21008 B | 
|                                           |            |                  |               |            |            |       |           | 
| ReaderLock · AsyncRWLock · Proto.Promises | 100        | NotCancelled     |   2,241.81 ns |   0.852 ns |   1.600 ns |  0.36 |         - | 
| ReaderLock · AsyncRWLock · DotNext        | 100        | NotCancelled     |   4,781.41 ns |  14.595 ns |  27.412 ns |  0.78 |         - | 
| ReaderLock · AsyncRWLock · Pooled         | 100        | NotCancelled     |   6,169.06 ns |  16.145 ns |  30.717 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx   | 100        | NotCancelled     |  13,072.03 ns |  23.913 ns |  44.914 ns |  2.12 |   31512 B | 
| ReaderLock · AsyncRWLock · VS.Threading   | 100        | NotCancelled     | 178,453.62 ns | 419.208 ns | 723.113 ns | 28.93 |   21008 B |