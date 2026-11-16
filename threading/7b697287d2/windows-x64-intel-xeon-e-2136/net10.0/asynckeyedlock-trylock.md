| Description                                          | Mean      | Ratio | Allocated | 
|----------------------------------------------------- |----------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    |  53.05 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) |  86.75 ns |  1.64 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  99.54 ns |  1.88 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 207.11 ns |  3.90 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 215.41 ns |  4.06 |     200 B |