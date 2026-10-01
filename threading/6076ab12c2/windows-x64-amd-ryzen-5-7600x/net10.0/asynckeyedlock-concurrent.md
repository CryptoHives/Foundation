| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.854 μs |  0.85 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   3.938 μs |  0.87 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.535 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   6.423 μs |  1.42 |     352 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   7.485 μs |  1.65 |   14753 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   7.721 μs |  1.70 |    5153 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  14.654 μs |  3.23 |   20414 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  17.146 μs |  3.78 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   4.080 μs |  0.80 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.210 μs |  0.82 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   5.116 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   7.163 μs |  1.40 |     352 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   7.474 μs |  1.46 |   14753 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   7.841 μs |  1.53 |    5153 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  12.603 μs |  2.46 |   20393 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  16.949 μs |  3.31 |   52414 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   9.241 μs |  0.51 |    1039 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  13.441 μs |  0.74 |    2143 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  14.448 μs |  0.80 |     724 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  18.090 μs |  1.00 |     726 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  22.862 μs |  1.26 |   29527 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  25.486 μs |  1.41 |   40727 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  31.153 μs |  1.72 |  104726 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  36.496 μs |  2.02 |   10329 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |   9.420 μs |  0.48 |     987 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  11.337 μs |  0.58 |     690 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  14.277 μs |  0.73 |    2209 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  19.553 μs |  1.00 |     729 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  22.758 μs |  1.16 |   29533 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  26.845 μs |  1.37 |   40725 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  29.977 μs |  1.53 |  104727 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  39.119 μs |  2.00 |   10330 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  17.290 μs |  0.42 |    3969 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  20.000 μs |  0.49 |    7401 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  23.232 μs |  0.57 |    1180 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  41.002 μs |  1.00 |    1145 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  42.434 μs |  1.03 |   58744 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  45.857 μs |  1.12 |   81144 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  54.697 μs |  1.33 |  209145 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  87.970 μs |  2.15 |   20349 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  20.359 μs |  0.46 |    6399 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  22.786 μs |  0.51 |   10464 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  28.493 μs |  0.64 |    1194 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  42.300 μs |  0.95 |   59052 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  42.448 μs |  0.95 |   81141 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  44.627 μs |  1.00 |    1147 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  50.403 μs |  1.13 |  209212 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  89.060 μs |  2.00 |   20355 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  30.395 μs |  0.34 |   15206 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  36.934 μs |  0.42 |    2151 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  41.535 μs |  0.47 |   33749 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  82.208 μs |  0.93 |  117305 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      |  88.844 μs |  1.00 |    2113 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  91.711 μs |  1.03 |  162106 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 105.474 μs |  1.19 |  418106 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 181.969 μs |  2.05 |   40543 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  39.844 μs |  0.44 |   21976 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  44.965 μs |  0.49 |   36225 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  49.673 μs |  0.54 |    2165 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  80.434 μs |  0.88 |  121282 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  87.343 μs |  0.95 |  162010 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       |  91.561 μs |  1.00 |    2133 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  96.716 μs |  1.06 |  418620 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 185.933 μs |  2.03 |   40606 B |