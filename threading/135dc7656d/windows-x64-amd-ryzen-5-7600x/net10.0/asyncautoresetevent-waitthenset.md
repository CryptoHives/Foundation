| Description                                                  | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |      24.23 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |      24.79 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |      26.08 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |      26.31 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |      32.52 ns |  1.25 |      96 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |      33.40 ns |  1.28 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |      38.85 ns |  1.49 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |     460.55 ns | 17.66 |     231 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |      39.10 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |      39.43 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      40.80 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      41.09 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      56.56 ns |  1.43 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |     307.08 ns |  7.79 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |     499.14 ns | 12.66 |     232 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |      51.11 ns |  0.85 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |      58.04 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |      59.40 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |      60.41 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |      60.69 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |      62.84 ns |  1.04 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |      92.07 ns |  1.52 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |     743.69 ns | 12.31 |     343 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |      89.82 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |      90.73 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      92.89 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      93.43 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     128.55 ns |  1.43 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |     566.81 ns |  6.31 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |     791.96 ns |  8.82 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |     260.75 ns |  0.69 |     960 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |     304.38 ns |  0.81 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |     311.59 ns |  0.83 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |     312.19 ns |  0.83 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |     326.99 ns |  0.87 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |     375.37 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |     464.41 ns |  1.24 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |   2,018.49 ns |  5.38 |    1233 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |     461.39 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |     462.00 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     469.02 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     476.91 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     663.37 ns |  1.44 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |   2,605.49 ns |  5.64 |    1238 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |   2,650.29 ns |  5.74 |    4000 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |   2,608.54 ns |  0.82 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |   2,852.94 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,877.16 ns |  0.90 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |   3,181.78 ns |  1.00 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |   3,183.07 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |   3,188.61 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,520.63 ns |  1.42 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             |  16,973.40 ns |  5.32 |   11318 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   4,472.44 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   4,592.44 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |   4,637.98 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |   4,643.92 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   6,443.24 ns |  1.39 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     |  29,991.17 ns |  6.46 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 136,549.51 ns | 29.40 |   11321 B |