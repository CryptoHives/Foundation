| Description                                          | Mean      | Error    | StdDev   | Ratio | Allocated | 
|----------------------------------------------------- |----------:|---------:|---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    |  54.64 ns | 0.055 ns | 0.100 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  75.44 ns | 0.113 ns | 0.215 ns |  1.38 |      24 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) |  80.11 ns | 0.626 ns | 1.176 ns |  1.47 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 180.03 ns | 0.326 ns | 0.603 ns |  3.29 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 212.15 ns | 0.961 ns | 1.733 ns |  3.88 |     200 B |