| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    23.63 ns |  0.87 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    27.21 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    27.65 ns |  1.02 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    35.22 ns |  1.29 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    62.91 ns |  2.31 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    64.71 ns |  2.38 |     144 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    81.59 ns |  3.00 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   100.23 ns |  3.68 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    91.08 ns |  0.80 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   109.25 ns |  0.96 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   113.48 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   121.52 ns |  1.07 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   236.22 ns |  2.08 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   244.34 ns |  2.15 |     576 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   327.07 ns |  2.88 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   370.26 ns |  3.26 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   358.38 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   359.40 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   441.18 ns |  1.23 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   463.80 ns |  1.29 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |   882.25 ns |  2.46 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |   935.54 ns |  2.61 |    2304 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,201.69 ns |  3.35 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,440.58 ns |  4.02 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,391.01 ns |  0.94 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 1,488.48 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,690.48 ns |  1.14 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 1,788.85 ns |  1.20 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 3,571.54 ns |  2.40 |    3072 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 3,679.67 ns |  2.47 |    9216 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 4,760.92 ns |  3.20 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 5,773.36 ns |  3.88 |   33280 B |