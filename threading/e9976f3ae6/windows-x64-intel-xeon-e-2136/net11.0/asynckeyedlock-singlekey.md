| Description                                            | Mean      | Error    | StdDev   | Ratio | Allocated | 
|------------------------------------------------------- |----------:|---------:|---------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  62.40 ns | 0.047 ns | 0.081 ns |  0.82 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  73.90 ns | 0.121 ns | 0.219 ns |  0.97 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  76.46 ns | 0.115 ns | 0.204 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  79.80 ns | 0.162 ns | 0.296 ns |  1.04 |         - | 
| LockAsync · AsyncKeyedLock · RefImpl                   | 155.82 ns | 0.198 ns | 0.358 ns |  2.04 |     144 B | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            | 171.73 ns | 0.413 ns | 0.745 ns |  2.25 |      48 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           | 200.09 ns | 0.631 ns | 1.154 ns |  2.62 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 257.86 ns | 2.018 ns | 3.741 ns |  3.37 |     504 B |