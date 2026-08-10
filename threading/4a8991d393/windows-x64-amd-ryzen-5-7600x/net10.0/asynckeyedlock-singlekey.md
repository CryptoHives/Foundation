| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  28.02 ns |  0.80 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  32.18 ns |  0.92 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  35.16 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  54.72 ns |  1.56 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  68.32 ns |  1.94 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  68.37 ns |  1.94 |     144 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  81.65 ns |  2.32 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 100.21 ns |  2.85 |     520 B |