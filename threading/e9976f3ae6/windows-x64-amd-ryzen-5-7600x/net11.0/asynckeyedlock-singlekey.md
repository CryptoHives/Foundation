| Description                                            | Mean      | Error    | StdDev   | Ratio | Allocated | 
|------------------------------------------------------- |----------:|---------:|---------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  28.87 ns | 0.065 ns | 0.058 ns |  0.79 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  36.65 ns | 0.083 ns | 0.069 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  36.72 ns | 0.096 ns | 0.085 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  42.18 ns | 0.066 ns | 0.058 ns |  1.15 |         - | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  64.85 ns | 0.245 ns | 0.217 ns |  1.77 |     144 B | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  72.74 ns | 0.083 ns | 0.078 ns |  1.98 |      48 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  89.39 ns | 0.226 ns | 0.189 ns |  2.43 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 103.38 ns | 0.312 ns | 0.276 ns |  2.82 |     504 B |