| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    35.96 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    38.56 ns |  0.87 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    44.12 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    63.35 ns |  1.44 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    77.18 ns |  1.75 |     144 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    77.76 ns |  1.76 |      48 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    92.84 ns |  2.10 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   117.60 ns |  2.67 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   119.15 ns |  0.75 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   142.50 ns |  0.90 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   157.83 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   228.15 ns |  1.45 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   285.84 ns |  1.81 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   287.69 ns |  1.82 |     576 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   347.65 ns |  2.20 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   432.26 ns |  2.74 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   433.89 ns |  0.72 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   493.56 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   605.38 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   851.48 ns |  1.41 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,042.03 ns |  1.72 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       | 1,136.08 ns |  1.88 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,378.70 ns |  2.28 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,752.67 ns |  2.90 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,747.82 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,980.05 ns |  0.84 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,360.73 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 3,363.56 ns |  1.42 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 4,185.34 ns |  1.77 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 4,336.90 ns |  1.84 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 5,434.76 ns |  2.30 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,999.17 ns |  2.97 |   33280 B |