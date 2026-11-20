| Description                                          | Mean     | Error    | StdDev   | Ratio | Allocated | 
|----------------------------------------------------- |---------:|---------:|---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 17.82 ns | 0.082 ns | 0.068 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 37.92 ns | 0.168 ns | 0.149 ns |  2.13 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 38.28 ns | 1.752 ns | 5.167 ns |  2.15 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 80.63 ns | 1.570 ns | 1.928 ns |  4.53 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 97.78 ns | 0.391 ns | 0.366 ns |  5.49 |     200 B |