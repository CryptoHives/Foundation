| Description                               | Iterations | cancellationType | Mean          | Error       | StdDev        | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------------:|--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |      7.435 ns |   0.0124 ns |     0.0104 ns |  0.97 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      7.652 ns |   0.0149 ns |     0.0132 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      8.328 ns |   0.0092 ns |     0.0087 ns |  1.09 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     15.436 ns |   0.0722 ns |     0.0640 ns |  2.02 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     17.884 ns |   0.0732 ns |     0.0649 ns |  2.34 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     18.896 ns |   0.0373 ns |     0.0291 ns |  2.47 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     18.911 ns |   0.0482 ns |     0.0427 ns |  2.47 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     20.980 ns |   0.0716 ns |     0.0635 ns |  2.74 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 0          | None             |     43.787 ns |   0.0670 ns |     0.0523 ns |  5.72 |     312 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     67.138 ns |   0.2430 ns |     0.2273 ns |  8.77 |     208 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |      7.392 ns |   0.0287 ns |     0.0268 ns |  0.96 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      7.679 ns |   0.0142 ns |     0.0111 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |      8.494 ns |   0.0195 ns |     0.0163 ns |  1.11 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     15.824 ns |   0.0562 ns |     0.0526 ns |  2.06 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     18.109 ns |   0.0478 ns |     0.0424 ns |  2.36 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     18.819 ns |   0.0608 ns |     0.0508 ns |  2.45 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     20.915 ns |   0.1105 ns |     0.1034 ns |  2.72 |         - | 
| Multiple · AsyncLock · Nito.AsyncEx       | 0          | NotCancelled     |     44.195 ns |   0.1992 ns |     0.1766 ns |  5.76 |     312 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     68.174 ns |   0.4421 ns |     0.4136 ns |  8.88 |     208 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |      7.699 ns |   0.0162 ns |     0.0136 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     15.413 ns |   0.2933 ns |     0.2600 ns |  2.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     17.409 ns |   0.0334 ns |     0.0296 ns |  2.26 |         - | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     34.132 ns |   0.0993 ns |     0.0929 ns |  0.96 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     35.476 ns |   0.1078 ns |     0.0955 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     42.454 ns |   0.1533 ns |     0.1280 ns |  1.20 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     62.495 ns |   0.1006 ns |     0.0892 ns |  1.76 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |     70.665 ns |   0.3756 ns |     0.3329 ns |  1.99 |         - | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     87.650 ns |   0.3631 ns |     0.3219 ns |  2.47 |     216 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 1          | None             |    108.787 ns |   0.1859 ns |     0.1552 ns |  3.07 |     712 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    130.039 ns |   0.6152 ns |     0.5755 ns |  3.67 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    214.743 ns |   1.2148 ns |     1.1364 ns |  6.05 |     208 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    282.401 ns |   0.2863 ns |     0.2678 ns |  7.96 |     432 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     53.636 ns |   0.0901 ns |     0.0704 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     64.007 ns |   0.0918 ns |     0.0814 ns |  1.19 |         - | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |     75.942 ns |   0.2939 ns |     0.2455 ns |  1.42 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     78.825 ns |   0.6355 ns |     0.5633 ns |  1.47 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    129.611 ns |   0.5608 ns |     0.4683 ns |  2.42 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    233.885 ns |   0.5332 ns |     0.4727 ns |  4.36 |     208 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 1          | NotCancelled     |    347.054 ns |   6.8337 ns |    15.7015 ns |  6.47 |     936 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    352.455 ns |   6.0958 ns |     5.7020 ns |  6.57 |     600 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    436.155 ns |   4.9533 ns |     4.3910 ns |  8.13 |     856 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     71.131 ns |   0.2085 ns |     0.1951 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    120.599 ns |   0.7445 ns |     0.6217 ns |  1.70 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    407.515 ns |   0.4258 ns |     0.3556 ns |  5.73 |     696 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    267.727 ns |   1.4450 ns |     1.2067 ns |  0.69 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    277.844 ns |   0.5463 ns |     0.4265 ns |  0.72 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    387.846 ns |   1.4379 ns |     1.2747 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | None             |    503.899 ns |   2.8755 ns |     2.6898 ns |  1.30 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    575.977 ns |   3.8973 ns |     3.2544 ns |  1.49 |    1680 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 10         | None             |    589.751 ns |   3.8021 ns |     2.9684 ns |  1.52 |    4312 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    692.155 ns |   1.6505 ns |     1.3783 ns |  1.78 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    706.189 ns |   4.0722 ns |     3.8091 ns |  1.82 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  2,025.600 ns |   8.3229 ns |     7.7852 ns |  5.22 |    1288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  2,307.384 ns |   7.1844 ns |     5.9993 ns |  5.95 |    3528 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    509.711 ns |   2.2964 ns |     2.0357 ns |  0.80 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    639.965 ns |   4.2204 ns |     3.5243 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |    641.573 ns |   9.5698 ns |     8.9516 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    692.013 ns |   1.5168 ns |     1.3446 ns |  1.08 |    2288 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    762.040 ns |   9.4534 ns |     8.8427 ns |  1.19 |    1680 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  2,314.637 ns |   6.5709 ns |     6.1464 ns |  3.62 |    1288 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 10         | NotCancelled     |  2,681.710 ns |  53.4455 ns |   120.6355 ns |  4.19 |    6552 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  2,929.433 ns |  19.7474 ns |    18.4718 ns |  4.58 |    5208 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  4,044.347 ns |  39.4420 ns |    32.9358 ns |  6.32 |    7768 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    811.925 ns |   2.8510 ns |     2.5273 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,128.944 ns |   7.3114 ns |     6.4813 ns |  1.39 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  3,182.291 ns |  27.5661 ns |    24.4366 ns |  3.92 |    6184 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,628.732 ns |   5.9512 ns |     5.2756 ns |  0.67 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,639.698 ns |  13.7647 ns |    12.8755 ns |  0.68 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,901.235 ns |  53.2277 ns |    49.7892 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | None             |  4,858.976 ns |  34.9447 ns |    32.6873 ns |  1.25 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  5,370.823 ns | 100.1716 ns |   107.1825 ns |  1.38 |   21120 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 100        | None             |  5,637.164 ns |  22.7560 ns |    20.1726 ns |  1.45 |   40312 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,338.601 ns |  31.3645 ns |    27.8038 ns |  1.63 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,610.756 ns |  25.4476 ns |    22.5587 ns |  1.69 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 21,763.962 ns |  64.5694 ns |    57.2391 ns |  5.58 |   12088 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 22,531.622 ns | 190.1589 ns |   148.4635 ns |  5.78 |   34488 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,904.430 ns |  25.9821 ns |    24.3037 ns |  0.79 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  6,181.483 ns |  30.2105 ns |    26.7808 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     |  6,287.868 ns |  27.0686 ns |    23.9956 ns |  1.02 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,306.054 ns |  19.6345 ns |    16.3957 ns |  1.02 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  7,215.442 ns |  35.3980 ns |    33.1114 ns |  1.17 |   21120 B | 
| Multiple · AsyncLock · Nito.AsyncEx       | 100        | NotCancelled     | 22,717.819 ns | 453.8810 ns | 1,121.8814 ns |  3.68 |   62712 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 24,568.875 ns |  71.8151 ns |    67.1759 ns |  3.97 |   12088 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 31,768.281 ns | 187.2560 ns |   175.1594 ns |  5.14 |   51288 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 43,090.173 ns | 152.1144 ns |   142.2879 ns |  6.97 |   76888 B | 
|                                           |            |                  |               |             |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  8,743.972 ns | 169.8666 ns |   232.5154 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 10,808.180 ns |  59.3762 ns |    55.5405 ns |  1.24 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 33,197.675 ns | 169.2493 ns |   158.3159 ns |  3.80 |   60904 B |