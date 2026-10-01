| Description                                            | Mean     | Ratio | Allocated | 
|------------------------------------------------------- |---------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 24.47 ns |  0.98 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    | 24.93 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) | 30.55 ns |  1.23 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  | 35.17 ns |  1.41 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            | 57.82 ns |  2.32 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   | 62.30 ns |  2.50 |     144 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           | 84.66 ns |  3.40 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 96.80 ns |  3.88 |     520 B |