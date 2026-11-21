| Description                               | InitialCount | Iterations | cancellationType | Mean         | Error      | StdDev       | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |-------------:|-----------:|-------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |     22.48 ns |   0.025 ns |     0.047 ns |  0.79 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |     28.46 ns |   0.105 ns |     0.197 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     47.03 ns |   0.045 ns |     0.084 ns |  1.65 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     48.00 ns |   0.043 ns |     0.078 ns |  1.69 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     48.69 ns |   0.069 ns |     0.130 ns |  1.71 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     58.09 ns |   0.055 ns |     0.100 ns |  2.04 |      32 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |     28.50 ns |   0.024 ns |     0.046 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     48.69 ns |   0.073 ns |     0.134 ns |  1.71 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     60.74 ns |   2.136 ns |     3.960 ns |  2.13 |      32 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |     28.19 ns |   0.017 ns |     0.032 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     48.88 ns |   0.645 ns |     1.227 ns |  1.73 |         - | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    697.36 ns |   2.300 ns |     4.205 ns |  0.56 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    878.08 ns |   1.718 ns |     3.054 ns |  0.70 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    931.81 ns |   1.133 ns |     2.129 ns |  0.75 |     880 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |  1,020.78 ns |   1.783 ns |     3.215 ns |  0.82 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |  1,247.46 ns |  13.518 ns |    24.719 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |  1,552.97 ns |   7.769 ns |    14.592 ns |  1.25 |    1712 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |  1,739.14 ns |  10.501 ns |    19.723 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |  1,963.89 ns |   4.365 ns |     7.981 ns |  1.13 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  6,693.85 ns |  20.626 ns |    37.192 ns |  3.85 |    5208 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |  2,349.86 ns |   8.950 ns |    16.811 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  7,377.18 ns |  78.230 ns |   145.005 ns |  3.14 |    6168 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  6,704.90 ns |   5.952 ns |    11.032 ns |  0.53 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  8,306.19 ns |  14.663 ns |    27.179 ns |  0.66 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  9,029.77 ns |  67.433 ns |   119.861 ns |  0.71 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  9,908.37 ns |  15.576 ns |    28.871 ns |  0.78 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             | 12,681.91 ns |  66.519 ns |   124.939 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             | 14,914.58 ns |  31.622 ns |    60.165 ns |  1.18 |   21152 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     | 17,276.53 ns | 166.423 ns |   312.582 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     | 18,962.80 ns |  50.738 ns |    96.534 ns |  1.10 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 73,183.95 ns | 655.817 ns | 1,247.760 ns |  4.24 |   51288 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            | 23,961.20 ns |  61.473 ns |   115.462 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 78,886.97 ns | 213.495 ns |   400.996 ns |  3.29 |   60888 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     73.71 ns |   0.413 ns |     0.775 ns |  0.69 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |    106.52 ns |   1.241 ns |     2.301 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |    112.30 ns |   0.091 ns |     0.169 ns |  1.05 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |    171.58 ns |   0.148 ns |     0.278 ns |  1.61 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |    174.29 ns |   0.628 ns |     1.194 ns |  1.64 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |    200.62 ns |   0.332 ns |     0.623 ns |  1.88 |      56 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |    109.46 ns |   0.369 ns |     0.657 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |    113.64 ns |   0.380 ns |     0.695 ns |  1.04 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |    200.65 ns |   0.325 ns |     0.594 ns |  1.83 |      56 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |    109.95 ns |   0.064 ns |     0.118 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |    110.69 ns |   0.163 ns |     0.310 ns |  1.01 |         - | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    765.73 ns |   4.468 ns |     8.392 ns |  0.58 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    997.42 ns |   3.286 ns |     6.253 ns |  0.75 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |  1,065.93 ns |  41.105 ns |    77.204 ns |  0.80 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |  1,150.92 ns |   2.111 ns |     4.017 ns |  0.87 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |  1,325.21 ns |   2.946 ns |     5.606 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |  1,708.40 ns |   4.646 ns |     8.495 ns |  1.29 |    1736 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |  1,801.82 ns |   2.836 ns |     5.256 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |  2,116.97 ns |   7.200 ns |    13.347 ns |  1.17 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  6,389.55 ns |  35.633 ns |    65.158 ns |  3.55 |    5208 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |  2,423.91 ns |   5.426 ns |    10.191 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  6,935.89 ns |  77.366 ns |   143.402 ns |  2.86 |    6168 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  6,901.01 ns |  33.789 ns |    64.287 ns |  0.56 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  8,583.76 ns |  92.456 ns |   171.373 ns |  0.70 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  9,120.74 ns |  54.033 ns |   100.154 ns |  0.74 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             | 10,151.72 ns |  68.096 ns |   127.900 ns |  0.82 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             | 12,344.58 ns |  57.971 ns |   110.296 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             | 15,170.55 ns |  41.146 ns |    74.194 ns |  1.23 |   21176 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     | 17,422.08 ns |  60.218 ns |   113.104 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     | 19,100.43 ns |  59.447 ns |   111.655 ns |  1.10 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 64,138.04 ns | 310.665 ns |   575.838 ns |  3.68 |   51288 B | 
|                                           |              |            |                  |              |            |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            | 24,135.63 ns | 227.841 ns |   433.491 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 70,502.18 ns | 410.708 ns |   781.415 ns |  2.92 |   60888 B |