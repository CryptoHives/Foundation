| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    32.18 ns |  0.83 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    34.16 ns |  0.88 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    38.90 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    54.17 ns |  1.39 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    65.90 ns |  1.69 |     144 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    69.61 ns |  1.79 |      48 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    80.05 ns |  2.06 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   104.78 ns |  2.69 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   113.00 ns |  0.83 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   118.71 ns |  0.87 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   135.89 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   241.89 ns |  1.78 |     576 B | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   279.14 ns |  2.05 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   297.23 ns |  2.19 |     192 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   315.83 ns |  2.32 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   385.96 ns |  2.84 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   404.45 ns |  0.79 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   437.00 ns |  0.85 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   513.33 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   738.09 ns |  1.44 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |   933.16 ns |  1.82 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |   980.05 ns |  1.91 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,206.64 ns |  2.35 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,568.04 ns |  3.05 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,607.29 ns |  0.79 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,721.46 ns |  0.85 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,035.23 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 3,093.80 ns |  1.52 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 3,717.46 ns |  1.83 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 3,837.22 ns |  1.89 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 4,797.59 ns |  2.36 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,012.99 ns |  2.95 |   33280 B |