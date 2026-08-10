| Description                                          | KeyCount | Iterations | cancellationType | Mean            | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |----------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        20.92 ns |  0.72 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        29.18 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        34.71 ns |  1.19 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |        64.85 ns |  2.22 |     144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |        68.95 ns |  2.36 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       100.19 ns |  3.43 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        21.26 ns |  0.74 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        28.69 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        34.70 ns |  1.21 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |        70.48 ns |  2.46 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |        99.81 ns |  3.48 |     520 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        21.63 ns |  0.74 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |        29.24 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |        69.16 ns |  2.37 |      48 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |        69.18 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     1,369.04 ns | 19.79 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     1,485.11 ns | 21.47 |     544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     1,580.16 ns | 22.84 |     432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     1,606.03 ns | 23.22 |     952 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     1,608.79 ns | 23.26 |     648 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |        86.02 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     1,449.68 ns | 16.86 |     832 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     1,469.95 ns | 17.09 |    1240 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     1,493.35 ns | 17.36 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     1,515.78 ns | 17.63 |     720 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       117.53 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     1,480.84 ns | 12.60 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     1,613.95 ns | 13.73 |     824 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |       534.26 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     7,696.61 ns | 14.41 |    2456 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     7,939.24 ns | 14.87 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     8,236.11 ns | 15.42 |    2520 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     8,940.97 ns | 16.74 |    4144 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     9,125.27 ns | 17.09 |    3744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |       651.82 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |    11,490.97 ns | 17.63 |    5336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |    11,794.01 ns | 18.10 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |    12,186.70 ns | 18.70 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |    12,695.46 ns | 19.48 |    7025 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     1,035.10 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |    11,066.90 ns | 10.69 |    6544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |    11,548.52 ns | 11.16 |    6440 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |     4,720.43 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    53,141.90 ns | 11.26 |   23339 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    57,841.13 ns | 12.26 |   23404 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    58,399.78 ns | 12.37 |   29469 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    66,078.37 ns | 14.00 |   40153 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    67,028.77 ns | 14.20 |   34718 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |     5,949.88 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    96,223.36 ns | 16.18 |   52179 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |    96,316.37 ns | 16.19 |   52210 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |   101,390.33 ns | 17.04 |   58273 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |   113,260.26 ns | 19.04 |   68972 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |     9,686.83 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |    85,637.77 ns |  8.84 |   64177 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |    87,101.98 ns |  8.99 |   62606 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |        93.01 ns |  0.98 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |        94.56 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       119.81 ns |  1.27 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       238.94 ns |  2.53 |     192 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       248.04 ns |  2.62 |     576 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |       418.38 ns |  4.43 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |        88.94 ns |  0.93 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |        95.28 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       120.16 ns |  1.26 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       236.81 ns |  2.49 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |       418.24 ns |  4.39 |    2080 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |        94.94 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |       101.94 ns |  1.07 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       235.40 ns |  2.48 |     192 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |       262.86 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     3,297.25 ns | 12.54 |    2098 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     3,509.07 ns | 13.35 |    3374 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     3,694.59 ns | 14.06 |    1064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     3,827.05 ns | 14.56 |    1269 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     4,038.04 ns | 15.36 |    1744 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |       327.04 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     4,361.98 ns | 13.34 |    2216 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     4,825.67 ns | 14.76 |    4527 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     4,918.04 ns | 15.04 |    2896 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     5,425.51 ns | 16.60 |    2424 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |       478.45 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     4,823.93 ns | 10.08 |    2704 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     5,313.23 ns | 11.11 |    2840 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     2,057.04 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    25,652.16 ns | 12.47 |    9418 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    26,360.60 ns | 12.81 |   13747 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    26,999.27 ns | 13.13 |    9625 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    30,314.39 ns | 14.74 |   14500 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    31,554.77 ns | 15.34 |   16150 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |     2,575.88 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    41,956.06 ns | 16.29 |   25269 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    42,402.09 ns | 16.47 |   21152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    44,048.97 ns | 17.11 |   20942 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    50,781.06 ns | 19.72 |   27673 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |     4,105.61 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    38,490.66 ns |  9.38 |   25313 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    42,253.07 ns | 10.29 |   25753 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    21,753.56 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   207,148.94 ns |  9.52 |   93202 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   207,474.08 ns |  9.54 |   92998 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   211,313.81 ns |  9.72 |  117484 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   248,337.74 ns | 11.42 |  138395 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   265,733.92 ns | 12.22 |  160208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    26,835.20 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   350,508.01 ns | 13.06 |  208200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   359,343.56 ns | 13.39 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   369,144.94 ns | 13.76 |  208407 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   409,956.98 ns | 15.28 |  275408 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |    41,865.76 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   327,452.12 ns |  7.82 |  250007 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   338,805.96 ns |  8.09 |  256208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |       368.12 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       375.38 ns |  1.02 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |       442.55 ns |  1.20 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |       887.26 ns |  2.41 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |       926.06 ns |  2.52 |    2304 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     1,470.45 ns |  4.00 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       344.90 ns |  0.94 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |       365.08 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |       444.76 ns |  1.22 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |       881.84 ns |  2.42 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     1,462.26 ns |  4.01 |    8320 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |       366.82 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |       413.10 ns |  1.13 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |       883.27 ns |  2.41 |     768 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     1,049.91 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |     8,145.48 ns |  7.76 |    7900 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     8,260.16 ns |  7.87 |    4588 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |     9,211.82 ns |  8.77 |   13030 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |    12,248.34 ns | 11.67 |    3849 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |    14,680.80 ns | 13.98 |    6550 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     1,276.82 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |    13,277.75 ns | 10.40 |    9199 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |    14,319.18 ns | 11.22 |   17647 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    16,275.30 ns | 12.75 |   11169 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |    16,391.76 ns | 12.84 |    8466 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     1,907.79 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |    13,868.90 ns |  7.27 |   10874 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    16,110.51 ns |  8.45 |   10395 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |     8,382.81 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    89,345.11 ns | 10.66 |   54562 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    90,847.47 ns | 10.84 |   38048 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    91,067.88 ns | 10.86 |   37278 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |   102,306.48 ns | 12.20 |   57513 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |   115,828.87 ns | 13.82 |   64159 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    10,445.96 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |   151,678.46 ns | 14.52 |   84178 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |   152,163.47 ns | 14.57 |  100681 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |   156,525.76 ns | 14.99 |   83399 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   179,095.05 ns | 17.15 |  110288 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    16,383.20 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |   136,382.02 ns |  8.32 |  100815 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |   156,797.65 ns |  9.57 |  102605 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |    96,427.88 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   794,854.84 ns |  8.24 |  372184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   811,187.49 ns |  8.41 |  371400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   817,374.14 ns |  8.48 |  469328 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             |   935,354.65 ns |  9.70 |  552928 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 1,041,798.82 ns | 10.81 |  640208 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   112,817.55 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 1,142,895.80 ns | 10.13 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 1,185,224.05 ns | 10.51 |  832984 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 1,325,226.28 ns | 11.75 |  832200 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,514,025.22 ns | 13.42 | 1101008 B | 
|                                                      |          |            |                  |                 |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   178,103.33 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 1,159,879.98 ns |  6.51 |  999384 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 1,317,679.55 ns |  7.40 | 1024207 B |