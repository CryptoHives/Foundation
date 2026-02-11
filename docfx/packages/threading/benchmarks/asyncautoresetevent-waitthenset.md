| Method                                                       | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None             |     25.76 ns |  0.90 |         - | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None             |     26.58 ns |  0.93 |         - | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None             |     27.96 ns |  0.97 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | None             |     28.70 ns |  1.00 |         - | 
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None             |     30.09 ns |  1.05 |      96 B | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None             |     34.53 ns |  1.20 |     160 B | 
| PooledAsTaskContSync                                         | 1          | None             |     39.36 ns |  1.37 |      80 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None             |    452.32 ns | 15.76 |     231 B | 
|                                                              |            |                  |              |       |           | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | NotCancelled     |     43.12 ns |  0.98 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | NotCancelled     |     43.91 ns |  1.00 |         - | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | NotCancelled     |     44.95 ns |  1.02 |         - | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | NotCancelled     |     46.07 ns |  1.05 |         - | 
| PooledAsTaskContSync                                         | 1          | NotCancelled     |     61.15 ns |  1.39 |      80 B | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | NotCancelled     |    294.48 ns |  6.71 |     400 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | NotCancelled     |    490.63 ns | 11.18 |     232 B | 
|                                                              |            |                  |              |       |           | 
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None             |     52.66 ns |  0.84 |     192 B | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None             |     60.44 ns |  0.97 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | None             |     62.52 ns |  1.00 |         - | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None             |     62.94 ns |  1.01 |         - | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None             |     63.15 ns |  1.01 |     320 B | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None             |     64.31 ns |  1.03 |         - | 
| PooledAsTaskContSync                                         | 2          | None             |     95.92 ns |  1.53 |     160 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None             |    737.04 ns | 11.79 |     343 B | 
|                                                              |            |                  |              |       |           | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | NotCancelled     |     91.15 ns |  0.97 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | NotCancelled     |     93.87 ns |  1.00 |         - | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | NotCancelled     |     94.60 ns |  1.01 |         - | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | NotCancelled     |     96.35 ns |  1.03 |         - | 
| PooledAsTaskContSync                                         | 2          | NotCancelled     |    133.44 ns |  1.42 |     160 B | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | NotCancelled     |    553.73 ns |  5.90 |     800 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | NotCancelled     |    836.58 ns |  8.91 |     344 B | 
|                                                              |            |                  |              |       |           | 
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None             |    263.45 ns |  0.79 |     960 B | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None             |    308.77 ns |  0.93 |         - | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None             |    313.07 ns |  0.94 |         - | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None             |    330.10 ns |  0.99 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | None             |    333.37 ns |  1.00 |         - | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None             |    355.55 ns |  1.07 |    1600 B | 
| PooledAsTaskContSync                                         | 10         | None             |    476.39 ns |  1.43 |     800 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None             |  1,967.17 ns |  5.90 |    1237 B | 
|                                                              |            |                  |              |       |           | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | NotCancelled     |    468.87 ns |  0.99 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | NotCancelled     |    472.14 ns |  1.00 |         - | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | NotCancelled     |    474.18 ns |  1.00 |         - | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | NotCancelled     |    503.13 ns |  1.07 |         - | 
| PooledAsTaskContSync                                         | 10         | NotCancelled     |    680.22 ns |  1.44 |     800 B | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | NotCancelled     |  2,446.24 ns |  5.18 |    4000 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | NotCancelled     |  2,614.57 ns |  5.54 |    1239 B | 
|                                                              |            |                  |              |       |           | 
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None             |  2,672.96 ns |  0.81 |    9600 B | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None             |  3,017.96 ns |  0.91 |         - | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None             |  3,041.67 ns |  0.92 |         - | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None             |  3,165.66 ns |  0.96 |   16000 B | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None             |  3,283.98 ns |  0.99 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | None             |  3,308.15 ns |  1.00 |         - | 
| PooledAsTaskContSync                                         | 100        | None             |  4,625.68 ns |  1.40 |    8000 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None             | 16,054.20 ns |  4.85 |   11319 B | 
|                                                              |            |                  |              |       |           | 
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | NotCancelled     |  4,579.86 ns |  0.99 |         - | 
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | NotCancelled     |  4,614.91 ns |  1.00 |         - | 
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | NotCancelled     |  4,644.99 ns |  1.01 |         - | 
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | NotCancelled     |  4,755.40 ns |  1.03 |         - | 
| PooledAsTaskContSync                                         | 100        | NotCancelled     |  6,933.55 ns |  1.50 |    8000 B | 
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | NotCancelled     | 23,620.90 ns |  5.12 |   40000 B | 
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 97,685.32 ns | 21.17 |   11321 B |