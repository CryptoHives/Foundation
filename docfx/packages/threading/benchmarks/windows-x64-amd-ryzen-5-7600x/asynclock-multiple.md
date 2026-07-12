| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      9.536 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.119 ns |  1.17 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.787 ns |  1.24 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     18.025 ns |  1.89 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     18.871 ns |  1.98 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.178 ns |  2.01 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     21.782 ns |  2.28 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     41.077 ns |  4.31 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     62.488 ns |  6.55 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      9.522 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.983 ns |  1.15 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     12.206 ns |  1.28 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     17.912 ns |  1.88 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     19.147 ns |  2.01 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.716 ns |  2.28 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.195 ns |  4.33 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     61.039 ns |  6.41 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     35.247 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     40.062 ns |  1.14 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     43.399 ns |  1.23 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     64.181 ns |  1.82 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     77.133 ns |  2.19 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    103.249 ns |  2.93 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    124.850 ns |  3.54 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    488.316 ns | 13.86 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    522.361 ns | 14.82 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     51.871 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     61.673 ns |  1.19 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     82.239 ns |  1.59 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    128.097 ns |  2.47 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    398.280 ns |  7.68 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    523.182 ns | 10.09 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    612.621 ns | 11.81 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    720.082 ns | 13.88 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    270.603 ns |  0.84 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    279.892 ns |  0.87 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    323.561 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    528.012 ns |  1.63 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    568.655 ns |  1.76 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    641.651 ns |  1.98 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    661.079 ns |  2.04 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,209.315 ns |  9.92 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,314.005 ns | 10.24 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    486.657 ns |  0.97 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    503.057 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    664.361 ns |  1.32 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    733.058 ns |  1.46 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,216.687 ns |  6.40 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,401.434 ns |  6.76 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,267.693 ns |  8.48 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,243.839 ns | 10.43 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,541.490 ns |  0.75 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,677.721 ns |  0.79 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,375.958 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,791.212 ns |  1.42 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,350.238 ns |  1.59 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,010.683 ns |  1.78 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,140.041 ns |  1.82 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 34,126.868 ns | 10.11 |   12215 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,701.113 ns | 10.58 |   21800 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,704.234 ns |  0.85 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,518.994 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,039.134 ns |  1.09 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  7,173.219 ns |  1.30 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 32,869.257 ns |  5.96 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 34,832.601 ns |  6.31 |   12216 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 43,939.460 ns |  7.96 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 51,746.601 ns |  9.38 |   50600 B |