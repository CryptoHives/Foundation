| Method                                                         | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 1          | None             |     19.57 ns |  0.45 |      96 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 1          | None             |     31.12 ns |  0.71 |      96 B |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 1          | None             |     41.94 ns |  0.96 |         - |          NA |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 1          | None             |     42.76 ns |  0.98 |         - |          NA |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 1          | None             |     43.47 ns |  0.99 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 1          | None             |     43.69 ns |  1.00 |         - |          NA |
| PooledAsTaskContSync                                           | 1          | None             |     56.70 ns |  1.30 |      80 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 1          | None             |    384.52 ns |  8.80 |     232 B |          NA |
|                                                                |            |                  |              |       |           |             |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 1          | NotCancelled     |     56.63 ns |  0.98 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 1          | NotCancelled     |     57.55 ns |  1.00 |         - |          NA |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 1          | NotCancelled     |     60.04 ns |  1.04 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 1          | NotCancelled     |     62.29 ns |  1.08 |         - |          NA |
| PooledAsTaskContSync                                           | 1          | NotCancelled     |     81.80 ns |  1.42 |      80 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 1          | NotCancelled     |    483.94 ns |  8.41 |     232 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 1          | NotCancelled     |    644.90 ns | 11.21 |     808 B |          NA |
|                                                                |            |                  |              |       |           |             |
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 2          | None             |     26.35 ns |  0.33 |      96 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 2          | None             |     40.32 ns |  0.51 |      96 B |          NA |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 2          | None             |     78.86 ns |  1.00 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 2          | None             |     79.13 ns |  1.00 |         - |          NA |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 2          | None             |     79.76 ns |  1.01 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 2          | None             |     79.90 ns |  1.01 |         - |          NA |
| PooledAsTaskContSync                                           | 2          | None             |    117.02 ns |  1.48 |     160 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 2          | None             |    801.17 ns | 10.13 |     344 B |          NA |
|                                                                |            |                  |              |       |           |             |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 2          | NotCancelled     |    105.91 ns |  0.95 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 2          | NotCancelled     |    111.01 ns |  1.00 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 2          | NotCancelled     |    112.28 ns |  1.01 |         - |          NA |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 2          | NotCancelled     |    117.24 ns |  1.06 |         - |          NA |
| PooledAsTaskContSync                                           | 2          | NotCancelled     |    160.67 ns |  1.45 |     160 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 2          | NotCancelled     |    880.11 ns |  7.93 |     344 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 2          | NotCancelled     |  1,234.88 ns | 11.12 |    1488 B |          NA |
|                                                                |            |                  |              |       |           |             |
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 10         | None             |     69.56 ns |  0.19 |      96 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | None             |    116.82 ns |  0.32 |      96 B |          NA |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 10         | None             |    345.78 ns |  0.95 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 10         | None             |    345.81 ns |  0.95 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | None             |    363.86 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | None             |    368.77 ns |  1.01 |         - |          NA |
| PooledAsTaskContSync                                           | 10         | None             |    524.84 ns |  1.44 |     800 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | None             |  2,435.21 ns |  6.69 |    1240 B |          NA |
|                                                                |            |                  |              |       |           |             |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 10         | NotCancelled     |    504.53 ns |  0.99 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | NotCancelled     |    509.75 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | NotCancelled     |    511.23 ns |  1.00 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 10         | NotCancelled     |    516.07 ns |  1.01 |         - |          NA |
| PooledAsTaskContSync                                           | 10         | NotCancelled     |    729.42 ns |  1.43 |     800 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | NotCancelled     |  3,010.97 ns |  5.91 |    1240 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | NotCancelled     |  3,872.49 ns |  7.60 |    6464 B |          NA |
|                                                                |            |                  |              |       |           |             |
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 100        | None             |    574.86 ns |  0.17 |      96 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 100        | None             |  1,008.67 ns |  0.30 |      96 B |          NA |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 100        | None             |  3,067.97 ns |  0.90 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 100        | None             |  3,196.87 ns |  0.94 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 100        | None             |  3,418.36 ns |  1.00 |         - |          NA |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 100        | None             |  3,433.97 ns |  1.00 |         - |          NA |
| PooledAsTaskContSync                                           | 100        | None             |  5,018.46 ns |  1.47 |    8000 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 100        | None             | 15,889.16 ns |  4.65 |   11320 B |          NA |
|                                                                |            |                  |              |       |           |             |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 100        | NotCancelled     |  4,757.20 ns |  0.97 |         - |          NA |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 100        | NotCancelled     |  4,823.00 ns |  0.99 |         - |          NA |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 100        | NotCancelled     |  4,843.29 ns |  0.99 |         - |          NA |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 100        | NotCancelled     |  4,883.15 ns |  1.00 |         - |          NA |
| PooledAsTaskContSync                                           | 100        | NotCancelled     |  7,276.77 ns |  1.49 |    8000 B |          NA |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 100        | NotCancelled     | 34,961.51 ns |  7.16 |   61638 B |          NA |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 83,421.23 ns | 17.08 |   11362 B |          NA |
