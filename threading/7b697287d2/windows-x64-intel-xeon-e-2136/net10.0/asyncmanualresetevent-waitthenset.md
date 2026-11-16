| Description                                                    | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |     65.79 ns |  0.69 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |     83.70 ns |  0.87 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |     90.08 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |     90.25 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |     95.41 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |     95.67 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |    108.27 ns |  1.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |    125.12 ns |  1.31 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | None             |    177.01 ns |  1.85 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |  1,000.29 ns | 10.46 |     232 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |    132.90 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |    134.76 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |    141.39 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |    142.76 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |    151.91 ns |  1.07 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |    173.16 ns |  1.22 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | NotCancelled     |    219.85 ns |  1.55 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |  1,107.76 ns |  7.83 |     232 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |  1,379.36 ns |  9.76 |     808 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |    216.43 ns |  1.00 |     152 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |     75.94 ns |  0.41 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |    136.04 ns |  0.73 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |    147.14 ns |  0.79 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |    182.35 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |    182.94 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |    187.20 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |    188.85 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |    265.01 ns |  1.42 |     160 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | None             |    313.34 ns |  1.67 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |  1,514.25 ns |  8.09 |     344 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    270.51 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    272.26 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |    278.65 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |    279.27 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |    280.11 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    360.47 ns |  1.29 |     160 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | NotCancelled     |    388.49 ns |  1.39 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |  1,717.34 ns |  6.13 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |  2,201.59 ns |  7.86 |    1488 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |    432.51 ns |  1.00 |     304 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |    178.27 ns |  0.17 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |    390.04 ns |  0.37 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |    657.82 ns |  0.63 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |  1,017.96 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |  1,028.75 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |  1,042.58 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |  1,044.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | None             |  1,344.46 ns |  1.29 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |  1,432.39 ns |  1.37 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |  4,498.63 ns |  4.31 |    1240 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |  1,350.20 ns |  0.88 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |  1,484.22 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |  1,499.89 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |  1,527.27 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |  1,537.63 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | NotCancelled     |  1,780.79 ns |  1.17 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |  1,888.12 ns |  1.24 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |  5,858.11 ns |  3.84 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |  7,960.17 ns |  5.21 |    6464 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |  2,336.53 ns |  1.00 |    1520 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |  1,372.47 ns |  0.13 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |  3,276.37 ns |  0.30 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |  6,437.62 ns |  0.60 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             | 10,242.40 ns |  0.95 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             | 10,282.78 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             | 10,744.26 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             | 10,756.67 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | None             | 13,018.95 ns |  1.21 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             | 14,776.87 ns |  1.38 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             | 30,454.83 ns |  2.83 |   11320 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     | 13,328.14 ns |  0.86 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     | 14,790.27 ns |  0.96 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     | 14,999.21 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     | 15,370.21 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     | 15,444.34 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | NotCancelled     | 17,771.49 ns |  1.15 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     | 19,409.11 ns |  1.26 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 40,439.56 ns |  2.62 |   11320 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 54,950.15 ns |  3.56 |   61611 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            | 23,368.69 ns |  1.00 |   15200 B |