| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      9.603 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 0          | None             |      9.677 ns |  1.01 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.189 ns |  1.17 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.991 ns |  1.25 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | None             |     17.739 ns |  1.85 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | None             |     19.119 ns |  1.99 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.519 ns |  2.03 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     22.080 ns |  2.30 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     46.286 ns |  4.82 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     61.892 ns |  6.45 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      9.535 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 0          | NotCancelled     |      9.702 ns |  1.02 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     11.155 ns |  1.17 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     12.558 ns |  1.32 |         - | 
| Multiple · SemaphoreSlim · System         | 0          | NotCancelled     |     17.664 ns |  1.85 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 0          | NotCancelled     |     19.287 ns |  2.02 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.851 ns |  2.29 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.877 ns |  4.39 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     62.354 ns |  6.54 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     34.262 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 1          | None             |     35.198 ns |  1.03 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     37.817 ns |  1.10 |         - | 
| Multiple · SemaphoreSlim · System         | 1          | None             |     46.305 ns |  1.35 |      88 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | None             |     65.499 ns |  1.91 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     81.201 ns |  2.37 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |    106.321 ns |  3.10 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    121.174 ns |  3.54 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    474.915 ns | 13.86 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    535.333 ns | 15.63 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     50.104 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 1          | NotCancelled     |     50.180 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     61.050 ns |  1.22 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1          | NotCancelled     |     81.354 ns |  1.62 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    152.062 ns |  3.04 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    414.277 ns |  8.27 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    530.419 ns | 10.59 |     272 B | 
| Multiple · SemaphoreSlim · System         | 1          | NotCancelled     |    622.956 ns | 12.43 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    733.678 ns | 14.64 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    277.202 ns |  0.81 |         - | 
| Multiple · SemaphoreSlim · System         | 10         | None             |    283.248 ns |  0.82 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    343.747 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 10         | None             |    348.147 ns |  1.01 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | None             |    539.280 ns |  1.57 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    603.218 ns |  1.76 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    650.448 ns |  1.89 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    679.240 ns |  1.98 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,099.676 ns |  9.02 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,405.050 ns |  9.91 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    513.084 ns |  0.94 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    547.844 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 10         | NotCancelled     |    558.685 ns |  1.02 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    692.270 ns |  1.26 |    2288 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 10         | NotCancelled     |    753.833 ns |  1.38 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,416.495 ns |  6.24 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,507.147 ns |  6.40 |    1352 B | 
| Multiple · SemaphoreSlim · System         | 10         | NotCancelled     |  4,677.141 ns |  8.54 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,253.061 ns |  9.59 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,649.251 ns |  0.82 |         - | 
| Multiple · SemaphoreSlim · System         | 100        | None             |  2,649.349 ns |  0.82 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,234.808 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 100        | None             |  3,316.259 ns |  1.03 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | None             |  4,912.174 ns |  1.52 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,453.920 ns |  1.69 |   41120 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,417.629 ns |  1.98 |   21600 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,768.567 ns |  2.09 |   21008 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 33,534.777 ns | 10.37 |   12195 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 36,539.666 ns | 11.30 |   21798 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,811.830 ns |  0.89 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,394.445 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (SyncCont)  | 100        | NotCancelled     |  5,408.787 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,883.702 ns |  1.28 |   21008 B | 
| Multiple · AsyncSemaphore · VS.Threading  | 100        | NotCancelled     |  7,337.297 ns |  1.36 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 33,196.887 ns |  6.15 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 36,068.165 ns |  6.69 |   12215 B | 
| Multiple · SemaphoreSlim · System         | 100        | NotCancelled     | 44,975.079 ns |  8.34 |   37791 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 56,519.259 ns | 10.48 |   50600 B |