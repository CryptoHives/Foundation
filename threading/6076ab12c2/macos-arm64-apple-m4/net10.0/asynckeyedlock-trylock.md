| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 11.41 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 29.28 ns |  2.57 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 29.50 ns |  2.59 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 61.88 ns |  5.42 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 82.28 ns |  7.21 |     200 B |