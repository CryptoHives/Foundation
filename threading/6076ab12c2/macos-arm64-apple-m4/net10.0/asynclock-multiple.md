| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      7.488 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      9.283 ns |  1.24 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.003 ns |  1.34 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     12.307 ns |  1.64 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     12.610 ns |  1.68 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     13.566 ns |  1.81 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     14.838 ns |  1.98 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     18.121 ns |  2.42 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     41.349 ns |  5.52 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     51.780 ns |  6.92 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      7.472 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |      9.130 ns |  1.22 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.038 ns |  1.34 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     12.336 ns |  1.65 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     13.814 ns |  1.85 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     14.694 ns |  1.97 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     17.793 ns |  2.38 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     44.086 ns |  5.90 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     51.184 ns |  6.85 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |      7.378 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     11.936 ns |  1.62 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     12.834 ns |  1.74 |         - | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     24.901 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     28.063 ns |  1.13 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     35.385 ns |  1.42 |      88 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |     44.575 ns |  1.79 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     53.733 ns |  2.16 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     68.003 ns |  2.73 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     95.413 ns |  3.83 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    111.144 ns |  4.46 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,280.416 ns | 51.42 |     271 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,353.476 ns | 54.35 |     351 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     38.703 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     42.273 ns |  1.09 |         - | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |     55.998 ns |  1.45 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     62.303 ns |  1.61 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    113.247 ns |  2.93 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    749.286 ns | 19.36 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,467.316 ns | 37.91 |     272 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |  1,469.746 ns | 37.98 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,486.970 ns | 38.42 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     69.058 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    111.085 ns |  1.61 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |  1,529.139 ns | 22.14 |     600 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    193.187 ns |  0.73 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    241.720 ns |  0.91 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    265.349 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | None             |    343.506 ns |  1.29 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    434.707 ns |  1.64 |    1680 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    557.480 ns |  2.10 |    2160 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    577.236 ns |  2.18 |    4400 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    578.475 ns |  2.18 |    2288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  7,469.205 ns | 28.15 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  7,629.401 ns | 28.76 |    1352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    336.792 ns |  0.85 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    396.897 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |    461.402 ns |  1.16 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    543.248 ns |  1.37 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    580.017 ns |  1.46 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  5,596.892 ns | 14.10 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,951.291 ns | 22.55 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     | 10,390.788 ns | 26.18 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 11,611.072 ns | 29.26 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    703.168 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,022.023 ns |  1.45 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  9,793.388 ns | 13.93 |    4848 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,800.430 ns |  0.75 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,169.972 ns |  0.91 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,392.774 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | None             |  3,114.150 ns |  1.30 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,365.697 ns |  1.82 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,141.526 ns |  2.15 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,268.262 ns |  2.20 |   21600 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,358.333 ns |  2.24 |   41120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 52,490.785 ns | 21.94 |   12162 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 54,731.891 ns | 22.87 |   21741 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,147.067 ns |  0.86 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  3,648.168 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     |  4,260.167 ns |  1.17 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,108.533 ns |  1.40 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  5,461.074 ns |  1.50 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 44,797.743 ns | 12.28 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 59,603.767 ns | 16.34 |   12158 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 84,546.608 ns | 23.18 |   37733 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 92,761.956 ns | 25.43 |   50547 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  6,683.582 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 10,219.949 ns |  1.53 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 75,164.628 ns | 11.25 |   47372 B |