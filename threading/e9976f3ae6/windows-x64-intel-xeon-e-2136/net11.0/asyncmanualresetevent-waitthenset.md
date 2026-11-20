| Description                                                    | Iterations | cancellationType | Mean         | Error        | StdDev        | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |-------------:|-------------:|--------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |     63.14 ns |     0.260 ns |      0.495 ns |  0.69 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |     80.59 ns |     0.202 ns |      0.369 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |     89.48 ns |     0.062 ns |      0.111 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |     90.55 ns |     0.569 ns |      1.069 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |     90.72 ns |     0.122 ns |      0.230 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |     91.15 ns |     0.773 ns |      1.452 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |    104.13 ns |     0.596 ns |      1.090 ns |  1.14 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |    135.60 ns |     2.615 ns |      4.976 ns |  1.49 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | None             |    172.72 ns |     0.134 ns |      0.249 ns |  1.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |    456.33 ns |     3.050 ns |      5.577 ns |  5.01 |     176 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |    129.80 ns |     0.525 ns |      0.973 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |    130.06 ns |     0.121 ns |      0.227 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |    132.03 ns |     0.246 ns |      0.461 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |    133.88 ns |     2.075 ns |      3.794 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |    148.54 ns |     0.380 ns |      0.704 ns |  1.13 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |    175.58 ns |     0.717 ns |      1.365 ns |  1.33 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | NotCancelled     |    205.61 ns |     0.273 ns |      0.513 ns |  1.56 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |    510.68 ns |     5.275 ns |      9.907 ns |  3.87 |     176 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |    724.77 ns |     3.694 ns |      6.754 ns |  5.49 |     744 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |    195.27 ns |     0.492 ns |      0.924 ns |  1.00 |     152 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |     70.39 ns |     0.058 ns |      0.103 ns |  0.39 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |    128.64 ns |     0.099 ns |      0.189 ns |  0.72 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |    142.62 ns |     0.924 ns |      1.713 ns |  0.80 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |    179.25 ns |     0.401 ns |      0.712 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |    180.01 ns |     0.199 ns |      0.373 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |    180.15 ns |     1.063 ns |      1.944 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |    180.81 ns |     0.558 ns |      1.034 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |    277.89 ns |     1.004 ns |      1.810 ns |  1.55 |     160 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | None             |    295.58 ns |     0.616 ns |      1.111 ns |  1.65 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |    728.21 ns |     2.240 ns |      4.207 ns |  4.06 |     288 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    266.39 ns |     0.220 ns |      0.402 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    268.59 ns |     1.048 ns |      1.968 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |    270.66 ns |     1.735 ns |      3.260 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |    272.03 ns |     0.588 ns |      1.104 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |    279.33 ns |     2.073 ns |      3.893 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | NotCancelled     |    363.61 ns |     0.284 ns |      0.512 ns |  1.34 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    369.87 ns |     1.254 ns |      2.292 ns |  1.37 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |    856.06 ns |     3.572 ns |      6.441 ns |  3.16 |     288 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |  1,290.22 ns |    12.309 ns |     23.119 ns |  4.77 |    1416 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |    398.98 ns |     3.706 ns |      7.051 ns |  1.00 |     304 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |    150.33 ns |     4.388 ns |      8.348 ns |  0.15 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |    345.56 ns |     7.583 ns |     13.865 ns |  0.34 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |    648.46 ns |     7.923 ns |     14.488 ns |  0.63 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |  1,010.05 ns |     2.117 ns |      3.817 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |  1,014.47 ns |     2.795 ns |      5.040 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |  1,022.41 ns |     5.123 ns |      9.747 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |  1,030.87 ns |     2.131 ns |      3.951 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | None             |  1,287.77 ns |     1.561 ns |      2.970 ns |  1.26 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |  1,475.14 ns |     6.199 ns |     11.490 ns |  1.44 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |  3,378.04 ns |    36.490 ns |     67.637 ns |  3.30 |    1184 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |  1,333.54 ns |     2.514 ns |      4.597 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |  1,449.07 ns |     2.277 ns |      4.106 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |  1,458.39 ns |     4.219 ns |      7.925 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |  1,458.78 ns |     4.510 ns |      8.247 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |  1,473.32 ns |     3.701 ns |      6.673 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | NotCancelled     |  1,648.12 ns |     1.695 ns |      3.224 ns |  1.12 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |  1,980.68 ns |    20.615 ns |     38.211 ns |  1.34 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |  4,177.45 ns |    59.629 ns |    170.126 ns |  2.84 |    1184 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |  5,550.75 ns |    61.620 ns |    129.977 ns |  3.77 |    6328 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |  2,152.43 ns |    14.734 ns |     27.673 ns |  1.00 |    1520 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |  1,333.84 ns |   108.428 ns |    192.731 ns |  0.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |  2,678.01 ns |     0.811 ns |      1.543 ns |  0.25 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |  6,370.24 ns |    49.508 ns |     94.194 ns |  0.61 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             | 10,290.76 ns |    23.582 ns |     43.710 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             | 10,353.56 ns |    56.203 ns |    106.932 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             | 10,506.15 ns |    19.304 ns |     36.728 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             | 10,510.71 ns |    28.938 ns |     55.058 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | None             | 12,454.49 ns |     5.200 ns |      9.894 ns |  1.18 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             | 15,349.34 ns |    62.215 ns |    118.370 ns |  1.46 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             | 33,976.72 ns |   161.776 ns |    307.795 ns |  3.23 |   11264 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     | 13,178.19 ns |    44.268 ns |     83.145 ns |  0.87 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     | 14,630.22 ns |    21.321 ns |     40.046 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     | 14,646.74 ns |    24.041 ns |     43.352 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     | 14,797.19 ns |    68.116 ns |    127.938 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     | 15,068.65 ns |   171.579 ns |    334.652 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | NotCancelled     | 16,311.95 ns |    20.119 ns |     37.788 ns |  1.08 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     | 19,956.30 ns |    97.381 ns |    182.906 ns |  1.32 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 49,373.36 ns |   676.206 ns |  3,469.873 ns |  3.28 |   11264 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 87,381.45 ns | 3,214.471 ns | 16,695.940 ns |  5.80 |   60752 B | 
|                                                                |            |                  |              |              |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            | 21,776.20 ns |   137.137 ns |    254.193 ns |  1.00 |   15200 B |