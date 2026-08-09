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
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        29.15 ns |  0.49 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        58.91 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        61.69 ns |  1.05 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |        72.43 ns |  1.23 |      48 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |        81.16 ns |  1.38 |     256 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       102.38 ns |  1.74 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        30.61 ns |  0.51 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        60.30 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        69.28 ns |  1.15 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |        71.44 ns |  1.18 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |       101.28 ns |  1.68 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        31.95 ns |  0.53 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |        60.20 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |        71.27 ns |  1.18 |      48 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |       114.43 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |       498.76 ns |  4.36 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |       664.26 ns |  5.81 |     544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |       731.84 ns |  6.40 |     632 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |       750.56 ns |  6.56 |     952 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |       780.87 ns |  6.82 |     432 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |       137.32 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |       688.77 ns |  5.02 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |       846.81 ns |  6.17 |     832 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |       937.79 ns |  6.83 |    1240 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |       951.65 ns |  6.93 |     720 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       158.25 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |       763.63 ns |  4.83 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     1,011.31 ns |  6.39 |     824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |       730.74 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     3,560.81 ns |  4.87 |    2456 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     3,722.90 ns |  5.09 |    3544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     3,780.42 ns |  5.17 |    2720 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     4,047.20 ns |  5.54 |    2520 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     4,634.23 ns |  6.34 |    4144 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |       890.84 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |     5,499.59 ns |  6.17 |    5336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |     5,501.97 ns |  6.18 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |     5,645.22 ns |  6.34 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |     6,806.82 ns |  7.64 |    7024 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     1,187.45 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |     5,564.80 ns |  4.69 |    6544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |     5,905.88 ns |  4.97 |    6440 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |     7,073.08 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    37,042.83 ns |  5.24 |   23399 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    38,552.64 ns |  5.45 |   23658 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    39,173.68 ns |  5.54 |   23464 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    39,258.52 ns |  5.55 |   29527 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    44,654.59 ns |  6.31 |   40208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |     8,595.24 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |    60,675.65 ns |  7.06 |   52264 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    61,121.99 ns |  7.11 |   52200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |    61,840.36 ns |  7.19 |   58328 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |    71,458.56 ns |  8.31 |   69008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |    12,407.51 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |    61,565.79 ns |  4.96 |   64208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |    62,696.38 ns |  5.05 |   62664 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |       104.79 ns |  0.49 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       203.10 ns |  0.95 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |       212.86 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       270.14 ns |  1.27 |     192 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       308.88 ns |  1.45 |    1024 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |       394.00 ns |  1.85 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |       105.19 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |       202.28 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       206.74 ns |  1.02 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       272.13 ns |  1.35 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |       384.75 ns |  1.90 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |       106.84 ns |  0.50 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |       211.64 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       269.67 ns |  1.27 |     192 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |       417.97 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     1,467.49 ns |  3.51 |    1064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     1,547.60 ns |  3.70 |    1223 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     1,577.59 ns |  3.77 |    2068 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     1,676.88 ns |  4.01 |    3339 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     1,954.98 ns |  4.68 |    1744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |       484.52 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     2,179.54 ns |  4.50 |    2216 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     2,277.22 ns |  4.70 |    2415 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     2,360.28 ns |  4.87 |    4523 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     2,986.90 ns |  6.17 |    2896 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |       622.30 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     2,251.23 ns |  3.62 |    2834 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     2,501.03 ns |  4.03 |    2704 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     2,802.04 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    17,325.27 ns |  6.18 |   10490 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    17,400.24 ns |  6.21 |   13792 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    17,449.73 ns |  6.23 |    9665 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    17,843.07 ns |  6.37 |    9479 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    21,105.39 ns |  7.53 |   16208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |     3,621.48 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    24,965.56 ns |  6.89 |   21000 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    26,805.08 ns |  7.40 |   25328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    27,654.44 ns |  7.64 |   21208 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    30,326.82 ns |  8.37 |   27728 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |     4,788.96 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    26,056.19 ns |  5.44 |   25808 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    26,828.03 ns |  5.60 |   25367 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    27,366.00 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   129,103.12 ns |  4.72 |  117488 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   129,202.53 ns |  4.72 |   94032 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   132,493.44 ns |  4.84 |   93000 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   132,813.94 ns |  4.85 |   93208 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   161,290.69 ns |  5.89 |  160208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    36,123.15 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   196,043.91 ns |  5.43 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   200,619.02 ns |  5.55 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   213,103.00 ns |  5.90 |  208200 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   250,882.33 ns |  6.95 |  275408 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |    46,988.56 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   200,770.31 ns |  4.27 |  250008 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   214,013.61 ns |  4.55 |  256208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       376.08 ns |  0.50 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |       752.62 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |       766.92 ns |  1.02 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |     1,046.06 ns |  1.39 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |     1,170.73 ns |  1.56 |    4096 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     1,676.04 ns |  2.23 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       378.09 ns |  0.51 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |       741.73 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     1,022.61 ns |  1.38 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |     1,076.63 ns |  1.45 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     1,561.09 ns |  2.10 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |       405.40 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |       745.03 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |     1,042.97 ns |  1.40 |     768 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     1,630.17 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |     4,928.20 ns |  3.02 |    3848 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |     5,643.84 ns |  3.46 |    7822 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     5,768.20 ns |  3.54 |    4487 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |     6,285.65 ns |  3.86 |   12940 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |     7,346.72 ns |  4.51 |    6546 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     1,840.03 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |     6,530.00 ns |  3.55 |    9118 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |     7,689.96 ns |  4.18 |   17583 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |     8,119.78 ns |  4.41 |    8461 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    15,728.05 ns |  8.55 |   11210 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     2,346.82 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |     7,108.44 ns |  3.03 |   10797 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    10,564.23 ns |  4.50 |   10406 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |    11,586.23 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    54,034.51 ns |  4.66 |   37320 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |    56,548.67 ns |  4.88 |   41361 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    58,299.50 ns |  5.03 |   38104 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    59,289.64 ns |  5.12 |   54608 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |    65,303.67 ns |  5.64 |   64208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    14,676.01 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |    83,719.38 ns |  5.71 |   83400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |    88,398.00 ns |  6.03 |  100688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |    89,397.54 ns |  6.10 |   84184 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   104,563.67 ns |  7.13 |  110288 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    21,572.33 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |    84,879.02 ns |  3.93 |  102608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |    89,690.88 ns |  4.16 |  100824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |   116,363.24 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   485,984.69 ns |  4.18 |  372184 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   489,346.76 ns |  4.21 |  469328 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             |   493,830.80 ns |  4.24 |  375504 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   523,892.34 ns |  4.50 |  371400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             |   605,154.83 ns |  5.20 |  640208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   149,795.49 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     |   749,679.37 ns |  5.00 |  832984 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     |   782,643.63 ns |  5.23 |  832200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     |   791,949.66 ns |  5.29 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,008,220.76 ns |  6.73 | 1101008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   195,240.31 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            |   767,298.45 ns |  3.93 |  999384 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            |   807,697.56 ns |  4.14 | 1024208 B | 
