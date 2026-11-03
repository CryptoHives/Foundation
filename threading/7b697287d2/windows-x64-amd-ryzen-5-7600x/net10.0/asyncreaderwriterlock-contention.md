| Description                             | Iterations | Mean       | Ratio | Allocated | 
|---------------------------------------- |----------- |-----------:|------:|----------:|
| Contention · AsyncRWLock · Pooled       | 1          |   111.0 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 1          | 2,093.0 ns | 18.86 |    1440 B | 
|                                         |            |            |       |           | 
| Contention · AsyncRWLock · Pooled       | 5          |   291.0 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 5          | 3,396.6 ns | 11.67 |    2560 B | 
|                                         |            |            |       |           | 
| Contention · AsyncRWLock · Pooled       | 10         |   498.3 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 10         | 5,082.6 ns | 10.20 |    3961 B |