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
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | False      |   3.806 μs |  0.75 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | False      |   4.065 μs |  0.80 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | False      |   5.062 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | False      |   6.341 μs |  1.25 |     353 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | False      |   9.807 μs |  1.94 |    5183 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | False      |  10.821 μs |  2.14 |   25991 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | False      |  12.803 μs |  2.53 |   20390 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | False      |  19.095 μs |  3.77 |   52415 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1           | True       |   3.900 μs |  0.75 |     352 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 1           | True       |   4.186 μs |  0.80 |     352 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 1           | True       |   5.209 μs |  1.00 |     352 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 1           | True       |   6.614 μs |  1.27 |     353 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 1           | True       |  10.137 μs |  1.95 |    5188 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 1           | True       |  12.068 μs |  2.32 |   25992 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 1           | True       |  14.404 μs |  2.77 |   20404 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 1           | True       |  19.473 μs |  3.74 |   52416 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | False      |   9.342 μs |  0.46 |    1135 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | False      |  10.036 μs |  0.49 |     683 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | False      |  16.800 μs |  0.83 |    2529 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | False      |  20.336 μs |  1.00 |     727 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | False      |  22.904 μs |  1.13 |   51928 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | False      |  25.241 μs |  1.24 |   40728 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | False      |  29.143 μs |  1.43 |  104728 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | False      |  34.343 μs |  1.69 |   10328 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 2           | True       |   9.262 μs |  0.46 |     989 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 2           | True       |  11.350 μs |  0.56 |     691 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 2           | True       |  17.030 μs |  0.84 |    2522 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 2           | True       |  20.175 μs |  1.00 |     728 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 2           | True       |  23.016 μs |  1.14 |   51925 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 2           | True       |  25.485 μs |  1.26 |   40727 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 2           | True       |  28.606 μs |  1.42 |  104731 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 2           | True       |  31.053 μs |  1.54 |   10331 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | False      |  18.286 μs |  0.42 |    4282 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | False      |  19.647 μs |  0.45 |    1207 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | False      |  22.339 μs |  0.52 |   10025 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | False      |  31.680 μs |  0.73 |  103608 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | False      |  33.783 μs |  0.78 |   81208 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | False      |  37.432 μs |  0.87 |  209208 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | False      |  43.199 μs |  1.00 |    1208 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | False      |  75.742 μs |  1.75 |   20417 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4           | True       |  18.710 μs |  0.43 |    4555 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 4           | True       |  23.553 μs |  0.55 |    1208 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 4           | True       |  24.193 μs |  0.56 |   12678 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 4           | True       |  31.651 μs |  0.73 |  103557 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 4           | True       |  33.562 μs |  0.78 |   81204 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 4           | True       |  36.041 μs |  0.84 |  209280 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 4           | True       |  43.092 μs |  1.00 |    1210 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 4           | True       |  75.952 μs |  1.76 |   20428 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | False      |  22.961 μs |  0.22 |   14451 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | False      |  29.066 μs |  0.28 |   35022 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | False      |  35.103 μs |  0.33 |    2168 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | False      |  49.685 μs |  0.47 |  206968 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | False      |  53.621 μs |  0.51 |  162168 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | False      |  67.567 μs |  0.64 |  418168 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | False      | 104.859 μs |  1.00 |    2168 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | False      | 158.552 μs |  1.51 |   40693 B | 
|                                                         |             |            |            |       |           | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 8           | True       |  27.415 μs |  0.25 |   20069 B | 
| Concurrent · AsyncKeyedLock · AsyncUtilities (Striped)  | 8           | True       |  44.345 μs |  0.40 |   52206 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores (Striped) | 8           | True       |  50.083 μs |  0.45 |    2168 B | 
| Concurrent · AsyncKeyedLock · RefImpl                   | 8           | True       |  53.749 μs |  0.49 |  206239 B | 
| Concurrent · AsyncKeyedLock · KeyedSemaphores           | 8           | True       |  53.862 μs |  0.49 |  162096 B | 
| Concurrent · AsyncKeyedLock · Dao.IndividualLock        | 8           | True       |  68.169 μs |  0.62 |  418620 B | 
| Concurrent · AsyncKeyedLock · Pooled                    | 8           | True       | 110.560 μs |  1.00 |    2170 B | 
| Concurrent · AsyncKeyedLock · AsyncKeyedLock            | 8           | True       | 164.410 μs |  1.49 |   40856 B | 
