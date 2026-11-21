| Description                                            | Mean      | Error    | StdDev   | Ratio | Allocated | 
|------------------------------------------------------- |----------:|---------:|---------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  20.73 ns | 0.014 ns | 0.013 ns |  0.96 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  21.71 ns | 0.055 ns | 0.043 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  31.17 ns | 0.068 ns | 0.064 ns |  1.44 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  32.93 ns | 0.351 ns | 0.328 ns |  1.52 |         - | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  58.50 ns | 0.085 ns | 0.079 ns |  2.69 |     144 B | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  67.77 ns | 0.409 ns | 0.382 ns |  3.12 |      48 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  93.20 ns | 0.156 ns | 0.139 ns |  4.29 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 105.52 ns | 0.301 ns | 0.282 ns |  4.86 |     504 B |