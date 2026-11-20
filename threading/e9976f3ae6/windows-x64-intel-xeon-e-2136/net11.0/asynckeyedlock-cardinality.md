| Description                                              | KeyCount | Mean         | Error     | StdDev     | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |-------------:|----------:|-----------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |     59.00 ns |  0.684 ns |   1.234 ns |  0.75 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |     74.39 ns |  1.713 ns |   3.217 ns |  0.94 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |     79.09 ns |  0.644 ns |   1.226 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |     86.13 ns |  0.661 ns |   1.258 ns |  1.09 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    164.57 ns |  0.328 ns |   0.599 ns |  2.08 |     144 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    170.27 ns |  0.267 ns |   0.495 ns |  2.15 |      48 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    198.68 ns |  0.464 ns |   0.871 ns |  2.51 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |    259.79 ns |  1.256 ns |   2.327 ns |  3.29 |     504 B | 
|                                                          |          |              |           |            |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    213.68 ns |  1.546 ns |   2.787 ns |  0.73 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |    268.27 ns |  0.571 ns |   1.045 ns |  0.91 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |    294.04 ns |  0.781 ns |   1.428 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |    304.68 ns |  2.712 ns |   5.027 ns |  1.04 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |    613.21 ns |  2.730 ns |   5.061 ns |  2.09 |     576 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |    652.29 ns |  0.678 ns |   1.257 ns |  2.22 |     192 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |    750.42 ns |  4.007 ns |   7.527 ns |  2.55 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |    980.64 ns |  4.074 ns |   7.241 ns |  3.34 |    2016 B | 
|                                                          |          |              |           |            |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |    833.78 ns |  4.429 ns |   8.319 ns |  0.72 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |  1,053.75 ns |  5.488 ns |  10.308 ns |  0.92 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |  1,150.27 ns |  6.939 ns |  12.154 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |  1,181.14 ns |  4.436 ns |   7.769 ns |  1.03 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |  2,407.04 ns | 10.484 ns |  19.433 ns |  2.09 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |  2,592.40 ns |  8.872 ns |  15.770 ns |  2.25 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       |  3,008.01 ns | 24.835 ns |  46.646 ns |  2.62 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       |  3,958.66 ns | 47.054 ns |  87.218 ns |  3.44 |    8064 B | 
|                                                          |          |              |           |            |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       |  3,353.08 ns | 18.627 ns |  34.986 ns |  0.72 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       |  4,145.93 ns | 27.429 ns |  51.518 ns |  0.90 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       |  4,632.01 ns | 20.177 ns |  38.389 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       |  4,712.99 ns |  8.396 ns |  15.140 ns |  1.02 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       |  9,641.60 ns | 44.891 ns |  84.315 ns |  2.08 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 10,340.38 ns |  9.289 ns |  17.447 ns |  2.23 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 12,109.97 ns | 74.156 ns | 141.089 ns |  2.61 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 15,372.04 ns | 36.464 ns |  67.588 ns |  3.32 |   32256 B |