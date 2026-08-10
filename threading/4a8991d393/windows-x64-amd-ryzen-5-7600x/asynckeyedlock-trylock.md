| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 14.69 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 35.76 ns |  2.43 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 39.57 ns |  2.69 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 68.94 ns |  4.69 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 84.50 ns |  5.75 |     200 B |