| Description                                                  | Iterations | cancellationType | Mean         | Error        | StdDev       | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|-------------:|-------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |     19.19 ns |     0.076 ns |     0.071 ns |  0.81 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |     22.30 ns |     0.116 ns |     0.103 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |     23.48 ns |     0.139 ns |     0.130 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |     23.58 ns |     0.167 ns |     0.148 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |     24.54 ns |     0.162 ns |     0.152 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |     26.47 ns |     0.031 ns |     0.027 ns |  1.12 |      96 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | None             |     31.75 ns |     0.105 ns |     0.098 ns |  1.35 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |     34.55 ns |     0.045 ns |     0.042 ns |  1.47 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |     36.04 ns |     0.127 ns |     0.106 ns |  1.53 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |    461.88 ns |    20.347 ns |    59.992 ns | 19.59 |     174 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     34.34 ns |     0.277 ns |     0.231 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     34.78 ns |     0.154 ns |     0.128 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |     35.21 ns |     0.171 ns |     0.152 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |     35.53 ns |     0.157 ns |     0.147 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |     36.44 ns |     0.076 ns |     0.071 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | NotCancelled     |     40.72 ns |     0.100 ns |     0.089 ns |  1.16 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     47.63 ns |     0.184 ns |     0.173 ns |  1.35 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |    308.43 ns |     6.130 ns |     9.175 ns |  8.76 |     176 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |    648.42 ns |     7.171 ns |     6.708 ns | 18.42 |     384 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |     64.91 ns |     0.087 ns |     0.073 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |     64.94 ns |     0.076 ns |     0.071 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |    488.94 ns |     9.623 ns |    20.921 ns |  7.53 |     327 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |     38.19 ns |     0.270 ns |     0.253 ns |  0.63 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |     48.09 ns |     0.095 ns |     0.089 ns |  0.80 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |     60.27 ns |     0.157 ns |     0.147 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |     60.57 ns |     0.075 ns |     0.071 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |     60.96 ns |     0.168 ns |     0.157 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |     61.20 ns |     0.110 ns |     0.103 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |     63.06 ns |     0.220 ns |     0.206 ns |  1.05 |     320 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | None             |     63.25 ns |     0.274 ns |     0.243 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |     84.91 ns |     0.165 ns |     0.155 ns |  1.41 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |    400.03 ns |     7.082 ns |     6.625 ns |  6.64 |     288 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |     72.42 ns |     0.205 ns |     0.181 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |     79.98 ns |     0.184 ns |     0.172 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |     80.58 ns |     0.170 ns |     0.159 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |     80.72 ns |     0.078 ns |     0.069 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |     81.18 ns |     0.208 ns |     0.195 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | NotCancelled     |     84.11 ns |     0.278 ns |     0.260 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    109.65 ns |     0.434 ns |     0.406 ns |  1.37 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |    606.43 ns |    11.903 ns |    15.478 ns |  7.58 |     288 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |  1,171.82 ns |    14.552 ns |    13.612 ns | 14.65 |     768 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |    141.24 ns |     0.125 ns |     0.111 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |    142.88 ns |     0.196 ns |     0.164 ns |  1.01 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |    745.21 ns |    14.660 ns |    16.882 ns |  5.28 |     592 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |    183.71 ns |     0.188 ns |     0.166 ns |  0.56 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |    244.56 ns |     0.561 ns |     0.524 ns |  0.74 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |    325.21 ns |     0.203 ns |     0.180 ns |  0.99 |    1600 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | None             |    326.42 ns |     0.594 ns |     0.527 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |    327.72 ns |     0.720 ns |     0.673 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |    328.48 ns |     0.585 ns |     0.547 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |    332.79 ns |     0.448 ns |     0.419 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |    333.92 ns |     0.620 ns |     0.580 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |    440.65 ns |     0.954 ns |     0.745 ns |  1.34 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |  3,213.82 ns |    29.512 ns |    27.606 ns |  9.78 |    1184 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |    364.31 ns |     0.924 ns |     0.819 ns |  0.81 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    438.68 ns |     1.138 ns |     1.065 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | NotCancelled     |    441.38 ns |     1.024 ns |     0.855 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    443.07 ns |     1.241 ns |     1.160 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |    447.37 ns |     0.691 ns |     0.646 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |    525.88 ns |     6.944 ns |     6.496 ns |  1.18 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    579.72 ns |     1.754 ns |     1.641 ns |  1.30 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |  5,246.10 ns |   102.544 ns |   153.483 ns | 11.73 |    1184 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |  5,409.09 ns |    71.319 ns |    66.712 ns | 12.09 |    3840 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |    721.31 ns |     0.782 ns |     0.731 ns |  0.99 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |    727.33 ns |     1.388 ns |     1.299 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |  5,972.28 ns |   115.289 ns |   161.619 ns |  8.21 |    2704 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |  1,800.59 ns |     1.400 ns |     1.310 ns |  0.58 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |  2,274.20 ns |     1.776 ns |     1.661 ns |  0.73 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |  2,827.40 ns |    15.651 ns |    13.874 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |  2,919.18 ns |    15.685 ns |    14.672 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |  2,971.38 ns |    33.335 ns |    31.181 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | None             |  3,073.46 ns |     4.402 ns |     3.676 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |  3,099.62 ns |     3.274 ns |     2.903 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |  3,178.55 ns |    44.274 ns |    39.248 ns |  1.03 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |  4,295.48 ns |    85.612 ns |    91.604 ns |  1.39 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             | 37,882.96 ns |   224.183 ns |   187.203 ns | 12.22 |   11263 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |  3,471.96 ns |     5.337 ns |     4.731 ns |  0.81 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  4,100.89 ns |     9.165 ns |     8.573 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  4,108.63 ns |     6.752 ns |     5.985 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | NotCancelled     |  4,232.00 ns |     5.169 ns |     4.582 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |  4,260.32 ns |    11.794 ns |    11.033 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |  4,304.16 ns |    15.280 ns |    14.293 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  5,507.35 ns |    11.379 ns |    10.644 ns |  1.29 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 49,776.63 ns |   964.684 ns |   902.366 ns | 11.68 |   11264 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     | 52,345.03 ns | 1,045.114 ns | 2,843.311 ns | 12.29 |   38400 B | 
|                                                              |            |                  |              |              |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            |  7,085.35 ns |    11.495 ns |    10.752 ns |  0.98 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            |  7,247.27 ns |    16.178 ns |    15.133 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            | 51,425.46 ns |   362.678 ns |   339.249 ns |  7.10 |   26463 B |