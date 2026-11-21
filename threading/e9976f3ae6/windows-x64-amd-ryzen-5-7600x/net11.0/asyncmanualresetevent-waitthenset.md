| Description                                                    | Iterations | cancellationType | Mean         | Error      | StdDev       | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |-------------:|-----------:|-------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |     18.12 ns |   0.058 ns |     0.051 ns |  0.66 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |     24.55 ns |   0.129 ns |     0.120 ns |  0.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |     26.36 ns |   0.067 ns |     0.056 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |     26.60 ns |   0.026 ns |     0.022 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |     27.37 ns |   0.077 ns |     0.068 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |     27.46 ns |   0.113 ns |     0.100 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |     29.66 ns |   0.194 ns |     0.172 ns |  1.08 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |     42.13 ns |   0.159 ns |     0.149 ns |  1.54 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | None             |     51.35 ns |   0.098 ns |     0.087 ns |  1.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |    203.36 ns |   1.085 ns |     1.015 ns |  7.43 |     176 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |     44.91 ns |   0.191 ns |     0.170 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     45.84 ns |   0.090 ns |     0.079 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |     45.89 ns |   0.133 ns |     0.118 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     46.50 ns |   0.126 ns |     0.112 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |     50.12 ns |   0.195 ns |     0.182 ns |  1.09 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | NotCancelled     |     61.51 ns |   0.227 ns |     0.213 ns |  1.34 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     66.33 ns |   0.255 ns |     0.213 ns |  1.45 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |    231.53 ns |   0.648 ns |     0.606 ns |  5.05 |     176 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |    348.45 ns |   5.474 ns |     4.571 ns |  7.59 |     744 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |     67.44 ns |   0.380 ns |     0.355 ns |  1.00 |     152 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |     24.11 ns |   0.096 ns |     0.090 ns |  0.38 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |     38.81 ns |   0.194 ns |     0.182 ns |  0.61 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |     45.89 ns |   0.118 ns |     0.092 ns |  0.72 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |     63.81 ns |   0.520 ns |     0.486 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |     64.08 ns |   0.603 ns |     0.564 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |     64.31 ns |   0.324 ns |     0.303 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |     64.62 ns |   0.219 ns |     0.194 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | None             |     92.13 ns |   0.380 ns |     0.355 ns |  1.44 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |    100.61 ns |   0.464 ns |     0.434 ns |  1.57 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |    361.49 ns |   0.546 ns |     0.510 ns |  5.64 |     288 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |     96.41 ns |   0.173 ns |     0.144 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    102.73 ns |   0.435 ns |     0.386 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |    103.54 ns |   0.347 ns |     0.308 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |    105.05 ns |   0.437 ns |     0.409 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    106.47 ns |   0.484 ns |     0.429 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | NotCancelled     |    114.95 ns |   0.589 ns |     0.523 ns |  1.11 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    147.39 ns |   0.819 ns |     0.684 ns |  1.42 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |    403.56 ns |   0.758 ns |     0.672 ns |  3.90 |     288 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |    630.99 ns |   2.750 ns |     2.437 ns |  6.09 |    1416 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |    152.50 ns |   0.929 ns |     0.869 ns |  1.00 |     304 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |     59.39 ns |   0.187 ns |     0.175 ns |  0.17 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |    112.65 ns |   0.311 ns |     0.276 ns |  0.32 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |    221.81 ns |   0.391 ns |     0.327 ns |  0.64 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |    329.62 ns |   3.974 ns |     3.717 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |    342.78 ns |   1.826 ns |     1.525 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |    342.85 ns |   4.712 ns |     4.407 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |    348.78 ns |   2.309 ns |     2.160 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | None             |    388.93 ns |   1.076 ns |     1.006 ns |  1.12 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |    515.57 ns |   6.537 ns |     6.115 ns |  1.48 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |  1,392.01 ns |   4.278 ns |     4.002 ns |  3.99 |    1184 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |    452.06 ns |   1.258 ns |     1.115 ns |  0.78 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | NotCancelled     |    541.44 ns |   1.718 ns |     1.523 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    566.38 ns |   5.454 ns |     5.102 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |    572.03 ns |   6.229 ns |     5.827 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    575.42 ns |   6.201 ns |     5.800 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |    582.21 ns |   6.883 ns |     6.438 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    771.59 ns |  10.742 ns |    10.048 ns |  1.33 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |  1,714.85 ns |  19.804 ns |    18.525 ns |  2.95 |    1184 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |  2,335.21 ns |  45.159 ns |    40.033 ns |  4.01 |    6328 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |    815.76 ns |  11.739 ns |    10.981 ns |  1.00 |    1520 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |    474.24 ns |   3.225 ns |     3.017 ns |  0.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |    906.08 ns |   1.866 ns |     1.654 ns |  0.25 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |  2,214.35 ns |   6.193 ns |     5.793 ns |  0.61 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |  3,340.35 ns |  61.460 ns |    57.490 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |  3,357.84 ns |  65.774 ns |    61.525 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |  3,499.49 ns |  56.468 ns |    52.820 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |  3,649.74 ns |  25.938 ns |    24.263 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | None             |  3,764.93 ns |  18.123 ns |    14.149 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |  5,242.10 ns |  82.790 ns |    77.442 ns |  1.44 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             | 13,454.38 ns | 155.866 ns |   130.155 ns |  3.69 |   11264 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |  4,552.96 ns |  22.184 ns |    20.751 ns |  0.79 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | NotCancelled     |  5,376.42 ns |  46.922 ns |    43.891 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |  5,750.50 ns |  83.652 ns |    78.248 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  5,769.59 ns |  90.578 ns |    84.726 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  5,864.08 ns |  60.506 ns |    56.598 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |  5,899.64 ns |  81.977 ns |    76.681 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  7,786.33 ns | 129.976 ns |   121.579 ns |  1.35 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 20,078.07 ns | 401.117 ns | 1,098.052 ns |  3.49 |   11264 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 32,182.52 ns | 957.712 ns | 2,808.805 ns |  5.60 |   60752 B | 
|                                                                |            |                  |              |            |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            |  8,150.00 ns |  72.408 ns |    64.188 ns |  1.00 |   15200 B |