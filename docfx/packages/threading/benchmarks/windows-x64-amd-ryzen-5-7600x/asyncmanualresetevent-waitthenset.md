| Description                                                    | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |      23.46 ns |  0.79 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |      26.79 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |      27.53 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |      27.97 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |      29.44 ns |  1.00 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |      29.52 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |      29.59 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |      40.22 ns |  1.36 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |     437.30 ns | 14.82 |     231 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      44.48 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |      45.70 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      45.87 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |      47.79 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |      53.77 ns |  1.18 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      67.39 ns |  1.47 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |     494.77 ns | 10.83 |     232 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |     631.42 ns | 13.82 |     808 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |      25.55 ns |  0.41 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |      39.19 ns |  0.62 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |      46.55 ns |  0.74 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |      58.58 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |      61.71 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |      61.96 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |      63.07 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |      89.99 ns |  1.43 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |     764.31 ns | 12.12 |     344 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |      92.17 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      99.76 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |     104.11 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |     104.40 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |     104.94 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     143.63 ns |  1.38 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |     849.96 ns |  8.14 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |   1,160.93 ns | 11.12 |    1488 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |      65.82 ns |  0.18 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |     114.63 ns |  0.32 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |     214.54 ns |  0.59 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |     335.07 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |     338.17 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |     361.04 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |     365.16 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |     485.45 ns |  1.34 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |   2,009.15 ns |  5.57 |    1240 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |     454.35 ns |  0.79 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     544.59 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     546.99 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |     550.41 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |     577.96 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     750.59 ns |  1.30 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |   2,948.93 ns |  5.10 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |   3,688.51 ns |  6.38 |    6464 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |     542.63 ns |  0.15 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |   1,007.36 ns |  0.29 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |   2,157.24 ns |  0.62 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |   3,178.58 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |   3,245.66 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |   3,508.22 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |   3,581.30 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,770.05 ns |  1.36 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             |  16,012.14 ns |  4.56 |   11320 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |   4,287.30 ns |  0.74 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   5,275.63 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   5,290.28 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |   5,426.20 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |   5,761.93 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   7,496.86 ns |  1.30 |    8000 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 120,832.80 ns | 20.97 |   61621 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 268,306.83 ns | 46.57 |   11323 B |