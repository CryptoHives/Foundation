| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     13.16 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     13.63 ns |  1.04 |         - | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 0          | None             |     19.24 ns |  1.46 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.70 ns |  1.50 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     22.70 ns |  1.72 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     38.33 ns |  2.91 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     58.19 ns |  4.42 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     12.80 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     13.94 ns |  1.09 |         - | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 0          | NotCancelled     |     19.73 ns |  1.54 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     22.40 ns |  1.75 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     37.55 ns |  2.93 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     57.40 ns |  4.48 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     38.73 ns |  1.00 |         - | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 1          | None             |     41.75 ns |  1.08 |      88 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     75.87 ns |  1.96 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     95.66 ns |  2.47 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    133.56 ns |  3.45 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    489.32 ns | 12.63 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    501.05 ns | 12.94 |     352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     55.37 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    115.52 ns |  2.09 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    382.16 ns |  6.90 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    534.78 ns |  9.66 |     272 B | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 1          | NotCancelled     |    585.39 ns | 10.57 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    651.48 ns | 11.77 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 10         | None             |    260.69 ns |  0.78 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    333.56 ns |  1.00 |         - | 
| Multiple · AsyncLock · Nito               | 10         | None             |    548.46 ns |  1.64 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    631.03 ns |  1.89 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    640.84 ns |  1.92 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,192.44 ns |  9.57 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,469.19 ns | 10.40 |    2296 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    516.65 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    642.69 ns |  1.24 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,124.91 ns |  6.05 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,362.27 ns |  6.51 |    1352 B | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 10         | NotCancelled     |  4,295.86 ns |  8.32 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,261.54 ns | 10.18 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 100        | None             |  2,502.49 ns |  0.79 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,170.11 ns |  1.00 |         - | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,090.40 ns |  1.61 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,878.93 ns |  1.85 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,981.69 ns |  1.89 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 32,406.42 ns | 10.22 |   12216 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,616.83 ns | 11.24 |   21800 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  4,933.30 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,942.03 ns |  1.20 |   21008 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 32,638.29 ns |  6.62 |   12216 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 32,766.09 ns |  6.64 |   65120 B | 
| Multiple · SemaphoreSlim · SemaphoreSlim  | 100        | NotCancelled     | 43,292.92 ns |  8.78 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 49,933.40 ns | 10.12 |   50600 B |