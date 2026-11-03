| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  32.21 ns |  0.79 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  38.58 ns |  0.95 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  40.75 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  65.14 ns |  1.60 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  74.70 ns |  1.83 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  75.77 ns |  1.86 |     144 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  91.17 ns |  2.24 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 112.50 ns |  2.76 |     520 B |