| Method                                                         | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|--------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 1          | None             |      18.03 ns |  0.46 |      96 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 1          | None             |      28.83 ns |  0.73 |      96 B | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 1          | None             |      38.09 ns |  0.97 |         - | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 1          | None             |      39.09 ns |  0.99 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 1          | None             |      39.26 ns |  1.00 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 1          | None             |      39.45 ns |  1.00 |         - | 
| PooledAsTaskContSync                                           | 1          | None             |      54.40 ns |  1.38 |      80 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 1          | None             |     435.28 ns | 11.04 |     231 B | 
|                                                                |            |                  |               |       |           | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 1          | NotCancelled     |      53.43 ns |  1.00 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 1          | NotCancelled     |      53.84 ns |  1.01 |         - | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 1          | NotCancelled     |      56.25 ns |  1.05 |         - | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 1          | NotCancelled     |      56.38 ns |  1.06 |         - | 
| PooledAsTaskContSync                                           | 1          | NotCancelled     |      81.52 ns |  1.53 |      80 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 1          | NotCancelled     |     491.66 ns |  9.20 |     232 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 1          | NotCancelled     |     618.55 ns | 11.58 |     808 B | 
|                                                                |            |                  |               |       |           | 
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 2          | None             |      24.32 ns |  0.34 |      96 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 2          | None             |      38.21 ns |  0.53 |      96 B | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 2          | None             |      72.02 ns |  0.99 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 2          | None             |      72.56 ns |  1.00 |         - | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 2          | None             |      74.81 ns |  1.03 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 2          | None             |      80.15 ns |  1.10 |         - | 
| PooledAsTaskContSync                                           | 2          | None             |     105.40 ns |  1.45 |     160 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 2          | None             |     717.28 ns |  9.89 |     344 B | 
|                                                                |            |                  |               |       |           | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 2          | NotCancelled     |     102.35 ns |  0.99 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 2          | NotCancelled     |     103.72 ns |  1.00 |         - | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 2          | NotCancelled     |     103.85 ns |  1.00 |         - | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 2          | NotCancelled     |     104.81 ns |  1.01 |         - | 
| PooledAsTaskContSync                                           | 2          | NotCancelled     |     146.96 ns |  1.42 |     160 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 2          | NotCancelled     |     830.69 ns |  8.01 |     344 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 2          | NotCancelled     |   1,030.21 ns |  9.94 |    1488 B | 
|                                                                |            |                  |               |       |           | 
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 10         | None             |      65.80 ns |  0.19 |      96 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | None             |     111.48 ns |  0.33 |      96 B | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 10         | None             |     320.53 ns |  0.94 |         - | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 10         | None             |     322.76 ns |  0.94 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | None             |     340.31 ns |  0.99 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | None             |     342.49 ns |  1.00 |         - | 
| PooledAsTaskContSync                                           | 10         | None             |     497.51 ns |  1.45 |     800 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | None             |   1,992.35 ns |  5.82 |    1239 B | 
|                                                                |            |                  |               |       |           | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 10         | NotCancelled     |     477.50 ns |  1.00 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | NotCancelled     |     478.37 ns |  1.00 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | NotCancelled     |     480.86 ns |  1.01 |         - | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 10         | NotCancelled     |     484.61 ns |  1.01 |         - | 
| PooledAsTaskContSync                                           | 10         | NotCancelled     |     716.62 ns |  1.50 |     800 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | NotCancelled     |   2,855.13 ns |  5.97 |    1240 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | NotCancelled     |   3,243.98 ns |  6.78 |    6464 B | 
|                                                                |            |                  |               |       |           | 
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 100        | None             |     571.10 ns |  0.18 |      96 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 100        | None             |     963.42 ns |  0.30 |      96 B | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 100        | None             |   2,852.62 ns |  0.89 |         - | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 100        | None             |   2,914.30 ns |  0.91 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 100        | None             |   3,201.46 ns |  1.00 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 100        | None             |   3,226.29 ns |  1.01 |         - | 
| PooledAsTaskContSync                                           | 100        | None             |   4,648.09 ns |  1.45 |    8000 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 100        | None             |  16,002.46 ns |  5.00 |   11320 B | 
|                                                                |            |                  |               |       |           | 
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 100        | NotCancelled     |   4,427.02 ns |  0.98 |         - | 
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 100        | NotCancelled     |   4,435.48 ns |  0.98 |         - | 
| PooledAsyncManualResetEventWaitThenSetAsync                    | 100        | NotCancelled     |   4,541.96 ns |  1.00 |         - | 
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 100        | NotCancelled     |   4,707.55 ns |  1.04 |         - | 
| PooledAsTaskContSync                                           | 100        | NotCancelled     |   6,653.11 ns |  1.47 |    8000 B | 
| NitoAsyncManualResetEventWaitThenSetAsync                      | 100        | NotCancelled     | 129,394.61 ns | 28.50 |   61615 B | 
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 306,354.51 ns | 67.47 |   11330 B |