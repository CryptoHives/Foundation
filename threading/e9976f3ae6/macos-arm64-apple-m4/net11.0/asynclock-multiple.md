| Description                               | Iterations | cancellationType | Mean          | Error         | StdDev        | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|--------------:|--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      5.821 ns |     0.0147 ns |     0.0138 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |      5.975 ns |     0.0200 ns |     0.0187 ns |  1.03 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      6.516 ns |     0.0070 ns |     0.0066 ns |  1.12 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     12.798 ns |     0.0145 ns |     0.0135 ns |  2.20 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     13.321 ns |     0.0262 ns |     0.0245 ns |  2.29 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     14.293 ns |     0.0311 ns |     0.0291 ns |  2.46 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     14.604 ns |     0.0283 ns |     0.0250 ns |  2.51 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     17.088 ns |     0.0181 ns |     0.0169 ns |  2.94 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 0          | None             |     42.479 ns |     0.0316 ns |     0.0247 ns |  7.30 |     312 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     56.380 ns |     0.0711 ns |     0.0665 ns |  9.69 |     208 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      5.754 ns |     0.0106 ns |     0.0099 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |      5.963 ns |     0.0215 ns |     0.0201 ns |  1.04 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |      6.637 ns |     0.0109 ns |     0.0097 ns |  1.15 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     12.621 ns |     0.0078 ns |     0.0073 ns |  2.19 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     13.502 ns |     0.0272 ns |     0.0241 ns |  2.35 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     14.474 ns |     0.0318 ns |     0.0297 ns |  2.52 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     17.076 ns |     0.0163 ns |     0.0144 ns |  2.97 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 0          | NotCancelled     |     43.156 ns |     0.0438 ns |     0.0410 ns |  7.50 |     312 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     56.793 ns |     0.1179 ns |     0.1103 ns |  9.87 |     208 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |      5.776 ns |     0.0226 ns |     0.0211 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     13.235 ns |     0.0442 ns |     0.0414 ns |  2.29 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     14.616 ns |     0.0433 ns |     0.0405 ns |  2.53 |         - | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     25.185 ns |     0.0935 ns |     0.0875 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     27.017 ns |     0.0634 ns |     0.0593 ns |  1.07 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     34.914 ns |     0.1125 ns |     0.0997 ns |  1.39 |      88 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |     43.094 ns |     0.0825 ns |     0.0689 ns |  1.71 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     54.318 ns |     0.1734 ns |     0.1622 ns |  2.16 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     70.350 ns |     0.2341 ns |     0.2190 ns |  2.79 |     216 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 1          | None             |    102.859 ns |     0.0785 ns |     0.0734 ns |  4.08 |     712 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    112.825 ns |     0.2057 ns |     0.1823 ns |  4.48 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    345.673 ns |     6.6929 ns |     6.2606 ns | 13.73 |     207 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    542.417 ns |    10.7638 ns |    21.7434 ns | 21.54 |     430 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     38.042 ns |     0.1928 ns |     0.1709 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     44.883 ns |     0.1096 ns |     0.0915 ns |  1.18 |         - | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |     52.577 ns |     0.0537 ns |     0.0502 ns |  1.38 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     63.846 ns |     0.0863 ns |     0.0807 ns |  1.68 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    111.746 ns |     0.1398 ns |     0.1239 ns |  2.94 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    375.701 ns |     7.0937 ns |     7.2847 ns |  9.88 |     207 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    478.996 ns |     9.4763 ns |    14.4713 ns | 12.59 |     599 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 1          | NotCancelled     |    634.025 ns |     6.4217 ns |     6.0068 ns | 16.67 |     936 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    653.934 ns |    11.0641 ns |    10.3494 ns | 17.19 |     854 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     67.641 ns |     0.3926 ns |     0.3672 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    116.895 ns |     0.2809 ns |     0.2490 ns |  1.73 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    700.946 ns |    13.9064 ns |    13.6579 ns | 10.36 |     694 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    213.816 ns |     0.8590 ns |     0.7615 ns |  0.69 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    265.827 ns |     1.1353 ns |     1.0620 ns |  0.86 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    310.175 ns |     1.3434 ns |     1.1908 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | None             |    345.591 ns |     0.9314 ns |     0.8712 ns |  1.11 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    466.728 ns |     1.0810 ns |     1.0112 ns |  1.50 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    600.603 ns |     0.5901 ns |     0.5231 ns |  1.94 |    2288 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    601.298 ns |     2.0531 ns |     1.9205 ns |  1.94 |    2160 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 10         | None             |    607.733 ns |     0.3571 ns |     0.3166 ns |  1.96 |    4312 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  2,764.906 ns |    39.5147 ns |    36.9620 ns |  8.91 |    1288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  4,199.541 ns |   142.4675 ns |   420.0685 ns | 13.54 |    3528 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    380.540 ns |     0.9573 ns |     0.8486 ns |  0.86 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    443.763 ns |     1.1428 ns |     1.0131 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |    460.214 ns |     0.7561 ns |     0.7073 ns |  1.04 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    585.492 ns |     1.9218 ns |     1.7977 ns |  1.32 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    603.230 ns |     1.2295 ns |     1.1501 ns |  1.36 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,187.366 ns |    51.9250 ns |    48.5707 ns |  7.18 |    1288 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 10         | NotCancelled     |  6,073.841 ns |   117.6622 ns |   152.9941 ns | 13.69 |    6552 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  8,951.447 ns |   176.5048 ns |   235.6289 ns | 20.17 |    5208 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  9,240.984 ns |   184.4363 ns |   404.8421 ns | 20.82 |    7768 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    730.489 ns |     2.8063 ns |     2.6250 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,083.516 ns |     2.6892 ns |     2.2456 ns |  1.48 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  8,514.694 ns |   164.6946 ns |   196.0572 ns | 11.66 |    6184 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,989.332 ns |    12.9640 ns |    12.1266 ns |  0.68 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,369.326 ns |     5.3510 ns |     5.0053 ns |  0.82 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,904.824 ns |     9.8357 ns |     9.2003 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | None             |  3,187.176 ns |    14.4158 ns |    13.4846 ns |  1.10 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,641.423 ns |    19.8692 ns |    18.5856 ns |  1.60 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,527.960 ns |    11.8794 ns |    11.1120 ns |  1.90 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,679.173 ns |    15.8498 ns |    14.0504 ns |  1.96 |   21600 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 100        | None             |  5,799.060 ns |    19.8412 ns |    17.5887 ns |  2.00 |   40312 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 34,876.955 ns |   369.9310 ns |   346.0337 ns | 12.01 |   12088 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 49,326.580 ns |   964.9243 ns |   947.6847 ns | 16.98 |   34488 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,660.610 ns |    10.5940 ns |     9.9096 ns |  0.86 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  4,254.114 ns |    14.1201 ns |    13.2080 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     |  4,292.075 ns |    10.3005 ns |     9.6351 ns |  1.01 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,502.896 ns |    10.4606 ns |     9.7849 ns |  1.29 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  5,805.724 ns |    18.3913 ns |    16.3034 ns |  1.36 |   21120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 42,116.063 ns |   501.1819 ns |   468.8059 ns |  9.90 |   12088 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 100        | NotCancelled     | 51,186.954 ns |   979.2821 ns | 2,170.0217 ns | 12.03 |   62712 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 73,370.819 ns | 1,436.4402 ns | 1,343.6471 ns | 17.25 |   76888 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 80,524.505 ns | 1,608.0964 ns | 4,179.6566 ns | 18.93 |   51288 B | 
|                                           |            |                  |               |               |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  7,152.069 ns |    19.7196 ns |    17.4809 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 11,045.132 ns |    55.9321 ns |    52.3189 ns |  1.54 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 67,211.411 ns | 1,287.9339 ns | 1,674.6780 ns |  9.40 |   60904 B |