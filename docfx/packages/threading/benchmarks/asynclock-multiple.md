| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     10.701 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.112 ns |  1.04 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.557 ns |  1.08 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     17.175 ns |  1.61 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     19.021 ns |  1.78 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.622 ns |  1.83 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     20.520 ns |  1.92 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     38.059 ns |  3.56 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     57.206 ns |  5.35 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      9.753 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     11.222 ns |  1.15 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     11.854 ns |  1.22 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     19.889 ns |  2.04 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.237 ns |  2.18 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     22.030 ns |  2.26 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     40.061 ns |  4.11 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     59.683 ns |  6.12 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     32.487 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     38.104 ns |  1.17 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     41.949 ns |  1.29 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     67.935 ns |  2.09 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     77.841 ns |  2.40 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     94.143 ns |  2.90 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    118.834 ns |  3.66 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    481.645 ns | 14.83 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    543.893 ns | 16.74 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     36.311 ns |  0.75 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     48.354 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     80.746 ns |  1.67 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    116.831 ns |  2.42 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    387.442 ns |  8.01 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    517.157 ns | 10.70 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    570.917 ns | 11.81 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    651.912 ns | 13.48 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    258.605 ns |  0.82 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    265.806 ns |  0.84 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    315.162 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    503.055 ns |  1.60 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    534.031 ns |  1.69 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    625.124 ns |  1.98 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    645.509 ns |  2.05 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,157.291 ns | 10.02 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,333.471 ns | 10.58 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    259.867 ns |  0.50 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    520.617 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    626.308 ns |  1.20 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    714.895 ns |  1.37 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,044.009 ns |  5.85 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,433.858 ns |  6.60 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,313.051 ns |  8.28 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  4,980.119 ns |  9.57 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,489.011 ns |  0.84 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,548.242 ns |  0.86 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,972.129 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,768.405 ns |  1.60 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,213.080 ns |  1.75 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,780.056 ns |  1.94 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,987.761 ns |  2.01 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 32,305.407 ns | 10.87 |   12216 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,087.580 ns | 11.81 |   21799 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  2,545.497 ns |  0.50 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,099.684 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,002.853 ns |  1.18 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  6,700.242 ns |  1.31 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 32,313.301 ns |  6.34 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 32,937.761 ns |  6.46 |   12216 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 42,757.867 ns |  8.39 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 50,234.814 ns |  9.85 |   50600 B |