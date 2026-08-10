| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.691 μs |  0.91 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   3.970 μs |  0.98 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.070 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   4.241 μs |  1.04 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   6.635 μs |  1.63 |    5152 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   6.816 μs |  1.67 |   14752 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  11.884 μs |  2.92 |   20414 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  14.629 μs |  3.59 |   52414 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.878 μs |  0.91 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.178 μs |  0.99 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   4.180 μs |  0.99 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   4.239 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   6.910 μs |  1.63 |    5153 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   7.117 μs |  1.68 |   14754 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  12.709 μs |  3.00 |   20415 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  14.584 μs |  3.44 |   52414 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  12.773 μs |  0.87 |     727 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  14.758 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  15.541 μs |  1.05 |    1162 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  16.844 μs |  1.14 |    1592 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  21.760 μs |  1.47 |   29528 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  25.134 μs |  1.70 |   40727 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  25.956 μs |  1.76 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  36.266 μs |  2.46 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  13.221 μs |  0.88 |     727 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  15.098 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  17.662 μs |  1.17 |    1352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  19.969 μs |  1.32 |    2068 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  22.280 μs |  1.48 |   29529 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  25.289 μs |  1.67 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  26.290 μs |  1.74 |  104730 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  35.379 μs |  2.34 |   10335 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  34.929 μs |  0.60 |    1180 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  36.450 μs |  0.63 |    3625 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  43.794 μs |  0.75 |    8012 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  46.633 μs |  0.80 |   58803 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  52.766 μs |  0.91 |   81201 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  54.958 μs |  0.95 |  209201 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  58.014 μs |  1.00 |    1199 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      | 110.983 μs |  1.91 |   20429 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  41.650 μs |  0.69 |    1186 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  43.925 μs |  0.73 |    5468 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  46.703 μs |  0.77 |    8901 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  53.377 μs |  0.89 |   81140 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  60.359 μs |  1.00 |    1205 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  63.513 μs |  1.05 |   60100 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  73.236 μs |  1.21 |  209002 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       | 112.146 μs |  1.86 |   20605 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  72.791 μs |  0.19 |   17114 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  83.861 μs |  0.22 |   39152 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  85.036 μs |  0.22 |    2155 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      | 135.573 μs |  0.36 |  117361 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      | 141.785 μs |  0.37 |  162164 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      | 146.821 μs |  0.39 |  418164 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 298.799 μs |  0.79 |   40741 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 383.431 μs |  1.01 |    2167 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  86.747 μs |  0.20 |   38770 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  95.894 μs |  0.22 |   23782 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       | 124.028 μs |  0.29 |    2164 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       | 140.547 μs |  0.33 |  119781 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       | 146.406 μs |  0.34 |  161902 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       | 151.283 μs |  0.35 |  419080 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 352.228 μs |  0.82 |   41515 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 444.899 μs |  1.04 |    2192 B |