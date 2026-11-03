| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     11.56 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     12.60 ns |  1.09 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     13.67 ns |  1.18 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     20.04 ns |  1.73 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     20.83 ns |  1.80 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     21.69 ns |  1.88 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     23.41 ns |  2.03 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     24.53 ns |  2.12 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     44.73 ns |  3.87 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     65.89 ns |  5.70 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     11.65 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     12.51 ns |  1.07 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     14.31 ns |  1.23 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     19.84 ns |  1.70 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     21.34 ns |  1.83 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     24.27 ns |  2.08 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     25.74 ns |  2.21 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     46.85 ns |  4.02 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     66.12 ns |  5.68 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |     11.63 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     20.64 ns |  1.77 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     21.26 ns |  1.83 |         - | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     42.71 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     42.75 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     49.11 ns |  1.15 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     72.33 ns |  1.69 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |     76.99 ns |  1.80 |         - | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     92.51 ns |  2.16 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    113.69 ns |  2.66 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    146.77 ns |  3.43 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    541.48 ns | 12.67 |     270 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    593.93 ns | 13.90 |     350 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     54.62 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     71.96 ns |  1.32 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     91.46 ns |  1.67 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |     91.91 ns |  1.68 |         - | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    134.32 ns |  2.46 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    366.90 ns |  6.72 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    549.59 ns | 10.06 |     272 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    623.06 ns | 11.41 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    713.53 ns | 13.06 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     89.00 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    143.35 ns |  1.61 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    653.65 ns |  7.34 |     600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    298.98 ns |  0.78 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    310.07 ns |  0.81 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    382.38 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | None             |    539.36 ns |  1.41 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    604.82 ns |  1.58 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    653.27 ns |  1.71 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    720.42 ns |  1.88 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    724.32 ns |  1.89 |    2288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  2,780.32 ns |  7.27 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,140.40 ns |  8.21 |    1352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    588.17 ns |  0.97 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    607.59 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    726.57 ns |  1.20 |    2288 B | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |    803.08 ns |  1.32 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    825.38 ns |  1.36 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  2,655.42 ns |  4.37 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,361.63 ns |  5.53 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  3,769.08 ns |  6.20 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,797.82 ns |  9.54 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    912.22 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,260.91 ns |  1.38 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  4,064.71 ns |  4.46 |    4848 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,889.72 ns |  0.68 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,947.48 ns |  0.70 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  4,228.43 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | None             |  5,041.70 ns |  1.19 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  5,529.68 ns |  1.31 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  6,241.08 ns |  1.48 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,749.63 ns |  1.60 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  7,332.16 ns |  1.74 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 26,861.96 ns |  6.36 |   12152 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 28,437.55 ns |  6.73 |   21736 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  5,856.03 ns |  0.96 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  6,104.58 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,826.38 ns |  1.12 |   21008 B | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     |  6,998.03 ns |  1.15 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  7,807.60 ns |  1.28 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 23,891.95 ns |  3.91 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 31,736.10 ns |  5.20 |   12152 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 36,383.95 ns |  5.96 |   37731 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 43,534.22 ns |  7.13 |   50539 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  9,020.88 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 12,508.49 ns |  1.39 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 39,890.56 ns |  4.42 |   47331 B |