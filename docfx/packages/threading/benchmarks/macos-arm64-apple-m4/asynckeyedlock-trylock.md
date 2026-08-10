| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 11.20 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 30.87 ns |  2.76 |      24 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 32.30 ns |  2.89 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 62.38 ns |  5.57 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 80.95 ns |  7.23 |     200 B |