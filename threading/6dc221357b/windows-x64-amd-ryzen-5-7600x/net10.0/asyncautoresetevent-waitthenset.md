| Description                                                  | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |      24.92 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |      25.19 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |      26.01 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |      26.43 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |      28.36 ns |  1.09 |      96 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |      36.42 ns |  1.40 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |      37.86 ns |  1.46 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |     448.93 ns | 17.26 |     231 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |      39.20 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |      39.69 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      40.45 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      41.14 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      62.83 ns |  1.58 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |     302.75 ns |  7.63 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |     495.08 ns | 12.47 |     232 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |      51.35 ns |  0.83 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |      59.22 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |      60.48 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |      60.89 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |      62.12 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |      64.39 ns |  1.04 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |      96.56 ns |  1.55 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |     719.91 ns | 11.59 |     343 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      88.08 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |      90.48 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |      91.23 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      94.90 ns |  1.04 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     149.77 ns |  1.64 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |     551.88 ns |  6.05 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |     822.69 ns |  9.02 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |     260.05 ns |  0.75 |     960 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |     302.32 ns |  0.87 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |     304.33 ns |  0.88 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |     322.52 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |     327.22 ns |  0.94 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |     347.12 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |     484.39 ns |  1.40 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |   2,020.30 ns |  5.82 |    1233 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |     463.29 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     467.38 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     470.15 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |     472.73 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     662.84 ns |  1.43 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |   2,510.53 ns |  5.42 |    1239 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |   2,649.41 ns |  5.72 |    4000 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |   2,596.71 ns |  0.80 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,870.80 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |   2,878.55 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |   3,209.05 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |   3,231.49 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |   3,420.56 ns |  1.06 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |   4,400.77 ns |  1.36 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             |  17,091.51 ns |  5.29 |   11317 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   4,515.95 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   4,573.71 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |   4,640.74 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |   4,700.58 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   6,421.38 ns |  1.37 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     |  26,491.03 ns |  5.64 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 239,519.31 ns | 50.96 |   11324 B |