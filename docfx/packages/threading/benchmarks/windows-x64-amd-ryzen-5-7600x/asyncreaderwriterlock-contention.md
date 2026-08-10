| Description                             | Iterations | Mean        | Ratio | Allocated | 
|---------------------------------------- |----------- |------------:|------:|----------:|
| Contention · AsyncRWLock · Pooled       | 1          |    98.81 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 1          | 1,869.17 ns | 18.92 |    1440 B | 
|                                         |            |             |       |           | 
| Contention · AsyncRWLock · Pooled       | 5          |   272.98 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 5          | 3,124.88 ns | 11.45 |    2560 B | 
|                                         |            |             |       |           | 
| Contention · AsyncRWLock · Pooled       | 10         |   437.32 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 10         | 4,478.11 ns | 10.24 |    3960 B |