| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 17.08 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 39.79 ns |  2.33 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 47.50 ns |  2.78 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 82.36 ns |  4.82 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 94.97 ns |  5.56 |     200 B |