| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 17.46 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 41.42 ns |  2.37 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 45.63 ns |  2.61 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 79.55 ns |  4.56 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 96.34 ns |  5.52 |     200 B |