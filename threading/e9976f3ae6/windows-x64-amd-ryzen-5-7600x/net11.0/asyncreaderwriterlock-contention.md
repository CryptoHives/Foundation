| Description                             | Iterations | Mean       | Error    | StdDev   | Ratio | Allocated | 
|---------------------------------------- |----------- |-----------:|---------:|---------:|------:|----------:|
| Contention · AsyncRWLock · Pooled       | 1          |   108.8 ns |  0.26 ns |  0.24 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 1          | 1,916.6 ns |  6.17 ns |  5.77 ns | 17.62 |    1336 B | 
|                                         |            |            |          |          |       |           | 
| Contention · AsyncRWLock · Pooled       | 5          |   270.1 ns |  1.01 ns |  0.84 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 5          | 3,423.5 ns |  7.61 ns |  6.75 ns | 12.67 |    2456 B | 
|                                         |            |            |          |          |       |           | 
| Contention · AsyncRWLock · Pooled       | 10         |   478.9 ns |  2.66 ns |  2.49 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 10         | 5,310.4 ns | 23.42 ns | 20.76 ns | 11.09 |    3856 B |