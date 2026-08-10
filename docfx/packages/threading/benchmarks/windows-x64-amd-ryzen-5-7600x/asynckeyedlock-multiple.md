| Description                                          | KeyCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |      29.71 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |      54.93 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |      59.98 ns |  1.09 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |      71.50 ns |  1.30 |      48 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |      75.95 ns |  1.38 |     144 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |     102.20 ns |  1.86 |     520 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |      29.37 ns |  0.53 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |      55.55 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |      59.76 ns |  1.08 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |      82.39 ns |  1.48 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |     104.69 ns |  1.88 |     520 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |      31.50 ns |  0.55 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |      57.75 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |      72.75 ns |  1.26 |      48 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |     103.21 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     512.52 ns |  4.97 |     368 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     642.26 ns |  6.22 |     544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     711.19 ns |  6.89 |     432 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     716.97 ns |  6.95 |     648 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     739.30 ns |  7.16 |     952 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |     123.44 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     641.56 ns |  5.20 |     656 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     811.52 ns |  6.57 |    1240 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     855.50 ns |  6.93 |     832 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     941.48 ns |  7.63 |     720 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |     147.73 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     748.11 ns |  5.06 |     784 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     946.56 ns |  6.41 |     824 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     660.11 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |   3,629.16 ns |  5.50 |    2456 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |   3,777.53 ns |  5.72 |    2520 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |   3,783.05 ns |  5.73 |    3544 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |   3,943.75 ns |  5.97 |    3744 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |   4,287.84 ns |  6.50 |    4144 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     846.97 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |   5,323.99 ns |  6.29 |    5336 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |   5,453.19 ns |  6.44 |    6424 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |   5,687.61 ns |  6.72 |    5400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |   6,621.44 ns |  7.82 |    7024 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |   1,109.35 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |   5,569.04 ns |  5.02 |    6544 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |   5,755.58 ns |  5.19 |    6440 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |   6,348.78 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |  37,400.45 ns |  5.89 |   29528 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |  37,500.12 ns |  5.91 |   23399 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |  37,990.90 ns |  5.98 |   34768 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |  38,282.91 ns |  6.03 |   23464 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |  41,877.79 ns |  6.60 |   40208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |   7,912.23 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |  52,123.25 ns |  6.59 |   52194 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |  54,240.08 ns |  6.86 |   58328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |  55,880.77 ns |  7.06 |   52264 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |  68,310.64 ns |  8.63 |   69008 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |  10,823.87 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |  54,186.25 ns |  5.01 |   64208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |  55,299.73 ns |  5.11 |   62664 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |      96.56 ns |  0.53 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |     183.82 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |     208.02 ns |  1.13 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |     262.91 ns |  1.43 |     576 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |     275.29 ns |  1.50 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |     403.86 ns |  2.20 |    2080 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |      96.10 ns |  0.52 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |     185.24 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |     201.67 ns |  1.09 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |     268.23 ns |  1.45 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |     390.74 ns |  2.11 |    2080 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |     104.73 ns |  0.55 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |     189.03 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |     269.27 ns |  1.42 |     192 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |     367.75 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |   1,434.60 ns |  3.90 |    1064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |   1,592.15 ns |  4.33 |    1157 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |   1,595.33 ns |  4.34 |    3334 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |   1,601.32 ns |  4.35 |    2029 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |   1,976.29 ns |  5.37 |    1744 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     477.41 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |   2,153.14 ns |  4.51 |    2216 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |   2,192.82 ns |  4.59 |    2416 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |   2,269.22 ns |  4.75 |    4524 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |   2,839.86 ns |  5.95 |    2896 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |     548.27 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |   2,187.40 ns |  3.99 |    2834 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |   2,534.38 ns |  4.62 |    2704 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |   2,524.93 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |  16,340.37 ns |  6.47 |   14536 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |  16,410.83 ns |  6.50 |   13789 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |  17,463.02 ns |  6.92 |    9480 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |  18,056.50 ns |  7.15 |    9687 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |  19,874.65 ns |  7.87 |   16208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |   3,251.56 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |  24,232.68 ns |  7.45 |   21000 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |  24,826.63 ns |  7.64 |   21208 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |  24,975.83 ns |  7.68 |   25328 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |  29,525.56 ns |  9.08 |   27728 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |   4,572.83 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |  25,349.72 ns |  5.54 |   25808 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |  26,257.79 ns |  5.74 |   25368 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |  25,094.37 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             | 129,971.31 ns |  5.18 |  117488 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             | 131,197.96 ns |  5.23 |   93208 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             | 133,841.55 ns |  5.33 |  138400 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             | 134,907.76 ns |  5.38 |   93000 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             | 146,109.63 ns |  5.82 |  160208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |  32,959.76 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     | 198,357.61 ns |  6.02 |  232688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     | 201,177.23 ns |  6.10 |  208200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     | 206,010.39 ns |  6.25 |  208408 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     | 245,100.47 ns |  7.44 |  275408 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |  44,896.73 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            | 204,354.68 ns |  4.55 |  250008 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            | 204,470.36 ns |  4.55 |  256208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |     382.68 ns |  0.56 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     685.23 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |     763.51 ns |  1.11 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |   1,050.83 ns |  1.53 |     768 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |   1,068.16 ns |  1.56 |    2304 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |   1,558.99 ns |  2.28 |    8320 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |     375.09 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     690.58 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     771.26 ns |  1.12 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |   1,045.69 ns |  1.51 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |   1,558.02 ns |  2.26 |    8320 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |     420.18 ns |  0.62 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |     683.18 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |   1,044.75 ns |  1.53 |     768 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |   1,630.49 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |   4,962.81 ns |  3.04 |    3848 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |   5,777.71 ns |  3.54 |    4487 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |   6,271.15 ns |  3.85 |   12939 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |   6,658.30 ns |  4.08 |    7816 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |   7,233.14 ns |  4.44 |    6546 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |   1,716.81 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |   6,413.16 ns |  3.74 |    9108 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |   7,510.16 ns |  4.37 |   17579 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |   8,508.97 ns |  4.96 |    8466 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |  14,415.87 ns |  8.40 |   11208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |   2,133.63 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |   7,085.77 ns |  3.32 |   10797 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |  11,313.91 ns |  5.30 |   10419 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |  10,353.08 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |  54,336.95 ns |  5.25 |   54608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |  54,789.10 ns |  5.29 |   38104 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |  55,557.77 ns |  5.37 |   37320 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |  57,195.32 ns |  5.52 |   57568 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |  66,274.37 ns |  6.40 |   64208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |  13,514.77 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |  80,035.95 ns |  5.92 |  100688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |  81,844.02 ns |  6.06 |   84184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |  86,849.97 ns |  6.43 |   83400 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     | 104,863.85 ns |  7.76 |  110288 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |  18,083.62 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |  84,799.99 ns |  4.69 |  102608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |  87,611.92 ns |  4.84 |  100824 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             | 107,192.86 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             | 501,299.81 ns |  4.68 |  469328 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             | 512,768.51 ns |  4.78 |  372184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             | 524,175.03 ns |  4.89 |  371400 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             | 524,378.89 ns |  4.89 |  552928 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 573,811.62 ns |  5.35 |  640208 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     | 144,934.65 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 752,789.79 ns |  5.19 |  832200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 769,195.74 ns |  5.31 |  832984 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 815,556.19 ns |  5.63 |  930128 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 932,581.79 ns |  6.44 | 1101008 B | 
|                                                      |          |            |                  |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            | 183,111.67 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 771,933.61 ns |  4.22 | 1024208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 774,973.12 ns |  4.23 |  999384 B |