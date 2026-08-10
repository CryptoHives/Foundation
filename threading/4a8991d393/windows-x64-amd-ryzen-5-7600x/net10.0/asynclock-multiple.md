| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.78 ns |  0.95 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     11.38 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     12.25 ns |  1.08 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     19.17 ns |  1.68 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     20.30 ns |  1.78 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     21.32 ns |  1.87 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     22.05 ns |  1.94 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     40.08 ns |  3.52 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     61.91 ns |  5.44 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.46 ns |  0.98 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     10.70 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     13.00 ns |  1.22 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     17.56 ns |  1.64 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     19.51 ns |  1.82 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.70 ns |  2.03 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     42.16 ns |  3.94 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     58.73 ns |  5.49 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |     10.47 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     18.02 ns |  1.72 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     20.98 ns |  2.00 |         - | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     34.17 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     36.42 ns |  1.07 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     42.36 ns |  1.24 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     65.51 ns |  1.92 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     76.80 ns |  2.25 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    101.89 ns |  2.98 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    122.57 ns |  3.59 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    466.41 ns | 13.65 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    507.71 ns | 14.86 |     352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     48.79 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     64.66 ns |  1.33 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     81.22 ns |  1.66 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    122.53 ns |  2.51 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    395.29 ns |  8.10 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    507.03 ns | 10.39 |     272 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    559.75 ns | 11.47 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    646.98 ns | 13.26 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     76.66 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    125.68 ns |  1.64 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    570.99 ns |  7.45 |     600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    265.46 ns |  0.79 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    276.82 ns |  0.82 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    336.65 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    546.60 ns |  1.62 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    572.11 ns |  1.70 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    645.76 ns |  1.92 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    653.44 ns |  1.94 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,199.22 ns |  9.50 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,403.76 ns | 10.11 |    2296 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    468.98 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    520.67 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    660.19 ns |  1.27 |    2288 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    743.33 ns |  1.43 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,239.64 ns |  6.22 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,521.10 ns |  6.76 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  4,709.30 ns |  9.05 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,019.18 ns |  9.64 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    797.82 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,153.37 ns |  1.45 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  4,380.18 ns |  5.49 |    4848 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,576.47 ns |  0.81 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,622.83 ns |  0.82 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,188.18 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,974.23 ns |  1.56 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,548.31 ns |  1.74 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,916.30 ns |  1.86 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,305.51 ns |  1.98 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 33,305.56 ns | 10.45 |   12215 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,911.66 ns | 11.26 |   21799 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,685.44 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,197.13 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,935.32 ns |  1.14 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  6,886.95 ns |  1.33 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 33,505.04 ns |  6.45 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 34,237.36 ns |  6.59 |   12215 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 42,009.73 ns |  8.08 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 49,590.10 ns |  9.54 |   50600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  7,974.46 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 10,830.72 ns |  1.36 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 41,658.75 ns |  5.22 |   47392 B |