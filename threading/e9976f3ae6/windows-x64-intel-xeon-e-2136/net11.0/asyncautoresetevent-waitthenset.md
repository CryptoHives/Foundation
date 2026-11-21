| Description                                                  | Iterations | cancellationType | Mean         | Error      | StdDev       | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|-----------:|-------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |     78.07 ns |   0.238 ns |     0.423 ns |  0.80 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |     90.64 ns |   0.300 ns |     0.556 ns |  0.93 |      96 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |     94.41 ns |   0.080 ns |     0.151 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |     95.25 ns |   0.356 ns |     0.651 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |     97.02 ns |   0.170 ns |     0.323 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |     97.38 ns |   1.110 ns |     1.973 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |     98.25 ns |   0.269 ns |     0.499 ns |  1.01 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |    136.37 ns |   0.321 ns |     0.602 ns |  1.40 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | None             |    157.89 ns |   0.324 ns |     0.593 ns |  1.62 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |    459.34 ns |   1.460 ns |     2.741 ns |  4.72 |     176 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |    134.55 ns |   0.470 ns |     0.871 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |    138.43 ns |   0.357 ns |     0.679 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |    138.71 ns |   0.798 ns |     1.438 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |    139.50 ns |   0.900 ns |     1.622 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |    144.20 ns |   0.527 ns |     0.978 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |    186.47 ns |   0.366 ns |     0.679 ns |  1.34 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | NotCancelled     |    190.63 ns |   0.176 ns |     0.326 ns |  1.37 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |    500.40 ns |   1.511 ns |     2.764 ns |  3.61 |     176 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |    585.38 ns |   6.756 ns |    25.734 ns |  4.22 |     384 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |    200.98 ns |   0.366 ns |     0.697 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |    203.04 ns |   0.895 ns |     1.682 ns |  1.01 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |    566.52 ns |   5.375 ns |     9.828 ns |  2.82 |     328 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |    149.87 ns |   0.311 ns |     0.544 ns |  0.73 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |    172.47 ns |   2.366 ns |     4.386 ns |  0.84 |     192 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |    198.88 ns |   3.508 ns |     6.414 ns |  0.97 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |    204.36 ns |   1.307 ns |     2.454 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |    205.82 ns |   1.036 ns |     1.894 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |    207.30 ns |   1.626 ns |     3.053 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |    209.47 ns |   1.448 ns |     2.611 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |    301.64 ns |   1.347 ns |     2.463 ns |  1.47 |     160 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | None             |    313.08 ns |   3.361 ns |     6.146 ns |  1.52 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |    793.57 ns |   7.027 ns |    13.199 ns |  3.86 |     288 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |    289.48 ns |   2.280 ns |     4.337 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    292.23 ns |   0.853 ns |     1.602 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    295.50 ns |   1.762 ns |     3.222 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |    297.63 ns |   0.439 ns |     0.781 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |    298.78 ns |   1.509 ns |     2.871 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | NotCancelled     |    379.96 ns |   0.817 ns |     1.514 ns |  1.27 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    394.46 ns |   1.827 ns |     3.341 ns |  1.32 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |    906.79 ns |  13.058 ns |    24.525 ns |  3.04 |     288 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |  1,135.27 ns |  12.942 ns |    62.818 ns |  3.80 |     768 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |    420.53 ns |   1.606 ns |     2.896 ns |  0.99 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |    424.16 ns |   1.451 ns |     2.654 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |  1,078.55 ns |   5.598 ns |    10.375 ns |  2.54 |     592 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |    707.15 ns |   0.534 ns |     0.990 ns |  0.58 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |    847.78 ns |  17.390 ns |    32.662 ns |  0.70 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |    970.85 ns |   1.919 ns |     3.650 ns |  0.80 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |  1,194.56 ns |   5.843 ns |    10.684 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |  1,204.97 ns |  12.411 ns |    23.004 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |  1,207.96 ns |   3.718 ns |     6.704 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |  1,215.67 ns |   5.080 ns |     9.541 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | None             |  1,536.64 ns |   7.764 ns |    14.391 ns |  1.26 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |  1,717.39 ns |  17.443 ns |    31.454 ns |  1.41 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |  3,748.54 ns |  18.078 ns |    32.598 ns |  3.08 |    1184 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |  1,398.31 ns |   1.658 ns |     3.113 ns |  0.84 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |  1,628.22 ns |   2.978 ns |     5.519 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |  1,664.89 ns |   5.408 ns |     9.889 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |  1,672.58 ns |   5.626 ns |    10.566 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |  1,704.44 ns |   6.373 ns |    12.125 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | NotCancelled     |  1,916.49 ns |  21.357 ns |    39.052 ns |  1.15 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |  2,130.73 ns |   6.275 ns |    11.474 ns |  1.27 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |  4,713.08 ns |  68.086 ns |   168.291 ns |  2.82 |    1184 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |  5,202.35 ns |  77.964 ns |   357.061 ns |  3.11 |    3840 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |  2,296.16 ns |   5.504 ns |    10.203 ns |  0.98 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |  2,350.51 ns |   9.009 ns |    17.141 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |  5,064.09 ns |  82.150 ns |   156.299 ns |  2.15 |    2704 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |  7,050.86 ns |   9.632 ns |    18.091 ns |  0.57 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |  8,215.26 ns |  38.878 ns |    73.022 ns |  0.66 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             | 10,007.77 ns | 145.816 ns |   270.280 ns |  0.80 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             | 12,318.32 ns |  92.839 ns |   169.761 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             | 12,326.22 ns | 129.237 ns |   245.886 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             | 12,449.16 ns |  60.285 ns |   110.234 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             | 12,473.95 ns |  75.627 ns |   143.888 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | None             | 15,245.61 ns |  95.909 ns |   177.773 ns |  1.22 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             | 17,070.84 ns |  26.417 ns |    50.261 ns |  1.37 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             | 35,694.66 ns |  87.012 ns |   163.431 ns |  2.86 |   11264 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     | 14,005.32 ns |  33.451 ns |    62.829 ns |  0.84 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     | 16,537.38 ns |  51.790 ns |    95.996 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     | 16,761.31 ns |  79.311 ns |   150.898 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     | 16,902.12 ns |  50.476 ns |    91.019 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     | 17,275.33 ns |  50.508 ns |    96.096 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | NotCancelled     | 19,179.57 ns | 110.554 ns |   207.647 ns |  1.14 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     | 21,928.18 ns |  45.964 ns |    86.332 ns |  1.31 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     | 43,130.37 ns | 622.735 ns | 3,223.387 ns |  2.57 |   38400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 50,590.78 ns | 603.470 ns | 2,946.367 ns |  3.02 |   11264 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            | 23,367.57 ns | 126.766 ns |   238.097 ns |  0.98 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            | 23,817.94 ns | 164.181 ns |   304.319 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            | 51,957.01 ns | 235.804 ns |   431.181 ns |  2.18 |   26464 B |