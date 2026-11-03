| Description                                                    | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| WaitThenSet · AsyncManualReset · RefImpl                       | 1          | None             |     20.71 ns |  0.64 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | None             |     29.91 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | None             |     30.38 ns |  0.93 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | None             |     32.58 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | None             |     32.86 ns |  1.01 |      96 B | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | None             |     33.17 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | None             |     41.43 ns |  1.27 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | None             |     46.95 ns |  1.44 |      80 B | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | None             |     55.13 ns |  1.69 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | None             |    512.55 ns | 15.73 |     230 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     49.12 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | NotCancelled     |     49.63 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     50.69 ns |  1.02 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 1          | NotCancelled     |     52.53 ns |  1.06 |         - | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 1          | NotCancelled     |     58.70 ns |  1.18 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 1          | NotCancelled     |     69.62 ns |  1.40 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     69.67 ns |  1.40 |      80 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 1          | NotCancelled     |    551.41 ns | 11.11 |     231 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 1          | NotCancelled     |    675.95 ns | 13.62 |     808 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 1          | Timed            |     80.06 ns |  1.00 |     152 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 2          | None             |     26.45 ns |  0.37 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | None             |     42.74 ns |  0.59 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | None             |     50.24 ns |  0.69 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | None             |     64.68 ns |  0.89 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | None             |     66.36 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | None             |     72.32 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | None             |     72.34 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | None             |     97.48 ns |  1.35 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | None             |    109.96 ns |  1.52 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | None             |    799.96 ns | 11.06 |     344 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 2          | NotCancelled     |    100.01 ns |  0.89 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 2          | NotCancelled     |    108.12 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    110.64 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | NotCancelled     |    111.86 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    115.41 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 2          | NotCancelled     |    130.66 ns |  1.17 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    158.35 ns |  1.42 |     160 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 2          | NotCancelled     |    925.94 ns |  8.28 |     344 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 2          | NotCancelled     |  1,112.83 ns |  9.95 |    1488 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 2          | Timed            |    175.17 ns |  1.00 |     304 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 10         | None             |     73.33 ns |  0.19 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | None             |    127.07 ns |  0.33 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | None             |    237.07 ns |  0.61 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | None             |    362.75 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | None             |    362.81 ns |  0.94 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | None             |    387.16 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | None             |    387.83 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | None             |    422.05 ns |  1.09 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | None             |    541.60 ns |  1.40 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | None             |  2,243.07 ns |  5.78 |    1240 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 10         | NotCancelled     |    480.31 ns |  0.83 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 10         | NotCancelled     |    568.42 ns |  0.98 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | NotCancelled     |    582.02 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    586.85 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    600.06 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 10         | NotCancelled     |    602.14 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    815.69 ns |  1.40 |     800 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 10         | NotCancelled     |  2,604.11 ns |  4.48 |    1240 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 10         | NotCancelled     |  3,086.18 ns |  5.30 |    6464 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 10         | Timed            |    903.71 ns |  1.00 |    1520 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · RefImpl                       | 100        | None             |    650.06 ns |  0.17 |      96 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | None             |  1,110.18 ns |  0.30 |      96 B | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | None             |  2,397.14 ns |  0.64 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | None             |  3,440.48 ns |  0.92 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | None             |  3,639.69 ns |  0.97 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | None             |  3,756.74 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | None             |  3,787.39 ns |  1.01 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | None             |  4,131.27 ns |  1.10 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | None             |  5,785.26 ns |  1.54 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | None             | 16,386.68 ns |  4.36 |   11320 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · ProtoPromise                  | 100        | NotCancelled     |  4,897.03 ns |  0.83 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (SyncCont)             | 100        | NotCancelled     |  5,803.83 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  5,811.71 ns |  0.99 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  5,877.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | NotCancelled     |  5,890.67 ns |  1.00 |         - | 
| WaitThenSet · AsyncManualReset · DotNext                       | 100        | NotCancelled     |  6,058.85 ns |  1.03 |         - | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  8,041.29 ns |  1.37 |    8000 B | 
| WaitThenSet · AsyncManualReset · Pooled (AsTask)               | 100        | NotCancelled     | 20,794.68 ns |  3.53 |   11320 B | 
| WaitThenSet · AsyncManualReset · Nito.AsyncEx                  | 100        | NotCancelled     | 23,683.59 ns |  4.02 |   61609 B | 
|                                                                |            |                  |              |       |           | 
| WaitThenSet · AsyncManualReset · Pooled (ValueTask)            | 100        | Timed            |  9,648.56 ns |  1.00 |   15200 B |