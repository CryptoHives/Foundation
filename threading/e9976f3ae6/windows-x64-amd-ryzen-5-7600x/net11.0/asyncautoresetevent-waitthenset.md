| Description                                                  | Iterations | cancellationType | Mean         | Error      | StdDev       | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|-----------:|-------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |     23.55 ns |   0.121 ns |     0.108 ns |  0.79 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |     27.43 ns |   0.061 ns |     0.051 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |     27.93 ns |   0.192 ns |     0.180 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |     29.44 ns |   0.061 ns |     0.054 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |     29.93 ns |   0.087 ns |     0.073 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |     31.52 ns |   0.119 ns |     0.112 ns |  1.05 |      96 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |     37.47 ns |   0.078 ns |     0.069 ns |  1.25 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |     43.82 ns |   0.247 ns |     0.219 ns |  1.46 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | None             |     49.47 ns |   0.346 ns |     0.289 ns |  1.65 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |    191.69 ns |   1.148 ns |     1.073 ns |  6.40 |     176 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |     46.29 ns |   0.228 ns |     0.202 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     47.36 ns |   0.178 ns |     0.149 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     47.44 ns |   0.184 ns |     0.172 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |     47.62 ns |   0.286 ns |     0.254 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |     49.06 ns |   0.129 ns |     0.114 ns |  1.06 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | NotCancelled     |     57.36 ns |   0.110 ns |     0.097 ns |  1.24 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     71.36 ns |   0.159 ns |     0.133 ns |  1.54 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |    226.64 ns |   0.565 ns |     0.501 ns |  4.90 |     176 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |    265.95 ns |   5.302 ns |    10.949 ns |  5.75 |     384 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |     66.47 ns |   0.310 ns |     0.275 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |     66.50 ns |   0.231 ns |     0.205 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |    257.14 ns |   0.423 ns |     0.375 ns |  3.87 |     328 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |     48.36 ns |   0.095 ns |     0.074 ns |  0.66 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |     55.53 ns |   0.101 ns |     0.089 ns |  0.76 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |     67.40 ns |   0.247 ns |     0.219 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |     67.89 ns |   0.337 ns |     0.281 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |     68.98 ns |   0.169 ns |     0.158 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |     73.48 ns |   0.294 ns |     0.261 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |     74.81 ns |   0.333 ns |     0.311 ns |  1.02 |     320 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | None             |     97.32 ns |   0.309 ns |     0.274 ns |  1.32 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |    109.19 ns |   0.578 ns |     0.512 ns |  1.49 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |    364.15 ns |   0.765 ns |     0.678 ns |  4.96 |     288 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |     99.23 ns |   0.434 ns |     0.384 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    108.07 ns |   0.331 ns |     0.276 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |    109.07 ns |   0.432 ns |     0.383 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    109.55 ns |   0.481 ns |     0.426 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |    113.22 ns |   0.477 ns |     0.423 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | NotCancelled     |    116.67 ns |   0.398 ns |     0.372 ns |  1.07 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    156.65 ns |   0.837 ns |     0.742 ns |  1.44 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |    426.70 ns |   3.414 ns |     3.026 ns |  3.91 |     288 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |    500.38 ns |  10.002 ns |    27.379 ns |  4.59 |     768 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |    149.77 ns |   1.038 ns |     0.971 ns |  0.94 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |    158.73 ns |   1.243 ns |     1.102 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |    446.42 ns |   0.537 ns |     0.476 ns |  2.81 |     592 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |    240.63 ns |   1.040 ns |     0.868 ns |  0.64 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |    268.23 ns |   0.983 ns |     0.821 ns |  0.72 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |    339.98 ns |   1.455 ns |     1.215 ns |  0.91 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |    361.27 ns |   1.767 ns |     1.476 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |    362.68 ns |   1.771 ns |     1.383 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |    374.11 ns |   3.425 ns |     2.860 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |    376.17 ns |   4.321 ns |     4.042 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | None             |    465.17 ns |   1.040 ns |     0.922 ns |  1.24 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |    555.82 ns |   3.403 ns |     3.184 ns |  1.49 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |  1,560.89 ns |   5.951 ns |     5.566 ns |  4.17 |    1184 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |    480.45 ns |   5.269 ns |     4.671 ns |  0.79 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    596.41 ns |   3.804 ns |     3.176 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |    606.78 ns |   3.697 ns |     2.886 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |    609.14 ns |   4.803 ns |     4.258 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    609.29 ns |   7.384 ns |     6.546 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | NotCancelled     |    611.79 ns |   4.227 ns |     3.529 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    807.92 ns |   7.787 ns |     7.284 ns |  1.33 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |  1,844.60 ns |  12.191 ns |    10.180 ns |  3.03 |    1184 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |  2,332.98 ns |  49.189 ns |   145.036 ns |  3.83 |    3840 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |    832.05 ns |   6.669 ns |     6.238 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |    856.60 ns |   5.545 ns |     5.187 ns |  1.03 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |  1,977.94 ns |   6.625 ns |     6.197 ns |  2.38 |    2704 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |  2,395.24 ns |  10.713 ns |     8.946 ns |  0.63 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |  2,650.82 ns |  46.063 ns |    43.088 ns |  0.69 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |  3,399.65 ns |  11.245 ns |    10.519 ns |  0.89 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |  3,564.26 ns |  44.050 ns |    39.049 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |  3,626.19 ns |  38.327 ns |    35.851 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |  3,817.06 ns |  53.449 ns |    49.997 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |  3,822.37 ns |  55.195 ns |    51.629 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | None             |  4,582.85 ns |  13.590 ns |    12.712 ns |  1.20 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |  5,588.43 ns |  55.658 ns |    49.339 ns |  1.46 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             | 14,817.92 ns |  88.398 ns |    78.363 ns |  3.88 |   11264 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |  4,740.63 ns |  22.679 ns |    18.938 ns |  0.78 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  6,031.03 ns |  41.600 ns |    36.877 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  6,067.39 ns |  73.041 ns |    68.323 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |  6,085.14 ns |  82.854 ns |    77.502 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |  6,166.29 ns |  49.557 ns |    46.355 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | NotCancelled     |  6,352.58 ns |  35.544 ns |    33.248 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  8,352.31 ns |  74.892 ns |    66.390 ns |  1.37 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 20,012.30 ns | 315.166 ns |   263.178 ns |  3.29 |   11264 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     | 22,040.15 ns | 642.256 ns | 1,883.626 ns |  3.62 |   38400 B | 
|                                                              |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            |  8,483.35 ns |  78.056 ns |    73.014 ns |  0.99 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            |  8,592.96 ns |  99.185 ns |    87.925 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            | 22,003.87 ns |  46.884 ns |    43.855 ns |  2.56 |   26464 B |