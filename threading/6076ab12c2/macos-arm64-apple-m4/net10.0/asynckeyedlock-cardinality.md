| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    23.48 ns |  0.86 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    27.16 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    27.88 ns |  1.03 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    35.73 ns |  1.32 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    63.90 ns |  2.35 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    66.22 ns |  2.44 |     144 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    86.48 ns |  3.18 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   101.48 ns |  3.74 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    91.96 ns |  0.80 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   111.23 ns |  0.97 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   115.02 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   121.10 ns |  1.05 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   238.16 ns |  2.07 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   244.86 ns |  2.13 |     576 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   330.40 ns |  2.87 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   375.78 ns |  3.27 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   358.85 ns |  0.98 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   365.91 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   444.70 ns |  1.22 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   460.26 ns |  1.26 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |   909.47 ns |  2.49 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |   945.56 ns |  2.58 |    2304 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,205.00 ns |  3.29 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,458.65 ns |  3.99 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,397.11 ns |  0.91 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 1,534.85 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,683.83 ns |  1.10 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 1,793.70 ns |  1.17 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 3,625.49 ns |  2.36 |    3072 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 3,703.88 ns |  2.41 |    9216 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 4,951.55 ns |  3.23 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 5,770.47 ns |  3.76 |   33280 B |