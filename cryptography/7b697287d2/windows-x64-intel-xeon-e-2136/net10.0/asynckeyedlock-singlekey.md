| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  73.56 ns |  0.78 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  87.19 ns |  0.93 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  93.97 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  | 111.42 ns |  1.19 |         - | 
| LockAsync · AsyncKeyedLock · RefImpl                   | 174.48 ns |  1.86 |     144 B | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            | 204.36 ns |  2.17 |      48 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           | 206.42 ns |  2.20 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 263.98 ns |  2.81 |     520 B |