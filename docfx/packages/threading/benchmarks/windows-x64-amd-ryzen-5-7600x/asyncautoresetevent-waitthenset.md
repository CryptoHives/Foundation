| Description                                                  | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |      24.17 ns |  0.81 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |      27.27 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |      27.61 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |      28.90 ns |  0.97 |      96 B | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |      29.28 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |      29.85 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |      36.58 ns |  1.23 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |      43.00 ns |  1.44 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |     441.04 ns | 14.78 |     231 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |      44.86 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |      46.20 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      46.32 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |      46.65 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      47.24 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      63.05 ns |  1.37 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |     313.43 ns |  6.79 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |     500.38 ns | 10.83 |     232 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |      46.65 ns |  0.66 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |      55.07 ns |  0.78 |     192 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |      64.45 ns |  0.91 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |      68.72 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |      70.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |      70.59 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |      76.05 ns |  1.08 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |      99.86 ns |  1.42 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |     753.15 ns | 10.67 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |      91.80 ns |  0.86 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |     104.89 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |     106.07 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |     107.21 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |     107.21 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     142.84 ns |  1.33 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |     567.88 ns |  5.30 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |     852.46 ns |  7.95 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |     239.97 ns |  0.65 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |     283.01 ns |  0.77 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |     328.30 ns |  0.90 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |     352.58 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |     354.08 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |     366.70 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |     378.39 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |     507.61 ns |  1.38 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |   2,067.19 ns |  5.64 |    1238 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |     452.59 ns |  0.78 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     551.19 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |     559.53 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     568.73 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |     580.97 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     746.11 ns |  1.28 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |   2,658.94 ns |  4.58 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |   2,849.32 ns |  4.91 |    1239 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |   2,336.03 ns |  0.65 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |   2,797.16 ns |  0.78 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |   3,268.45 ns |  0.91 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |   3,287.09 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |   3,313.43 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |   3,585.64 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |   3,730.78 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,913.21 ns |  1.37 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             |  16,379.01 ns |  4.57 |   11320 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |   4,450.66 ns |  0.82 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   5,333.77 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |   5,434.85 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   5,502.45 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |   5,624.81 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   7,367.23 ns |  1.36 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     |  25,614.65 ns |  4.71 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 230,927.40 ns | 42.50 |   11324 B |