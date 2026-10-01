| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  33.24 ns |  0.83 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  37.10 ns |  0.93 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  40.06 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  64.13 ns |  1.60 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  74.16 ns |  1.85 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  77.91 ns |  1.95 |     144 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  92.01 ns |  2.30 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 120.16 ns |  3.00 |     520 B |