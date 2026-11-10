| Description                                              | KeyCount | Mean         | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |-------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |     76.82 ns |  0.81 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |     80.68 ns |  0.85 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |     95.15 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    110.27 ns |  1.16 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    180.42 ns |  1.90 |     144 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    199.39 ns |  2.10 |     200 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    201.85 ns |  2.12 |      48 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |    267.66 ns |  2.81 |     520 B | 
|                                                          |          |              |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    260.22 ns |  0.75 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |    284.50 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |    347.09 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |    396.66 ns |  1.14 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |    649.27 ns |  1.87 |     576 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |    758.84 ns |  2.19 |     192 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |    764.35 ns |  2.20 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |  1,015.82 ns |  2.93 |    2080 B | 
|                                                          |          |              |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |    993.49 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |  1,101.32 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |  1,340.31 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |  1,528.90 ns |  1.14 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |  2,580.39 ns |  1.93 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |  2,982.70 ns |  2.23 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       |  3,017.39 ns |  2.25 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       |  3,995.97 ns |  2.98 |    8320 B | 
|                                                          |          |              |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       |  3,906.19 ns |  0.73 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       |  4,346.52 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       |  5,324.02 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       |  6,064.24 ns |  1.14 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 10,077.59 ns |  1.89 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 11,901.75 ns |  2.24 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 12,043.69 ns |  2.26 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 16,109.78 ns |  3.03 |   33280 B |