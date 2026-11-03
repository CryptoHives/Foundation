| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      7.488 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |      9.160 ns |  1.22 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.084 ns |  1.35 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     12.450 ns |  1.66 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     12.553 ns |  1.68 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     13.928 ns |  1.86 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | None             |     14.841 ns |  1.98 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     18.005 ns |  2.40 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     39.963 ns |  5.34 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     52.112 ns |  6.96 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      7.495 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     10.142 ns |  1.35 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.206 ns |  1.36 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     12.178 ns |  1.62 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     14.182 ns |  1.89 |         - | 
| Multiple · AsyncLock · DotNext            | 0          | NotCancelled     |     14.753 ns |  1.97 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     17.684 ns |  2.36 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     40.224 ns |  5.37 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     51.842 ns |  6.92 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |      7.500 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     11.797 ns |  1.57 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     13.123 ns |  1.75 |         - | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     24.352 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     27.890 ns |  1.15 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     35.619 ns |  1.46 |      88 B | 
| Multiple · AsyncLock · DotNext            | 1          | None             |     44.279 ns |  1.82 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     52.613 ns |  2.16 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     67.987 ns |  2.79 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     94.225 ns |  3.87 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    108.942 ns |  4.47 |     416 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |  1,230.073 ns | 50.51 |     351 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |  1,291.755 ns | 53.05 |     272 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     37.719 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     42.656 ns |  1.13 |         - | 
| Multiple · AsyncLock · DotNext            | 1          | NotCancelled     |     56.319 ns |  1.49 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     61.188 ns |  1.62 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    111.847 ns |  2.97 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    648.418 ns | 17.19 |     968 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |  1,403.680 ns | 37.22 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |  1,461.703 ns | 38.75 |     640 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |  1,466.456 ns | 38.88 |     272 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     68.220 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    112.556 ns |  1.65 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |  1,465.500 ns | 21.48 |     600 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    190.772 ns |  0.72 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    240.002 ns |  0.90 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    265.298 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | None             |    346.407 ns |  1.31 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    434.506 ns |  1.64 |    1680 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    557.198 ns |  2.10 |    2160 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    561.544 ns |  2.12 |    4400 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    564.125 ns |  2.13 |    2288 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  6,810.928 ns | 25.67 |    2296 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  8,445.873 ns | 31.84 |    1352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    328.793 ns |  0.84 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    391.588 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 10         | NotCancelled     |    460.323 ns |  1.18 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    542.840 ns |  1.39 |    1680 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    565.837 ns |  1.45 |    2288 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  5,340.362 ns | 13.64 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  8,823.102 ns | 22.53 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     | 10,106.298 ns | 25.81 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     | 10,990.635 ns | 28.07 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    700.332 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,010.703 ns |  1.44 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  9,707.466 ns | 13.86 |    4848 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  1,773.755 ns |  0.75 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,198.919 ns |  0.93 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  2,363.493 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | None             |  3,154.281 ns |  1.33 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,314.535 ns |  1.83 |   21120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  4,969.703 ns |  2.10 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  5,308.738 ns |  2.25 |   21600 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,354.421 ns |  2.27 |   41120 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 51,682.696 ns | 21.87 |   21742 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 52,671.927 ns | 22.29 |   12165 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  3,143.312 ns |  0.87 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  3,613.905 ns |  1.00 |         - | 
| Multiple · AsyncLock · DotNext            | 100        | NotCancelled     |  4,219.926 ns |  1.17 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  5,038.353 ns |  1.39 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  5,371.957 ns |  1.49 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 55,049.812 ns | 15.23 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 59,761.893 ns | 16.54 |   12170 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 82,344.581 ns | 22.79 |   37769 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 92,282.372 ns | 25.54 |   50584 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  6,664.543 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 10,151.455 ns |  1.52 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 74,160.195 ns | 11.13 |   47335 B |