| Description                               | InitialCount | Iterations | cancellationType | Mean          | Error       | StdDev      | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------------:|------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      5.899 ns |   0.0125 ns |   0.0111 ns |  0.72 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |      8.152 ns |   0.0414 ns |   0.0387 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     13.183 ns |   0.0585 ns |   0.0547 ns |  1.62 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     17.275 ns |   0.0510 ns |   0.0477 ns |  2.12 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     17.660 ns |   0.0484 ns |   0.0404 ns |  2.17 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     19.826 ns |   0.0916 ns |   0.0812 ns |  2.43 |      32 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |      8.296 ns |   0.0107 ns |   0.0084 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     16.050 ns |   0.0439 ns |   0.0389 ns |  1.93 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     19.937 ns |   0.0852 ns |   0.0797 ns |  2.40 |      32 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |      7.869 ns |   0.0326 ns |   0.0305 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     16.524 ns |   0.0581 ns |   0.0515 ns |  2.10 |         - | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    219.921 ns |   0.6851 ns |   0.6409 ns |  0.57 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    278.276 ns |   2.2313 ns |   2.0872 ns |  0.73 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    289.216 ns |   5.7054 ns |   7.4186 ns |  0.76 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    336.108 ns |   1.6032 ns |   1.4996 ns |  0.88 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    382.956 ns |   5.7310 ns |   5.3608 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    582.973 ns |   6.4258 ns |   5.6963 ns |  1.52 |    1712 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    610.713 ns |   4.7374 ns |   4.4314 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    802.242 ns |  12.9389 ns |  10.8046 ns |  1.31 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  2,973.459 ns |  26.6482 ns |  22.2524 ns |  4.87 |    5208 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    837.508 ns |   6.9240 ns |   6.4767 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  3,134.473 ns |  25.7451 ns |  24.0819 ns |  3.74 |    6168 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  2,149.975 ns |   8.0188 ns |   7.1085 ns |  0.56 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,712.510 ns |  53.2211 ns |  78.0108 ns |  0.71 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,823.719 ns |  37.8979 ns |  33.5955 ns |  0.74 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  3,216.543 ns |  12.2524 ns |  10.8615 ns |  0.84 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  3,823.317 ns |  76.4413 ns |  71.5033 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  5,518.615 ns | 109.1738 ns | 116.8147 ns |  1.44 |   21152 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  6,143.679 ns |  47.7785 ns |  44.6920 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  7,421.489 ns | 121.8341 ns | 130.3611 ns |  1.21 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 32,217.569 ns | 431.0320 ns | 403.1876 ns |  5.24 |   51288 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  8,551.009 ns | 100.0841 ns |  93.6187 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 33,870.520 ns | 389.8437 ns | 364.6600 ns |  3.96 |   60888 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     14.221 ns |   0.0273 ns |   0.0228 ns |  0.58 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     24.499 ns |   0.0875 ns |   0.0819 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     32.363 ns |   0.1629 ns |   0.1444 ns |  1.32 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     44.628 ns |   0.1373 ns |   0.1285 ns |  1.82 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     53.145 ns |   0.1753 ns |   0.1554 ns |  2.17 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     62.738 ns |   0.9480 ns |   0.8868 ns |  2.56 |      56 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     24.437 ns |   0.0823 ns |   0.0769 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     32.438 ns |   0.2409 ns |   0.2011 ns |  1.33 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     61.244 ns |   0.4447 ns |   0.4160 ns |  2.51 |      56 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     25.256 ns |   0.0514 ns |   0.0481 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     33.972 ns |   0.1253 ns |   0.1111 ns |  1.35 |         - | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    219.928 ns |   0.6288 ns |   0.5882 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    323.749 ns |   0.8919 ns |   0.8343 ns |  0.79 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    354.140 ns |   2.4577 ns |   2.2989 ns |  0.87 |     880 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    407.918 ns |   7.0977 ns |   6.6392 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    411.453 ns |   1.6220 ns |   1.4379 ns |  1.01 |    1600 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    614.507 ns |   4.1729 ns |   3.9033 ns |  1.51 |    1736 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    613.925 ns |   7.3422 ns |   6.8679 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    826.256 ns |   5.8990 ns |   5.2293 ns |  1.35 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  2,808.403 ns |  19.6737 ns |  18.4028 ns |  4.58 |    5208 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    867.398 ns |   6.9482 ns |   6.4994 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  2,962.566 ns |  39.1394 ns |  36.6110 ns |  3.42 |    6168 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  2,220.954 ns |  41.4905 ns |  38.8102 ns |  0.58 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,721.115 ns |  22.8792 ns |  21.4012 ns |  0.71 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  3,140.433 ns |   9.3201 ns |   8.7180 ns |  0.82 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  3,210.567 ns |  11.1192 ns |   9.2850 ns |  0.84 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  3,838.543 ns |  24.3926 ns |  22.8169 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  5,442.063 ns |  41.9786 ns |  39.2668 ns |  1.42 |   21176 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  6,245.768 ns |  77.8696 ns |  72.8393 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  8,032.051 ns |  61.8946 ns |  54.8679 ns |  1.29 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 29,635.829 ns | 361.2581 ns | 337.9210 ns |  4.75 |   51288 B | 
|                                           |              |            |                  |               |             |             |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  8,384.824 ns |  80.9282 ns |  75.7003 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 30,801.965 ns | 404.8284 ns | 378.6768 ns |  3.67 |   60888 B |