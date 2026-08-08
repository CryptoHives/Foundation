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
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.873 μs |  0.75 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   4.317 μs |  0.84 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   5.158 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   6.318 μs |  1.23 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |  11.233 μs |  2.18 |    5181 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |  12.948 μs |  2.51 |   25997 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  14.850 μs |  2.88 |   20404 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  19.058 μs |  3.70 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   4.031 μs |  0.74 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.358 μs |  0.80 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   5.431 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   6.705 μs |  1.23 |     353 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |  11.141 μs |  2.05 |    5187 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |  11.822 μs |  2.18 |   25990 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  15.395 μs |  2.84 |   20399 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  19.556 μs |  3.60 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   9.224 μs |  0.43 |    1051 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  11.412 μs |  0.53 |     692 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  16.186 μs |  0.75 |    1932 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  21.545 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  23.387 μs |  1.09 |   51928 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  26.368 μs |  1.22 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  31.248 μs |  1.45 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  33.905 μs |  1.57 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  10.424 μs |  0.47 |    1117 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  13.796 μs |  0.63 |     707 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  16.930 μs |  0.77 |    2065 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  22.018 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  23.230 μs |  1.06 |   51924 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  26.655 μs |  1.21 |   40725 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  30.796 μs |  1.40 |  104733 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  33.554 μs |  1.53 |   10330 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  18.575 μs |  0.32 |    3966 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  22.599 μs |  0.39 |    1208 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  24.339 μs |  0.42 |   12231 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  32.332 μs |  0.56 |  103608 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  40.642 μs |  0.70 |   81208 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  42.977 μs |  0.74 |  209208 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  58.139 μs |  1.00 |    1208 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  74.371 μs |  1.29 |   20414 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  19.357 μs |  0.32 |    4662 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  22.533 μs |  0.37 |    8633 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  26.520 μs |  0.44 |    1208 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  30.633 μs |  0.50 |  103561 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  35.005 μs |  0.57 |   81198 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  43.929 μs |  0.72 |  209273 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  61.232 μs |  1.01 |    1210 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  74.869 μs |  1.23 |   20425 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  27.209 μs |  0.17 |   18772 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  28.381 μs |  0.17 |   30781 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  38.594 μs |  0.24 |    2168 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  53.007 μs |  0.33 |  206968 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  54.859 μs |  0.34 |  162168 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      |  57.248 μs |  0.35 |  418167 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 158.720 μs |  0.97 |   40699 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 165.637 μs |  1.02 |    2168 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  27.023 μs |  0.16 |   17242 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  44.436 μs |  0.26 |   49962 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  49.842 μs |  0.30 |  206280 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  53.574 μs |  0.32 |    2169 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  56.185 μs |  0.33 |  162132 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  67.949 μs |  0.40 |  418569 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 159.416 μs |  0.95 |   40743 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 171.232 μs |  1.02 |    2169 B | 
