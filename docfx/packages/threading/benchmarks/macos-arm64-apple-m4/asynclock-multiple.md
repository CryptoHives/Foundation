| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      8.368 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      9.397 ns |  1.12 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.378 ns |  1.24 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     12.323 ns |  1.47 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     13.095 ns |  1.56 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     13.553 ns |  1.62 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     17.759 ns |  2.12 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     39.907 ns |  4.77 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     52.356 ns |  6.26 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      8.462 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     10.081 ns |  1.19 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.460 ns |  1.24 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     12.755 ns |  1.51 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     14.508 ns |  1.71 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     18.445 ns |  2.18 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     40.995 ns |  4.84 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     52.274 ns |  6.18 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     23.222 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     28.409 ns |  1.22 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     40.139 ns |  1.73 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     53.005 ns |  2.28 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     65.919 ns |  2.84 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     95.272 ns |  4.10 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    105.201 ns |  4.53 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,269.871 ns | 54.68 |     271 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,293.851 ns | 55.72 |     351 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     37.654 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     42.569 ns |  1.13 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     63.486 ns |  1.69 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    106.488 ns |  2.83 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    650.840 ns | 17.29 |     968 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |  1,412.727 ns | 37.52 |     504 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,451.814 ns | 38.56 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,502.699 ns | 39.91 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    198.342 ns |  0.84 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    235.201 ns |  1.00 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    248.975 ns |  1.06 |     880 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    442.289 ns |  1.88 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    557.133 ns |  2.37 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    569.457 ns |  2.42 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    607.351 ns |  2.58 |    2160 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  6,970.103 ns | 29.63 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  7,947.434 ns | 33.79 |    1352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    331.749 ns |  0.87 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    379.534 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    546.459 ns |  1.44 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    564.817 ns |  1.49 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  5,447.181 ns | 14.35 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,802.898 ns | 23.19 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     | 10,310.311 ns | 27.17 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 10,884.100 ns | 28.68 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,789.182 ns |  0.79 |         - | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,196.842 ns |  0.98 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,252.586 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,442.435 ns |  1.97 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  4,921.270 ns |  2.18 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,287.735 ns |  2.35 |   21600 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,341.002 ns |  2.37 |   41120 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 51,641.016 ns | 22.93 |   21740 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 53,658.530 ns | 23.82 |   12199 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,208.488 ns |  0.91 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  3,545.207 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,041.091 ns |  1.42 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  5,477.210 ns |  1.54 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 60,030.207 ns | 16.93 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 60,118.447 ns | 16.96 |   12171 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 88,304.214 ns | 24.91 |   37732 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 98,347.659 ns | 27.74 |   50588 B |