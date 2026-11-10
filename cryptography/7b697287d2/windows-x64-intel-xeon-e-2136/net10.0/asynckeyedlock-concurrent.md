| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   7.665 μs |  0.75 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   8.425 μs |  0.83 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |  10.203 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |  11.022 μs |  1.08 |     352 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |  24.841 μs |  2.43 |   14812 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |  33.546 μs |  3.29 |    5216 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  35.299 μs |  3.46 |   20416 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  43.604 μs |  4.27 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   8.472 μs |  0.81 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   8.894 μs |  0.85 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |  10.431 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |  11.290 μs |  1.08 |     353 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |  24.797 μs |  2.38 |   14814 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |  33.908 μs |  3.25 |    5215 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  35.840 μs |  3.44 |   20416 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  43.931 μs |  4.21 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  30.094 μs |  0.66 |     816 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  31.064 μs |  0.68 |    1261 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  33.312 μs |  0.73 |     727 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  45.911 μs |  1.00 |     724 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  56.863 μs |  1.24 |   29526 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  59.056 μs |  1.29 |   40726 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  68.265 μs |  1.49 |  104727 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  87.198 μs |  1.90 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  31.556 μs |  0.68 |    1249 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  36.153 μs |  0.78 |     879 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  39.348 μs |  0.85 |     727 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  46.524 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  58.323 μs |  1.25 |   29535 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  59.524 μs |  1.28 |   40722 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  68.541 μs |  1.47 |  104729 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  84.912 μs |  1.83 |   10332 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  38.739 μs |  0.35 |    4556 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  39.118 μs |  0.35 |    5674 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  42.351 μs |  0.38 |    1155 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  85.101 μs |  0.76 |   81146 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  89.903 μs |  0.81 |   58745 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  94.190 μs |  0.84 |  209147 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      | 111.568 μs |  1.00 |    1149 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      | 187.734 μs |  1.68 |   20376 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  42.265 μs |  0.38 |    4209 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  44.380 μs |  0.39 |    9027 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  50.115 μs |  0.45 |    1160 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  88.700 μs |  0.79 |   81146 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  92.876 μs |  0.83 |   58801 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       | 101.783 μs |  0.90 |  209175 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       | 112.519 μs |  1.00 |    1149 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       | 190.884 μs |  1.70 |   20427 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  70.865 μs |  0.31 |    2125 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  79.147 μs |  0.35 |   26487 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  81.126 μs |  0.36 |   19041 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      | 175.260 μs |  0.77 |  117307 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 187.103 μs |  0.83 |  418113 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 192.103 μs |  0.85 |  162108 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 226.615 μs |  1.00 |    2144 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 370.345 μs |  1.63 |   40618 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  81.800 μs |  0.36 |   17564 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  84.883 μs |  0.37 |   31577 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       | 100.504 μs |  0.44 |    2149 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 174.401 μs |  0.76 |  162164 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       | 175.364 μs |  0.77 |  120218 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 192.348 μs |  0.84 |  418877 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 229.064 μs |  1.00 |    2139 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 383.103 μs |  1.67 |   40989 B |