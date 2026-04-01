| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      9.944 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.279 ns |  1.03 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.144 ns |  1.12 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     17.640 ns |  1.77 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     18.594 ns |  1.87 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.394 ns |  1.95 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     20.600 ns |  2.07 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     39.078 ns |  3.93 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     58.457 ns |  5.88 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     10.323 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.642 ns |  1.03 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     11.886 ns |  1.15 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     17.517 ns |  1.70 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     19.447 ns |  1.88 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.326 ns |  2.07 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     38.806 ns |  3.76 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     56.755 ns |  5.50 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     28.165 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     36.486 ns |  1.30 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     42.075 ns |  1.49 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     64.412 ns |  2.29 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     76.101 ns |  2.70 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     91.453 ns |  3.25 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    116.605 ns |  4.14 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    480.060 ns | 17.05 |     271 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    543.285 ns | 19.29 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     46.467 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     78.408 ns |  1.69 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     79.121 ns |  1.70 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    119.281 ns |  2.57 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    394.059 ns |  8.48 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    516.424 ns | 11.12 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    565.700 ns | 12.18 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    660.724 ns | 14.22 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    261.829 ns |  0.84 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    270.938 ns |  0.87 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    309.915 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    511.846 ns |  1.65 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    542.904 ns |  1.75 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    619.827 ns |  2.00 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    634.247 ns |  2.05 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,191.047 ns | 10.30 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,509.004 ns | 11.32 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    466.087 ns |  0.91 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    515.058 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    628.808 ns |  1.22 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    700.242 ns |  1.36 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,204.949 ns |  6.22 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,474.221 ns |  6.75 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,349.064 ns |  8.45 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  4,972.770 ns |  9.66 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,582.434 ns |  0.81 |         - | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,587.874 ns |  0.82 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,169.397 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,740.432 ns |  1.50 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,232.310 ns |  1.65 |   41120 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,004.082 ns |  1.89 |   21600 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,037.141 ns |  1.91 |   21008 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 34,158.735 ns | 10.78 |   12215 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,626.170 ns | 11.24 |   21800 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,536.588 ns |  0.91 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  4,987.139 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,916.785 ns |  1.19 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  6,643.265 ns |  1.33 |   21120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 33,360.289 ns |  6.69 |   12216 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 33,478.485 ns |  6.71 |   65120 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 43,340.455 ns |  8.69 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 51,865.969 ns | 10.40 |   50600 B |