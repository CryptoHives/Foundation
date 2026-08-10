| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     13.04 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     13.61 ns |  1.04 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     18.93 ns |  1.45 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.55 ns |  1.50 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     21.87 ns |  1.68 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     37.94 ns |  2.91 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     60.37 ns |  4.63 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     12.83 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     14.29 ns |  1.11 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     18.62 ns |  1.45 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     22.51 ns |  1.75 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     38.52 ns |  3.00 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     57.67 ns |  4.49 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     40.60 ns |  1.00 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     42.39 ns |  1.04 |      88 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     77.31 ns |  1.90 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     97.07 ns |  2.39 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    129.89 ns |  3.20 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    494.64 ns | 12.18 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    523.15 ns | 12.88 |     352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     55.06 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    114.49 ns |  2.08 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    390.54 ns |  7.09 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    517.53 ns |  9.40 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    569.76 ns | 10.35 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    625.92 ns | 11.37 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    275.13 ns |  0.83 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    333.25 ns |  1.00 |         - | 
| Multiple · AsyncLock · Nito               | 10         | None             |    539.61 ns |  1.62 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    625.28 ns |  1.88 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    638.65 ns |  1.92 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,068.11 ns |  9.21 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,470.03 ns | 10.41 |    2296 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    500.33 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    639.69 ns |  1.28 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,243.15 ns |  6.48 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,371.60 ns |  6.74 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,205.11 ns |  8.41 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,230.69 ns | 10.46 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,458.42 ns |  0.79 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,129.31 ns |  1.00 |         - | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,260.35 ns |  1.68 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,793.57 ns |  1.85 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,001.93 ns |  1.92 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 32,138.44 ns | 10.27 |   12216 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,861.10 ns | 11.46 |   21800 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  4,951.47 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,835.19 ns |  1.18 |   21008 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 32,032.42 ns |  6.47 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 32,452.95 ns |  6.55 |   12216 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 40,571.34 ns |  8.19 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 51,376.96 ns | 10.38 |   50600 B |