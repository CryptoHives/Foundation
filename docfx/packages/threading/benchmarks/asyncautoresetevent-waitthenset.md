| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None             |      28.17 ns |  0.92 |         - |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None             |      28.85 ns |  0.95 |         - |          NA |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None             |      29.78 ns |  0.98 |         - |          NA |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None             |      30.31 ns |  0.99 |      96 B |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | None             |      30.50 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None             |      36.70 ns |  1.20 |     160 B |          NA |
| PooledAsTaskContSync                                         | 1          | None             |      45.54 ns |  1.49 |      80 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None             |     392.63 ns | 12.88 |     232 B |          NA |
|                                                              |            |                  |               |       |           |             |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | NotCancelled     |      44.91 ns |  0.99 |         - |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | NotCancelled     |      45.49 ns |  1.00 |         - |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | NotCancelled     |      47.69 ns |  1.05 |         - |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | NotCancelled     |      51.24 ns |  1.13 |         - |          NA |
| PooledAsTaskContSync                                         | 1          | NotCancelled     |      67.49 ns |  1.48 |      80 B |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | NotCancelled     |     335.75 ns |  7.38 |     400 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | NotCancelled     |     459.67 ns | 10.10 |     232 B |          NA |
|                                                              |            |                  |               |       |           |             |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None             |      55.84 ns |  0.82 |     192 B |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None             |      66.69 ns |  0.98 |         - |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None             |      67.26 ns |  0.99 |         - |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | None             |      67.84 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None             |      68.41 ns |  1.01 |         - |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None             |      70.65 ns |  1.04 |     320 B |          NA |
| PooledAsTaskContSync                                         | 2          | None             |     102.22 ns |  1.51 |     160 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None             |     855.36 ns | 12.61 |     344 B |          NA |
|                                                              |            |                  |               |       |           |             |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | NotCancelled     |      99.00 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | NotCancelled     |     100.56 ns |  1.02 |         - |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | NotCancelled     |     102.09 ns |  1.03 |         - |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | NotCancelled     |     106.36 ns |  1.07 |         - |          NA |
| PooledAsTaskContSync                                         | 2          | NotCancelled     |     151.93 ns |  1.53 |     160 B |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | NotCancelled     |     607.96 ns |  6.14 |     800 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | NotCancelled     |     930.59 ns |  9.40 |     344 B |          NA |
|                                                              |            |                  |               |       |           |             |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None             |     285.66 ns |  0.81 |     960 B |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None             |     337.95 ns |  0.95 |         - |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None             |     339.19 ns |  0.96 |         - |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | None             |     354.67 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None             |     355.35 ns |  1.00 |    1600 B |          NA |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None             |     363.39 ns |  1.02 |         - |          NA |
| PooledAsTaskContSync                                         | 10         | None             |     518.18 ns |  1.46 |     800 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None             |   2,429.83 ns |  6.85 |    1240 B |          NA |
|                                                              |            |                  |               |       |           |             |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | NotCancelled     |     494.26 ns |  0.99 |         - |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | NotCancelled     |     501.56 ns |  1.00 |         - |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | NotCancelled     |     503.32 ns |  1.00 |         - |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | NotCancelled     |     505.63 ns |  1.01 |         - |          NA |
| PooledAsTaskContSync                                         | 10         | NotCancelled     |     723.35 ns |  1.44 |     800 B |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | NotCancelled     |   2,892.91 ns |  5.77 |    4000 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | NotCancelled     |   3,092.34 ns |  6.17 |    1240 B |          NA |
|                                                              |            |                  |               |       |           |             |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None             |   2,869.74 ns |  0.82 |    9600 B |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None             |   3,157.36 ns |  0.90 |         - |          NA |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None             |   3,192.06 ns |  0.91 |         - |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | None             |   3,494.61 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None             |   3,551.16 ns |  1.02 |         - |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None             |   3,589.47 ns |  1.03 |   16000 B |          NA |
| PooledAsTaskContSync                                         | 100        | None             |   5,131.95 ns |  1.47 |    8000 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None             |  16,915.60 ns |  4.84 |   11321 B |          NA |
|                                                              |            |                  |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | NotCancelled     |   4,801.14 ns |  0.98 |         - |          NA |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | NotCancelled     |   4,818.74 ns |  0.98 |         - |          NA |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | NotCancelled     |   4,921.33 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | NotCancelled     |   4,944.66 ns |  1.00 |         - |          NA |
| PooledAsTaskContSync                                         | 100        | NotCancelled     |   7,200.37 ns |  1.46 |    8000 B |          NA |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | NotCancelled     |  34,267.94 ns |  6.96 |   40000 B |          NA |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 308,299.22 ns | 62.65 |   11343 B |          NA |
