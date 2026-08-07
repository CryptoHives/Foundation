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
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        30.08 ns |  0.36 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        62.51 ns |  0.75 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |        74.15 ns |  0.89 |      48 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        83.60 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |        85.70 ns |  1.03 |     256 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       102.51 ns |  1.23 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        28.61 ns |  0.31 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        65.17 ns |  0.71 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |        72.45 ns |  0.79 |      48 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        91.47 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |       105.83 ns |  1.16 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |       536.98 ns |  0.74 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |       664.59 ns |  0.92 |     544 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |       724.56 ns |  1.00 |     408 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |       729.25 ns |  1.01 |     632 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |       782.69 ns |  1.08 |     952 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |       801.60 ns |  1.11 |     432 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |       714.92 ns |  0.88 |     656 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |       811.14 ns |  1.00 |     408 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |       870.35 ns |  1.07 |     832 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |       890.96 ns |  1.10 |     720 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |       937.99 ns |  1.16 |    1240 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     3,850.20 ns |  0.80 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     3,866.76 ns |  0.80 |    2456 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     3,881.73 ns |  0.81 |    2720 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     3,957.68 ns |  0.82 |    2520 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     4,595.64 ns |  0.95 |    4144 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     4,818.33 ns |  1.00 |    2496 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     5,162.35 ns |  1.00 |    2496 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |     5,740.35 ns |  1.11 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |     5,822.66 ns |  1.13 |    5336 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |     5,936.71 ns |  1.15 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |     6,816.72 ns |  1.32 |    7024 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    37,326.32 ns |  0.77 |   23390 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    38,156.80 ns |  0.79 |   29521 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    39,001.36 ns |  0.81 |   23658 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    39,265.26 ns |  0.81 |   23455 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    46,837.83 ns |  0.97 |   40208 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |    48,222.82 ns |  1.00 |   23436 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |    52,693.07 ns |  1.00 |   23439 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    60,524.23 ns |  1.15 |   52199 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |    60,821.83 ns |  1.15 |   58326 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |    62,953.07 ns |  1.19 |   52262 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |    73,235.75 ns |  1.39 |   69007 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |       100.37 ns |  0.36 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       207.56 ns |  0.74 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       271.58 ns |  0.97 |     192 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |       280.92 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       304.67 ns |  1.08 |    1024 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |       395.36 ns |  1.41 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |       104.79 ns |  0.35 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       213.46 ns |  0.71 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |       298.58 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |       402.01 ns |  1.35 |    2080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       404.74 ns |  1.36 |     192 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     1,523.82 ns |  0.79 |    1064 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     1,632.02 ns |  0.85 |    2068 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     1,703.71 ns |  0.89 |    1226 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     1,755.64 ns |  0.91 |    3335 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |     1,923.33 ns |  1.00 |    1101 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     2,055.65 ns |  1.07 |    1744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     2,104.83 ns |  1.00 |    1104 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     2,253.43 ns |  1.07 |    2216 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     2,297.27 ns |  1.09 |    2415 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     2,403.99 ns |  1.14 |    4523 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     2,992.12 ns |  1.42 |    2896 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    17,065.49 ns |  0.78 |   10480 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    17,637.08 ns |  0.80 |    9474 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    17,785.38 ns |  0.81 |    9668 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    18,337.43 ns |  0.83 |   13778 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    21,353.06 ns |  0.97 |   16204 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |    21,972.12 ns |  1.00 |    9511 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |    24,310.03 ns |  1.00 |    9517 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    25,854.01 ns |  1.06 |   20998 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    26,476.94 ns |  1.09 |   25322 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    27,103.71 ns |  1.12 |   21205 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    31,722.88 ns |  1.31 |   27721 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   134,450.49 ns |  0.82 |   94032 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   135,071.24 ns |  0.83 |  117488 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   135,984.94 ns |  0.83 |   93208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   136,042.20 ns |  0.83 |   93000 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |   163,207.66 ns |  1.00 |  133776 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   163,398.33 ns |  1.00 |  160208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |   177,590.18 ns |  1.00 |  133776 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   198,471.56 ns |  1.12 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   204,060.18 ns |  1.15 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   210,986.07 ns |  1.19 |  208200 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   257,643.46 ns |  1.45 |  275408 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       417.30 ns |  0.40 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |       886.86 ns |  0.85 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     1,042.29 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |     1,065.82 ns |  1.02 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |     1,168.15 ns |  1.12 |    4096 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     1,596.89 ns |  1.53 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       380.25 ns |  0.37 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |       792.67 ns |  0.77 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     1,031.26 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |     1,053.83 ns |  1.02 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     1,568.42 ns |  1.52 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     5,116.93 ns |  1.00 |    3773 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |     5,145.93 ns |  1.01 |    3848 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     5,645.79 ns |  1.10 |    4485 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |     5,795.14 ns |  1.13 |    7825 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |     6,262.83 ns |  1.22 |   12937 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |     7,044.52 ns |  1.38 |    6544 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     6,825.12 ns |  1.00 |    3850 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |     7,054.14 ns |  1.04 |    9129 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |     8,020.53 ns |  1.18 |   17588 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |     8,414.54 ns |  1.23 |    8461 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    16,454.98 ns |  2.42 |   11215 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    56,486.09 ns |  0.76 |   37319 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    59,040.65 ns |  0.79 |   38095 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |    60,370.74 ns |  0.81 |   41419 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    60,647.90 ns |  0.81 |   54608 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |    68,386.15 ns |  0.92 |   64207 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |    74,540.32 ns |  1.00 |   39791 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    81,419.30 ns |  1.00 |   39789 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |    88,497.17 ns |  1.09 |   84183 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |    90,092.35 ns |  1.11 |  100688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |    92,595.66 ns |  1.14 |   83400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   111,485.65 ns |  1.37 |  110288 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             |   509,396.25 ns |  0.79 |  375504 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   516,154.88 ns |  0.80 |  372184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   519,313.25 ns |  0.81 |  371400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   522,198.69 ns |  0.81 |  469328 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             |   637,969.41 ns |  0.99 |  640208 B | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |   643,660.21 ns |  1.00 |  592752 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   719,547.72 ns |  1.00 |  592752 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     |   787,786.35 ns |  1.09 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     |   794,378.47 ns |  1.10 |  832200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     |   804,165.98 ns |  1.12 |  832984 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,039,626.05 ns |  1.44 | 1101008 B | 
