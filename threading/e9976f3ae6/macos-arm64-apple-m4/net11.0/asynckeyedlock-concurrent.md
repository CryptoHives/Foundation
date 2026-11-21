| Description                                             | ThreadCount | SharedKeys | Mean       | Error      | StdDev     | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|-----------:|-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   2.763 μs |  0.0079 μs |  0.0070 μs |  0.99 |     280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   2.786 μs |  0.0042 μs |  0.0040 μs |  1.00 |     280 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   3.698 μs |  0.0079 μs |  0.0074 μs |  1.33 |     280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   3.999 μs |  0.0135 μs |  0.0126 μs |  1.44 |     280 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   7.139 μs |  0.0196 μs |  0.0184 μs |  2.56 |   14680 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   8.730 μs |  0.0574 μs |  0.0448 μs |  3.13 |    5080 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  11.813 μs |  0.0256 μs |  0.0239 μs |  4.24 |   20280 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  13.530 μs |  0.0205 μs |  0.0192 μs |  4.86 |   50680 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   2.755 μs |  0.0037 μs |  0.0035 μs |  0.88 |     280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   3.132 μs |  0.0045 μs |  0.0042 μs |  1.00 |     280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   3.976 μs |  0.0117 μs |  0.0110 μs |  1.27 |     280 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   4.072 μs |  0.0248 μs |  0.0232 μs |  1.30 |     280 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   7.495 μs |  0.0463 μs |  0.0433 μs |  2.39 |   14680 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   8.531 μs |  0.0347 μs |  0.0307 μs |  2.72 |    5080 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  12.061 μs |  0.0398 μs |  0.0372 μs |  3.85 |   20280 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  13.643 μs |  0.0207 μs |  0.0194 μs |  4.36 |   50680 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  12.163 μs |  0.1125 μs |  0.1053 μs |  1.00 |     584 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  12.224 μs |  0.0441 μs |  0.0391 μs |  1.01 |     584 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  13.052 μs |  0.1175 μs |  0.1099 μs |  1.07 |    1206 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  17.664 μs |  0.1469 μs |  0.1374 μs |  1.45 |    2480 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  21.705 μs |  0.1110 μs |  0.1038 μs |  1.78 |   29384 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  26.230 μs |  0.1128 μs |  0.1055 μs |  2.16 |   40584 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  26.675 μs |  0.1751 μs |  0.1638 μs |  2.19 |  101384 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  32.475 μs |  0.1622 μs |  0.1355 μs |  2.67 |   10184 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  12.666 μs |  0.2446 μs |  0.2288 μs |  1.00 |     585 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  13.086 μs |  0.0406 μs |  0.0360 μs |  1.03 |     584 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  15.744 μs |  0.1048 μs |  0.0980 μs |  1.24 |    1343 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  19.898 μs |  0.1552 μs |  0.1451 μs |  1.57 |    2932 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  20.685 μs |  0.1083 μs |  0.0960 μs |  1.63 |   29389 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  25.121 μs |  0.0595 μs |  0.0528 μs |  1.98 |   40584 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  25.585 μs |  0.2827 μs |  0.2644 μs |  2.02 |  101386 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  35.128 μs |  0.3335 μs |  0.2604 μs |  2.77 |   10188 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  36.678 μs |  0.1540 μs |  0.1440 μs |  0.73 |    4412 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  40.581 μs |  0.0784 μs |  0.0695 μs |  0.81 |    1048 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  44.050 μs |  0.0639 μs |  0.0534 μs |  0.88 |    8793 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  44.720 μs |  0.2114 μs |  0.1977 μs |  0.89 |   58648 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  47.821 μs |  0.9199 μs |  0.8155 μs |  0.95 |   81048 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  49.050 μs |  0.7046 μs |  0.6591 μs |  0.98 |  202648 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  50.141 μs |  0.1662 μs |  0.1555 μs |  1.00 |    1048 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  93.164 μs |  1.8541 μs |  2.1352 μs |  1.86 |   20260 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  45.933 μs |  0.2213 μs |  0.2070 μs |  0.88 |    5260 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  46.138 μs |  0.1497 μs |  0.1250 μs |  0.88 |    1048 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  46.433 μs |  0.3570 μs |  0.3340 μs |  0.89 |   81031 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  52.324 μs |  0.2037 μs |  0.1806 μs |  1.00 |    1063 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  52.761 μs |  0.0540 μs |  0.0422 μs |  1.01 |   13804 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  58.914 μs |  0.5516 μs |  0.5160 μs |  1.13 |   59719 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  67.714 μs |  0.8508 μs |  0.7959 μs |  1.29 |  202437 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  90.841 μs |  0.1348 μs |  0.1126 μs |  1.74 |   20424 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  69.519 μs |  0.1218 μs |  0.1139 μs |  0.15 |   12306 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  80.723 μs |  0.5055 μs |  0.4728 μs |  0.17 |    1976 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  84.341 μs |  0.2319 μs |  0.2169 μs |  0.18 |   34272 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 139.054 μs |  0.0939 μs |  0.0832 μs |  0.30 |  161976 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 145.235 μs |  0.2008 μs |  0.1567 μs |  0.31 |  405176 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      | 147.385 μs |  2.8678 μs |  3.9255 μs |  0.32 |  117176 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 321.699 μs |  6.0599 μs |  6.9786 μs |  0.69 |   40687 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 471.253 μs | 12.3619 μs | 34.8668 μs |  1.00 |    1976 B | 
|                                                         |             |            |            |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  87.324 μs |  0.1432 μs |  0.1269 μs |  0.19 |   17270 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  93.577 μs |  0.3455 μs |  0.3063 μs |  0.21 |   41736 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       | 111.877 μs |  0.4409 μs |  0.3682 μs |  0.25 |    1976 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 149.545 μs |  2.9047 μs |  3.4578 μs |  0.33 |  161861 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       | 151.527 μs |  0.2484 μs |  0.1939 μs |  0.33 |  120448 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 160.226 μs |  0.1342 μs |  0.1189 μs |  0.35 |  406153 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 328.864 μs |  6.2503 μs |  6.6878 μs |  0.73 |   41406 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 453.593 μs |  8.9158 μs | 16.7461 μs |  1.00 |    2008 B |