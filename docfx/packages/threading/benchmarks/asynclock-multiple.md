| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      9.982 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.288 ns |  1.13 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.512 ns |  1.15 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     18.415 ns |  1.84 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.814 ns |  1.98 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     19.926 ns |  2.00 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     21.421 ns |  2.15 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     40.493 ns |  4.06 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     61.062 ns |  6.12 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      9.961 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     11.654 ns |  1.17 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     12.486 ns |  1.25 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     19.151 ns |  1.92 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     20.561 ns |  2.06 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.864 ns |  2.19 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     39.537 ns |  3.97 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     63.557 ns |  6.38 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     32.036 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     39.483 ns |  1.23 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     64.189 ns |  2.00 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     67.815 ns |  2.12 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     80.841 ns |  2.52 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     97.514 ns |  3.04 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    120.123 ns |  3.75 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    465.730 ns | 14.54 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    541.835 ns | 16.91 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     48.392 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     63.314 ns |  1.31 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     84.703 ns |  1.75 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    123.076 ns |  2.54 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    383.019 ns |  7.92 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    527.330 ns | 10.90 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    615.076 ns | 12.71 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    690.744 ns | 14.27 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    273.653 ns |  0.86 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    306.379 ns |  0.96 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    319.273 ns |  1.00 |         - | 
| Multiple · AsyncLock · Nito               | 10         | None             |    548.522 ns |  1.72 |    4400 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    563.387 ns |  1.76 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    638.643 ns |  2.00 |    2288 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    680.233 ns |  2.13 |    2160 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,153.577 ns |  9.88 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,500.843 ns | 10.97 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    500.333 ns |  0.98 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    509.105 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    648.018 ns |  1.27 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    770.817 ns |  1.51 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,184.195 ns |  6.25 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,437.208 ns |  6.75 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,461.538 ns |  8.76 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  4,953.170 ns |  9.73 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,572.538 ns |  0.85 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,719.887 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,026.152 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,976.758 ns |  1.64 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,319.848 ns |  1.76 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,013.208 ns |  1.99 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,270.949 ns |  2.07 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 33,983.552 ns | 11.23 |   12215 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,457.147 ns | 11.72 |   21799 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,037.526 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  5,172.330 ns |  1.03 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,992.105 ns |  1.19 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  7,191.230 ns |  1.43 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 33,415.924 ns |  6.63 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 34,985.282 ns |  6.95 |   12215 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 45,791.255 ns |  9.09 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 52,995.111 ns | 10.52 |   50600 B |