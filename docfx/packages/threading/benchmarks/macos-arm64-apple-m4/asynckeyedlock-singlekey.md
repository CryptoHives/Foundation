| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  23.30 ns |  0.94 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  24.92 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  30.40 ns |  1.22 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  35.79 ns |  1.44 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  57.08 ns |  2.29 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  60.93 ns |  2.45 |     144 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  87.04 ns |  3.49 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 102.09 ns |  4.10 |     520 B |