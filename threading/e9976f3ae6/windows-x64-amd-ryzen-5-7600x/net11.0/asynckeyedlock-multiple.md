| Description                                          | KeyCount | Iterations | cancellationType | Mean          | Error         | StdDev        | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |--------------:|--------------:|--------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |      27.26 ns |      0.161 ns |      0.143 ns |  0.74 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |      36.70 ns |      0.705 ns |      0.659 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |      44.18 ns |      0.869 ns |      1.246 ns |  1.20 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |      64.46 ns |      0.156 ns |      0.138 ns |  1.76 |     144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |      73.91 ns |      0.160 ns |      0.134 ns |  2.01 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |     109.32 ns |      0.298 ns |      0.249 ns |  2.98 |     504 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |      28.32 ns |      0.339 ns |      0.317 ns |  0.81 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |      34.98 ns |      0.056 ns |      0.047 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |      39.70 ns |      0.079 ns |      0.070 ns |  1.14 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |      75.66 ns |      0.077 ns |      0.060 ns |  2.16 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |     109.09 ns |      0.418 ns |      0.349 ns |  3.12 |     504 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |      26.40 ns |      0.117 ns |      0.104 ns |  0.74 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |      35.48 ns |      0.083 ns |      0.069 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |      73.72 ns |      0.083 ns |      0.069 ns |  2.08 |      48 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |      92.76 ns |      0.890 ns |      0.833 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |     291.55 ns |      0.683 ns |      0.639 ns |  3.14 |     432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |     388.75 ns |      0.633 ns |      0.592 ns |  4.19 |     520 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |     413.59 ns |      0.810 ns |      0.718 ns |  4.46 |     728 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |     416.81 ns |      0.812 ns |      0.720 ns |  4.49 |     560 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |     417.16 ns |      1.842 ns |      1.438 ns |  4.50 |     887 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |     104.74 ns |      0.213 ns |      0.178 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |     447.63 ns |      2.649 ns |      2.212 ns |  4.27 |     856 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     584.80 ns |      6.014 ns |      5.625 ns |  5.58 |     944 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     684.57 ns |     10.987 ns |      9.739 ns |  6.54 |     984 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     696.44 ns |      8.559 ns |      8.007 ns |  6.65 |    1312 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |     130.39 ns |      0.576 ns |      0.481 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     551.22 ns |      1.869 ns |      1.561 ns |  4.23 |     992 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     596.28 ns |      0.991 ns |      0.774 ns |  4.57 |    1048 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     643.98 ns |      1.063 ns |      0.888 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |   2,320.01 ns |     12.323 ns |     11.527 ns |  3.60 |    3600 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |   2,559.81 ns |      5.133 ns |      4.286 ns |  3.97 |    3408 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |   2,888.00 ns |     13.959 ns |     13.058 ns |  4.48 |    3832 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |   3,142.83 ns |      8.599 ns |      8.044 ns |  4.88 |    5048 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |   3,257.81 ns |     64.746 ns |     79.514 ns |  5.06 |    4160 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     845.04 ns |      5.302 ns |      4.700 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |   3,858.06 ns |     29.286 ns |     25.961 ns |  4.57 |    7840 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |   4,094.07 ns |     17.191 ns |     14.356 ns |  4.84 |    8072 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |   4,366.07 ns |     31.118 ns |     27.585 ns |  5.17 |    7648 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |   4,903.95 ns |     30.424 ns |     26.970 ns |  5.80 |    8400 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |   1,130.76 ns |      7.910 ns |      7.012 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |   3,981.50 ns |     12.518 ns |     11.709 ns |  3.52 |    8968 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |   4,368.49 ns |      8.823 ns |      6.889 ns |  3.86 |    9112 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |   5,877.17 ns |     70.966 ns |     66.382 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |  23,838.80 ns |     67.989 ns |     63.597 ns |  4.06 |   35280 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |  24,777.72 ns |     92.186 ns |     81.720 ns |  4.22 |   28608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |  27,705.37 ns |     51.621 ns |     45.761 ns |  4.71 |   36952 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |  30,692.44 ns |     52.500 ns |     43.840 ns |  5.22 |   40128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |  31,147.28 ns |     86.559 ns |     72.281 ns |  5.30 |   48248 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |   7,980.33 ns |     48.038 ns |     44.935 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |  40,313.11 ns |    195.037 ns |    182.438 ns |  5.05 |   77680 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |  41,770.12 ns |    263.421 ns |    233.516 ns |  5.23 |   71008 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |  45,874.34 ns |    833.787 ns |    739.130 ns |  5.75 |   79352 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |  51,081.55 ns |    208.906 ns |    185.190 ns |  6.40 |   82528 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |  10,531.61 ns |     63.485 ns |     56.278 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |  41,179.16 ns |    166.200 ns |    155.464 ns |  3.91 |   88890 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |  45,351.20 ns |    169.513 ns |    158.563 ns |  4.31 |   89752 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |      93.27 ns |      0.348 ns |      0.325 ns |  0.72 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |     129.81 ns |      0.178 ns |      0.139 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |     149.10 ns |      0.241 ns |      0.201 ns |  1.15 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |     243.14 ns |      0.628 ns |      0.524 ns |  1.87 |     576 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |     285.08 ns |      1.158 ns |      1.026 ns |  2.20 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |     427.75 ns |      1.173 ns |      0.916 ns |  3.30 |    2016 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |     100.87 ns |      0.365 ns |      0.323 ns |  0.75 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |     134.69 ns |      0.246 ns |      0.230 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |     149.92 ns |      0.242 ns |      0.215 ns |  1.11 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |     283.76 ns |      1.324 ns |      1.174 ns |  2.11 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |     418.02 ns |      1.611 ns |      1.428 ns |  3.10 |    2016 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |      94.26 ns |      0.236 ns |      0.209 ns |  0.73 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |     129.35 ns |      0.249 ns |      0.208 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |     285.64 ns |      0.998 ns |      0.885 ns |  2.21 |     192 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |     339.80 ns |      4.637 ns |      3.872 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |   1,077.28 ns |      3.157 ns |      2.953 ns |  3.17 |    1488 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |   1,196.55 ns |      2.621 ns |      2.188 ns |  3.52 |    1766 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |   1,317.11 ns |      4.555 ns |      4.261 ns |  3.88 |    3232 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |   1,480.50 ns |      3.057 ns |      2.710 ns |  4.36 |    2595 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |   1,494.65 ns |      3.127 ns |      2.925 ns |  4.40 |    1760 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     397.45 ns |      0.850 ns |      0.753 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |   1,718.61 ns |     12.987 ns |     10.845 ns |  4.32 |    3184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |   1,933.31 ns |      9.829 ns |      8.713 ns |  4.86 |    3464 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |   2,001.94 ns |     23.165 ns |     20.535 ns |  5.04 |    4936 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |   2,750.13 ns |     54.408 ns |     66.817 ns |  6.92 |    3456 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |     524.84 ns |      1.738 ns |      1.541 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |   1,990.69 ns |     15.680 ns |     14.667 ns |  3.79 |    3656 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |   2,008.64 ns |      5.839 ns |      4.876 ns |  3.83 |    3880 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |   2,470.51 ns |      9.217 ns |      8.621 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |   9,119.41 ns |     31.189 ns |     26.044 ns |  3.69 |   14160 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |  10,131.11 ns |     23.099 ns |     19.289 ns |  4.10 |   13320 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |  10,972.67 ns |     37.294 ns |     34.885 ns |  4.44 |   15016 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |  12,521.66 ns |     39.110 ns |     32.659 ns |  5.07 |   19880 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |  12,845.29 ns |    207.695 ns |    194.278 ns |  5.20 |   16128 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |   3,305.70 ns |     12.249 ns |     10.859 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |  15,063.76 ns |     42.352 ns |     35.366 ns |  4.56 |   31120 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |  16,811.60 ns |    110.453 ns |     97.914 ns |  5.09 |   31976 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |  18,881.17 ns |     84.248 ns |     78.806 ns |  5.71 |   30280 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |  20,839.55 ns |    299.361 ns |    280.022 ns |  6.30 |   33088 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |   4,580.56 ns |     46.542 ns |     41.258 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |  15,856.48 ns |     28.608 ns |     25.360 ns |  3.46 |   35608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |  17,631.38 ns |     25.154 ns |     23.529 ns |  3.85 |   36136 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |  24,931.75 ns |     97.914 ns |     86.799 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |  96,483.57 ns |    187.075 ns |    174.990 ns |  3.87 |  140880 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             | 104,941.16 ns |    355.472 ns |    315.117 ns |  4.21 |  114120 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             | 110,916.98 ns |    324.956 ns |    303.964 ns |  4.45 |  147496 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             | 126,992.99 ns |  2,535.122 ns |  3,113.358 ns |  5.09 |  160128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             | 128,299.94 ns |    699.743 ns |    654.540 ns |  5.15 |  192680 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |  32,940.40 ns |    140.640 ns |    131.555 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     | 169,955.24 ns |    548.675 ns |    513.231 ns |  5.16 |  310480 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     | 180,479.26 ns |    757.440 ns |    708.510 ns |  5.48 |  317096 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     | 182,314.94 ns |  2,060.293 ns |  1,927.199 ns |  5.53 |  283720 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     | 190,159.23 ns |    685.857 ns |    607.994 ns |  5.77 |  329728 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |  42,752.50 ns |    164.832 ns |    146.119 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            | 162,442.30 ns |    390.657 ns |    365.420 ns |  3.80 |  355288 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            | 180,006.60 ns |    535.462 ns |    447.135 ns |  4.21 |  358696 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |     359.57 ns |      0.765 ns |      0.639 ns |  0.73 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     495.02 ns |      0.696 ns |      0.581 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |     596.11 ns |      1.907 ns |      1.592 ns |  1.20 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |     955.79 ns |      3.436 ns |      3.046 ns |  1.93 |    2304 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |   1,132.34 ns |      7.751 ns |      6.871 ns |  2.29 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |   1,714.93 ns |      5.185 ns |      4.597 ns |  3.46 |    8064 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |     399.50 ns |      1.041 ns |      0.923 ns |  0.78 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     511.47 ns |      2.828 ns |      2.507 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     584.44 ns |      2.419 ns |      2.020 ns |  1.14 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |   1,155.42 ns |      3.197 ns |      2.834 ns |  2.26 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |   1,698.96 ns |      8.762 ns |      8.196 ns |  3.32 |    8064 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |     378.68 ns |      4.898 ns |      4.090 ns |  0.74 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |     510.13 ns |      2.737 ns |      2.137 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |   1,119.63 ns |      4.232 ns |      3.751 ns |  2.19 |     768 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |   1,327.50 ns |      2.532 ns |      1.977 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |   4,108.32 ns |     44.236 ns |     41.378 ns |  3.09 |    6730 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |   4,171.53 ns |     10.313 ns |      9.142 ns |  3.14 |    5712 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |   4,365.49 ns |     38.437 ns |     34.073 ns |  3.29 |   12624 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |   4,851.55 ns |     14.949 ns |     13.252 ns |  3.65 |   10062 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |   5,562.11 ns |     23.039 ns |     20.423 ns |  4.19 |    6528 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |   1,556.54 ns |     24.689 ns |     23.094 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |   6,740.85 ns |    103.577 ns |     96.886 ns |  4.33 |   12496 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |   6,817.68 ns |     44.979 ns |     39.872 ns |  4.38 |   13543 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |   7,364.25 ns |     34.381 ns |     32.160 ns |  4.73 |   19432 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |   9,774.45 ns |    111.890 ns |     93.433 ns |  6.28 |   13312 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |   2,420.93 ns |     14.660 ns |     11.446 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |   7,427.63 ns |     31.608 ns |     29.566 ns |  3.07 |   15208 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |   7,884.04 ns |     29.920 ns |     26.523 ns |  3.26 |   14296 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |  10,054.38 ns |    124.910 ns |    116.841 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |  36,465.43 ns |    108.634 ns |     96.301 ns |  3.63 |   56400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |  42,137.55 ns |    102.678 ns |     85.741 ns |  4.19 |   52968 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |  46,943.29 ns |    125.957 ns |    111.657 ns |  4.67 |   59752 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |  48,361.42 ns |    176.800 ns |    156.729 ns |  4.81 |   64128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |  51,120.40 ns |    133.150 ns |    118.034 ns |  5.09 |   79208 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |  14,103.56 ns |     63.692 ns |     53.185 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |  61,171.46 ns |    223.026 ns |    197.707 ns |  4.34 |  124240 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |  69,311.27 ns |    242.627 ns |    226.953 ns |  4.91 |  127592 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |  74,918.12 ns |    588.181 ns |    550.185 ns |  5.31 |  120808 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |  78,015.93 ns |    470.342 ns |    392.756 ns |  5.53 |  131968 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |  17,660.40 ns |     94.918 ns |     79.261 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |  63,805.25 ns |    290.514 ns |    271.747 ns |  3.61 |  142168 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |  71,013.81 ns |    181.291 ns |    160.710 ns |  4.02 |  144232 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             | 100,197.92 ns |    283.348 ns |    251.180 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             | 408,718.76 ns |  1,171.528 ns |  1,095.848 ns |  4.08 |  563280 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             | 416,375.26 ns |  1,343.127 ns |  1,190.647 ns |  4.16 |  456168 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             | 457,608.66 ns |    910.758 ns |    851.924 ns |  4.57 |  589672 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 502,234.23 ns |    782.777 ns |    653.654 ns |  5.01 |  640129 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             | 555,940.62 ns |  1,720.496 ns |  1,525.175 ns |  5.55 |  770409 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     | 132,290.14 ns |    615.321 ns |    545.466 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 661,581.98 ns |  1,509.813 ns |  1,338.410 ns |  5.00 | 1241681 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 720,569.06 ns | 11,241.070 ns | 10,514.903 ns |  5.45 | 1134569 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 725,239.12 ns |  7,949.237 ns |  7,435.722 ns |  5.48 | 1268073 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 796,114.59 ns |  2,211.913 ns |  2,069.025 ns |  6.02 | 1318530 B | 
|                                                      |          |            |                  |               |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            | 183,136.55 ns |  1,053.041 ns |    985.015 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 690,282.32 ns |  2,596.194 ns |  2,428.482 ns |  3.77 | 1420889 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 739,060.13 ns |  2,361.389 ns |  1,971.867 ns |  4.04 | 1434473 B |