| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.606 μs |  0.85 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   3.863 μs |  0.91 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   4.071 μs |  0.96 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.236 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   6.806 μs |  1.61 |    5153 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   6.947 μs |  1.64 |   14753 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  12.755 μs |  3.01 |   20415 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  14.430 μs |  3.41 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.724 μs |  0.87 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.103 μs |  0.96 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   4.120 μs |  0.96 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   4.290 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   7.883 μs |  1.84 |    5156 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   9.412 μs |  2.19 |   14789 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  12.577 μs |  2.93 |   20415 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  14.327 μs |  3.34 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  12.066 μs |  0.80 |     728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  14.689 μs |  0.98 |    1133 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  15.025 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  16.315 μs |  1.09 |    1414 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  21.022 μs |  1.40 |   29528 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  24.874 μs |  1.66 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  25.385 μs |  1.69 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  36.073 μs |  2.40 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  12.872 μs |  0.86 |     727 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  15.045 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  16.797 μs |  1.12 |    1354 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  18.395 μs |  1.22 |    1915 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  21.811 μs |  1.45 |   29529 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  24.802 μs |  1.65 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  25.699 μs |  1.71 |  104729 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  36.111 μs |  2.40 |   10340 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  34.998 μs |  0.60 |    1179 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  41.898 μs |  0.72 |    4332 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  46.331 μs |  0.79 |    9046 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  46.653 μs |  0.80 |   58806 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  52.430 μs |  0.90 |  209204 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  53.173 μs |  0.91 |   81202 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  58.412 μs |  1.00 |    1198 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  94.996 μs |  1.63 |   20422 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  37.846 μs |  0.63 |    1183 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  41.688 μs |  0.70 |    5566 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  44.995 μs |  0.75 |   10256 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  53.189 μs |  0.89 |   81149 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  59.925 μs |  1.00 |    1212 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  63.915 μs |  1.07 |   60061 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  71.651 μs |  1.20 |  209085 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       | 100.833 μs |  1.68 |   20617 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  71.706 μs |  0.13 |   17160 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  77.706 μs |  0.14 |   31886 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  85.088 μs |  0.16 |    2162 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      | 128.425 μs |  0.24 |  117368 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 145.598 μs |  0.27 |  162165 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 164.784 μs |  0.31 |  418168 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 296.681 μs |  0.55 |   40777 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 538.670 μs |  1.00 |    2168 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  77.924 μs |  0.17 |   21531 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       | 103.906 μs |  0.23 |   45327 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       | 133.499 μs |  0.29 |    2167 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       | 139.050 μs |  0.31 |  119713 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 147.249 μs |  0.32 |  161998 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 169.101 μs |  0.37 |  419234 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 337.997 μs |  0.74 |   41513 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 453.984 μs |  1.00 |    2180 B |