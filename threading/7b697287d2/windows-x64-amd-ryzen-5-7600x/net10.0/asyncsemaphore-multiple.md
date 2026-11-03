| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      9.678 ns |  0.86 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |     11.294 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     19.868 ns |  1.76 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     20.184 ns |  1.79 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     24.488 ns |  2.17 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     26.758 ns |  2.37 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |     11.832 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     20.292 ns |  1.72 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     26.386 ns |  2.23 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |     10.378 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     22.580 ns |  2.18 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    234.039 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    296.679 ns |  0.68 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    304.375 ns |  0.70 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    381.153 ns |  0.87 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    436.216 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    589.919 ns |  1.35 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    625.232 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    813.054 ns |  1.30 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  3,879.405 ns |  6.21 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    942.381 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  4,050.053 ns |  4.30 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  2,322.531 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,841.331 ns |  0.68 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,969.183 ns |  0.71 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  3,512.218 ns |  0.84 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  4,185.029 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  5,421.979 ns |  1.30 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  6,211.279 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  7,795.015 ns |  1.26 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 34,757.176 ns |  5.60 |   37721 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  9,400.575 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 35,953.496 ns |  3.82 |   47321 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     16.466 ns |  0.69 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     23.708 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     42.608 ns |  1.80 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     59.882 ns |  2.53 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     61.567 ns |  2.60 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     73.274 ns |  3.09 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     23.295 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     42.477 ns |  1.82 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     73.984 ns |  3.18 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     23.350 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     46.757 ns |  2.00 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    271.425 ns |  0.61 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    339.579 ns |  0.76 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    341.312 ns |  0.76 |     880 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    410.492 ns |  0.92 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    448.113 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    647.498 ns |  1.44 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    648.723 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    877.360 ns |  1.35 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  2,705.172 ns |  4.17 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    954.985 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  2,917.896 ns |  3.06 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  2,322.409 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,915.251 ns |  0.69 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  3,001.405 ns |  0.71 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  3,597.722 ns |  0.85 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  4,222.343 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  5,408.849 ns |  1.28 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  6,257.113 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  7,586.780 ns |  1.21 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 25,534.598 ns |  4.08 |   37722 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  9,328.871 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 26,317.900 ns |  2.82 |   47321 B |