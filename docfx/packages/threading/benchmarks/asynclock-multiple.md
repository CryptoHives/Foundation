| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     10.37 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.39 ns |  1.10 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.64 ns |  1.12 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     19.31 ns |  1.86 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     19.78 ns |  1.91 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     20.61 ns |  1.99 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     21.61 ns |  2.08 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     41.49 ns |  4.00 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     61.43 ns |  5.92 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     10.72 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     11.81 ns |  1.10 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     12.52 ns |  1.17 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     18.46 ns |  1.72 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     20.84 ns |  1.95 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     22.20 ns |  2.07 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.33 ns |  3.86 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     62.09 ns |  5.79 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     32.10 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     44.13 ns |  1.38 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     44.37 ns |  1.38 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     67.90 ns |  2.12 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     82.51 ns |  2.57 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    106.56 ns |  3.32 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    129.22 ns |  4.03 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    467.14 ns | 14.56 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    517.64 ns | 16.13 |     352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     47.26 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     63.62 ns |  1.35 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     81.42 ns |  1.72 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    124.50 ns |  2.64 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    448.00 ns |  9.48 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    522.48 ns | 11.06 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    585.40 ns | 12.39 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    692.24 ns | 14.65 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    273.89 ns |  0.83 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    294.30 ns |  0.90 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    328.37 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    549.88 ns |  1.67 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    612.18 ns |  1.86 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    651.25 ns |  1.98 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    683.48 ns |  2.08 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,145.39 ns |  9.58 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,373.07 ns | 10.27 |    2296 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    484.31 ns |  0.93 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    521.52 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    698.26 ns |  1.34 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    755.77 ns |  1.45 |    1680 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,455.39 ns |  6.63 |    1352 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,486.41 ns |  6.69 |    6800 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,372.02 ns |  8.38 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,219.07 ns | 10.01 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,639.18 ns |  0.85 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,717.96 ns |  0.88 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,096.70 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  5,001.31 ns |  1.62 |   21120 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,198.73 ns |  2.00 |   21600 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,321.47 ns |  2.04 |   21008 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  7,248.57 ns |  2.34 |   41120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 34,271.89 ns | 11.07 |   12215 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 36,087.90 ns | 11.65 |   21799 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,788.87 ns |  0.93 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,165.91 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,428.33 ns |  1.24 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  7,012.27 ns |  1.36 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 34,116.86 ns |  6.61 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 35,176.16 ns |  6.81 |   12216 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 44,594.54 ns |  8.63 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 55,929.97 ns | 10.83 |   50599 B |