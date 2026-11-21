| Description                                                    | Iterations | cancellationType | Mean          | Error        | StdDev       | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |--------------:|-------------:|-------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |      16.01 ns |     0.087 ns |     0.077 ns |  0.74 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |      20.01 ns |     0.079 ns |     0.074 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |      21.39 ns |     0.038 ns |     0.036 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |      21.42 ns |     0.028 ns |     0.026 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |      21.64 ns |     0.070 ns |     0.065 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |      22.05 ns |     0.075 ns |     0.066 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |      28.89 ns |     0.112 ns |     0.105 ns |  1.34 |      96 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | None             |      33.88 ns |     0.393 ns |     0.328 ns |  1.57 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |      34.49 ns |     0.078 ns |     0.073 ns |  1.59 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |     326.29 ns |     5.717 ns |     5.347 ns | 15.08 |     175 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      33.27 ns |     0.117 ns |     0.110 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |      33.74 ns |     0.072 ns |     0.056 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      35.26 ns |     0.681 ns |     0.757 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |      35.33 ns |     0.150 ns |     0.140 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |      37.26 ns |     0.132 ns |     0.124 ns |  1.10 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | NotCancelled     |      47.15 ns |     0.892 ns |     0.954 ns |  1.40 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      47.71 ns |     0.114 ns |     0.107 ns |  1.41 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |     314.74 ns |     3.143 ns |     2.940 ns |  9.33 |     176 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |     642.99 ns |    19.756 ns |    58.252 ns | 19.06 |     743 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |      63.93 ns |     0.247 ns |     0.231 ns |  1.00 |     152 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |      19.25 ns |     0.045 ns |     0.043 ns |  0.35 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |      36.23 ns |     0.204 ns |     0.191 ns |  0.67 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |      37.07 ns |     0.167 ns |     0.156 ns |  0.68 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |      54.35 ns |     0.182 ns |     0.170 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |      55.68 ns |     0.211 ns |     0.187 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |      57.82 ns |     0.084 ns |     0.078 ns |  1.06 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |      58.29 ns |     0.142 ns |     0.133 ns |  1.07 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | None             |      67.44 ns |     0.679 ns |     0.635 ns |  1.24 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |      83.73 ns |     1.672 ns |     2.840 ns |  1.54 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |     400.16 ns |     5.886 ns |     4.915 ns |  7.36 |     288 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |      72.12 ns |     0.311 ns |     0.291 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |      76.16 ns |     0.270 ns |     0.252 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |      77.93 ns |     0.296 ns |     0.277 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      80.40 ns |     0.291 ns |     0.258 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      82.33 ns |     0.273 ns |     0.242 ns |  1.06 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | NotCancelled     |      90.77 ns |     0.595 ns |     0.557 ns |  1.16 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     106.81 ns |     0.595 ns |     0.557 ns |  1.37 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |     564.78 ns |    10.490 ns |    10.773 ns |  7.25 |     288 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |   1,069.03 ns |    23.805 ns |    70.189 ns | 13.72 |    1416 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |     137.33 ns |     0.274 ns |     0.256 ns |  1.00 |     304 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |      60.73 ns |     0.295 ns |     0.276 ns |  0.20 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |      97.34 ns |     1.475 ns |     1.380 ns |  0.33 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |     177.08 ns |     1.208 ns |     1.008 ns |  0.59 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |     296.36 ns |     1.146 ns |     1.072 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |     298.45 ns |     0.705 ns |     0.659 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |     306.20 ns |     1.035 ns |     0.968 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |     310.58 ns |     0.324 ns |     0.287 ns |  1.04 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | None             |     313.19 ns |     2.316 ns |     2.167 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |     415.31 ns |     4.534 ns |     4.020 ns |  1.39 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |   3,537.07 ns |    70.021 ns |    65.498 ns | 11.85 |    1184 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |     351.91 ns |     1.818 ns |     1.700 ns |  0.83 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |     423.39 ns |     0.973 ns |     0.760 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |     424.53 ns |     1.975 ns |     1.847 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     426.00 ns |     0.943 ns |     0.836 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     428.26 ns |     1.074 ns |     1.005 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | NotCancelled     |     440.41 ns |     2.731 ns |     2.555 ns |  1.04 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     583.35 ns |    11.351 ns |    13.513 ns |  1.37 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |   4,867.98 ns |    96.376 ns |   131.921 ns | 11.47 |    1184 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |   5,175.11 ns |    91.566 ns |    81.171 ns | 12.19 |    6328 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |     699.06 ns |     1.199 ns |     1.121 ns |  1.00 |    1520 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |     354.92 ns |     1.436 ns |     1.343 ns |  0.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |     764.30 ns |     4.164 ns |     3.895 ns |  0.29 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |   1,691.92 ns |     4.045 ns |     3.783 ns |  0.64 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |   2,662.63 ns |    14.921 ns |    13.957 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |   2,776.60 ns |     9.697 ns |     9.071 ns |  1.04 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,894.08 ns |     4.343 ns |     4.062 ns |  1.09 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |   2,907.39 ns |     9.046 ns |     8.462 ns |  1.09 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | None             |   2,923.52 ns |    56.937 ns |    86.949 ns |  1.10 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,002.11 ns |    74.029 ns |   101.331 ns |  1.50 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             |  35,990.03 ns |   718.794 ns |   637.192 ns | 13.52 |   11264 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |   3,401.94 ns |    11.854 ns |    11.089 ns |  0.83 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   3,946.47 ns |    10.660 ns |     9.971 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   4,042.78 ns |    18.737 ns |    17.527 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |   4,099.63 ns |    13.243 ns |    12.388 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |   4,100.50 ns |    16.853 ns |    15.764 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | NotCancelled     |   4,211.95 ns |    14.430 ns |    13.497 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   5,271.79 ns |     9.006 ns |     8.424 ns |  1.29 |    8000 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     |  83,046.84 ns | 1,651.359 ns | 2,713.230 ns | 20.26 |   60752 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 133,358.01 ns | 2,665.110 ns | 3,822.222 ns | 32.53 |   11264 B | 
|                                                                |            |                  |               |              |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            |   7,007.11 ns |    20.860 ns |    19.513 ns |  1.00 |   15200 B |