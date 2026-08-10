| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.596 μs |  0.81 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   3.754 μs |  0.84 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.452 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   5.794 μs |  1.30 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   6.891 μs |  1.55 |    5153 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |   7.078 μs |  1.59 |   14757 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  10.240 μs |  2.30 |   20382 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  14.767 μs |  3.32 |   52405 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.621 μs |  0.76 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   3.937 μs |  0.83 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   4.737 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   6.547 μs |  1.38 |     354 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   6.862 μs |  1.45 |    5153 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   7.157 μs |  1.51 |   14757 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |   9.602 μs |  2.03 |   20363 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  15.253 μs |  3.22 |   52412 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   9.139 μs |  0.55 |    1038 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  10.489 μs |  0.63 |     686 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  15.195 μs |  0.91 |    2264 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  16.726 μs |  1.00 |     726 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  19.760 μs |  1.18 |   29528 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  22.049 μs |  1.32 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  24.707 μs |  1.48 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  34.011 μs |  2.03 |   10329 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |   9.781 μs |  0.54 |     681 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  10.112 μs |  0.56 |     906 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  15.651 μs |  0.86 |    1837 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  18.146 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  20.080 μs |  1.11 |   29555 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  22.466 μs |  1.24 |   40727 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  23.927 μs |  1.32 |  104738 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  34.143 μs |  1.88 |   10330 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  18.666 μs |  0.48 |    4889 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  20.922 μs |  0.54 |    8257 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  22.581 μs |  0.58 |    1208 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  33.567 μs |  0.86 |   58808 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  34.977 μs |  0.90 |   81208 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  39.056 μs |  1.00 |    1208 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  42.229 μs |  1.08 |  209208 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  85.683 μs |  2.19 |   20416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  18.986 μs |  0.45 |    4800 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  22.852 μs |  0.54 |   11189 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  25.349 μs |  0.60 |    1208 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  32.551 μs |  0.77 |   58919 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  33.569 μs |  0.80 |  209262 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  35.853 μs |  0.85 |   81188 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  42.120 μs |  1.00 |    1209 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  85.646 μs |  2.03 |   20419 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  23.785 μs |  0.22 |   15817 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  26.238 μs |  0.24 |   29189 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  32.358 μs |  0.30 |    2168 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  53.321 μs |  0.49 |  117368 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  55.770 μs |  0.51 |  162168 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      |  70.481 μs |  0.65 |  418168 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 109.070 μs |  1.00 |    2168 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 163.132 μs |  1.50 |   40674 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  33.318 μs |  0.28 |   39041 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  34.404 μs |  0.29 |   22514 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  45.550 μs |  0.39 |    2168 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  51.798 μs |  0.44 |  162088 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  53.580 μs |  0.46 |  119093 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  55.230 μs |  0.47 |  418843 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 117.191 μs |  1.00 |    2169 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 171.513 μs |  1.47 |   40846 B |