| Description                             | Iterations | Mean       | Error    | StdDev   | Ratio | Allocated | 
|---------------------------------------- |----------- |-----------:|---------:|---------:|------:|----------:|
| Contention · AsyncRWLock · Pooled       | 1          |   119.3 ns |  0.52 ns |  0.46 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 1          | 1,699.2 ns | 16.15 ns | 15.11 ns | 14.24 |    1336 B | 
|                                         |            |            |          |          |       |           | 
| Contention · AsyncRWLock · Pooled       | 5          |   321.8 ns |  0.70 ns |  0.65 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 5          | 2,620.8 ns |  4.73 ns |  4.42 ns |  8.15 |    2456 B | 
|                                         |            |            |          |          |       |           | 
| Contention · AsyncRWLock · Pooled       | 10         |   565.8 ns |  1.19 ns |  1.05 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 10         | 4,276.6 ns | 11.82 ns | 11.06 ns |  7.56 |    3856 B |