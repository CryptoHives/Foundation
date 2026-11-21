| Description                             | Iterations | Mean        | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------- |----------- |------------:|----------:|----------:|------:|----------:|
| Contention · AsyncRWLock · Pooled       | 1          |    349.7 ns |   0.54 ns |   1.01 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 1          |  3,995.4 ns |  44.70 ns |  82.85 ns | 11.42 |    1336 B | 
|                                         |            |             |           |           |       |           | 
| Contention · AsyncRWLock · Pooled       | 5          |    900.0 ns |   0.68 ns |   1.25 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 5          |  7,737.2 ns | 179.41 ns | 341.34 ns |  8.60 |    2456 B | 
|                                         |            |             |           |           |       |           | 
| Contention · AsyncRWLock · Pooled       | 10         |  1,590.5 ns |   5.75 ns |  10.66 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 10         | 12,641.5 ns | 112.64 ns | 203.12 ns |  7.95 |    3856 B |