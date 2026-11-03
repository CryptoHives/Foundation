| Description                                          | KeyCount | Iterations | cancellationType | Mean            | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |----------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        21.11 ns |  0.72 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        29.51 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        33.07 ns |  1.12 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |        65.54 ns |  2.22 |     144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |        68.54 ns |  2.32 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |        97.86 ns |  3.32 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        21.02 ns |  0.70 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        29.97 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        37.74 ns |  1.26 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |        72.39 ns |  2.42 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |        98.39 ns |  3.28 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        21.68 ns |  0.72 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |        29.91 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |        68.24 ns |  2.28 |      48 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |        72.95 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     1,302.58 ns | 17.86 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     1,418.50 ns | 19.45 |     544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     1,534.31 ns | 21.03 |     648 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     1,559.73 ns | 21.38 |     952 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     1,569.72 ns | 21.52 |     432 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |        84.66 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     1,407.52 ns | 16.63 |     832 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     1,455.22 ns | 17.19 |    1240 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     1,479.16 ns | 17.47 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     1,549.32 ns | 18.30 |     720 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       120.25 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     1,506.27 ns | 12.53 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     1,515.38 ns | 12.60 |     824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |       545.60 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     7,127.42 ns | 13.07 |    2456 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     7,919.00 ns | 14.52 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     8,024.83 ns | 14.71 |    2520 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     8,642.97 ns | 15.85 |    3744 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     8,708.41 ns | 15.97 |    4144 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |       638.77 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |    11,132.62 ns | 17.43 |    5336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |    11,690.02 ns | 18.30 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |    11,768.13 ns | 18.42 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |    12,543.93 ns | 19.64 |    7024 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     1,031.81 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |    10,862.90 ns | 10.53 |    6544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |    11,364.31 ns | 11.01 |    6440 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |     4,764.33 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    57,173.26 ns | 12.01 |   23342 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    57,351.84 ns | 12.05 |   29468 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    59,933.68 ns | 12.59 |   23405 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    65,130.90 ns | 13.68 |   40147 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    68,260.48 ns | 14.34 |   34711 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |     5,898.92 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    96,062.60 ns | 16.28 |   52196 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |    99,820.57 ns | 16.92 |   58284 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |   101,377.33 ns | 17.19 |   52256 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |   111,539.47 ns | 18.91 |   69003 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |     9,897.83 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |    84,681.62 ns |  8.56 |   64184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |    92,777.00 ns |  9.37 |   62659 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |        94.65 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |        98.18 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       126.40 ns |  1.29 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       234.78 ns |  2.39 |     192 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       255.18 ns |  2.60 |     576 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |       411.50 ns |  4.19 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |        85.78 ns |  0.90 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |        95.32 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       125.89 ns |  1.32 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       243.98 ns |  2.56 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |       408.79 ns |  4.29 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |        95.29 ns |  0.98 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |        97.09 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       238.71 ns |  2.46 |     192 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |       279.53 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     3,206.41 ns | 11.47 |    2098 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     3,435.11 ns | 12.29 |    3375 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     3,530.40 ns | 12.63 |    1064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     3,895.94 ns | 13.94 |    1271 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     4,006.17 ns | 14.33 |    1744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |       321.77 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     4,507.85 ns | 14.01 |    2216 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     4,565.69 ns | 14.19 |    4528 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     4,999.23 ns | 15.54 |    2896 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     5,330.87 ns | 16.57 |    2424 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |       471.61 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     4,661.40 ns |  9.88 |    2704 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     5,267.48 ns | 11.17 |    2840 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     2,154.88 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    25,910.35 ns | 12.02 |    9421 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    26,017.98 ns | 12.07 |   13754 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    26,780.69 ns | 12.43 |    9627 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    29,270.29 ns | 13.58 |   14504 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    33,151.17 ns | 15.39 |   16178 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |     2,622.40 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    40,426.24 ns | 15.42 |   25278 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    42,376.10 ns | 16.16 |   21161 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    42,956.33 ns | 16.38 |   20967 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    49,472.97 ns | 18.87 |   27720 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |     4,153.97 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    37,655.55 ns |  9.07 |   25310 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    44,016.06 ns | 10.60 |   25797 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    22,046.64 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   217,498.08 ns |  9.87 |   93208 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   218,082.84 ns |  9.89 |  117488 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   218,186.90 ns |  9.90 |   93000 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   249,366.49 ns | 11.31 |  138400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   265,243.75 ns | 12.03 |  160208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    26,719.29 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   352,704.56 ns | 13.20 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   355,755.70 ns | 13.31 |  208200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   374,256.49 ns | 14.01 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   379,819.30 ns | 14.22 |  275408 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |    41,807.32 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   329,656.44 ns |  7.89 |  250008 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   337,288.32 ns |  8.07 |  256208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       355.64 ns |  0.99 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |       357.69 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |       440.40 ns |  1.23 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |       876.65 ns |  2.45 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |       948.60 ns |  2.65 |    2304 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     1,450.73 ns |  4.06 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       331.47 ns |  0.92 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |       362.19 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |       447.39 ns |  1.24 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |       879.64 ns |  2.43 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     1,444.58 ns |  3.99 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |       360.41 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |       361.70 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |       897.97 ns |  2.48 |     768 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     1,043.65 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |     7,651.25 ns |  7.33 |    7902 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     8,885.14 ns |  8.51 |    4569 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |     9,018.71 ns |  8.64 |   13038 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |    11,930.72 ns | 11.43 |    3849 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |    15,014.33 ns | 14.39 |    6549 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     1,262.86 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |    12,659.96 ns | 10.03 |    9206 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |    13,190.82 ns | 10.45 |   17625 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    16,316.52 ns | 12.92 |   11167 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |    16,875.15 ns | 13.36 |    8468 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     1,886.81 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |    13,325.37 ns |  7.06 |   10877 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    16,707.11 ns |  8.85 |   10398 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |     8,733.06 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    91,231.79 ns | 10.45 |   54549 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    92,595.68 ns | 10.60 |   38095 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    94,247.31 ns | 10.79 |   37290 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |   105,229.00 ns | 12.05 |   57568 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |   116,838.30 ns | 13.38 |   64208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    10,539.25 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |   146,347.33 ns | 13.89 |   83397 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |   150,854.42 ns | 14.31 |  100687 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |   156,486.80 ns | 14.85 |   84184 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   167,094.43 ns | 15.85 |  110288 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    16,108.72 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |   136,037.04 ns |  8.45 |  100823 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |   145,253.17 ns |  9.02 |  102608 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |    95,134.10 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   791,577.72 ns |  8.32 |  469328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   801,693.84 ns |  8.43 |  372184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   840,349.65 ns |  8.83 |  371400 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             |   851,970.26 ns |  8.96 |  552928 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 1,065,330.97 ns | 11.20 |  640208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   111,770.12 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 1,171,261.02 ns | 10.48 |  832984 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 1,181,033.61 ns | 10.57 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 1,329,154.46 ns | 11.89 |  832200 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,482,600.61 ns | 13.26 | 1101008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   176,589.11 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 1,170,757.13 ns |  6.63 |  999384 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 1,310,003.38 ns |  7.42 | 1024208 B |