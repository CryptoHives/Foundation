| Description                                                  | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |     26.65 ns |  0.82 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |     29.52 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |     30.04 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |     32.57 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |     32.81 ns |  1.01 |      96 B | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |     33.93 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |     39.58 ns |  1.22 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |     45.97 ns |  1.41 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | None             |     54.97 ns |  1.69 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |    478.98 ns | 14.71 |     230 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |     48.36 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |     48.91 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |     51.15 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |     51.28 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |     51.43 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |     69.06 ns |  1.41 |      80 B | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 1          | NotCancelled     |     72.92 ns |  1.49 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |    282.90 ns |  5.78 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |    525.21 ns | 10.74 |     232 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |     76.74 ns |  0.78 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |     98.39 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |    610.96 ns |  6.21 |     384 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |     51.38 ns |  0.65 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |     59.87 ns |  0.76 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |     71.66 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |     71.79 ns |  0.91 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |     74.26 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |     78.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |     78.56 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | None             |    103.06 ns |  1.31 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |    108.69 ns |  1.38 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |    779.07 ns |  9.92 |     344 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |    102.07 ns |  0.87 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |    117.69 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |    117.85 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |    119.93 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |    121.92 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 2          | NotCancelled     |    134.56 ns |  1.14 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |    162.84 ns |  1.38 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |    529.86 ns |  4.50 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |    955.76 ns |  8.12 |     344 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |    174.36 ns |  0.96 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |    181.30 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |  1,086.35 ns |  5.99 |     648 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |    265.90 ns |  0.59 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |    306.66 ns |  0.68 |     960 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |    352.17 ns |  0.78 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |    386.15 ns |  0.86 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |    396.46 ns |  0.88 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |    431.20 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |    450.07 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | None             |    498.15 ns |  1.11 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |    583.25 ns |  1.30 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |  2,206.50 ns |  4.90 |    1240 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |    510.89 ns |  0.77 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |    605.45 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |    625.53 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |    638.56 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |    663.33 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 10         | NotCancelled     |    689.78 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |    856.46 ns |  1.29 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |  2,219.05 ns |  3.35 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |  2,645.32 ns |  3.99 |    1240 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |    924.90 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |    927.31 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |  2,937.59 ns |  3.17 |    2760 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |  2,656.18 ns |  0.67 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |  3,042.30 ns |  0.76 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |  3,591.86 ns |  0.90 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |  3,630.74 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |  3,727.14 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |  3,979.84 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |  4,119.23 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | None             |  5,052.46 ns |  1.27 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |  5,552.11 ns |  1.40 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             | 15,691.19 ns |  3.94 |   11320 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |  5,087.81 ns |  0.85 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |  5,964.42 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |  6,069.07 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |  6,098.67 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |  6,266.34 ns |  1.05 |         - | 
| WaitThenSet · AsyncAutoReset · DotNext                       | 100        | NotCancelled     |  7,091.95 ns |  1.19 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |  8,418.99 ns |  1.41 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     | 20,418.71 ns |  3.42 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 20,451.33 ns |  3.43 |   11320 B | 
|                                                              |            |                  |              |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            |  9,027.14 ns |  0.97 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            |  9,318.36 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            | 24,169.31 ns |  2.59 |   26521 B |