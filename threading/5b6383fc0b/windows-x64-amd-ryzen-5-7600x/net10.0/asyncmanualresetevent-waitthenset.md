| Description                                                    | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |      21.77 ns |  0.85 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |      23.40 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |      24.13 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |      25.07 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |      25.56 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |      26.57 ns |  1.04 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |      28.83 ns |  1.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |      36.29 ns |  1.42 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |     442.78 ns | 17.33 |     231 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      38.68 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      40.45 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |      40.63 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |      41.05 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |      49.45 ns |  1.21 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      60.87 ns |  1.48 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |     492.64 ns | 12.01 |     232 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |     650.27 ns | 15.85 |     808 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |      26.16 ns |  0.46 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |      39.16 ns |  0.69 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |      46.20 ns |  0.81 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |      51.22 ns |  0.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |      53.31 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |      54.87 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |      57.20 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |      82.64 ns |  1.45 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |     714.79 ns | 12.50 |     343 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |      89.91 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      91.04 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |      91.89 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |      93.81 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      95.38 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     129.08 ns |  1.38 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |     803.51 ns |  8.57 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |   1,185.20 ns | 12.64 |    1488 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |      64.93 ns |  0.20 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |     110.41 ns |  0.34 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |     214.27 ns |  0.66 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |     298.82 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |     300.43 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |     324.51 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |     325.91 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |     453.70 ns |  1.40 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |   1,971.93 ns |  6.08 |    1239 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |     454.68 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     482.97 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |     497.87 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |     515.24 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     531.65 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     737.97 ns |  1.43 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |   3,031.89 ns |  5.88 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |   4,436.31 ns |  8.61 |    6464 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |     533.53 ns |  0.15 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |     928.28 ns |  0.27 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |   2,275.95 ns |  0.65 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,857.04 ns |  0.82 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |   2,901.30 ns |  0.83 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |   3,161.49 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |   3,482.75 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,674.61 ns |  1.34 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             |  15,704.57 ns |  4.51 |   11320 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |   4,415.36 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   4,908.97 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |   4,971.60 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   4,996.67 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |   5,026.19 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   7,174.00 ns |  1.43 |    8000 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 115,582.83 ns | 23.00 |   61617 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 263,666.83 ns | 52.46 |   11327 B |