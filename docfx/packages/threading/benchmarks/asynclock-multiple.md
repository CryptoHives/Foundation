| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|
| LockUnlockPooledMultipleAsync        | 0          | None             |     12.84 ns |  1.00 |         - | 
| LockUnlockPooledTaskMultipleAsync    | 0          | None             |     13.66 ns |  1.06 |         - | 
| LockUnlockSemaphoreSlimMultipleAsync | 0          | None             |     19.21 ns |  1.50 |         - | 
| LockUnlockRefImplMultipleAsync       | 0          | None             |     19.94 ns |  1.55 |         - | 
| LockUnlockNonKeyedMultipleAsync      | 0          | None             |     22.80 ns |  1.78 |         - | 
| LockUnlockNitoMultipleAsync          | 0          | None             |     41.13 ns |  3.20 |     320 B | 
| LockUnlockNeoSmartMultipleAsync      | 0          | None             |     58.38 ns |  4.55 |     208 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockPooledMultipleAsync        | 0          | NotCancelled     |     13.10 ns |  1.00 |         - | 
| LockUnlockSemaphoreSlimMultipleAsync | 0          | NotCancelled     |     18.87 ns |  1.44 |         - | 
| LockUnlockPooledTaskMultipleAsync    | 0          | NotCancelled     |     21.93 ns |  1.67 |         - | 
| LockUnlockNonKeyedMultipleAsync      | 0          | NotCancelled     |     22.67 ns |  1.73 |         - | 
| LockUnlockNitoMultipleAsync          | 0          | NotCancelled     |     39.37 ns |  3.00 |     320 B | 
| LockUnlockNeoSmartMultipleAsync      | 0          | NotCancelled     |     59.74 ns |  4.56 |     208 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockPooledMultipleAsync        | 1          | None             |     40.90 ns |  1.00 |         - | 
| LockUnlockSemaphoreSlimMultipleAsync | 1          | None             |     43.97 ns |  1.08 |      88 B | 
| LockUnlockRefImplMultipleAsync       | 1          | None             |     77.88 ns |  1.90 |     216 B | 
| LockUnlockNitoMultipleAsync          | 1          | None             |    100.41 ns |  2.46 |     728 B | 
| LockUnlockNeoSmartMultipleAsync      | 1          | None             |    117.18 ns |  2.87 |     416 B | 
| LockUnlockPooledTaskMultipleAsync    | 1          | None             |    501.80 ns | 12.27 |     272 B | 
| LockUnlockNonKeyedMultipleAsync      | 1          | None             |    529.36 ns | 12.94 |     352 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockPooledMultipleAsync        | 1          | NotCancelled     |     55.49 ns |  1.00 |         - | 
| LockUnlockNeoSmartMultipleAsync      | 1          | NotCancelled     |    117.72 ns |  2.12 |     416 B | 
| LockUnlockNitoMultipleAsync          | 1          | NotCancelled     |    379.94 ns |  6.85 |     968 B | 
| LockUnlockSemaphoreSlimMultipleAsync | 1          | NotCancelled     |    578.24 ns | 10.42 |     504 B | 
| LockUnlockPooledTaskMultipleAsync    | 1          | NotCancelled     |    597.82 ns | 10.77 |     272 B | 
| LockUnlockNonKeyedMultipleAsync      | 1          | NotCancelled     |    697.58 ns | 12.57 |     640 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockSemaphoreSlimMultipleAsync | 10         | None             |    273.21 ns |  0.79 |     880 B | 
| LockUnlockPooledMultipleAsync        | 10         | None             |    345.86 ns |  1.00 |         - | 
| LockUnlockNitoMultipleAsync          | 10         | None             |    554.40 ns |  1.60 |    4400 B | 
| LockUnlockNeoSmartMultipleAsync      | 10         | None             |    648.23 ns |  1.87 |    2288 B | 
| LockUnlockRefImplMultipleAsync       | 10         | None             |    656.64 ns |  1.90 |    2160 B | 
| LockUnlockPooledTaskMultipleAsync    | 10         | None             |  3,084.78 ns |  8.92 |    1352 B | 
| LockUnlockNonKeyedMultipleAsync      | 10         | None             |  3,346.23 ns |  9.68 |    2296 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockPooledMultipleAsync        | 10         | NotCancelled     |    496.73 ns |  1.00 |         - | 
| LockUnlockNeoSmartMultipleAsync      | 10         | NotCancelled     |    655.21 ns |  1.32 |    2288 B | 
| LockUnlockNitoMultipleAsync          | 10         | NotCancelled     |  3,186.16 ns |  6.41 |    6800 B | 
| LockUnlockPooledTaskMultipleAsync    | 10         | NotCancelled     |  3,446.33 ns |  6.94 |    1352 B | 
| LockUnlockSemaphoreSlimMultipleAsync | 10         | NotCancelled     |  4,509.52 ns |  9.08 |    3888 B | 
| LockUnlockNonKeyedMultipleAsync      | 10         | NotCancelled     |  5,103.15 ns | 10.27 |    5176 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockSemaphoreSlimMultipleAsync | 100        | None             |  2,606.46 ns |  0.81 |    8800 B | 
| LockUnlockPooledMultipleAsync        | 100        | None             |  3,218.54 ns |  1.00 |         - | 
| LockUnlockNitoMultipleAsync          | 100        | None             |  5,329.26 ns |  1.66 |   41120 B | 
| LockUnlockNeoSmartMultipleAsync      | 100        | None             |  5,963.23 ns |  1.85 |   21008 B | 
| LockUnlockRefImplMultipleAsync       | 100        | None             |  6,173.39 ns |  1.92 |   21600 B | 
| LockUnlockPooledTaskMultipleAsync    | 100        | None             | 32,232.62 ns | 10.02 |   12216 B | 
| LockUnlockNonKeyedMultipleAsync      | 100        | None             | 37,393.45 ns | 11.62 |   21799 B | 
|                                      |            |                  |              |       |           | 
| LockUnlockPooledMultipleAsync        | 100        | NotCancelled     |  4,882.01 ns |  1.00 |         - | 
| LockUnlockNeoSmartMultipleAsync      | 100        | NotCancelled     |  6,016.89 ns |  1.23 |   21008 B | 
| LockUnlockPooledTaskMultipleAsync    | 100        | NotCancelled     | 33,647.89 ns |  6.89 |   12216 B | 
| LockUnlockNitoMultipleAsync          | 100        | NotCancelled     | 34,219.46 ns |  7.01 |   65120 B | 
| LockUnlockSemaphoreSlimMultipleAsync | 100        | NotCancelled     | 41,846.83 ns |  8.57 |   37792 B | 
| LockUnlockNonKeyedMultipleAsync      | 100        | NotCancelled     | 53,666.62 ns | 10.99 |   50600 B |