| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      9.524 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.026 ns |  1.16 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.636 ns |  1.22 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     17.688 ns |  1.86 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     18.970 ns |  1.99 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.118 ns |  2.01 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     21.376 ns |  2.24 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     44.416 ns |  4.66 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     58.186 ns |  6.11 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      9.580 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.904 ns |  1.14 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     11.922 ns |  1.24 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     17.639 ns |  1.84 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     19.830 ns |  2.07 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     22.728 ns |  2.37 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     39.177 ns |  4.09 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     58.758 ns |  6.13 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     30.312 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     38.128 ns |  1.26 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     43.053 ns |  1.42 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     71.197 ns |  2.35 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     76.606 ns |  2.53 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     98.038 ns |  3.23 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    118.103 ns |  3.90 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    467.260 ns | 15.42 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    537.478 ns | 17.73 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     48.928 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     68.091 ns |  1.39 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     82.251 ns |  1.68 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    121.842 ns |  2.49 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    381.676 ns |  7.80 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    513.639 ns | 10.50 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    597.392 ns | 12.21 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    696.758 ns | 14.24 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    270.858 ns |  0.81 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    283.837 ns |  0.85 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    335.026 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    526.298 ns |  1.57 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    553.332 ns |  1.65 |    4400 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    635.329 ns |  1.90 |    2288 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    654.051 ns |  1.95 |    2160 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,158.086 ns |  9.43 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,455.383 ns | 10.31 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    496.349 ns |  0.80 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    623.256 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    642.343 ns |  1.03 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    734.316 ns |  1.18 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,224.239 ns |  5.17 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,366.491 ns |  5.40 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,357.466 ns |  6.99 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,054.288 ns |  8.11 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,538.924 ns |  0.80 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,616.672 ns |  0.82 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,179.786 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,894.898 ns |  1.54 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,325.309 ns |  1.67 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,895.268 ns |  1.85 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,318.729 ns |  1.99 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 33,600.780 ns | 10.57 |   12216 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,603.366 ns | 11.20 |   21800 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,689.983 ns |  0.87 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,360.730 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,968.076 ns |  1.11 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  7,014.726 ns |  1.31 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 31,183.481 ns |  5.82 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 35,534.963 ns |  6.63 |   12216 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 44,303.836 ns |  8.27 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 54,064.472 ns | 10.09 |   50600 B |