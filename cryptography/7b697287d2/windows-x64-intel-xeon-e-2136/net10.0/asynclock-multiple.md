| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     25.23 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     29.88 ns |  1.18 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     35.74 ns |  1.42 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     49.78 ns |  1.97 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     52.17 ns |  2.07 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     54.42 ns |  2.16 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     56.71 ns |  2.25 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     62.04 ns |  2.46 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |    123.17 ns |  4.88 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |    156.52 ns |  6.20 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     25.22 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     29.87 ns |  1.18 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     35.72 ns |  1.42 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     52.88 ns |  2.10 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     56.50 ns |  2.24 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     60.70 ns |  2.41 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     62.06 ns |  2.46 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |    123.21 ns |  4.89 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |    155.39 ns |  6.16 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |     25.21 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     51.85 ns |  2.06 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     54.34 ns |  2.16 |         - | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |    112.59 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |    125.81 ns |  1.12 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |    144.80 ns |  1.29 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |    193.07 ns |  1.71 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |    223.08 ns |  1.98 |         - | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |    227.53 ns |  2.02 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    302.54 ns |  2.69 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    312.56 ns |  2.78 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,095.86 ns |  9.73 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,203.04 ns | 10.68 |     352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |    164.16 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |    193.74 ns |  1.18 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |    229.09 ns |  1.40 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |    260.24 ns |  1.59 |         - | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    310.59 ns |  1.89 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    837.42 ns |  5.10 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,211.56 ns |  7.38 |     272 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |  1,297.38 ns |  7.90 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,475.42 ns |  8.99 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |    239.20 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    356.91 ns |  1.49 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |  1,335.71 ns |  5.58 |     600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    857.22 ns |  0.71 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    938.64 ns |  0.78 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |  1,210.21 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |  1,499.05 ns |  1.24 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |  1,666.71 ns |  1.38 |    2288 B | 
| Multiple · AsyncLock · DotNext            | 10         | None             |  1,667.27 ns |  1.38 |         - | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |  1,846.56 ns |  1.53 |    2160 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |  1,850.85 ns |  1.53 |    4400 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  7,791.74 ns |  6.44 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  7,846.12 ns |  6.48 |    2296 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |  1,522.40 ns |  0.90 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |  1,668.58 ns |  0.99 |    2288 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |  1,682.30 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |  1,991.96 ns |  1.18 |    1680 B | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |  2,107.31 ns |  1.25 |         - | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  6,012.79 ns |  3.57 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,531.41 ns |  5.07 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  9,359.46 ns |  5.56 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 10,264.29 ns |  6.10 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |  2,435.15 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  3,171.19 ns |  1.30 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  9,668.51 ns |  3.97 |    4848 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  8,308.27 ns |  0.69 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  8,981.58 ns |  0.75 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             | 11,984.87 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             | 14,352.53 ns |  1.20 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             | 15,456.07 ns |  1.29 |   21008 B | 
| Multiple · AsyncLock · DotNext            | 100        | None             | 15,927.22 ns |  1.33 |         - | 
| Multiple · AsyncLock · Nito               | 100        | None             | 17,700.65 ns |  1.48 |   41120 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             | 17,765.96 ns |  1.48 |   21600 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 50,813.65 ns |  4.24 |   21736 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 53,229.89 ns |  4.44 |   12152 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     | 15,073.39 ns |  0.88 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     | 16,962.29 ns |  0.99 |   21008 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     | 17,203.02 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     | 19,136.98 ns |  1.11 |   21120 B | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     | 20,606.47 ns |  1.20 |         - | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 52,980.45 ns |  3.08 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 61,722.96 ns |  3.59 |   12152 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 69,436.72 ns |  4.04 |   37730 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 82,146.23 ns |  4.78 |   50544 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            | 24,853.29 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 31,110.39 ns |  1.25 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 74,824.20 ns |  3.01 |   47329 B |