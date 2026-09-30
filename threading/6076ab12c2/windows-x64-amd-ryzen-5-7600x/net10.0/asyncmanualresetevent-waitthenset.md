| Description                                                    | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |     20.70 ns |  0.61 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |     28.77 ns |  0.85 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |     29.99 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |     31.31 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |     32.40 ns |  0.96 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |     33.75 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |     33.93 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |     47.35 ns |  1.40 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | None             |     58.55 ns |  1.73 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |    481.40 ns | 14.19 |     230 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |     47.91 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |     48.56 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     49.02 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     50.20 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |     52.89 ns |  1.10 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | NotCancelled     |     70.09 ns |  1.46 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     72.48 ns |  1.51 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |    563.73 ns | 11.77 |     231 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |    674.40 ns | 14.08 |     808 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |     80.01 ns |  1.00 |     152 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |     26.41 ns |  0.36 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |     42.51 ns |  0.58 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |     51.12 ns |  0.69 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |     65.22 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |     68.15 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |     71.41 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |     73.87 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | None             |     96.76 ns |  1.31 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |    112.00 ns |  1.52 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |    746.75 ns | 10.11 |     343 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |     99.81 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |    110.71 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |    112.94 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    113.76 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    114.82 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | NotCancelled     |    128.31 ns |  1.14 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    165.55 ns |  1.47 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |    939.89 ns |  8.32 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |  1,165.51 ns | 10.32 |    1488 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |    177.28 ns |  1.00 |     304 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |     71.09 ns |  0.18 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |    123.95 ns |  0.32 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |    246.30 ns |  0.63 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |    377.08 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |    379.84 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |    388.24 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |    392.65 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | None             |    429.83 ns |  1.11 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |    543.92 ns |  1.40 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |  2,216.20 ns |  5.71 |    1240 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |    479.94 ns |  0.82 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |    582.04 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    592.20 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    599.19 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | NotCancelled     |    612.33 ns |  1.05 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |    627.13 ns |  1.08 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    804.46 ns |  1.38 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |  2,598.44 ns |  4.46 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |  3,058.66 ns |  5.26 |    6464 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |    893.97 ns |  1.00 |    1520 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |    588.79 ns |  0.15 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |  1,045.15 ns |  0.27 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |  2,422.12 ns |  0.63 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |  3,483.61 ns |  0.91 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |  3,594.75 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |  3,817.48 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |  3,843.76 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | None             |  4,226.61 ns |  1.10 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |  5,259.64 ns |  1.37 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             | 16,287.51 ns |  4.24 |   11320 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |  4,744.69 ns |  0.82 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |  5,817.63 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  5,903.37 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  5,935.90 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |  5,967.15 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | NotCancelled     |  6,049.49 ns |  1.04 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  8,083.64 ns |  1.39 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 20,970.05 ns |  3.61 |   11320 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 27,454.34 ns |  4.72 |   61610 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            |  8,965.68 ns |  1.00 |   15200 B |