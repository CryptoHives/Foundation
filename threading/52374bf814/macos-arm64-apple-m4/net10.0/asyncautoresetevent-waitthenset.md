| Description                                                  | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |      17.96 ns |  0.84 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |      18.43 ns |  0.86 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |      18.49 ns |  0.86 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |      21.41 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |      21.58 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |      24.44 ns |  1.14 |      96 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |      29.64 ns |  1.38 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |      31.51 ns |  1.47 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |   1,230.34 ns | 57.47 |     229 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      29.64 ns |  0.88 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      29.84 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |      30.59 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |      32.65 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |      33.57 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      41.08 ns |  1.22 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |     628.48 ns | 18.72 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |   1,369.58 ns | 40.80 |     232 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |      34.51 ns |  0.71 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |      43.38 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |      45.39 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |      47.53 ns |  0.97 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |      48.84 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |      49.37 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |      60.79 ns |  1.24 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |      72.14 ns |  1.48 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |   1,814.28 ns | 37.15 |     342 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |      61.65 ns |  0.86 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      67.33 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      68.59 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |      71.95 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |      72.46 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |      94.77 ns |  1.32 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |   1,071.33 ns | 14.89 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |   1,935.44 ns | 26.90 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |     165.84 ns |  0.64 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |     230.77 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |     235.56 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |     237.92 ns |  0.92 |     960 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |     258.24 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |     265.52 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |     298.09 ns |  1.15 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |     364.88 ns |  1.41 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |   5,112.86 ns | 19.80 |    1239 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |     313.55 ns |  0.82 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     348.47 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     355.19 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |     376.28 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |     381.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     475.57 ns |  1.25 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |   5,104.58 ns | 13.39 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |   6,877.33 ns | 18.04 |    1240 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |   1,606.21 ns |  0.64 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |   2,147.13 ns |  0.86 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |   2,157.25 ns |  0.86 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,184.42 ns |  0.87 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |   2,501.68 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |   2,519.45 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |   2,873.12 ns |  1.15 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |   3,552.41 ns |  1.42 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             |  33,795.11 ns | 13.51 |   11319 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |   3,062.41 ns |  0.83 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   3,339.76 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   3,360.55 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |   3,679.41 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |   3,722.32 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   4,558.07 ns |  1.24 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     |  61,744.88 ns | 16.78 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 112,610.58 ns | 30.61 |   11326 B |