| Description                                                  | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |      23.67 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |      23.76 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |      25.51 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |      25.68 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |      28.91 ns |  1.13 |      96 B | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |      29.48 ns |  1.15 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |      36.83 ns |  1.43 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |      39.48 ns |  1.54 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |     437.51 ns | 17.03 |     231 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      40.45 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      41.07 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |      41.15 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |      41.49 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |      45.61 ns |  1.10 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      60.56 ns |  1.46 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |     304.86 ns |  7.35 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |     494.77 ns | 11.93 |     232 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |      46.20 ns |  0.74 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |      57.68 ns |  0.92 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |      60.76 ns |  0.97 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |      61.78 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |      62.51 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |      69.01 ns |  1.10 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |      92.97 ns |  1.49 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |      94.70 ns |  1.51 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |     758.54 ns | 12.13 |     343 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |      90.24 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |      95.85 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      97.10 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |      98.20 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |     100.12 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     141.96 ns |  1.45 |     160 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |     559.48 ns |  5.70 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |     816.18 ns |  8.31 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |     238.66 ns |  0.69 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |     278.11 ns |  0.80 |     960 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |     322.31 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |     324.45 ns |  0.93 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |     331.23 ns |  0.95 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |     348.15 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |     350.61 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |     509.40 ns |  1.46 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |   2,027.40 ns |  5.82 |    1239 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |     443.78 ns |  0.84 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     510.85 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     522.37 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |     527.66 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |     530.53 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     749.94 ns |  1.41 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |   2,641.41 ns |  4.98 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |   2,783.51 ns |  5.25 |    1239 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |   2,276.40 ns |  0.67 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |   2,830.92 ns |  0.84 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |   3,015.75 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |   3,116.66 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |   3,358.72 ns |  0.99 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |   3,364.45 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |   3,383.75 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |   5,046.55 ns |  1.49 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             |  15,938.99 ns |  4.71 |   11320 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |   4,369.55 ns |  0.84 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   4,995.37 ns |  0.96 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |   5,085.51 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   5,120.61 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |   5,192.85 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   7,536.83 ns |  1.45 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     |  25,212.43 ns |  4.86 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 261,463.56 ns | 50.36 |   11324 B |