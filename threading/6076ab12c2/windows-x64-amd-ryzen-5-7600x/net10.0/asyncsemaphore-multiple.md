| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      8.612 ns |  0.73 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |     11.778 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     22.026 ns |  1.87 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     25.180 ns |  2.14 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     26.521 ns |  2.25 |      32 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     43.561 ns |  3.70 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |     12.031 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     21.648 ns |  1.80 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     26.866 ns |  2.23 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |     10.452 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     23.826 ns |  2.28 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    238.105 ns |  0.56 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    297.105 ns |  0.70 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    320.132 ns |  0.76 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    363.053 ns |  0.86 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    422.566 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    596.130 ns |  1.41 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    634.381 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    834.447 ns |  1.32 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  3,706.197 ns |  5.84 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    966.316 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  4,014.842 ns |  4.16 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  2,355.844 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,805.590 ns |  0.65 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,983.982 ns |  0.69 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  3,415.799 ns |  0.79 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  4,299.283 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  5,914.153 ns |  1.38 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  6,386.037 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  7,603.756 ns |  1.19 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 35,534.293 ns |  5.57 |   37720 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  9,260.749 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 32,831.176 ns |  3.55 |   47322 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     16.470 ns |  0.68 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     24.072 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     41.621 ns |  1.73 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     59.904 ns |  2.49 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     62.904 ns |  2.61 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     72.958 ns |  3.03 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     23.448 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     43.177 ns |  1.84 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     73.592 ns |  3.14 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     22.656 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     47.238 ns |  2.09 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    246.477 ns |  0.56 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    322.415 ns |  0.73 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    336.179 ns |  0.76 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    402.077 ns |  0.91 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    443.922 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    686.786 ns |  1.55 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    647.817 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    906.084 ns |  1.40 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  2,738.108 ns |  4.23 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    957.060 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  2,916.390 ns |  3.05 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  2,433.677 ns |  0.58 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  2,847.413 ns |  0.68 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,879.078 ns |  0.69 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  3,527.427 ns |  0.85 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  4,171.632 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  5,483.484 ns |  1.31 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  6,303.714 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  7,722.505 ns |  1.23 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 25,340.921 ns |  4.02 |   37721 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  9,387.841 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 26,200.330 ns |  2.79 |   47321 B |