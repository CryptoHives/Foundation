| Description                               | InitialCount | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |     24.07 ns |  0.76 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |     31.67 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     46.92 ns |  1.48 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     47.65 ns |  1.50 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     48.22 ns |  1.52 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     63.93 ns |  2.02 |      32 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |     32.29 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     47.63 ns |  1.48 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     60.54 ns |  1.87 |      32 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |     31.35 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     50.87 ns |  1.62 |         - | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    698.64 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    903.53 ns |  0.70 |     960 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    932.03 ns |  0.73 |     880 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |  1,023.56 ns |  0.80 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |  1,284.43 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |  1,514.71 ns |  1.18 |    1712 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |  1,790.04 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |  1,992.88 ns |  1.11 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  9,354.53 ns |  5.23 |    3880 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |  2,501.00 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  9,869.94 ns |  3.95 |    4840 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  6,620.48 ns |  0.51 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  8,578.73 ns |  0.66 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  8,983.93 ns |  0.70 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             | 10,732.98 ns |  0.83 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             | 12,904.93 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             | 14,379.30 ns |  1.11 |   21152 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     | 18,197.08 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     | 19,008.46 ns |  1.04 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 69,376.92 ns |  3.81 |   37722 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            | 25,289.49 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 77,127.56 ns |  3.05 |   47323 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     73.53 ns |  0.68 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |    107.66 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |    113.06 ns |  1.05 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |    169.04 ns |  1.57 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |    171.04 ns |  1.59 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |    206.42 ns |  1.92 |      56 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |    108.70 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |    112.90 ns |  1.04 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |    206.31 ns |  1.90 |      56 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |    107.90 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |    119.81 ns |  1.11 |         - | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    745.74 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    996.11 ns |  0.74 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |  1,026.33 ns |  0.76 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |  1,150.71 ns |  0.86 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |  1,345.46 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |  1,689.54 ns |  1.26 |    1736 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |  1,866.86 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |  2,140.61 ns |  1.15 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  6,336.60 ns |  3.39 |    3880 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |  2,519.55 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  7,547.94 ns |  3.00 |    4840 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  6,705.92 ns |  0.51 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  8,839.23 ns |  0.67 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  9,029.91 ns |  0.69 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             | 10,071.33 ns |  0.77 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             | 13,095.64 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             | 14,716.60 ns |  1.12 |   21176 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     | 18,278.37 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     | 19,310.37 ns |  1.06 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 51,653.11 ns |  2.83 |   37723 B | 
|                                           |              |            |                  |              |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            | 25,321.43 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 56,660.93 ns |  2.24 |   47324 B |