```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                                             | ThreadCount | SharedKeys | Mean       | Ratio | Allocated | 
|-------------------------------------------------------- |------------ |----------- |-----------:|------:|----------:|
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.872 μs |  0.79 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   4.140 μs |  0.84 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   4.915 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   6.124 μs |  1.25 |     353 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   8.611 μs |  1.75 |    5163 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |  10.225 μs |  2.08 |   25971 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  13.877 μs |  2.82 |   20410 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  17.977 μs |  3.66 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.966 μs |  0.75 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.228 μs |  0.80 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   5.293 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   6.975 μs |  1.32 |     354 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   8.604 μs |  1.63 |    5166 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |   9.804 μs |  1.85 |   25973 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  12.991 μs |  2.45 |   20410 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  17.889 μs |  3.38 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |  10.363 μs |  0.53 |    1030 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  11.375 μs |  0.59 |     694 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  16.495 μs |  0.85 |    2265 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  19.402 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  22.939 μs |  1.18 |   51927 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  26.865 μs |  1.38 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  29.461 μs |  1.52 |  104725 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  34.093 μs |  1.76 |   10325 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  10.061 μs |  0.50 |    1018 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  12.586 μs |  0.63 |     708 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  16.667 μs |  0.83 |    1921 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  20.031 μs |  1.00 |     726 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  22.893 μs |  1.14 |   51908 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  25.024 μs |  1.25 |   40716 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  28.480 μs |  1.42 |  104735 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  33.962 μs |  1.70 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  16.642 μs |  0.36 |    3335 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  20.840 μs |  0.45 |    7915 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  23.640 μs |  0.51 |    1206 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  34.128 μs |  0.74 |  103606 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  35.278 μs |  0.77 |   81207 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  38.090 μs |  0.83 |  209205 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  46.096 μs |  1.00 |    1205 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  77.481 μs |  1.68 |   20410 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  19.125 μs |  0.40 |    5765 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  22.140 μs |  0.47 |    9443 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  25.214 μs |  0.53 |    1205 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  31.741 μs |  0.67 |  103564 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  35.273 μs |  0.74 |   81196 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  43.075 μs |  0.91 |  209284 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  47.418 μs |  1.00 |    1207 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  77.370 μs |  1.63 |   20417 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  23.843 μs |  0.20 |   15197 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  28.240 μs |  0.24 |   32074 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  40.856 μs |  0.34 |    2162 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  55.098 μs |  0.46 |  206952 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  55.337 μs |  0.47 |  162158 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      |  56.697 μs |  0.48 |  418156 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 118.914 μs |  1.00 |    2167 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 165.300 μs |  1.39 |   40664 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  27.181 μs |  0.23 |   18860 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  33.480 μs |  0.28 |   39687 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  50.602 μs |  0.42 |    2162 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  51.193 μs |  0.43 |  206370 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  67.552 μs |  0.56 |  162132 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  68.993 μs |  0.57 |  418550 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 120.731 μs |  1.00 |    2169 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 163.754 μs |  1.36 |   40729 B | 
