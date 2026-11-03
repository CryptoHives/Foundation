| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · Pooled                    |  24.62 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  24.70 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  30.73 ns |  1.25 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  35.25 ns |  1.43 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  57.31 ns |  2.33 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  61.76 ns |  2.51 |     144 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  84.85 ns |  3.45 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 101.20 ns |  4.11 |     520 B |