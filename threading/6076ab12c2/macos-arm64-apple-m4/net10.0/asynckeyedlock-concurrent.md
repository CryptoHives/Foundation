| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.633 μs |  0.84 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   4.035 μs |  0.94 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.310 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   4.669 μs |  1.09 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   6.833 μs |  1.59 |    5154 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   7.325 μs |  1.70 |   14758 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  13.210 μs |  3.07 |   20415 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  14.695 μs |  3.42 |   52413 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.603 μs |  0.86 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.044 μs |  0.96 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   4.205 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   4.593 μs |  1.09 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   7.000 μs |  1.67 |    5154 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   8.068 μs |  1.92 |   14780 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  13.339 μs |  3.17 |   20415 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  14.551 μs |  3.46 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  12.304 μs |  0.83 |     727 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  12.496 μs |  0.84 |     935 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  14.907 μs |  1.00 |     722 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  20.909 μs |  1.40 |   29528 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  21.763 μs |  1.46 |    1483 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  25.020 μs |  1.68 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  25.475 μs |  1.71 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  36.225 μs |  2.43 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  13.008 μs |  0.85 |     727 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  15.371 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  17.088 μs |  1.11 |    1719 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  17.632 μs |  1.15 |    1443 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  21.740 μs |  1.42 |   29529 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  24.536 μs |  1.60 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  25.758 μs |  1.68 |  104729 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  36.720 μs |  2.39 |   10348 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  30.523 μs |  0.51 |    1176 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  42.447 μs |  0.71 |    4609 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  43.950 μs |  0.73 |    7438 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  47.512 μs |  0.79 |   58804 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  51.531 μs |  0.86 |   81204 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  55.118 μs |  0.92 |  209203 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  60.127 μs |  1.00 |    1197 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  97.329 μs |  1.62 |   20426 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  38.000 μs |  0.60 |    1184 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  43.610 μs |  0.69 |    4332 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  49.043 μs |  0.78 |   81139 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  49.636 μs |  0.79 |   11659 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  62.974 μs |  1.00 |    1209 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  66.104 μs |  1.05 |   60182 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  75.220 μs |  1.19 |  209009 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       | 101.804 μs |  1.62 |   20681 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  76.302 μs |  0.17 |   31660 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  78.396 μs |  0.17 |   21390 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  78.974 μs |  0.17 |    2154 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      | 136.073 μs |  0.30 |  117360 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 139.237 μs |  0.31 |  162156 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 164.340 μs |  0.36 |  418167 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 343.055 μs |  0.75 |   40834 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 458.815 μs |  1.01 |    2168 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  76.691 μs |  0.15 |   20252 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  91.694 μs |  0.18 |   40163 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       | 133.128 μs |  0.26 |    2167 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 158.776 μs |  0.32 |  161924 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       | 159.505 μs |  0.32 |  119859 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 173.312 μs |  0.34 |  419268 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 345.288 μs |  0.69 |   41591 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 505.006 μs |  1.01 |    2176 B |