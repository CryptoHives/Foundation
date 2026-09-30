| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     11.02 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     13.06 ns |  1.19 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     13.59 ns |  1.23 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     21.00 ns |  1.91 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     22.06 ns |  2.00 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     22.56 ns |  2.05 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     24.54 ns |  2.23 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     24.62 ns |  2.24 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     43.88 ns |  3.98 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     68.19 ns |  6.19 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     11.71 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     12.98 ns |  1.11 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     13.92 ns |  1.19 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     20.67 ns |  1.77 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     22.10 ns |  1.89 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     24.61 ns |  2.10 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     28.43 ns |  2.43 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     45.45 ns |  3.88 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     67.40 ns |  5.76 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |     11.82 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     20.96 ns |  1.77 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     21.69 ns |  1.83 |         - | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     37.78 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     42.48 ns |  1.12 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     49.14 ns |  1.30 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     73.85 ns |  1.95 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |     78.75 ns |  2.08 |         - | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     93.38 ns |  2.47 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    118.14 ns |  3.13 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    136.65 ns |  3.62 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    529.15 ns | 14.01 |     270 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    550.25 ns | 14.57 |     350 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     58.93 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     70.29 ns |  1.19 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     91.72 ns |  1.56 |     168 B | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |     94.25 ns |  1.60 |         - | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    139.98 ns |  2.38 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    374.69 ns |  6.36 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    582.95 ns |  9.89 |     271 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    700.79 ns | 11.89 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    712.88 ns | 12.10 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     87.19 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    151.34 ns |  1.74 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    659.46 ns |  7.57 |     600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    310.21 ns |  0.81 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    319.65 ns |  0.83 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    383.31 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | None             |    539.27 ns |  1.41 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    603.62 ns |  1.58 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    627.88 ns |  1.64 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    732.62 ns |  1.91 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    744.31 ns |  1.94 |    2288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  2,769.55 ns |  7.23 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,133.15 ns |  8.18 |    1352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    547.15 ns |  0.91 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    598.77 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |    731.58 ns |  1.22 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    734.66 ns |  1.23 |    2288 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    857.44 ns |  1.43 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  2,746.70 ns |  4.59 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,285.31 ns |  5.49 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  3,984.03 ns |  6.66 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,101.59 ns |  8.52 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    903.80 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,258.12 ns |  1.39 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  4,108.95 ns |  4.55 |    4848 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,949.41 ns |  0.78 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  3,014.41 ns |  0.80 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,762.74 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | None             |  5,193.48 ns |  1.38 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  5,568.08 ns |  1.48 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,994.04 ns |  1.59 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,887.71 ns |  1.83 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,939.28 ns |  1.84 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 27,332.15 ns |  7.27 |   12152 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 29,358.28 ns |  7.80 |   21736 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  5,337.39 ns |  0.89 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  6,003.68 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,962.92 ns |  1.16 |   21008 B | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     |  7,050.99 ns |  1.17 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  7,869.21 ns |  1.31 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 22,303.24 ns |  3.72 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 28,934.81 ns |  4.82 |   12152 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 36,310.08 ns |  6.05 |   37730 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 43,191.12 ns |  7.20 |   50537 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  8,765.63 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 12,098.18 ns |  1.38 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 37,755.21 ns |  4.31 |   47330 B |