| Description                               | Iterations | cancellationType | Mean         | Error      | StdDev       | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|-----------:|-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     21.45 ns |   0.156 ns |     0.290 ns |  0.96 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     22.34 ns |   0.010 ns |     0.019 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     29.68 ns |   0.156 ns |     0.294 ns |  1.33 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     46.29 ns |   0.092 ns |     0.173 ns |  2.07 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     48.88 ns |   0.018 ns |     0.033 ns |  2.19 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     50.89 ns |   0.075 ns |     0.132 ns |  2.28 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     52.27 ns |   0.192 ns |     0.360 ns |  2.34 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     53.33 ns |   0.089 ns |     0.161 ns |  2.39 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 0          | None             |    124.72 ns |   2.302 ns |     4.209 ns |  5.58 |     312 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |    147.40 ns |   0.200 ns |     0.370 ns |  6.60 |     208 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     21.43 ns |   0.318 ns |     0.573 ns |  0.92 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     23.31 ns |   0.720 ns |     1.335 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     29.87 ns |   0.008 ns |     0.015 ns |  1.29 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     49.05 ns |   0.078 ns |     0.146 ns |  2.11 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     51.00 ns |   0.022 ns |     0.039 ns |  2.19 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     52.65 ns |   0.209 ns |     0.377 ns |  2.27 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     53.50 ns |   0.062 ns |     0.114 ns |  2.30 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 0          | NotCancelled     |    121.66 ns |   0.253 ns |     0.468 ns |  5.24 |     312 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |    151.17 ns |   0.275 ns |     0.510 ns |  6.51 |     208 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |     23.32 ns |   0.920 ns |     1.727 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     50.41 ns |   0.021 ns |     0.039 ns |  2.17 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     52.37 ns |   1.070 ns |     1.901 ns |  2.26 |         - | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |    111.60 ns |   0.389 ns |     0.702 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |    121.46 ns |   0.997 ns |     1.745 ns |  1.09 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |    133.94 ns |   0.166 ns |     0.303 ns |  1.20 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |    187.69 ns |   0.527 ns |     0.991 ns |  1.68 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |    207.33 ns |   0.261 ns |     0.470 ns |  1.86 |         - | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |    220.18 ns |   0.616 ns |     1.142 ns |  1.97 |     216 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 1          | None             |    298.69 ns |   0.666 ns |     1.217 ns |  2.68 |     712 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    303.68 ns |   0.404 ns |     0.738 ns |  2.72 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    505.06 ns |   6.027 ns |    11.320 ns |  4.53 |     208 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    584.28 ns |   2.824 ns |     5.304 ns |  5.24 |     432 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |    152.68 ns |   0.520 ns |     0.965 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |    187.88 ns |   0.360 ns |     0.668 ns |  1.23 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |    220.01 ns |   0.474 ns |     0.879 ns |  1.44 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |    240.87 ns |   1.063 ns |     1.918 ns |  1.58 |         - | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    312.76 ns |   0.567 ns |     1.064 ns |  2.05 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    527.56 ns |   5.292 ns |     9.677 ns |  3.46 |     208 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    743.16 ns |   8.032 ns |    15.085 ns |  4.87 |     600 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 1          | NotCancelled     |    796.70 ns |   9.434 ns |    20.510 ns |  5.22 |     936 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    886.34 ns |   7.854 ns |    14.558 ns |  5.81 |     856 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |    217.32 ns |   0.880 ns |     1.674 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    336.18 ns |   1.747 ns |     3.281 ns |  1.55 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    808.82 ns |   5.905 ns |    10.945 ns |  3.72 |     696 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    850.42 ns |   4.711 ns |     8.849 ns |  0.69 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    925.48 ns |   4.965 ns |     9.446 ns |  0.75 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |  1,227.50 ns |   3.414 ns |     6.328 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |  1,490.47 ns |   3.614 ns |     6.787 ns |  1.21 |    1680 B | 
| Multiple · AsyncLock · DotNext            | 10         | None             |  1,584.00 ns |   4.910 ns |     9.341 ns |  1.29 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |  1,627.74 ns |   7.109 ns |    12.999 ns |  1.33 |    2288 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |  1,804.15 ns |   1.521 ns |     2.820 ns |  1.47 |    2160 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 10         | None             |  1,827.41 ns |   5.876 ns |    11.180 ns |  1.49 |    4312 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  4,719.93 ns |  49.748 ns |    93.439 ns |  3.85 |    1288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  5,042.87 ns |  19.398 ns |    35.470 ns |  4.11 |    3528 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |  1,537.42 ns |   3.472 ns |     6.348 ns |  0.91 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |  1,628.85 ns |   1.975 ns |     3.611 ns |  0.96 |    2288 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |  1,689.53 ns |   3.301 ns |     5.953 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |  1,905.03 ns |   3.756 ns |     7.055 ns |  1.13 |    1680 B | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |  1,963.95 ns |   2.962 ns |     5.416 ns |  1.16 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  5,272.26 ns |  38.137 ns |    69.735 ns |  3.12 |    1288 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 10         | NotCancelled     |  5,795.80 ns |  75.301 ns |   252.889 ns |  3.43 |    6552 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  6,534.01 ns |  39.050 ns |    73.346 ns |  3.87 |    5208 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  8,206.38 ns |  55.648 ns |   101.755 ns |  4.86 |    7768 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |  2,324.36 ns |   7.702 ns |    14.084 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  2,955.21 ns |  13.901 ns |    26.448 ns |  1.27 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  7,280.69 ns |  83.986 ns |   155.673 ns |  3.13 |    6184 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  7,978.87 ns |  13.016 ns |    23.801 ns |  0.64 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  8,702.68 ns |  52.224 ns |    95.494 ns |  0.70 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             | 12,443.53 ns |  44.429 ns |    82.351 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             | 14,371.37 ns |  34.396 ns |    62.895 ns |  1.15 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             | 15,003.56 ns |  24.962 ns |    45.645 ns |  1.21 |   21008 B | 
| Multiple · AsyncLock · DotNext            | 100        | None             | 15,292.66 ns |  24.408 ns |    42.749 ns |  1.23 |         - | 
| Multiple · AsyncLock · RefImpl            | 100        | None             | 17,464.83 ns |  90.710 ns |   168.137 ns |  1.40 |   21600 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 100        | None             | 17,782.94 ns |  42.339 ns |    78.478 ns |  1.43 |   40312 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 50,762.81 ns |  88.513 ns |   166.248 ns |  4.08 |   12088 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 52,363.75 ns | 549.031 ns | 1,017.664 ns |  4.21 |   34488 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     | 15,000.97 ns | 187.280 ns |   356.319 ns |  0.88 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     | 15,249.59 ns | 151.340 ns |   287.939 ns |  0.89 |   21008 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     | 17,129.31 ns |  34.063 ns |    63.978 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     | 18,228.78 ns |  51.708 ns |    95.844 ns |  1.06 |   21120 B | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     | 19,047.21 ns |  34.471 ns |    64.746 ns |  1.11 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 100        | NotCancelled     | 55,137.47 ns | 527.794 ns | 1,066.170 ns |  3.22 |   62712 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 56,410.44 ns | 115.195 ns |   210.640 ns |  3.29 |   12088 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 69,938.70 ns | 911.717 ns | 1,689.927 ns |  4.08 |   51288 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 88,544.79 ns | 602.171 ns | 1,116.163 ns |  5.17 |   76888 B | 
|                                           |            |                  |              |            |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            | 23,403.92 ns |  50.799 ns |    94.159 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 29,725.48 ns | 199.277 ns |   379.146 ns |  1.27 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 77,524.58 ns | 294.883 ns |   546.584 ns |  3.31 |   60904 B |