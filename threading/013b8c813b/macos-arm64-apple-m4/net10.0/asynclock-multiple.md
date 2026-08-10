| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      8.425 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      9.284 ns |  1.10 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.440 ns |  1.24 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     12.675 ns |  1.50 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     13.141 ns |  1.56 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     14.235 ns |  1.69 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     18.142 ns |  2.15 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     41.584 ns |  4.94 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     50.834 ns |  6.03 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      8.514 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |      9.266 ns |  1.09 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.493 ns |  1.23 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     12.882 ns |  1.51 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     14.293 ns |  1.68 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     18.182 ns |  2.14 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.084 ns |  4.83 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     51.570 ns |  6.06 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     25.441 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     27.270 ns |  1.07 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     36.967 ns |  1.45 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     52.469 ns |  2.06 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     65.429 ns |  2.57 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     94.398 ns |  3.71 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    104.984 ns |  4.13 |     416 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,274.175 ns | 50.09 |     351 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,452.753 ns | 57.10 |     271 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     38.623 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     42.165 ns |  1.09 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     62.016 ns |  1.61 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    108.661 ns |  2.81 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    649.216 ns | 16.81 |     968 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |  1,424.487 ns | 36.88 |     504 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,465.472 ns | 37.94 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,480.866 ns | 38.34 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    194.709 ns |  0.72 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    245.409 ns |  0.91 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    270.181 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    453.778 ns |  1.68 |    1680 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    556.398 ns |  2.06 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    559.989 ns |  2.07 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    562.881 ns |  2.08 |    4400 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  7,555.876 ns | 27.97 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  8,143.090 ns | 30.14 |    1352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    334.922 ns |  0.86 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    389.866 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    551.252 ns |  1.41 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    563.921 ns |  1.45 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  4,833.723 ns | 12.40 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,736.692 ns | 22.41 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     | 10,615.816 ns | 27.23 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 10,925.889 ns | 28.02 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,807.087 ns |  0.78 |         - | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,229.703 ns |  0.96 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,324.326 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,462.744 ns |  1.92 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  4,946.453 ns |  2.13 |   21008 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,257.998 ns |  2.26 |   41120 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,321.844 ns |  2.29 |   21600 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 50,706.763 ns | 21.82 |   21739 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 52,025.798 ns | 22.38 |   12155 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,207.920 ns |  0.88 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  3,639.009 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  4,930.770 ns |  1.36 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  5,529.917 ns |  1.52 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 59,235.902 ns | 16.28 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 60,318.879 ns | 16.58 |   12190 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 83,624.877 ns | 22.98 |   37738 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 94,018.415 ns | 25.84 |   50542 B |