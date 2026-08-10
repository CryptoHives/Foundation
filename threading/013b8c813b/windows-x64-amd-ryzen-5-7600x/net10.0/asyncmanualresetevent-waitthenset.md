| Description                                                    | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |      21.31 ns |  0.73 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |      26.05 ns |  0.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |      26.90 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |      27.19 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |      28.86 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |      29.00 ns |  1.00 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |      29.01 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |      41.05 ns |  1.42 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |     439.28 ns | 15.14 |     231 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |      43.70 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      44.63 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |      45.36 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      45.72 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |      47.92 ns |  1.06 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      63.31 ns |  1.40 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |     487.66 ns | 10.75 |     232 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |     619.69 ns | 13.66 |     808 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |      24.12 ns |  0.37 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |      38.01 ns |  0.58 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |      45.85 ns |  0.70 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |      59.82 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |      60.29 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |      65.21 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |      65.37 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |      91.73 ns |  1.40 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |     769.23 ns | 11.77 |     344 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |      89.35 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      93.97 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |      99.86 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |     101.01 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |     101.79 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     140.33 ns |  1.38 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |     900.51 ns |  8.85 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |   1,075.26 ns | 10.56 |    1488 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |      65.32 ns |  0.18 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |     111.64 ns |  0.31 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |     213.75 ns |  0.60 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |     319.12 ns |  0.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |     322.67 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |     351.34 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |     354.82 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |     486.56 ns |  1.37 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |   2,053.86 ns |  5.79 |    1239 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |     426.86 ns |  0.81 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     518.51 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |     527.70 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |     531.19 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     552.29 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     725.76 ns |  1.38 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |   2,835.69 ns |  5.37 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |   3,459.05 ns |  6.56 |    6464 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |     545.01 ns |  0.16 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |     929.35 ns |  0.27 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |   2,117.15 ns |  0.62 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |   3,064.17 ns |  0.89 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |   3,078.54 ns |  0.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |   3,435.63 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |   3,459.37 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,804.34 ns |  1.40 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             |  15,421.83 ns |  4.49 |   11320 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |   4,210.12 ns |  0.81 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   5,195.50 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |   5,212.95 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   5,218.04 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |   5,247.35 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   7,302.66 ns |  1.40 |    8000 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 128,084.00 ns | 24.57 |   61615 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 309,059.35 ns | 59.29 |   11326 B |