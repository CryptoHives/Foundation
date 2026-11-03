| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.819 μs |  0.83 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   4.060 μs |  0.89 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.586 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   6.065 μs |  1.32 |     352 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   7.642 μs |  1.67 |   14754 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   7.981 μs |  1.74 |    5153 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  11.975 μs |  2.61 |   20392 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  17.028 μs |  3.71 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.839 μs |  0.69 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.524 μs |  0.81 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   5.597 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   7.097 μs |  1.27 |     353 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   7.671 μs |  1.37 |   14753 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   7.726 μs |  1.38 |    5153 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  13.318 μs |  2.38 |   20409 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  17.325 μs |  3.10 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   8.775 μs |  0.48 |    1020 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  13.224 μs |  0.72 |     715 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  13.358 μs |  0.72 |    2141 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  18.431 μs |  1.00 |     726 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  23.779 μs |  1.29 |   29525 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  29.213 μs |  1.59 |   40726 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  31.224 μs |  1.69 |  104727 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  37.291 μs |  2.02 |   10329 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |   7.992 μs |  0.41 |     797 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  13.396 μs |  0.68 |    2228 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  15.156 μs |  0.77 |     724 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  19.731 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  23.917 μs |  1.21 |   29536 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  29.672 μs |  1.50 |   40726 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  29.939 μs |  1.52 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  39.796 μs |  2.02 |   10329 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  20.330 μs |  0.50 |    7968 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  22.256 μs |  0.55 |   10329 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  22.606 μs |  0.56 |    1174 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  40.364 μs |  1.00 |    1144 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  41.527 μs |  1.03 |   58744 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  46.227 μs |  1.15 |   81144 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  53.938 μs |  1.34 |  209145 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  89.119 μs |  2.21 |   20351 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  18.972 μs |  0.43 |    5562 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  24.556 μs |  0.56 |   13695 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  28.153 μs |  0.64 |    1188 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  44.127 μs |  1.00 |    1146 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  45.038 μs |  1.02 |   59030 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  46.058 μs |  1.04 |   81142 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  53.333 μs |  1.21 |  209193 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  90.396 μs |  2.05 |   20357 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  30.428 μs |  0.36 |   14862 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  39.709 μs |  0.48 |    2160 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  45.652 μs |  0.55 |   38091 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      |  83.466 μs |  1.00 |    2116 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  95.369 μs |  1.14 |  117305 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 104.950 μs |  1.26 |  162105 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 106.367 μs |  1.27 |  418106 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 180.093 μs |  2.16 |   40532 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  34.167 μs |  0.39 |   19040 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  44.820 μs |  0.51 |   38481 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  52.742 μs |  0.61 |    2155 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  85.712 μs |  0.98 |  121299 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  86.899 μs |  1.00 |  162028 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       |  87.052 μs |  1.00 |    2123 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 102.842 μs |  1.18 |  418669 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 183.202 μs |  2.10 |   40601 B |