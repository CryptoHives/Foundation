| Description                                             | ThreadCount | SharedKeys | Mean       | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|----------:|----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   2.814 μs | 0.0019 μs | 0.0018 μs |  0.82 |     280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   3.420 μs | 0.0022 μs | 0.0021 μs |  1.00 |     280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   3.764 μs | 0.0041 μs | 0.0039 μs |  1.10 |     280 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   4.547 μs | 0.0043 μs | 0.0040 μs |  1.33 |     280 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   7.621 μs | 0.0190 μs | 0.0169 μs |  2.23 |   14680 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   8.289 μs | 0.0409 μs | 0.0382 μs |  2.42 |    5080 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  10.428 μs | 0.0504 μs | 0.0447 μs |  3.05 |   20280 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  12.492 μs | 0.0360 μs | 0.0337 μs |  3.65 |   50680 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.032 μs | 0.0024 μs | 0.0022 μs |  0.80 |     280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   3.781 μs | 0.0021 μs | 0.0018 μs |  1.00 |     280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   3.844 μs | 0.0023 μs | 0.0020 μs |  1.02 |     280 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   4.751 μs | 0.0061 μs | 0.0054 μs |  1.26 |     280 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   8.032 μs | 0.0480 μs | 0.0449 μs |  2.12 |   14680 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   8.513 μs | 0.0189 μs | 0.0158 μs |  2.25 |    5080 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  10.992 μs | 0.0292 μs | 0.0273 μs |  2.91 |   20280 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  12.376 μs | 0.0544 μs | 0.0509 μs |  3.27 |   50680 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   8.460 μs | 0.0139 μs | 0.0123 μs |  0.71 |    1271 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  10.529 μs | 0.0209 μs | 0.0196 μs |  0.89 |    2055 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  11.128 μs | 0.0262 μs | 0.0232 μs |  0.94 |     584 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  11.896 μs | 0.0159 μs | 0.0141 μs |  1.00 |     584 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  21.607 μs | 0.0507 μs | 0.0450 μs |  1.82 |   40584 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  21.988 μs | 0.0277 μs | 0.0259 μs |  1.85 |   29384 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  26.557 μs | 0.0600 μs | 0.0532 μs |  2.23 |  101384 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  35.599 μs | 0.0413 μs | 0.0367 μs |  2.99 |   10185 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |   8.955 μs | 0.1224 μs | 0.1145 μs |  0.65 |     973 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  11.600 μs | 0.0280 μs | 0.0234 μs |  0.84 |    1907 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  11.798 μs | 0.0246 μs | 0.0218 μs |  0.86 |     584 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  13.739 μs | 0.0660 μs | 0.0617 μs |  1.00 |     585 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  22.938 μs | 0.0332 μs | 0.0278 μs |  1.67 |   29390 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  23.742 μs | 0.0759 μs | 0.0634 μs |  1.73 |  101386 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  26.412 μs | 0.0289 μs | 0.0270 μs |  1.92 |   40584 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  36.377 μs | 0.0353 μs | 0.0295 μs |  2.65 |   10185 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  17.752 μs | 0.0785 μs | 0.0656 μs |  0.47 |    5070 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  17.877 μs | 0.0961 μs | 0.0899 μs |  0.47 |    7618 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  18.256 μs | 0.2423 μs | 0.2266 μs |  0.48 |    1048 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  38.073 μs | 0.7089 μs | 0.6962 μs |  1.00 |    1048 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  39.263 μs | 0.1448 μs | 0.1284 μs |  1.03 |   58648 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  51.070 μs | 0.0932 μs | 0.0826 μs |  1.34 |  202648 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  54.116 μs | 0.0709 μs | 0.0664 μs |  1.42 |   81048 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  86.575 μs | 0.3706 μs | 0.3467 μs |  2.27 |   20251 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  18.068 μs | 0.1116 μs | 0.1044 μs |  0.44 |    5273 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  20.311 μs | 0.1156 μs | 0.1025 μs |  0.50 |    1048 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  21.038 μs | 0.1925 μs | 0.1801 μs |  0.51 |   12009 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  40.079 μs | 0.1528 μs | 0.1429 μs |  0.98 |   59133 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  40.909 μs | 0.6772 μs | 0.6334 μs |  1.00 |    1049 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  51.262 μs | 0.1449 μs | 0.1356 μs |  1.25 |  202805 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  53.365 μs | 0.0772 μs | 0.0722 μs |  1.30 |   81040 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  89.448 μs | 0.2345 μs | 0.2193 μs |  2.19 |   20258 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  32.690 μs | 0.1715 μs | 0.1604 μs |  0.48 |   15175 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  33.523 μs | 0.6700 μs | 1.6562 μs |  0.49 |    1976 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  37.952 μs | 0.1353 μs | 0.1266 μs |  0.55 |   36177 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      |  68.594 μs | 1.3087 μs | 1.1601 μs |  1.00 |    1976 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      |  79.811 μs | 0.9757 μs | 0.9127 μs |  1.16 |  405176 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  86.824 μs | 0.2132 μs | 0.1890 μs |  1.27 |  161976 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  97.811 μs | 0.1824 μs | 0.1706 μs |  1.43 |  117176 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 174.506 μs | 1.7613 μs | 1.6476 μs |  2.54 |   40382 B | 
|                                                         |             |            |            |           |           |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  36.489 μs | 0.1982 μs | 0.1854 μs |  0.45 |   17500 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  43.491 μs | 1.0040 μs | 2.9286 μs |  0.54 |    1976 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  44.152 μs | 0.2707 μs | 0.2532 μs |  0.55 |   39753 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       |  81.038 μs | 1.5991 μs | 2.8836 μs |  1.00 |    1981 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  89.421 μs | 0.3662 μs | 0.3425 μs |  1.10 |  405913 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  94.096 μs | 0.0884 μs | 0.0826 μs |  1.16 |  120194 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 109.438 μs | 0.1327 μs | 0.1177 μs |  1.35 |  161950 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 176.476 μs | 1.2692 μs | 1.0598 μs |  2.18 |   40417 B |