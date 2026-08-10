| Description                                                  | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | None             |      18.06 ns |  0.76 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | None             |      21.47 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | None             |      23.67 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | None             |      24.36 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | None             |      24.43 ns |  1.03 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 1          | None             |      25.29 ns |  1.07 |      96 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | None             |      31.84 ns |  1.35 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | None             |      33.55 ns |  1.42 |      80 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | None             |   1,193.24 ns | 50.42 |     230 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 1          | NotCancelled     |      31.13 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 1          | NotCancelled     |      31.25 ns |  0.89 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | NotCancelled     |      33.27 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 1          | NotCancelled     |      34.46 ns |  0.99 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | NotCancelled     |      34.93 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 1          | NotCancelled     |      45.95 ns |  1.32 |      80 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 1          | NotCancelled     |     599.08 ns | 17.16 |     400 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | NotCancelled     |   1,421.32 ns | 40.70 |     232 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 1          | Timed            |      63.54 ns |  0.97 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 1          | Timed            |      65.70 ns |  1.00 |     152 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 1          | Timed            |   1,407.48 ns | 21.42 |     384 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | None             |      34.91 ns |  0.60 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 2          | None             |      48.34 ns |  0.82 |     192 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | None             |      53.16 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | None             |      53.47 ns |  0.91 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | None             |      58.63 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | None             |      58.94 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | None             |      64.45 ns |  1.10 |     320 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | None             |      77.92 ns |  1.33 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | None             |   1,811.15 ns | 30.89 |     343 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 2          | NotCancelled     |      63.50 ns |  0.60 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | NotCancelled     |      74.19 ns |  0.70 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 2          | NotCancelled     |      74.73 ns |  0.71 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 2          | NotCancelled     |      76.98 ns |  0.73 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 2          | NotCancelled     |     100.97 ns |  0.95 |     160 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | NotCancelled     |     105.84 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 2          | NotCancelled     |   1,249.99 ns | 11.81 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | NotCancelled     |   2,025.97 ns | 19.14 |     344 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 2          | Timed            |     139.09 ns |  0.97 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 2          | Timed            |     142.74 ns |  1.00 |     304 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 2          | Timed            |   2,226.79 ns | 15.60 |     648 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | None             |     172.26 ns |  0.55 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 10         | None             |     233.45 ns |  0.74 |     960 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | None             |     273.10 ns |  0.87 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | None             |     275.69 ns |  0.88 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | None             |     309.34 ns |  0.98 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | None             |     315.02 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | None             |     317.02 ns |  1.01 |    1600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | None             |     407.13 ns |  1.29 |     800 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | None             |   5,151.28 ns | 16.36 |    1238 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 10         | NotCancelled     |     317.44 ns |  0.78 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | NotCancelled     |     384.48 ns |  0.94 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 10         | NotCancelled     |     388.79 ns |  0.95 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | NotCancelled     |     408.08 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 10         | NotCancelled     |     415.43 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 10         | NotCancelled     |     515.10 ns |  1.26 |     800 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 10         | NotCancelled     |   5,020.09 ns | 12.30 |    4000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | NotCancelled     |   6,927.29 ns | 16.98 |    1240 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 10         | Timed            |     718.30 ns |  0.96 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 10         | Timed            |     748.10 ns |  1.00 |    1520 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 10         | Timed            |   7,616.35 ns | 10.18 |    2760 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | None             |   1,645.04 ns |  0.59 |         - | 
| WaitThenSet · AsyncAutoReset · RefImpl                       | 100        | None             |   2,149.94 ns |  0.77 |    9600 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | None             |   2,506.11 ns |  0.90 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | None             |   2,512.80 ns |  0.90 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | None             |   2,785.69 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | None             |   2,800.53 ns |  1.01 |         - | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | None             |   3,086.65 ns |  1.11 |   16000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | None             |   3,577.61 ns |  1.28 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | None             |  34,101.12 ns | 12.24 |   11319 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · ProtoPromise                  | 100        | NotCancelled     |   3,027.86 ns |  0.78 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | NotCancelled     |   3,574.78 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask SyncCont) | 100        | NotCancelled     |   3,595.51 ns |  0.92 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | NotCancelled     |   3,890.86 ns |  1.00 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (SyncCont)             | 100        | NotCancelled     |   3,986.15 ns |  1.02 |         - | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask SyncCont)      | 100        | NotCancelled     |   4,769.14 ns |  1.23 |    8000 B | 
| WaitThenSet · AsyncAutoReset · Nito.AsyncEx                  | 100        | NotCancelled     |  56,074.55 ns | 14.41 |   40000 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | NotCancelled     | 158,031.13 ns | 40.62 |   11331 B | 
|                                                              |            |                  |               |       |           | 
| WaitThenSet · AsyncAutoReset · Pooled (AsValueTask)          | 100        | Timed            |   6,864.17 ns |  0.96 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (ValueTask)            | 100        | Timed            |   7,150.81 ns |  1.00 |   15200 B | 
| WaitThenSet · AsyncAutoReset · Pooled (AsTask)               | 100        | Timed            |  71,854.36 ns | 10.05 |   26557 B |