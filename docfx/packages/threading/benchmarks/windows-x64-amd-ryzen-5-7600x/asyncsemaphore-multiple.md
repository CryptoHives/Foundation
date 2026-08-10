| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      7.937 ns |  0.74 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |     10.773 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     17.944 ns |  1.67 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     18.280 ns |  1.70 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     21.226 ns |  1.97 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     24.139 ns |  2.24 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |     10.719 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     18.058 ns |  1.68 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     23.855 ns |  2.23 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |      9.889 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     20.156 ns |  2.04 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    215.017 ns |  0.57 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    269.827 ns |  0.71 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    282.417 ns |  0.74 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    335.311 ns |  0.88 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    379.113 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    542.475 ns |  1.43 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    553.099 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    737.423 ns |  1.33 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  4,416.227 ns |  7.99 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    858.658 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  4,306.859 ns |  5.02 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  2,038.278 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,499.823 ns |  0.67 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,639.886 ns |  0.71 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  3,166.735 ns |  0.85 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  3,731.634 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  4,853.596 ns |  1.30 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  5,587.803 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  7,012.870 ns |  1.26 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 43,740.471 ns |  7.83 |   37784 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  8,583.455 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 43,020.549 ns |  5.01 |   47384 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     14.511 ns |  0.71 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     20.563 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     38.113 ns |  1.85 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     53.016 ns |  2.58 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     55.325 ns |  2.69 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     69.669 ns |  3.39 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     20.378 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     37.684 ns |  1.85 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     65.724 ns |  3.23 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     20.398 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     41.498 ns |  2.03 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    216.991 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    277.587 ns |  0.70 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    307.363 ns |  0.77 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    371.828 ns |  0.93 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    397.992 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    600.704 ns |  1.51 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    574.920 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    784.192 ns |  1.36 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  3,284.918 ns |  5.71 |    3872 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    858.458 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  3,502.251 ns |  4.08 |    4835 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  2,080.967 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,559.386 ns |  0.67 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,653.789 ns |  0.69 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  3,288.228 ns |  0.86 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  3,819.925 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  4,931.337 ns |  1.29 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  5,616.876 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  6,950.390 ns |  1.24 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 35,922.804 ns |  6.40 |   37771 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  8,436.404 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 38,552.732 ns |  4.57 |   47366 B |