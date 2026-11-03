| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 11.19 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 27.96 ns |  2.50 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 29.72 ns |  2.66 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 62.93 ns |  5.63 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 84.57 ns |  7.56 |     200 B |