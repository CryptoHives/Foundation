| Description                                              | KeyCount | Mean        | Error     | StdDev    | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|----------:|----------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    21.28 ns |  0.062 ns |  0.058 ns |  0.86 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    24.75 ns |  0.031 ns |  0.029 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    33.60 ns |  0.045 ns |  0.042 ns |  1.36 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    34.74 ns |  0.027 ns |  0.024 ns |  1.40 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    65.53 ns |  0.136 ns |  0.127 ns |  2.65 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    69.79 ns |  0.187 ns |  0.166 ns |  2.82 |     144 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    91.81 ns |  0.173 ns |  0.162 ns |  3.71 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   108.40 ns |  0.108 ns |  0.101 ns |  4.38 |     504 B | 
|                                                          |          |             |           |           |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    87.33 ns |  0.092 ns |  0.086 ns |  0.80 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   109.45 ns |  0.222 ns |  0.197 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   127.83 ns |  0.186 ns |  0.174 ns |  1.17 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   135.76 ns |  0.624 ns |  0.584 ns |  1.24 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   237.81 ns |  0.297 ns |  0.277 ns |  2.17 |     576 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   259.32 ns |  0.372 ns |  0.329 ns |  2.37 |     192 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   360.08 ns |  0.568 ns |  0.531 ns |  3.29 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   425.36 ns |  0.709 ns |  0.664 ns |  3.89 |    2016 B | 
|                                                          |          |             |           |           |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   346.10 ns |  1.973 ns |  1.846 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   422.90 ns |  0.811 ns |  0.759 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   477.24 ns |  0.671 ns |  0.627 ns |  1.13 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   530.19 ns |  1.722 ns |  1.611 ns |  1.25 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |   914.41 ns |  1.668 ns |  1.478 ns |  2.16 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |   984.46 ns |  1.123 ns |  1.050 ns |  2.33 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,405.45 ns | 10.028 ns |  9.380 ns |  3.32 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,714.10 ns |  1.756 ns |  1.557 ns |  4.05 |    8064 B | 
|                                                          |          |             |           |           |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,356.55 ns |  2.452 ns |  2.293 ns |  0.81 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 1,676.31 ns |  7.312 ns |  6.839 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 1,866.07 ns |  3.350 ns |  3.133 ns |  1.11 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 2,066.43 ns | 10.371 ns |  9.701 ns |  1.23 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 3,583.82 ns |  5.377 ns |  5.029 ns |  2.14 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 3,905.88 ns | 10.656 ns |  9.968 ns |  2.33 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 5,624.17 ns | 23.055 ns | 21.566 ns |  3.36 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,624.65 ns | 11.376 ns |  9.500 ns |  3.95 |   32256 B |