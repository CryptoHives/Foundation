| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      5.200 ns |  0.68 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |      7.686 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     10.536 ns |  1.37 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     11.562 ns |  1.50 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     11.593 ns |  1.51 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     16.162 ns |  2.10 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |      7.655 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     12.165 ns |  1.59 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     16.855 ns |  2.20 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |      7.327 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     12.628 ns |  1.72 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    152.785 ns |  0.47 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    232.920 ns |  0.71 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    284.196 ns |  0.87 |     880 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    295.824 ns |  0.91 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    325.798 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    438.347 ns |  1.35 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    431.987 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    553.264 ns |  1.28 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     | 10,627.066 ns | 24.60 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    741.483 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  9,584.652 ns | 12.93 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  1,405.859 ns |  0.48 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,077.806 ns |  0.72 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,165.107 ns |  0.75 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  2,767.901 ns |  0.95 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  2,899.528 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  4,393.775 ns |  1.52 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  4,191.616 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  5,476.563 ns |  1.31 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 85,557.306 ns | 20.41 |   37733 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  7,143.217 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 75,727.323 ns | 10.60 |   47335 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     15.304 ns |  0.77 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     19.795 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     25.928 ns |  1.31 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     34.137 ns |  1.72 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     36.388 ns |  1.84 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     52.233 ns |  2.64 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     19.775 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     28.191 ns |  1.43 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     48.733 ns |  2.46 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     18.833 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     28.372 ns |  1.51 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    157.758 ns |  0.47 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    256.345 ns |  0.76 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    263.318 ns |  0.78 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    321.240 ns |  0.95 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    336.955 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    483.691 ns |  1.44 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    453.244 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    600.563 ns |  1.33 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  9,465.654 ns | 20.88 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    771.878 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  9,580.059 ns | 12.41 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  1,429.281 ns |  0.49 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,127.022 ns |  0.73 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,160.210 ns |  0.74 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  2,817.446 ns |  0.96 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  2,920.392 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  4,431.605 ns |  1.52 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  4,121.928 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  5,479.631 ns |  1.33 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 54,673.613 ns | 13.26 |   37721 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  7,183.053 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 59,013.468 ns |  8.22 |   47322 B |