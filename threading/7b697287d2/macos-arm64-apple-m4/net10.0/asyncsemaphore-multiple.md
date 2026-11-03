| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      5.225 ns |  0.68 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |      7.724 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     10.694 ns |  1.38 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     10.921 ns |  1.41 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     11.361 ns |  1.47 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     16.432 ns |  2.13 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |      7.645 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     11.804 ns |  1.54 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     15.980 ns |  2.09 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |      7.251 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     12.146 ns |  1.68 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    148.536 ns |  0.48 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    230.508 ns |  0.74 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    234.756 ns |  0.76 |     880 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    298.826 ns |  0.96 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    310.643 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    436.812 ns |  1.41 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    424.019 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    546.224 ns |  1.29 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     | 10,559.767 ns | 24.90 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    721.936 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  9,077.976 ns | 12.57 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  1,406.586 ns |  0.51 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,033.273 ns |  0.73 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,184.942 ns |  0.79 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  2,727.810 ns |  0.98 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  2,776.252 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  4,335.996 ns |  1.56 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  4,022.722 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  5,478.262 ns |  1.36 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 84,456.575 ns | 21.00 |   37723 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  6,944.182 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 74,831.489 ns | 10.78 |   47348 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     15.165 ns |  0.78 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     19.536 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     26.623 ns |  1.36 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     34.125 ns |  1.75 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     34.565 ns |  1.77 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     49.865 ns |  2.55 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     19.515 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     28.000 ns |  1.43 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     51.555 ns |  2.64 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     18.512 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     27.429 ns |  1.48 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    154.870 ns |  0.47 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    252.628 ns |  0.77 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    255.151 ns |  0.78 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    315.515 ns |  0.96 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    328.691 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    487.965 ns |  1.48 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    430.262 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    594.601 ns |  1.38 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  9,043.101 ns | 21.02 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    742.967 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  8,816.312 ns | 11.87 |    4839 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  1,379.121 ns |  0.50 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,103.671 ns |  0.76 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,175.034 ns |  0.79 |    8800 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  2,758.499 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  2,824.243 ns |  1.02 |   16000 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  4,366.869 ns |  1.58 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  4,053.642 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  5,496.099 ns |  1.36 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 55,709.893 ns | 13.74 |   37722 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  6,985.060 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 59,342.712 ns |  8.50 |   47322 B |