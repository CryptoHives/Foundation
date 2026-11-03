| Description                                          | KeyCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |      31.99 ns |  0.51 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |      62.21 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |      69.74 ns |  1.12 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |      79.15 ns |  1.27 |      48 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |      88.34 ns |  1.42 |     144 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |     117.22 ns |  1.88 |     520 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |      38.31 ns |  0.62 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |      62.28 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |      69.76 ns |  1.12 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |      81.61 ns |  1.31 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |     112.08 ns |  1.80 |     520 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |      36.32 ns |  0.57 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |      63.86 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |      80.43 ns |  1.26 |      48 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |     117.53 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     598.46 ns |  5.09 |     367 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     749.22 ns |  6.38 |     648 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     753.19 ns |  6.41 |     544 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     789.97 ns |  6.72 |     952 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     802.57 ns |  6.83 |     432 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |     128.83 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     735.87 ns |  5.71 |     656 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     795.37 ns |  6.17 |     832 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     876.28 ns |  6.80 |    1240 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     966.73 ns |  7.50 |     720 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |     166.53 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     786.59 ns |  4.72 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |   1,012.35 ns |  6.08 |     824 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     746.78 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |   3,276.46 ns |  4.39 |    2456 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |   3,430.54 ns |  4.59 |    3544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |   3,475.79 ns |  4.65 |    2520 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |   4,128.55 ns |  5.53 |    3744 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |   5,422.02 ns |  7.26 |    4144 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     974.94 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |   5,679.84 ns |  5.83 |    5336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |   6,306.53 ns |  6.47 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |   6,350.16 ns |  6.51 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |   7,638.20 ns |  7.83 |    7024 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |   1,269.75 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |   6,218.52 ns |  4.90 |    6440 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |   6,412.89 ns |  5.05 |    6544 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |   7,545.21 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |  30,525.78 ns |  4.05 |   23336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |  31,557.98 ns |  4.18 |   29464 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |  31,770.83 ns |  4.21 |   23400 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |  37,246.12 ns |  4.94 |   34705 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |  38,124.43 ns |  5.05 |   40146 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |   8,744.95 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |  49,390.63 ns |  5.65 |   58271 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |  49,986.15 ns |  5.72 |   52143 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |  52,283.95 ns |  5.98 |   52207 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |  61,578.67 ns |  7.04 |   68990 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |  12,944.65 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |  51,315.40 ns |  3.96 |   64172 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |  52,019.26 ns |  4.02 |   62601 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |     113.25 ns |  0.53 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |     213.99 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |     229.88 ns |  1.07 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |     290.42 ns |  1.36 |     576 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |     303.98 ns |  1.42 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |     448.25 ns |  2.09 |    2080 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |     110.45 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |     213.59 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |     235.14 ns |  1.10 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |     297.80 ns |  1.39 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |     423.57 ns |  1.98 |    2080 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |     117.23 ns |  0.55 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |     213.60 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |     297.37 ns |  1.39 |     192 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |     470.43 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |   1,461.65 ns |  3.11 |    1064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |   1,635.14 ns |  3.48 |    1236 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |   1,677.23 ns |  3.57 |    3338 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |   1,764.66 ns |  3.75 |    2006 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |   2,007.13 ns |  4.27 |    1744 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     498.63 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |   2,236.57 ns |  4.49 |    2420 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |   2,271.50 ns |  4.56 |    4526 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |   2,280.52 ns |  4.57 |    2216 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |   2,928.82 ns |  5.87 |    2896 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |     617.42 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |   2,399.16 ns |  3.89 |    2838 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |   2,850.37 ns |  4.62 |    2704 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |   2,873.48 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |  12,412.08 ns |  4.32 |   13744 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |  13,074.14 ns |  4.55 |    9416 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |  13,174.70 ns |  4.58 |    9624 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |  15,753.77 ns |  5.48 |   14496 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |  16,400.39 ns |  5.71 |   16144 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |   3,670.12 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |  20,090.43 ns |  5.47 |   25264 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |  20,510.55 ns |  5.59 |   21144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |  21,409.71 ns |  5.83 |   20936 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |  25,850.31 ns |  7.04 |   27664 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |   5,069.76 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |  21,391.78 ns |  4.22 |   25304 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |  21,884.25 ns |  4.32 |   25744 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |  28,775.99 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             | 109,588.50 ns |  3.81 |   92986 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             | 113,746.75 ns |  3.95 |   93200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             | 119,529.40 ns |  4.15 |  117487 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             | 134,288.99 ns |  4.67 |  138400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             | 139,394.38 ns |  4.84 |  160207 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |  36,995.12 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     | 181,329.40 ns |  4.90 |  208200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     | 200,314.42 ns |  5.42 |  208408 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     | 200,953.06 ns |  5.43 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     | 250,381.46 ns |  6.77 |  275408 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |  53,068.96 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            | 191,764.22 ns |  3.61 |  256208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            | 219,460.59 ns |  4.14 |  250008 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |     432.06 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     804.03 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |     865.45 ns |  1.08 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |   1,185.86 ns |  1.47 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |   1,189.82 ns |  1.48 |    2304 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |   1,690.05 ns |  2.10 |    8320 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |     428.18 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     822.23 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     882.34 ns |  1.07 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |   1,281.72 ns |  1.56 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |   1,696.48 ns |  2.06 |    8320 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |     445.09 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |     819.53 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |   1,190.68 ns |  1.45 |     768 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |   1,664.83 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |   4,275.58 ns |  2.57 |    4490 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |   4,866.23 ns |  2.92 |   12942 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |   5,527.34 ns |  3.32 |    7813 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |   6,093.06 ns |  3.66 |    3848 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |   8,644.92 ns |  5.19 |    6544 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |   1,913.09 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |   5,697.84 ns |  2.98 |    9194 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |   6,100.53 ns |  3.19 |   17656 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |   9,685.95 ns |  5.06 |    8456 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |  12,989.68 ns |  6.79 |   11152 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |   2,460.71 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |   6,254.05 ns |  2.54 |   10888 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |  11,729.15 ns |  4.77 |   10384 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |  15,643.01 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |  44,811.11 ns |  2.86 |   54548 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |  49,001.34 ns |  3.13 |   37257 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |  49,029.45 ns |  3.13 |   38045 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |  57,330.59 ns |  3.67 |   57549 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |  61,404.50 ns |  3.93 |   64165 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |  15,511.91 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |  74,904.46 ns |  4.83 |  100667 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |  77,151.53 ns |  4.97 |   83378 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |  81,422.14 ns |  5.25 |   84179 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     | 103,562.91 ns |  6.68 |  110266 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |  21,319.88 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |  85,732.87 ns |  4.02 |  100811 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |  88,379.81 ns |  4.15 |  102602 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             | 122,270.98 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             | 431,839.97 ns |  3.53 |  371400 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             | 453,882.21 ns |  3.71 |  372184 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             | 476,110.63 ns |  3.89 |  469328 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 544,212.86 ns |  4.45 |  640208 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             | 561,268.16 ns |  4.59 |  552928 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     | 152,825.18 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 739,946.58 ns |  4.84 |  832200 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 779,733.18 ns |  5.10 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 784,423.72 ns |  5.13 |  832984 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 959,962.97 ns |  6.28 | 1101008 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            | 211,751.58 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 808,662.51 ns |  3.82 |  999384 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 826,319.54 ns |  3.90 | 1024208 B |