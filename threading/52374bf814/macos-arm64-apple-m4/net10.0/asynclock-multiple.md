| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      7.891 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      9.628 ns |  1.22 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |      9.871 ns |  1.25 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     12.949 ns |  1.64 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     13.427 ns |  1.70 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     14.463 ns |  1.83 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     18.020 ns |  2.28 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     41.402 ns |  5.25 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     52.997 ns |  6.72 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      8.057 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     10.232 ns |  1.27 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.256 ns |  1.27 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     12.621 ns |  1.57 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     14.560 ns |  1.81 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     18.759 ns |  2.33 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.284 ns |  5.12 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     52.493 ns |  6.52 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     23.490 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     28.130 ns |  1.20 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     37.045 ns |  1.58 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     54.599 ns |  2.32 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     68.697 ns |  2.92 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     94.316 ns |  4.02 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    109.366 ns |  4.66 |     416 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,216.363 ns | 51.79 |     350 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,381.198 ns | 58.80 |     271 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     36.277 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     44.412 ns |  1.22 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     63.203 ns |  1.74 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    107.268 ns |  2.96 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    646.678 ns | 17.83 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,484.811 ns | 40.93 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,498.509 ns | 41.31 |     640 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |  1,598.035 ns | 44.05 |     504 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    197.073 ns |  0.82 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    240.851 ns |  1.00 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    253.671 ns |  1.05 |     880 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    451.128 ns |  1.87 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    565.469 ns |  2.35 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    567.840 ns |  2.36 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    578.067 ns |  2.40 |    2288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  7,081.010 ns | 29.40 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  8,263.349 ns | 34.31 |    1352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    339.757 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    377.674 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    552.628 ns |  1.46 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    572.761 ns |  1.52 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  5,022.693 ns | 13.30 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,764.494 ns | 23.21 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     | 10,892.329 ns | 28.84 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 10,994.378 ns | 29.11 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,824.031 ns |  0.81 |         - | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,212.582 ns |  0.98 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,252.599 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,467.492 ns |  1.98 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  4,974.090 ns |  2.21 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,289.120 ns |  2.35 |   21600 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,310.252 ns |  2.36 |   41120 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 51,740.124 ns | 22.97 |   21738 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 52,126.799 ns | 23.14 |   12158 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,179.227 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  3,519.580 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,035.855 ns |  1.43 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  5,525.962 ns |  1.57 |   21120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 60,399.318 ns | 17.16 |   12155 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 62,085.556 ns | 17.64 |   65120 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 81,425.204 ns | 23.14 |   37736 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 93,239.964 ns | 26.50 |   50542 B |