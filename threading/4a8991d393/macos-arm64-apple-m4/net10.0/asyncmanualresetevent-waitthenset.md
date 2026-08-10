| Description                                                    | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |      15.83 ns |  0.69 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |      18.04 ns |  0.79 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |      20.63 ns |  0.90 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |      22.16 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |      22.83 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |      22.83 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |      25.79 ns |  1.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |      31.70 ns |  1.39 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |   1,207.35 ns | 52.88 |     230 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      30.83 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      31.48 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |      31.63 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |      33.07 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |      33.49 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      43.13 ns |  1.30 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |   1,383.32 ns | 41.83 |     232 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |   1,430.14 ns | 43.25 |     808 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |      63.07 ns |  1.00 |     152 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |      19.48 ns |  0.37 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |      33.50 ns |  0.63 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |      33.60 ns |  0.63 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |      53.26 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |      54.45 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |      55.95 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |      57.61 ns |  1.08 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |      71.83 ns |  1.35 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |   1,791.09 ns | 33.63 |     342 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |      62.37 ns |  0.87 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      68.94 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      69.24 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |      72.02 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |      72.08 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |      96.90 ns |  1.35 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |   1,991.30 ns | 27.65 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |   2,359.60 ns | 32.76 |    1488 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |     151.82 ns |  1.00 |     304 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |      66.16 ns |  0.24 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |     100.77 ns |  0.36 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |     156.36 ns |  0.56 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |     263.38 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |     265.10 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |     281.09 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |     285.44 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |     374.09 ns |  1.33 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |   5,306.25 ns | 18.88 |    1240 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |     302.84 ns |  0.77 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     363.41 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     370.16 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |     392.26 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |     393.41 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     492.80 ns |  1.25 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |   7,141.63 ns | 18.15 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |   7,235.63 ns | 18.39 |    6464 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |     703.32 ns |  1.00 |    1520 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |     463.65 ns |  0.18 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |     824.93 ns |  0.32 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |   1,491.10 ns |  0.58 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,367.28 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |   2,469.75 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |   2,563.50 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |   2,660.15 ns |  1.04 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |   3,489.11 ns |  1.36 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             |  31,408.30 ns | 12.25 |   11321 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |   2,911.63 ns |  0.77 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   3,426.07 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   3,497.45 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |   3,772.40 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |   3,784.26 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   4,682.60 ns |  1.24 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 162,965.51 ns | 43.20 |   11327 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 200,731.76 ns | 53.21 |   61620 B | 
|                                                                |            |                  |               |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            |   6,833.67 ns |  1.00 |   15200 B |