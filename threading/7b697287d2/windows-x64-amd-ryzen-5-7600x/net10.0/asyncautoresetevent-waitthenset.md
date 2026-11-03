| Description                                                  | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |     26.60 ns |  0.85 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |     28.63 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |     29.26 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |     31.26 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |     31.71 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |     31.81 ns |  1.02 |      96 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |     39.60 ns |  1.27 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |     45.01 ns |  1.44 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | None             |     55.47 ns |  1.77 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |    497.99 ns | 15.93 |     230 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |     49.07 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     49.10 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |     49.31 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     50.79 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |     50.98 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | NotCancelled     |     67.87 ns |  1.38 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     68.05 ns |  1.38 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |    256.45 ns |  5.20 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |    522.86 ns | 10.60 |     232 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |     76.16 ns |  0.97 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |     78.24 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |    686.94 ns |  8.78 |     384 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |     51.14 ns |  0.70 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |     63.00 ns |  0.87 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |     72.62 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |     72.80 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |     74.33 ns |  1.02 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |     84.42 ns |  1.16 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | None             |    101.87 ns |  1.40 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |    103.32 ns |  1.42 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |    107.82 ns |  1.48 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |    822.84 ns | 11.30 |     343 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |    101.83 ns |  0.90 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |    112.68 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    116.45 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |    116.63 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    118.13 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | NotCancelled     |    131.49 ns |  1.17 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    157.38 ns |  1.40 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |    533.31 ns |  4.73 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |    905.61 ns |  8.04 |     344 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |    178.45 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |    180.00 ns |  1.01 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |  1,051.62 ns |  5.89 |     648 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |    257.74 ns |  0.62 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |    307.72 ns |  0.74 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |    357.45 ns |  0.86 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |    385.01 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |    387.40 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |    411.77 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |    414.96 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | None             |    495.49 ns |  1.19 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |    572.50 ns |  1.38 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |  2,249.01 ns |  5.42 |    1240 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |    494.74 ns |  0.81 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    603.17 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |    611.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |    619.92 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    623.99 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | NotCancelled     |    673.15 ns |  1.10 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    832.47 ns |  1.36 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |  2,313.02 ns |  3.78 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |  2,655.40 ns |  4.34 |    1240 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |    893.13 ns |  0.98 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |    909.70 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |  2,969.49 ns |  3.26 |    2760 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |  2,570.42 ns |  0.65 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |  3,157.58 ns |  0.80 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |  3,570.85 ns |  0.90 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |  3,625.90 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |  3,646.90 ns |  0.92 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |  3,963.53 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |  4,035.07 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | None             |  4,888.32 ns |  1.23 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |  5,733.61 ns |  1.45 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             | 15,968.91 ns |  4.03 |   11320 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |  5,366.24 ns |  0.90 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  5,924.26 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |  5,982.66 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |  6,003.29 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  6,034.59 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | NotCancelled     |  6,964.85 ns |  1.16 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  8,229.25 ns |  1.38 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     | 18,617.52 ns |  3.11 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 20,679.88 ns |  3.46 |   11320 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            |  8,840.80 ns |  0.97 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            |  9,125.99 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            | 23,606.71 ns |  2.59 |   26521 B |