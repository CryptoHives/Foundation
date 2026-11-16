| Description                                                  | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |     80.85 ns |  0.82 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |     93.80 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |     95.11 ns |  0.96 |      96 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |     95.45 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |     99.20 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |     99.41 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |    105.48 ns |  1.06 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |    132.19 ns |  1.33 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | None             |    161.90 ns |  1.63 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |  1,015.25 ns | 10.23 |     232 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |    141.11 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |    143.90 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |    143.99 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |    145.46 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |    145.78 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |    181.49 ns |  1.25 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | NotCancelled     |    201.78 ns |  1.39 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |    607.66 ns |  4.18 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |  1,091.74 ns |  7.51 |     232 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |    217.07 ns |  0.96 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |    225.13 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |  1,326.36 ns |  5.89 |     384 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |    156.70 ns |  0.72 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |    189.55 ns |  0.88 |     192 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |    203.67 ns |  0.94 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |    207.66 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |    209.62 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |    213.03 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |    216.38 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |    291.66 ns |  1.35 |     160 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | None             |    320.46 ns |  1.48 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |  1,447.57 ns |  6.69 |     344 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |    285.34 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    300.20 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    303.27 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |    304.35 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |    308.86 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    392.13 ns |  1.27 |     160 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | NotCancelled     |    401.95 ns |  1.30 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |  1,118.17 ns |  3.62 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |  1,754.94 ns |  5.68 |     344 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |    450.90 ns |  0.97 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |    463.86 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |  2,051.12 ns |  4.42 |     648 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |    759.84 ns |  0.60 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |    902.06 ns |  0.72 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |  1,014.81 ns |  0.80 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |  1,182.97 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |  1,195.42 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |  1,240.92 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |  1,260.82 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | None             |  1,569.49 ns |  1.24 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |  1,671.68 ns |  1.33 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |  4,494.35 ns |  3.56 |    1240 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |  1,411.81 ns |  0.79 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |  1,659.77 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |  1,675.26 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |  1,768.70 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |  1,786.66 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | NotCancelled     |  1,994.12 ns |  1.12 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |  2,087.54 ns |  1.17 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |  5,188.33 ns |  2.90 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |  5,432.45 ns |  3.04 |    1240 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |  2,467.96 ns |  0.98 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |  2,526.42 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |  7,420.99 ns |  2.94 |    2760 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |  7,632.18 ns |  0.60 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |  8,733.19 ns |  0.69 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             | 10,190.44 ns |  0.80 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             | 12,134.63 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             | 12,301.94 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             | 12,663.06 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             | 12,743.27 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | None             | 15,665.73 ns |  1.23 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             | 16,481.61 ns |  1.29 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             | 31,849.71 ns |  2.50 |   11319 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     | 14,078.21 ns |  0.79 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     | 16,703.03 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     | 17,144.47 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     | 17,530.56 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     | 17,809.14 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | NotCancelled     | 20,339.24 ns |  1.14 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     | 21,441.58 ns |  1.20 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     | 39,470.63 ns |  2.22 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 43,606.71 ns |  2.45 |   11320 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            | 24,561.71 ns |  0.97 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            | 25,276.15 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            | 51,367.50 ns |  2.03 |   26523 B |