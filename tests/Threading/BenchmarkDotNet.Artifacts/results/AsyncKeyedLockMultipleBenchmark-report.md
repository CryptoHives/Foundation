```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                                          | KeyCount | Iterations | cancellationType | Mean            | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |----------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        30.31 ns |  0.49 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        61.31 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        61.78 ns |  1.01 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |        73.34 ns |  1.20 |      48 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |        82.13 ns |  1.34 |     256 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       105.95 ns |  1.73 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        31.33 ns |  0.47 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        61.79 ns |  0.92 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        66.99 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |        72.33 ns |  1.08 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |       102.24 ns |  1.53 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        34.32 ns |  0.56 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |        60.93 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |        71.96 ns |  1.18 |      48 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |       121.25 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |       518.69 ns |  4.28 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |       647.47 ns |  5.34 |     544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |       732.68 ns |  6.05 |     632 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |       753.85 ns |  6.22 |     432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |       778.26 ns |  6.42 |     952 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |       138.42 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |       696.49 ns |  5.03 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |       882.57 ns |  6.38 |     832 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |       941.14 ns |  6.80 |     720 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     1,003.76 ns |  7.25 |    1240 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       164.17 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |       757.43 ns |  4.61 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |       988.99 ns |  6.03 |     824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |       877.97 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     3,512.97 ns |  4.00 |    2456 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     3,756.61 ns |  4.28 |    2520 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     3,763.37 ns |  4.29 |    2720 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     3,798.11 ns |  4.33 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     4,479.84 ns |  5.10 |    4144 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |       905.37 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |     5,517.88 ns |  6.09 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |     5,587.71 ns |  6.17 |    5336 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |     5,632.49 ns |  6.22 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |     6,953.51 ns |  7.68 |    7024 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     1,205.31 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |     5,575.18 ns |  4.63 |    6544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |     5,937.55 ns |  4.93 |    6440 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |     8,358.37 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    37,802.80 ns |  4.52 |   23399 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    38,103.73 ns |  4.56 |   23664 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    38,282.72 ns |  4.58 |   23464 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    39,403.38 ns |  4.71 |   29527 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    47,288.62 ns |  5.66 |   40208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |     8,468.15 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    58,173.02 ns |  6.87 |   52200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |    62,140.99 ns |  7.34 |   52264 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |    63,921.04 ns |  7.55 |   58328 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |    76,693.16 ns |  9.06 |   69008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |    11,740.10 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |    63,206.81 ns |  5.38 |   64208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |    65,287.66 ns |  5.56 |   62664 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |        98.51 ns |  0.49 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |       202.20 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       205.09 ns |  1.01 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       288.45 ns |  1.43 |     192 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       297.55 ns |  1.47 |    1024 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |       400.94 ns |  1.98 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |        96.89 ns |  0.48 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |       203.15 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       213.38 ns |  1.05 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       276.87 ns |  1.36 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |       387.64 ns |  1.91 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |       105.51 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |       203.73 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       284.34 ns |  1.40 |     192 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |       418.07 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     1,425.77 ns |  3.41 |    1064 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     1,590.77 ns |  3.81 |    2067 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     1,605.65 ns |  3.84 |    1226 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     1,641.96 ns |  3.93 |    3339 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     2,098.84 ns |  5.02 |    1744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |       479.76 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     2,137.33 ns |  4.46 |    2216 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     2,263.88 ns |  4.72 |    4524 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     2,298.11 ns |  4.79 |    2419 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     3,051.05 ns |  6.36 |    2896 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |       626.68 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     2,297.59 ns |  3.67 |    2836 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     2,543.88 ns |  4.06 |    2704 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     2,787.73 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    16,883.23 ns |  6.06 |   10490 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    17,520.88 ns |  6.29 |   13791 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    18,128.07 ns |  6.50 |    9470 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    18,681.03 ns |  6.70 |    9675 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    21,415.79 ns |  7.68 |   16207 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |     3,531.08 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    25,080.58 ns |  7.10 |   20997 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    26,342.51 ns |  7.46 |   25322 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    26,641.02 ns |  7.55 |   21207 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    32,064.51 ns |  9.08 |   27728 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |     5,044.50 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    26,557.55 ns |  5.27 |   25367 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    26,919.55 ns |  5.34 |   25808 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    28,070.07 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   129,434.41 ns |  4.61 |  117488 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   129,751.62 ns |  4.62 |   94032 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   136,120.58 ns |  4.85 |   93208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   139,183.73 ns |  4.96 |   93000 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   166,299.59 ns |  5.93 |  160208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    36,023.40 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   193,265.14 ns |  5.37 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   209,039.06 ns |  5.80 |  208200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   215,308.77 ns |  5.98 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   278,175.04 ns |  7.72 |  275408 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |    46,735.75 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   201,526.92 ns |  4.31 |  250008 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   216,331.83 ns |  4.63 |  256208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       392.52 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |       752.46 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |       776.29 ns |  1.03 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |     1,070.45 ns |  1.42 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |     1,125.85 ns |  1.50 |    4096 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     1,562.82 ns |  2.08 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       398.63 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |       760.84 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |       773.15 ns |  1.02 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |     1,083.80 ns |  1.42 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     1,560.82 ns |  2.05 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |       403.72 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |       754.67 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |     1,097.80 ns |  1.45 |     768 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     1,635.86 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |     5,003.74 ns |  3.06 |    3848 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |     5,582.73 ns |  3.41 |    7826 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     5,661.32 ns |  3.46 |    4488 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |     6,314.60 ns |  3.86 |   12941 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |     7,108.08 ns |  4.35 |    6545 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     1,867.42 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |     6,931.21 ns |  3.71 |    9119 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |     7,942.63 ns |  4.25 |   17587 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |     8,235.04 ns |  4.41 |    8458 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    16,203.73 ns |  8.68 |   11213 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     2,604.24 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |     7,403.28 ns |  2.84 |   10811 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    11,011.03 ns |  4.23 |   10403 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |    11,376.36 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    54,586.15 ns |  4.80 |   37320 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    58,089.26 ns |  5.11 |   54608 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |    58,678.08 ns |  5.16 |   41424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    61,117.12 ns |  5.37 |   38104 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |    66,057.55 ns |  5.81 |   64208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    14,622.21 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |    83,040.21 ns |  5.68 |   83400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |    85,614.99 ns |  5.86 |  100688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |    89,244.74 ns |  6.10 |   84184 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   107,391.68 ns |  7.34 |  110288 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    19,185.56 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |    87,887.11 ns |  4.58 |  102608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |    99,979.47 ns |  5.21 |  100824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |   118,806.43 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             |   475,524.00 ns |  4.00 |  375504 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   496,538.27 ns |  4.18 |  469328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   496,693.96 ns |  4.18 |  372184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   521,596.50 ns |  4.39 |  371400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             |   611,807.41 ns |  5.15 |  640208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   148,755.92 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     |   754,027.97 ns |  5.07 |  832984 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     |   799,142.73 ns |  5.37 |  832200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     |   820,323.12 ns |  5.51 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,029,972.41 ns |  6.92 | 1101008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   216,462.81 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            |   772,669.00 ns |  3.57 |  999384 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            |   811,617.81 ns |  3.75 | 1024208 B | 
