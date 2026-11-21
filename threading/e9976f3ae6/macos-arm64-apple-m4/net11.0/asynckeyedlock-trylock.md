| Description                                          | Mean     | Error    | StdDev   | Ratio | Allocated | 
|----------------------------------------------------- |---------:|---------:|---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 11.18 ns | 0.027 ns | 0.026 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 26.39 ns | 0.071 ns | 0.063 ns |  2.36 |      24 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 38.82 ns | 0.769 ns | 0.945 ns |  3.47 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 71.00 ns | 0.081 ns | 0.072 ns |  6.35 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 86.12 ns | 0.161 ns | 0.151 ns |  7.70 |     200 B |