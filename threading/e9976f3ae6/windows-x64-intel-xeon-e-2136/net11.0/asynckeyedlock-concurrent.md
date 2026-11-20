| Description                                             | ThreadCount | SharedKeys | Mean       | Error     | StdDev     | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|----------:|-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   6.273 μs | 0.0413 μs |  0.0755 μs |  0.74 |     280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   8.162 μs | 0.1304 μs |  0.2449 μs |  0.96 |     280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   8.514 μs | 0.0876 μs |  0.1942 μs |  1.00 |     280 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   9.086 μs | 0.1076 μs |  0.1995 μs |  1.07 |     280 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |  17.675 μs | 0.1011 μs |  0.1873 μs |  2.08 |   14680 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |  19.652 μs | 0.1002 μs |  0.1882 μs |  2.31 |    5080 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  21.414 μs | 0.0388 μs |  0.0689 μs |  2.52 |   20280 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  27.919 μs | 0.0730 μs |  0.1334 μs |  3.28 |   50680 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   7.019 μs | 0.0599 μs |  0.1139 μs |  0.78 |     280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   8.979 μs | 0.0661 μs |  0.1258 μs |  1.00 |     280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   9.098 μs | 0.0195 μs |  0.0367 μs |  1.01 |     280 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   9.548 μs | 0.0437 μs |  0.0820 μs |  1.06 |     280 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |  17.782 μs | 0.2125 μs |  0.3885 μs |  1.98 |   14680 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |  19.815 μs | 0.0896 μs |  0.1660 μs |  2.21 |    5080 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  21.916 μs | 0.0533 μs |  0.0988 μs |  2.44 |   20280 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  27.684 μs | 0.0601 μs |  0.1099 μs |  3.08 |   50680 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  21.526 μs | 0.3621 μs |  0.6890 μs |  0.67 |    1140 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  22.579 μs | 0.3542 μs |  0.6565 μs |  0.70 |    1486 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  25.401 μs | 0.0396 μs |  0.0733 μs |  0.79 |     584 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  32.159 μs | 0.4858 μs |  0.9004 μs |  1.00 |     584 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  46.966 μs | 1.0820 μs |  2.0585 μs |  1.46 |   29384 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  50.423 μs | 0.4770 μs |  0.8722 μs |  1.57 |   40584 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  57.022 μs | 0.5247 μs |  0.9594 μs |  1.77 |  101384 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  80.419 μs | 2.4530 μs |  4.6670 μs |  2.50 |   10185 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  23.842 μs | 0.3996 μs |  0.7603 μs |  0.72 |     922 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  24.730 μs | 0.0793 μs |  0.1450 μs |  0.75 |    1597 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  26.768 μs | 0.3117 μs |  0.5699 μs |  0.81 |     584 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  33.000 μs | 0.2894 μs |  0.5435 μs |  1.00 |     585 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  47.667 μs | 0.2295 μs |  0.4253 μs |  1.44 |   29411 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  50.927 μs | 0.3201 μs |  0.5933 μs |  1.54 |   40584 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  56.713 μs | 0.2833 μs |  0.5250 μs |  1.72 |  101387 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  74.952 μs | 2.7873 μs |  5.3031 μs |  2.27 |   10188 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  40.901 μs | 1.6057 μs |  3.0160 μs |  0.41 |    3895 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  40.949 μs | 0.5287 μs |  0.9800 μs |  0.42 |    6747 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  44.679 μs | 0.1633 μs |  0.3068 μs |  0.45 |    1048 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  92.274 μs | 1.3503 μs |  2.5362 μs |  0.94 |   58648 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  93.876 μs | 0.7387 μs |  1.3874 μs |  0.95 |   81048 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  97.231 μs | 0.8916 μs |  1.6964 μs |  0.99 |  202648 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  98.950 μs | 2.6625 μs |  6.0098 μs |  1.00 |    1048 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      | 181.975 μs | 1.9499 μs |  3.7098 μs |  1.85 |   20261 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  42.808 μs | 0.4470 μs |  0.8396 μs |  0.41 |    4164 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  42.962 μs | 0.6968 μs |  1.3087 μs |  0.41 |    8909 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  54.333 μs | 1.2404 μs |  2.2681 μs |  0.52 |    1048 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  92.290 μs | 1.0497 μs |  1.9971 μs |  0.89 |   58978 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  94.217 μs | 0.6811 μs |  1.2960 μs |  0.91 |   81057 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  98.579 μs | 0.4387 μs |  0.8132 μs |  0.95 |  202952 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       | 103.824 μs | 2.4096 μs |  4.6425 μs |  1.00 |    1049 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       | 183.788 μs | 6.7606 μs | 12.6980 μs |  1.77 |   20323 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  71.879 μs | 2.1462 μs |  4.0834 μs |  0.34 |    9112 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  84.605 μs | 1.0466 μs |  4.1239 μs |  0.40 |    1976 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  89.371 μs | 3.3101 μs |  6.1356 μs |  0.42 |   34101 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      | 177.951 μs | 1.2405 μs |  2.2993 μs |  0.84 |  117176 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 187.908 μs | 2.0714 μs |  3.7876 μs |  0.88 |  161976 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 196.418 μs | 2.2103 μs |  4.0970 μs |  0.92 |  405176 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 212.962 μs | 4.8135 μs |  9.0408 μs |  1.00 |    1976 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 370.616 μs | 7.5332 μs | 14.3327 μs |  1.74 |   40395 B | 
|                                                         |             |            |            |           |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  80.237 μs | 0.7673 μs |  1.4222 μs |  0.36 |   15599 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  94.455 μs | 1.5251 μs |  2.9017 μs |  0.42 |   37843 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       | 102.251 μs | 1.4356 μs |  5.3810 μs |  0.46 |    1976 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       | 183.033 μs | 4.5781 μs |  8.7103 μs |  0.82 |  118991 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 185.773 μs | 1.2905 μs |  2.3919 μs |  0.83 |  162015 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 199.591 μs | 1.2164 μs |  2.2846 μs |  0.89 |  405688 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 224.129 μs | 2.3521 μs |  4.4751 μs |  1.00 |    1983 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 369.280 μs | 5.4823 μs | 21.8577 μs |  1.65 |   40609 B |