| Description                                          | KeyCount | Iterations | cancellationType | Mean            | Error         | StdDev        | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |----------------:|--------------:|--------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        59.34 ns |      0.132 ns |      0.238 ns |  0.68 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        84.14 ns |      0.725 ns |      1.363 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        87.87 ns |      0.412 ns |      0.732 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |       171.54 ns |      1.601 ns |      2.967 ns |  1.95 |     144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |       183.76 ns |      0.652 ns |      1.224 ns |  2.09 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       271.42 ns |      0.794 ns |      1.472 ns |  3.09 |     504 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        58.15 ns |      0.100 ns |      0.187 ns |  0.66 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        83.18 ns |      0.323 ns |      0.598 ns |  0.95 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        87.65 ns |      0.373 ns |      0.663 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |       184.40 ns |      1.461 ns |      2.743 ns |  2.10 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |       272.38 ns |      0.992 ns |      1.789 ns |  3.11 |     504 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        59.17 ns |      0.071 ns |      0.131 ns |  0.68 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |        87.09 ns |      0.508 ns |      0.967 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |       183.32 ns |      0.118 ns |      0.213 ns |  2.11 |      48 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |       239.82 ns |      1.223 ns |      2.297 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |       634.33 ns |      6.441 ns |     12.255 ns |  2.65 |     432 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |       795.81 ns |      4.862 ns |      8.891 ns |  3.32 |     559 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |       817.13 ns |      1.882 ns |      3.535 ns |  3.41 |     520 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |       858.57 ns |      3.797 ns |      7.039 ns |  3.58 |     728 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |       879.26 ns |      2.756 ns |      5.176 ns |  3.67 |     888 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |       282.89 ns |      0.806 ns |      1.494 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |       950.27 ns |     12.018 ns |     22.865 ns |  3.36 |     856 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |     1,083.22 ns |     12.712 ns |     23.562 ns |  3.83 |     944 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     1,118.20 ns |      7.841 ns |     14.726 ns |  3.95 |     983 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |     1,213.94 ns |      6.503 ns |     12.055 ns |  4.29 |    1311 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       356.43 ns |      0.733 ns |      1.284 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |     1,055.61 ns |      4.228 ns |      7.731 ns |  2.96 |     992 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     1,134.12 ns |      4.576 ns |      8.594 ns |  3.18 |    1047 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |     1,946.52 ns |      3.639 ns |      6.835 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     5,361.51 ns |     41.695 ns |     75.185 ns |  2.75 |    3600 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     5,785.42 ns |     29.228 ns |     54.176 ns |  2.97 |    3832 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     5,815.56 ns |     45.914 ns |     85.104 ns |  2.99 |    3408 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     6,565.70 ns |     21.746 ns |     40.308 ns |  3.37 |    5048 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     6,584.67 ns |     26.247 ns |     48.651 ns |  3.38 |    4160 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |     2,431.34 ns |     10.951 ns |     20.569 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |     8,574.28 ns |     51.153 ns |     97.324 ns |  3.53 |    7840 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |     8,926.29 ns |     50.979 ns |     95.751 ns |  3.67 |    8072 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |     9,226.49 ns |     59.992 ns |    109.699 ns |  3.80 |    7648 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |     9,979.65 ns |     65.517 ns |    121.439 ns |  4.10 |    8400 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     3,098.87 ns |      3.952 ns |      7.227 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |     9,362.02 ns |     94.907 ns |    180.570 ns |  3.02 |    8968 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |     9,550.58 ns |    112.282 ns |    208.123 ns |  3.08 |    9112 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |    19,106.68 ns |     60.011 ns |    112.715 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    57,212.43 ns |    493.811 ns |    927.497 ns |  2.99 |   35280 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    59,053.46 ns |    400.453 ns |    752.148 ns |  3.09 |   28608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    60,311.62 ns |    645.905 ns |  1,197.227 ns |  3.16 |   36952 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    67,283.52 ns |    366.815 ns |    688.968 ns |  3.52 |   40128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    68,160.28 ns |    223.257 ns |    408.238 ns |  3.57 |   48248 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |    23,712.57 ns |     78.405 ns |    149.174 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    92,530.26 ns |    435.933 ns |    829.408 ns |  3.90 |   77680 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |    95,415.29 ns |    552.660 ns |  1,038.029 ns |  4.02 |   79352 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |    96,460.13 ns |    458.729 ns |    838.812 ns |  4.07 |   71008 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |   104,993.32 ns |    619.015 ns |  1,162.660 ns |  4.43 |   82528 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |    30,272.16 ns |     87.817 ns |    167.081 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |    99,898.80 ns |    534.883 ns |    978.064 ns |  3.30 |   88888 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |   101,223.15 ns |    459.618 ns |    840.437 ns |  3.34 |   89752 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |       213.52 ns |      1.281 ns |      2.342 ns |  0.67 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       303.03 ns |      0.365 ns |      0.667 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |       316.86 ns |      1.335 ns |      2.508 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       614.42 ns |      1.193 ns |      2.211 ns |  1.94 |     576 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       712.12 ns |      2.432 ns |      4.626 ns |  2.25 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |     1,085.46 ns |     10.480 ns |     19.685 ns |  3.43 |    2016 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |       216.10 ns |      4.193 ns |      7.771 ns |  0.68 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       313.40 ns |      6.879 ns |     12.579 ns |  0.99 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |       317.26 ns |      0.523 ns |      0.969 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       710.01 ns |      2.507 ns |      4.584 ns |  2.24 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |     1,068.60 ns |      5.570 ns |     10.597 ns |  3.37 |    2016 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |       227.15 ns |      6.517 ns |     12.081 ns |  0.72 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |       315.01 ns |      1.585 ns |      2.898 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       712.19 ns |      2.514 ns |      4.597 ns |  2.26 |     192 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |       932.50 ns |      4.920 ns |      8.745 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     2,362.66 ns |     35.471 ns |     67.487 ns |  2.53 |    1488 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     2,897.73 ns |     17.371 ns |     32.627 ns |  3.11 |    1767 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     2,962.60 ns |     32.605 ns |     61.240 ns |  3.18 |    1760 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     3,136.36 ns |     10.903 ns |     20.210 ns |  3.36 |    2599 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     3,197.31 ns |     25.011 ns |     46.360 ns |  3.43 |    3238 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |     1,118.95 ns |      3.866 ns |      7.069 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     3,592.63 ns |     24.458 ns |     45.939 ns |  3.21 |    3184 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     4,140.83 ns |     22.546 ns |     39.487 ns |  3.70 |    3464 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     4,259.72 ns |     27.279 ns |     50.563 ns |  3.81 |    3456 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     4,629.85 ns |     42.026 ns |     82.955 ns |  4.14 |    4936 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |     1,392.66 ns |      4.946 ns |      9.167 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     3,942.08 ns |     25.223 ns |     47.375 ns |  2.83 |    3656 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     4,332.78 ns |     23.522 ns |     43.011 ns |  3.11 |    3880 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     7,678.22 ns |     41.132 ns |     75.211 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    21,451.55 ns |    205.232 ns |    385.476 ns |  2.79 |   14160 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    24,048.04 ns |    363.301 ns |    691.219 ns |  3.13 |   15017 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    25,416.43 ns |    486.257 ns |  1,402.964 ns |  3.31 |   13320 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    26,086.96 ns |    198.283 ns |    362.572 ns |  3.40 |   16128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    28,232.90 ns |    136.760 ns |    253.494 ns |  3.68 |   19880 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |     9,718.81 ns |     36.382 ns |     66.526 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    34,737.11 ns |    389.109 ns |    711.508 ns |  3.57 |   31120 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    38,547.96 ns |    215.428 ns |    393.923 ns |  3.97 |   31976 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    39,439.02 ns |    348.058 ns |    653.738 ns |  4.06 |   33088 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    39,930.66 ns |    302.727 ns |    561.125 ns |  4.11 |   30280 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |    12,282.69 ns |     19.584 ns |     36.783 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    37,259.92 ns |    244.766 ns |    465.693 ns |  3.03 |   35608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    44,068.95 ns |    532.787 ns |  1,266.225 ns |  3.59 |   36136 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    73,268.64 ns |    152.523 ns |    290.191 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   226,230.28 ns |  1,720.704 ns |  3,273.819 ns |  3.09 |  140880 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   238,487.66 ns |  1,230.247 ns |  2,310.703 ns |  3.26 |  114120 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   260,086.78 ns |  1,141.546 ns |  2,087.381 ns |  3.55 |  147496 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   269,220.87 ns |  1,651.441 ns |  3,101.807 ns |  3.67 |  160128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   284,515.31 ns |  1,936.939 ns |  3,777.851 ns |  3.88 |  192680 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    94,256.10 ns |    244.507 ns |    440.897 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   373,483.07 ns |  1,749.366 ns |  3,328.352 ns |  3.96 |  310480 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   380,549.32 ns |  2,083.775 ns |  3,964.600 ns |  4.04 |  283720 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   399,878.95 ns |  1,690.129 ns |  3,215.646 ns |  4.24 |  317096 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   423,578.04 ns |  1,982.841 ns |  3,575.471 ns |  4.49 |  329728 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |   121,437.91 ns |    398.433 ns |    728.558 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   412,344.24 ns |  5,992.458 ns | 14,472.461 ns |  3.40 |  355288 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   439,772.02 ns |  2,632.830 ns |  4,747.537 ns |  3.62 |  358696 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       833.79 ns |      0.884 ns |      1.549 ns |  0.68 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |     1,185.45 ns |      1.413 ns |      2.585 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |     1,229.22 ns |      3.609 ns |      6.866 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |     2,529.61 ns |      9.566 ns |     17.967 ns |  2.06 |    2304 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |     3,089.79 ns |     57.132 ns |    108.699 ns |  2.51 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     4,326.94 ns |      9.314 ns |     17.722 ns |  3.52 |    8064 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       845.31 ns |      7.256 ns |     13.085 ns |  0.69 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |     1,174.67 ns |      2.442 ns |      4.646 ns |  0.96 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |     1,226.90 ns |      3.496 ns |      6.651 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |     3,095.54 ns |     25.893 ns |     49.264 ns |  2.52 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     4,343.75 ns |     13.431 ns |     24.895 ns |  3.54 |    8064 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |       862.43 ns |      1.165 ns |      2.160 ns |  0.70 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |     1,224.26 ns |      6.598 ns |     12.553 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |     3,004.87 ns |     21.896 ns |     41.660 ns |  2.45 |     768 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     3,668.59 ns |      9.615 ns |     17.582 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |     9,464.04 ns |    144.370 ns |    267.599 ns |  2.58 |    5712 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |    11,327.44 ns |    294.562 ns |    545.990 ns |  3.09 |    6528 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |    11,469.21 ns |     96.548 ns |    178.957 ns |  3.13 |    6736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |    12,517.55 ns |     99.366 ns |    184.182 ns |  3.41 |   12627 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |    12,578.49 ns |    100.005 ns |    185.367 ns |  3.43 |   10061 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     4,448.26 ns |      5.547 ns |     10.281 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |    14,755.21 ns |    276.406 ns |    594.993 ns |  3.32 |   12496 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    17,346.63 ns |    306.532 ns |    823.477 ns |  3.90 |   13312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |    17,362.18 ns |    153.976 ns |    303.933 ns |  3.90 |   13536 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |    19,123.65 ns |    167.757 ns |    319.176 ns |  4.30 |   19428 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     5,538.23 ns |     15.147 ns |     27.698 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    15,683.89 ns |    207.094 ns |    454.576 ns |  2.83 |   14296 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |    18,354.52 ns |    133.016 ns |    249.837 ns |  3.31 |   15204 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |    30,871.91 ns |     49.415 ns |     89.106 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    97,634.73 ns |  4,138.774 ns | 13,842.624 ns |  3.16 |   56400 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    98,007.46 ns |    413.782 ns |    787.264 ns |  3.17 |   52968 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |   101,896.09 ns |    581.248 ns |  1,077.381 ns |  3.30 |   59752 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |   103,336.32 ns |    849.967 ns |  1,637.597 ns |  3.35 |   64128 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |   114,095.46 ns |    649.950 ns |  1,138.334 ns |  3.70 |   79208 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    38,978.81 ns |     91.639 ns |    174.353 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |   137,143.17 ns |  1,068.416 ns |  2,006.744 ns |  3.52 |  124240 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   155,304.39 ns |  1,062.729 ns |  1,969.836 ns |  3.98 |  131968 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |   161,466.86 ns |  1,133.891 ns |  2,129.723 ns |  4.14 |  127592 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |   161,928.55 ns |    750.267 ns |  1,427.461 ns |  4.15 |  120808 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    49,497.79 ns |    185.563 ns |    339.312 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |   151,392.78 ns |    783.823 ns |  1,433.266 ns |  3.06 |  142168 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |   174,319.42 ns |    741.185 ns |  1,355.298 ns |  3.52 |  144232 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |   298,339.37 ns |    738.602 ns |  1,387.273 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   933,902.10 ns |  8,774.636 ns | 16,480.896 ns |  3.13 |  563281 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   950,764.62 ns |  5,674.116 ns | 10,795.596 ns |  3.19 |  456169 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             | 1,003,924.62 ns |  7,624.638 ns | 14,320.920 ns |  3.37 |  589673 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             | 1,079,445.49 ns |  9,902.062 ns | 18,354.108 ns |  3.62 |  640129 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             | 1,154,891.23 ns |  3,723.121 ns |  6,901.045 ns |  3.87 |  770409 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   381,686.66 ns |  1,345.472 ns |  2,460.271 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 1,496,755.50 ns |  5,883.508 ns | 11,193.986 ns |  3.92 | 1241681 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 1,642,657.13 ns |  7,185.988 ns | 13,497.029 ns |  4.30 | 1134569 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 1,652,682.56 ns |  6,876.219 ns | 12,745.514 ns |  4.33 | 1268121 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,684,813.72 ns | 12,833.625 ns | 23,141.675 ns |  4.41 | 1318577 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   508,923.42 ns |  1,637.106 ns |  3,074.882 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            | 1,633,930.04 ns | 11,472.978 ns | 21,265.902 ns |  3.21 | 1420897 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 1,822,836.10 ns |  7,147.353 ns | 13,424.462 ns |  3.58 | 1434473 B |