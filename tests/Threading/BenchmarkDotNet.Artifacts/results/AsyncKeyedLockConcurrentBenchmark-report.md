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
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.721 μs |  0.48 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   4.076 μs |  0.52 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   5.817 μs |  0.75 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   7.802 μs |  1.00 |     355 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   7.895 μs |  1.01 |    5160 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |  12.278 μs |  1.57 |   25991 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  13.292 μs |  1.70 |   20389 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  19.626 μs |  2.52 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.821 μs |  0.48 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.265 μs |  0.54 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   6.564 μs |  0.83 |     353 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |   7.430 μs |  0.94 |    5157 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   7.892 μs |  1.00 |     355 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |  13.116 μs |  1.66 |   25993 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  14.509 μs |  1.84 |   20398 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  19.771 μs |  2.51 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   8.966 μs |  0.37 |    1017 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |   9.128 μs |  0.38 |     677 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  16.625 μs |  0.69 |    1931 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  23.664 μs |  0.98 |   51927 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  24.160 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  25.458 μs |  1.05 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  28.544 μs |  1.18 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  33.700 μs |  1.39 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |  11.288 μs |  0.43 |    1002 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  11.721 μs |  0.45 |     693 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  17.656 μs |  0.67 |    2146 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  23.401 μs |  0.89 |   51925 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  25.815 μs |  0.98 |   40726 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  26.268 μs |  1.00 |     738 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  29.680 μs |  1.13 |  104732 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  33.604 μs |  1.28 |   10329 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  18.635 μs |  0.34 |    5448 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  23.192 μs |  0.42 |    1207 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  23.583 μs |  0.43 |   10210 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  34.487 μs |  0.62 |   81207 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  36.698 μs |  0.66 |  209207 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  37.747 μs |  0.68 |  103607 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  55.418 μs |  1.00 |    1207 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  78.066 μs |  1.41 |   20411 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  18.706 μs |  0.33 |    4748 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  24.187 μs |  0.43 |   12408 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  26.235 μs |  0.46 |    1207 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  33.341 μs |  0.59 |   81206 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  37.180 μs |  0.66 |  103582 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  41.648 μs |  0.73 |  209262 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  56.699 μs |  1.00 |    1228 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  77.884 μs |  1.37 |   20416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  26.309 μs |  0.18 |   18140 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  30.955 μs |  0.22 |   33084 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  41.494 μs |  0.29 |    2165 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  54.417 μs |  0.38 |  206959 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  54.453 μs |  0.38 |  162163 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      |  55.867 μs |  0.39 |  418156 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 142.242 μs |  1.00 |    2168 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 160.588 μs |  1.13 |   40663 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  31.952 μs |  0.22 |   38157 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  34.148 μs |  0.23 |   21766 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  51.968 μs |  0.36 |  206336 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  53.016 μs |  0.36 |    2166 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  66.539 μs |  0.46 |  162125 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  67.676 μs |  0.46 |  418507 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 146.141 μs |  1.00 |    2191 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 160.530 μs |  1.10 |   40700 B | 
