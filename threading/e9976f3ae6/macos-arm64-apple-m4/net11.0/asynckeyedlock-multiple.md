| Description                                          | KeyCount | Iterations | cancellationType | Mean            | Error         | StdDev        | Ratio | Allocated | 
|----------------------------------------------------- |--------- |----------- |----------------- |----------------:|--------------:|--------------:|------:|----------:|
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | None             |        17.79 ns |      0.028 ns |      0.026 ns |  0.56 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | None             |        31.60 ns |      0.149 ns |      0.139 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | None             |        40.13 ns |      0.183 ns |      0.171 ns |  1.27 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 0          | None             |        65.49 ns |      0.143 ns |      0.134 ns |  2.07 |     144 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | None             |        67.73 ns |      0.097 ns |      0.081 ns |  2.14 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | None             |       107.36 ns |      0.109 ns |      0.102 ns |  3.40 |     504 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | NotCancelled     |        18.39 ns |      0.022 ns |      0.019 ns |  0.54 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | NotCancelled     |        34.19 ns |      0.263 ns |      0.246 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 0          | NotCancelled     |        39.64 ns |      0.098 ns |      0.087 ns |  1.16 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | NotCancelled     |        66.59 ns |      0.165 ns |      0.154 ns |  1.95 |      48 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 0          | NotCancelled     |       107.21 ns |      0.141 ns |      0.132 ns |  3.14 |     504 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 0          | Timed            |        18.84 ns |      0.023 ns |      0.022 ns |  0.55 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 0          | Timed            |        34.21 ns |      0.223 ns |      0.209 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 0          | Timed            |        66.65 ns |      0.246 ns |      0.192 ns |  1.95 |      48 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | None             |        73.36 ns |      0.256 ns |      0.240 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | None             |       475.67 ns |      5.841 ns |      4.878 ns |  6.48 |     431 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | None             |       682.26 ns |     13.600 ns |     23.094 ns |  9.30 |     526 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | None             |       699.97 ns |     13.921 ns |     16.032 ns |  9.54 |     511 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | None             |       824.38 ns |     14.689 ns |     13.740 ns | 11.24 |     876 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 1          | None             |       857.42 ns |     17.026 ns |     35.539 ns | 11.69 |     718 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | NotCancelled     |        86.01 ns |      0.113 ns |      0.101 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | NotCancelled     |       749.82 ns |     14.411 ns |     18.738 ns |  8.72 |     854 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | NotCancelled     |       859.77 ns |     17.020 ns |     30.691 ns | 10.00 |     933 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 1          | NotCancelled     |       965.23 ns |     19.237 ns |     32.140 ns | 11.22 |    1301 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 1          | NotCancelled     |     1,127.46 ns |     22.484 ns |     28.435 ns | 13.11 |     946 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 1          | Timed            |       124.30 ns |      0.354 ns |      0.331 ns |  1.00 |     152 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 1          | Timed            |       724.03 ns |     14.394 ns |     24.828 ns |  5.83 |     975 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 1          | Timed            |     1,119.78 ns |     21.184 ns |     20.806 ns |  9.01 |    1036 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | None             |       526.89 ns |      3.614 ns |      3.381 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | None             |     3,564.71 ns |     69.041 ns |     84.788 ns |  6.77 |    3600 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | None             |     4,146.82 ns |     70.076 ns |     65.549 ns |  7.87 |    3824 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | None             |     4,223.48 ns |     82.481 ns |    118.291 ns |  8.02 |    4136 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | None             |     4,398.74 ns |     85.504 ns |    114.145 ns |  8.35 |    3400 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 10         | None             |     5,161.57 ns |     78.123 ns |     73.076 ns |  9.80 |    5040 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | NotCancelled     |       694.34 ns |      1.882 ns |      1.761 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | NotCancelled     |     9,074.27 ns |    179.503 ns |    328.231 ns | 13.07 |    8064 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | NotCancelled     |     9,318.97 ns |    185.988 ns |    404.322 ns | 13.42 |    7840 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 10         | NotCancelled     |     9,620.57 ns |    189.376 ns |    194.475 ns | 13.86 |    7640 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 10         | NotCancelled     |    10,977.84 ns |    213.019 ns |    227.928 ns | 15.81 |    8376 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 10         | Timed            |     1,041.44 ns |      5.413 ns |      5.064 ns |  1.00 |    1520 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 10         | Timed            |     9,822.15 ns |    191.234 ns |    329.869 ns |  9.43 |    9104 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 10         | Timed            |    10,254.78 ns |    204.129 ns |    286.160 ns |  9.85 |    8968 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | None             |     4,611.60 ns |     64.546 ns |     60.376 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | None             |    32,026.46 ns |    188.192 ns |    176.034 ns |  6.95 |   35288 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | None             |    33,184.47 ns |    219.776 ns |    194.826 ns |  7.20 |   36944 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | None             |    35,886.73 ns |    627.773 ns |    587.219 ns |  7.78 |   28600 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | None             |    40,312.83 ns |    215.618 ns |    201.690 ns |  8.74 |   40136 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 1        | 100        | None             |    43,128.51 ns |    198.021 ns |    185.229 ns |  9.35 |   48240 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | NotCancelled     |     5,962.52 ns |     17.789 ns |     16.640 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | NotCancelled     |    69,229.11 ns |  1,306.551 ns |  1,452.228 ns | 11.61 |   77688 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 1        | 100        | NotCancelled     |    73,823.74 ns |  1,449.825 ns |  1,984.537 ns | 12.38 |   82536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | NotCancelled     |    75,148.42 ns |  1,453.974 ns |  2,038.268 ns | 12.60 |   79344 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 1        | 100        | NotCancelled     |    81,895.62 ns |    888.050 ns |    830.683 ns | 13.74 |   71000 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 1        | 100        | Timed            |     9,688.28 ns |     21.586 ns |     19.136 ns |  1.00 |   15200 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 1        | 100        | Timed            |    58,528.75 ns |    783.771 ns |    733.140 ns |  6.04 |   89744 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 1        | 100        | Timed            |    58,618.04 ns |    732.422 ns |    685.108 ns |  6.05 |   88896 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | None             |        87.80 ns |      0.272 ns |      0.255 ns |  0.86 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | None             |       102.67 ns |      0.689 ns |      0.644 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | None             |       125.24 ns |      0.330 ns |      0.292 ns |  1.22 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 0          | None             |       255.10 ns |      0.577 ns |      0.539 ns |  2.48 |     576 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | None             |       274.45 ns |      1.130 ns |      1.057 ns |  2.67 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | None             |       453.22 ns |      0.225 ns |      0.176 ns |  4.41 |    2016 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | NotCancelled     |        86.56 ns |      0.362 ns |      0.339 ns |  0.89 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | NotCancelled     |        97.29 ns |      0.720 ns |      0.673 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 0          | NotCancelled     |       124.38 ns |      0.166 ns |      0.156 ns |  1.28 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | NotCancelled     |       275.22 ns |      0.855 ns |      0.758 ns |  2.83 |     192 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 0          | NotCancelled     |       464.06 ns |      0.633 ns |      0.592 ns |  4.77 |    2016 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 0          | Timed            |        88.17 ns |      0.340 ns |      0.318 ns |  0.91 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 0          | Timed            |        97.10 ns |      0.346 ns |      0.289 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 0          | Timed            |       273.26 ns |      0.588 ns |      0.521 ns |  2.81 |     192 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | None             |       273.57 ns |      0.726 ns |      0.644 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | None             |     1,470.69 ns |     28.931 ns |     38.622 ns |  5.38 |    1760 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | None             |     1,502.32 ns |     29.720 ns |     59.354 ns |  5.49 |    3231 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 1          | None             |     1,633.31 ns |     32.647 ns |     70.277 ns |  5.97 |    2591 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | None             |     2,701.90 ns |     53.246 ns |     49.806 ns |  9.88 |    1488 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | None             |     3,152.88 ns |     36.977 ns |     34.589 ns | 11.52 |    1728 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | NotCancelled     |       324.58 ns |      1.449 ns |      1.355 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | NotCancelled     |     2,984.50 ns |     59.212 ns |     72.718 ns |  9.20 |    3184 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 1          | NotCancelled     |     3,274.20 ns |     64.811 ns |    104.658 ns | 10.09 |    3423 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 1          | NotCancelled     |     3,500.42 ns |     69.332 ns |    119.594 ns | 10.78 |    4925 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | NotCancelled     |     4,043.73 ns |     78.380 ns |    112.410 ns | 12.46 |    3454 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 1          | Timed            |       465.55 ns |      1.257 ns |      1.176 ns |  1.00 |     608 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 1          | Timed            |     4,063.92 ns |     76.018 ns |     74.660 ns |  8.73 |    3640 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 1          | Timed            |     4,291.74 ns |     44.416 ns |     39.374 ns |  9.22 |    3869 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | None             |     2,151.36 ns |      6.618 ns |      6.191 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | None             |    14,455.13 ns |    180.371 ns |    168.719 ns |  6.72 |   15008 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | None             |    15,016.54 ns |    253.398 ns |    237.029 ns |  6.98 |   14160 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | None             |    15,041.31 ns |    229.670 ns |    214.834 ns |  6.99 |   13312 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | None             |    17,678.04 ns |    213.429 ns |    178.223 ns |  8.22 |   16136 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 10         | None             |    22,470.59 ns |    527.207 ns |  1,554.482 ns | 10.44 |   19872 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | NotCancelled     |     2,638.82 ns |      5.085 ns |      4.508 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 10         | NotCancelled     |    38,237.59 ns |    506.205 ns |    448.737 ns | 14.49 |   30272 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | NotCancelled     |    39,117.07 ns |    628.041 ns |    587.469 ns | 14.82 |   31968 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | NotCancelled     |    39,781.63 ns |    757.183 ns |    708.270 ns | 15.08 |   31120 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 10         | NotCancelled     |    45,023.51 ns |    896.261 ns |  1,447.295 ns | 17.06 |   33096 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 10         | Timed            |     4,216.68 ns |     14.089 ns |     13.179 ns |  1.00 |    6080 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 10         | Timed            |    36,356.75 ns |    603.019 ns |    564.064 ns |  8.62 |   36128 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 10         | Timed            |    40,280.19 ns |    790.834 ns |  1,385.083 ns |  9.55 |   35608 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | None             |    21,735.74 ns |     74.227 ns |     69.432 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | None             |   126,774.06 ns |    466.856 ns |    436.697 ns |  5.83 |  147488 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | None             |   154,181.05 ns |  1,736.067 ns |  1,623.918 ns |  7.09 |  114112 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | None             |   163,331.24 ns |  2,152.560 ns |  2,013.506 ns |  7.51 |  160136 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 4        | 100        | None             |   164,613.00 ns |  2,660.000 ns |  2,221.220 ns |  7.57 |  192672 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | None             |   171,865.24 ns |  1,381.206 ns |  1,291.981 ns |  7.91 |  140888 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | NotCancelled     |    27,257.54 ns |     94.225 ns |     88.139 ns |  1.00 |   40736 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 4        | 100        | NotCancelled     |   184,056.80 ns |    700.395 ns |    584.862 ns |  6.75 |  283712 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | NotCancelled     |   221,930.76 ns |  1,531.521 ns |  1,432.586 ns |  8.14 |  317088 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | NotCancelled     |   290,085.27 ns |  5,556.259 ns |  5,705.869 ns | 10.64 |  310488 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 4        | 100        | NotCancelled     |   337,797.82 ns |  6,717.840 ns |  9,846.923 ns | 12.39 |  329736 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 4        | 100        | Timed            |    42,050.22 ns |    152.650 ns |    142.789 ns |  1.00 |  101536 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 4        | 100        | Timed            |   198,778.43 ns |  1,322.182 ns |  1,236.770 ns |  4.73 |  358688 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 4        | 100        | Timed            |   259,528.66 ns |  2,224.698 ns |  2,080.984 ns |  6.17 |  355288 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | None             |       338.97 ns |      1.251 ns |      1.170 ns |  0.90 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | None             |       378.66 ns |      1.310 ns |      1.225 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | None             |       462.74 ns |      0.466 ns |      0.413 ns |  1.22 |         - | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 0          | None             |       916.19 ns |      1.051 ns |      0.932 ns |  2.42 |    2304 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | None             |     1,048.99 ns |      2.016 ns |      1.885 ns |  2.77 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | None             |     1,636.22 ns |      1.121 ns |      0.994 ns |  4.32 |    8064 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | NotCancelled     |       334.51 ns |      0.989 ns |      0.925 ns |  0.89 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | NotCancelled     |       377.75 ns |      1.803 ns |      1.687 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 0          | NotCancelled     |       459.54 ns |      2.159 ns |      2.020 ns |  1.22 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | NotCancelled     |     1,047.80 ns |      2.416 ns |      2.260 ns |  2.77 |     768 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 0          | NotCancelled     |     1,645.49 ns |      2.422 ns |      2.266 ns |  4.36 |    8064 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 0          | Timed            |       351.58 ns |      1.691 ns |      1.582 ns |  0.93 |         - | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 0          | Timed            |       377.38 ns |      2.292 ns |      2.144 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 0          | Timed            |     1,093.56 ns |     11.621 ns |     10.870 ns |  2.90 |     768 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | None             |     1,059.94 ns |      7.596 ns |      7.105 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | None             |     7,568.89 ns |     58.317 ns |     51.697 ns |  7.14 |   12627 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | None             |     8,376.57 ns |    149.010 ns |    139.384 ns |  7.90 |    6528 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | None             |     8,763.14 ns |    198.745 ns |    586.005 ns |  8.27 |    5712 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | None             |     9,433.11 ns |     66.054 ns |     61.787 ns |  8.90 |    6723 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 1          | None             |    10,171.79 ns |     90.261 ns |     84.430 ns |  9.60 |   10053 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | NotCancelled     |     1,274.01 ns |      3.822 ns |      3.575 ns |  1.00 |         - | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | NotCancelled     |    12,128.94 ns |    241.544 ns |    361.532 ns |  9.52 |   12496 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 1          | NotCancelled     |    13,960.55 ns |    275.647 ns |    338.519 ns | 10.96 |   13312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | NotCancelled     |    15,828.11 ns |     87.945 ns |     82.264 ns | 12.42 |   13502 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 1          | NotCancelled     |    16,896.78 ns |    184.758 ns |    172.823 ns | 13.26 |   19384 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 1          | Timed            |     1,842.42 ns |      7.021 ns |      6.224 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 1          | Timed            |    13,413.82 ns |    261.838 ns |    422.820 ns |  7.28 |   14296 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 1          | Timed            |    15,871.14 ns |    104.130 ns |     97.404 ns |  8.61 |   15163 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | None             |     8,731.97 ns |     50.819 ns |     45.049 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | None             |    71,238.30 ns |  1,313.891 ns |  1,229.015 ns |  8.16 |   52960 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | None             |    76,062.89 ns |    842.597 ns |    746.940 ns |  8.71 |   59744 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | None             |    78,080.95 ns |  1,550.710 ns |  3,236.909 ns |  8.94 |   56400 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 10         | None             |    83,380.19 ns |  1,517.161 ns |  1,419.153 ns |  9.55 |   79200 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | None             |    83,611.35 ns |  1,652.735 ns |  3,063.450 ns |  9.58 |   64139 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | NotCancelled     |    10,684.85 ns |     25.411 ns |     23.769 ns |  1.00 |    2432 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | NotCancelled     |   108,917.18 ns |    831.147 ns |    736.790 ns | 10.19 |  127584 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 10         | NotCancelled     |   122,663.48 ns |    852.520 ns |    797.448 ns | 11.48 |  120800 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | NotCancelled     |   161,577.79 ns |  2,448.613 ns |  2,290.434 ns | 15.12 |  124240 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 10         | NotCancelled     |   186,729.48 ns |  3,705.206 ns |  4,550.326 ns | 17.48 |  131976 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 10         | Timed            |    16,698.97 ns |     60.132 ns |     56.247 ns |  1.00 |   26752 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 10         | Timed            |    97,393.96 ns |    431.319 ns |    403.456 ns |  5.83 |  144224 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 10         | Timed            |   128,112.20 ns |  2,407.796 ns |  2,576.315 ns |  7.67 |  142168 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | None             |    91,235.51 ns |    368.628 ns |    344.815 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | None             |   647,976.47 ns |  9,097.294 ns |  8,509.614 ns |  7.10 |  563281 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | None             |   653,325.20 ns |  4,596.998 ns |  4,300.035 ns |  7.16 |  640137 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | None             |   704,733.58 ns | 14,067.882 ns | 18,292.222 ns |  7.72 |  456161 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | None             |   754,123.81 ns | 14,913.452 ns | 18,315.060 ns |  8.27 |  589665 B | 
| Multiple · AsyncKeyedLock · RefImpl                  | 16       | 100        | None             |   940,971.58 ns |  8,438.499 ns |  7,893.377 ns | 10.31 |  770401 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | NotCancelled     |   112,725.48 ns |    494.017 ns |    462.104 ns |  1.00 |  221312 B | 
| Multiple · AsyncKeyedLock · AsyncUtilities (Striped) | 16       | 100        | NotCancelled     | 1,203,142.21 ns | 23,846.190 ns | 27,461.308 ns | 10.67 | 1318537 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | NotCancelled     | 1,236,540.81 ns | 23,479.093 ns | 20,813.604 ns | 10.97 | 1241681 B | 
| Multiple · AsyncKeyedLock · Dao.IndividualLock       | 16       | 100        | NotCancelled     | 1,316,862.45 ns |  8,356.197 ns |  7,816.392 ns | 11.68 | 1134561 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | NotCancelled     | 1,360,114.77 ns | 23,164.608 ns | 21,668.188 ns | 12.07 | 1268065 B | 
|                                                      |          |            |                  |                 |               |               |       |           | 
| Multiple · AsyncKeyedLock · Pooled                   | 16       | 100        | Timed            |   175,175.69 ns |    540.463 ns |    505.550 ns |  1.00 |  464512 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock (Striped) | 16       | 100        | Timed            |   991,083.19 ns | 17,731.906 ns | 16,586.436 ns |  5.66 | 1420889 B | 
| Multiple · AsyncKeyedLock · AsyncKeyedLock           | 16       | 100        | Timed            | 1,318,841.23 ns | 10,481.527 ns |  9,804.427 ns |  7.53 | 1434465 B |