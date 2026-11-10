| Description                                          | KeyCount | Iterations | cancellationType | Mean            | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |----------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        73.92 ns |  0.64 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |       113.43 ns |  0.98 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |       116.28 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |       196.23 ns |  1.69 |     144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |       212.02 ns |  1.82 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       275.55 ns |  2.37 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        74.12 ns |  0.65 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |       110.61 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |       114.88 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |       214.83 ns |  1.87 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |       272.71 ns |  2.37 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        82.07 ns |  0.72 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |       114.73 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |       222.60 ns |  1.94 |      48 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |       271.60 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     1,265.29 ns |  4.66 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     1,466.07 ns |  5.40 |     544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     1,502.01 ns |  5.53 |     648 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     1,559.70 ns |  5.74 |     432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     1,611.81 ns |  5.93 |     952 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |       317.11 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     1,560.54 ns |  4.92 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     1,795.87 ns |  5.66 |     832 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     1,957.20 ns |  6.17 |     720 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     2,011.07 ns |  6.34 |    1240 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       398.18 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     1,668.52 ns |  4.19 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     2,015.21 ns |  5.06 |     824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     2,037.41 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     7,820.44 ns |  3.84 |    2456 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     8,360.95 ns |  4.10 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     8,489.43 ns |  4.17 |    2520 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     9,213.74 ns |  4.52 |    4144 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     9,336.37 ns |  4.58 |    3744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     2,525.57 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |    10,601.31 ns |  4.20 |    5336 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |    11,286.26 ns |  4.47 |    5400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |    11,806.75 ns |  4.67 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |    13,192.78 ns |  5.22 |    7024 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     3,276.17 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |    11,996.54 ns |  3.66 |    6544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |    12,844.11 ns |  3.92 |    6440 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |    19,837.96 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    54,587.07 ns |  2.75 |   23336 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    60,775.41 ns |  3.06 |   23401 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    62,228.36 ns |  3.14 |   29465 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    67,101.61 ns |  3.38 |   34705 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    69,991.44 ns |  3.53 |   40145 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |    24,634.62 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    95,939.52 ns |  3.89 |   52170 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |   105,566.11 ns |  4.29 |   52248 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |   111,953.74 ns |  4.54 |   58325 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |   125,733.08 ns |  5.10 |   69008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |    32,725.44 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |   113,537.39 ns |  3.47 |   64207 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |   118,024.83 ns |  3.61 |   62664 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |       255.44 ns |  0.62 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       385.00 ns |  0.93 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |       412.41 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       683.96 ns |  1.66 |     576 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       821.70 ns |  1.99 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |     1,099.71 ns |  2.67 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |       254.22 ns |  0.63 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       392.74 ns |  0.97 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |       406.11 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       812.30 ns |  2.00 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |     1,095.64 ns |  2.70 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |       270.42 ns |  0.65 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |       413.99 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       865.99 ns |  2.09 |     192 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |     1,053.57 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     3,169.45 ns |  3.01 |    1064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     3,217.61 ns |  3.05 |    1205 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     3,376.48 ns |  3.20 |    2007 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     3,514.73 ns |  3.34 |    3333 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     4,076.07 ns |  3.87 |    1744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     1,262.42 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     4,326.49 ns |  3.43 |    2216 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     4,381.31 ns |  3.47 |    2418 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     4,862.73 ns |  3.85 |    4526 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     5,321.05 ns |  4.21 |    2896 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |     1,573.55 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     4,595.64 ns |  2.92 |    2838 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     4,780.54 ns |  3.04 |    2704 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     8,179.53 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    25,276.39 ns |  3.09 |    9416 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    27,517.13 ns |  3.36 |    9624 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    28,504.05 ns |  3.48 |   13744 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    29,957.17 ns |  3.66 |   14496 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    31,173.15 ns |  3.81 |   16144 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |    10,336.36 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    36,527.00 ns |  3.53 |   20936 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    37,256.27 ns |  3.60 |   21144 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    38,223.98 ns |  3.70 |   25266 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    42,961.92 ns |  4.16 |   27664 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |    13,336.86 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    39,642.76 ns |  2.97 |   25304 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    39,918.15 ns |  2.99 |   25744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    80,768.35 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   226,177.35 ns |  2.80 |   92997 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   251,243.51 ns |  3.11 |  117487 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   254,921.24 ns |  3.16 |   93208 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   282,391.72 ns |  3.50 |  160208 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   293,173.67 ns |  3.63 |  138400 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    99,662.06 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   335,639.64 ns |  3.37 |  208200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   363,700.65 ns |  3.65 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   370,582.15 ns |  3.72 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   429,514.38 ns |  4.31 |  275408 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |   131,266.29 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   384,937.86 ns |  2.93 |  256208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   389,263.95 ns |  2.97 |  250008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       965.54 ns |  0.61 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |     1,498.99 ns |  0.95 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     1,579.81 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |     2,862.45 ns |  1.81 |    2304 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |     3,259.30 ns |  2.06 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     4,445.73 ns |  2.81 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       970.80 ns |  0.62 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     1,505.07 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     1,568.52 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |     3,236.73 ns |  2.06 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     4,379.80 ns |  2.79 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |     1,013.38 ns |  0.64 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |     1,576.53 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |     3,254.77 ns |  2.06 |     768 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     4,116.14 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     9,925.11 ns |  2.41 |    4484 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |    11,317.85 ns |  2.75 |    3848 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |    11,491.56 ns |  2.79 |   12934 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |    11,747.84 ns |  2.85 |    7817 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |    15,046.66 ns |  3.66 |    6544 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     4,890.42 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |    11,583.91 ns |  2.37 |    9104 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |    13,088.53 ns |  2.68 |   17571 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |    16,065.28 ns |  3.29 |    8456 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    19,191.16 ns |  3.92 |   11152 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     6,229.00 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |    12,787.57 ns |  2.05 |   10796 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    17,703.24 ns |  2.84 |   10385 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |    33,266.41 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    94,236.96 ns |  2.83 |   37275 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    98,707.60 ns |  2.97 |   38052 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |   109,163.86 ns |  3.28 |   54598 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |   116,354.08 ns |  3.50 |   64166 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |   131,754.17 ns |  3.96 |   57564 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    41,603.94 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |   137,867.52 ns |  3.31 |   83378 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |   160,342.22 ns |  3.85 |   84182 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   162,398.13 ns |  3.90 |  110282 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |   168,787.98 ns |  4.06 |  100687 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    53,871.25 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |   145,635.70 ns |  2.70 |  102603 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |   173,554.38 ns |  3.22 |  100821 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |   328,465.44 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   905,538.17 ns |  2.76 |  371400 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   967,769.47 ns |  2.95 |  372184 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   989,682.55 ns |  3.01 |  469328 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             | 1,081,039.47 ns |  3.29 |  552928 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 1,095,139.57 ns |  3.33 |  640208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   429,364.68 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 1,305,558.14 ns |  3.04 |  832200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 1,448,398.80 ns |  3.37 |  832984 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 1,479,036.52 ns |  3.44 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,626,354.93 ns |  3.79 | 1101008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   557,599.38 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 1,480,075.17 ns |  2.65 | 1024208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 1,514,823.49 ns |  2.72 |  999384 B |