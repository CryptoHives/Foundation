| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      7.724 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      9.486 ns |  1.23 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.173 ns |  1.32 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     12.598 ns |  1.63 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     12.988 ns |  1.68 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     13.951 ns |  1.81 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     18.561 ns |  2.40 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     43.116 ns |  5.58 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     52.378 ns |  6.78 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      7.815 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     10.181 ns |  1.30 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.243 ns |  1.31 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     12.730 ns |  1.63 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     13.889 ns |  1.78 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     18.202 ns |  2.33 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.381 ns |  5.30 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     53.685 ns |  6.87 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |      7.727 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     12.258 ns |  1.59 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     14.106 ns |  1.83 |         - | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     25.106 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     27.580 ns |  1.10 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     36.931 ns |  1.47 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     52.447 ns |  2.09 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     66.225 ns |  2.64 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     94.826 ns |  3.78 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    107.797 ns |  4.29 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,296.822 ns | 51.65 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,310.447 ns | 52.20 |     351 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     37.671 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     43.522 ns |  1.16 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     62.956 ns |  1.67 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    108.992 ns |  2.89 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    662.878 ns | 17.60 |     968 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |  1,389.101 ns | 36.88 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,450.717 ns | 38.51 |     640 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,460.859 ns | 38.78 |     272 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     69.093 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    111.052 ns |  1.61 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |  1,441.760 ns | 20.87 |     600 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    193.277 ns |  0.72 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    244.604 ns |  0.91 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    268.499 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    441.605 ns |  1.64 |    1680 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    559.372 ns |  2.08 |    2160 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    576.463 ns |  2.15 |    4400 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    631.382 ns |  2.35 |    2288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  6,935.348 ns | 25.83 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  8,194.363 ns | 30.52 |    1352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    336.788 ns |  0.84 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    403.062 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    548.900 ns |  1.36 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    574.370 ns |  1.43 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  6,251.773 ns | 15.51 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,615.484 ns | 21.38 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 11,241.568 ns | 27.89 |    5176 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     | 11,521.099 ns | 28.58 |    3888 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    705.923 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,020.732 ns |  1.45 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            | 10,082.439 ns | 14.28 |    4848 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,794.136 ns |  0.76 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,163.398 ns |  0.92 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,352.239 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,399.251 ns |  1.87 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,026.425 ns |  2.14 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,302.819 ns |  2.25 |   21600 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,462.572 ns |  2.32 |   41120 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 50,453.447 ns | 21.45 |   21740 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 53,937.654 ns | 22.93 |   12159 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,174.473 ns |  0.87 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  3,649.135 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,072.342 ns |  1.39 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  5,515.230 ns |  1.51 |   21120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 59,970.020 ns | 16.43 |   12186 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 61,254.037 ns | 16.79 |   65120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 84,571.194 ns | 23.18 |   37735 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 91,222.677 ns | 25.00 |   50554 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  6,705.339 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 10,341.317 ns |  1.54 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 75,865.809 ns | 11.31 |   47342 B |