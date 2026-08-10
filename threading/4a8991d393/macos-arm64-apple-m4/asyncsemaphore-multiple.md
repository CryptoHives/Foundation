| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      5.154 ns |  0.68 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |      7.583 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     11.263 ns |  1.49 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     11.270 ns |  1.49 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     11.915 ns |  1.57 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     16.441 ns |  2.17 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |      7.568 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     12.408 ns |  1.64 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     16.538 ns |  2.19 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |      7.138 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     12.436 ns |  1.74 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    151.433 ns |  0.48 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    239.878 ns |  0.76 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    240.523 ns |  0.76 |     880 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    302.816 ns |  0.96 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    314.981 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    445.749 ns |  1.42 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    432.472 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    554.328 ns |  1.28 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     | 10,449.587 ns | 24.16 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    738.568 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  9,886.284 ns | 13.39 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  1,374.539 ns |  0.49 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,081.201 ns |  0.74 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,463.057 ns |  0.87 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  2,716.079 ns |  0.96 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  2,816.511 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  4,413.035 ns |  1.57 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  4,135.669 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  5,499.336 ns |  1.33 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 87,558.476 ns | 21.17 |   37748 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  7,116.690 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 73,285.207 ns | 10.30 |   47331 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     14.222 ns |  0.73 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     19.419 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     26.791 ns |  1.38 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     35.629 ns |  1.83 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     36.952 ns |  1.90 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     52.790 ns |  2.72 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     19.381 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     29.279 ns |  1.51 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     51.992 ns |  2.68 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     18.296 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     27.879 ns |  1.52 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    155.825 ns |  0.44 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    254.375 ns |  0.72 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    259.754 ns |  0.73 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    315.763 ns |  0.89 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    353.457 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    494.099 ns |  1.40 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    442.568 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    603.646 ns |  1.36 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  9,711.259 ns | 21.94 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    754.337 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  9,873.981 ns | 13.09 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  1,401.117 ns |  0.50 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,107.620 ns |  0.75 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,209.130 ns |  0.78 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  2,738.454 ns |  0.97 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  2,815.522 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  4,457.113 ns |  1.58 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  4,123.531 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  5,549.553 ns |  1.35 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 56,754.185 ns | 13.76 |   37723 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  7,280.864 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 58,468.373 ns |  8.03 |   47323 B |