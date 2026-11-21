| Description                               | InitialCount | Iterations | cancellationType | Mean          | Error         | StdDev        | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|--------------:|--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      4.118 ns |     0.0138 ns |     0.0129 ns |  0.82 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |      5.050 ns |     0.0128 ns |     0.0119 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     11.471 ns |     0.0305 ns |     0.0285 ns |  2.27 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     12.511 ns |     0.0281 ns |     0.0249 ns |  2.48 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     12.763 ns |     0.0726 ns |     0.0679 ns |  2.53 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     16.321 ns |     0.0495 ns |     0.0463 ns |  3.23 |      32 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |      5.224 ns |     0.0237 ns |     0.0222 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     12.611 ns |     0.0398 ns |     0.0372 ns |  2.41 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     16.426 ns |     0.0529 ns |     0.0495 ns |  3.14 |      32 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |      5.223 ns |     0.0208 ns |     0.0195 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     12.947 ns |     0.0413 ns |     0.0387 ns |  2.48 |         - | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    176.747 ns |     0.4793 ns |     0.4483 ns |  0.57 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    245.431 ns |     0.5613 ns |     0.5251 ns |  0.79 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    264.533 ns |     0.6584 ns |     0.6159 ns |  0.86 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    307.120 ns |     1.0823 ns |     1.0123 ns |  0.99 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    308.885 ns |     0.5959 ns |     0.5574 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    474.739 ns |     1.4342 ns |     1.3415 ns |  1.54 |    1712 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    453.369 ns |     2.3128 ns |     2.1634 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    586.456 ns |     1.9243 ns |     1.8000 ns |  1.29 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  8,139.596 ns |   160.7864 ns |   332.0518 ns | 17.95 |    5200 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    727.288 ns |     1.9354 ns |     1.8103 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  7,982.209 ns |   136.9516 ns |   128.1046 ns | 10.98 |    6160 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  1,625.164 ns |     5.5614 ns |     5.2022 ns |  0.57 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,194.328 ns |     8.4702 ns |     7.5086 ns |  0.77 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,274.078 ns |     7.3606 ns |     6.8851 ns |  0.80 |    9600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  2,850.341 ns |     9.1638 ns |     8.5718 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  3,001.572 ns |     8.3985 ns |     7.8560 ns |  1.05 |   16000 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  4,691.642 ns |     8.1251 ns |     7.2027 ns |  1.65 |   21152 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  4,262.662 ns |    14.2563 ns |    12.6378 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  5,826.172 ns |    13.7860 ns |    12.8954 ns |  1.37 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 70,444.445 ns | 1,352.0386 ns | 1,264.6977 ns | 16.53 |   51280 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  7,152.501 ns |    20.8841 ns |    19.5350 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 60,318.416 ns | 1,175.6102 ns | 1,609.1886 ns |  8.43 |   60880 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     14.112 ns |     0.0352 ns |     0.0330 ns |  0.94 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     14.973 ns |     0.0498 ns |     0.0466 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     27.499 ns |     0.0597 ns |     0.0529 ns |  1.84 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     41.220 ns |     0.1089 ns |     0.1018 ns |  2.75 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     43.904 ns |     0.1796 ns |     0.1680 ns |  2.93 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     52.681 ns |     0.0745 ns |     0.0697 ns |  3.52 |      56 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     14.967 ns |     0.0255 ns |     0.0239 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     28.187 ns |     0.0309 ns |     0.0274 ns |  1.88 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     52.983 ns |     0.1385 ns |     0.1295 ns |  3.54 |      56 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     14.930 ns |     0.0689 ns |     0.0644 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     28.139 ns |     0.1441 ns |     0.1348 ns |  1.88 |         - | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    177.335 ns |     0.3918 ns |     0.3474 ns |  0.56 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    250.339 ns |     0.7794 ns |     0.7291 ns |  0.79 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    286.545 ns |     0.9263 ns |     0.8665 ns |  0.90 |     960 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    318.893 ns |     1.6752 ns |     1.4850 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    324.609 ns |     0.7389 ns |     0.6911 ns |  1.02 |    1600 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    516.789 ns |     0.8646 ns |     0.8087 ns |  1.62 |    1736 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    464.913 ns |     1.0730 ns |     0.9512 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    627.217 ns |     1.8519 ns |     1.7323 ns |  1.35 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  7,155.270 ns |   139.8853 ns |   209.3738 ns | 15.39 |    5200 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    734.042 ns |     2.9084 ns |     2.7206 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  7,249.813 ns |   144.3414 ns |   228.9407 ns |  9.88 |    6160 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  1,638.582 ns |     6.8260 ns |     6.3850 ns |  0.58 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,246.536 ns |     9.8507 ns |     9.2143 ns |  0.79 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,275.403 ns |     8.8548 ns |     8.2828 ns |  0.80 |    9600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  2,846.642 ns |    15.9419 ns |    14.9121 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  2,893.194 ns |     7.8907 ns |     7.3810 ns |  1.02 |   16000 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  4,717.278 ns |    24.6125 ns |    21.8183 ns |  1.66 |   21176 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  4,325.738 ns |    25.4794 ns |    22.5868 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  5,891.130 ns |     7.1976 ns |     6.7326 ns |  1.36 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 62,969.457 ns |   497.6932 ns |   465.5425 ns | 14.56 |   51280 B | 
|                                           |              |            |                  |               |               |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  7,150.661 ns |    16.5290 ns |    14.6526 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 62,728.578 ns | 1,171.2728 ns | 1,253.2488 ns |  8.77 |   60880 B |