| Description                               | Mean         | Ratio | Allocated | 
|------------------------------------------ |-------------:|------:|----------:|
| WriterLock · RWLockSlim · System          |     6.905 ns |  0.66 |         - | 
| WriterLock · AsyncRWLock · Proto.Promises |     8.379 ns |  0.80 |         - | 
| WriterLock · AsyncRWLock · Pooled         |    10.460 ns |  1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl        |    18.797 ns |  1.80 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx   |    54.581 ns |  5.22 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading   | 1,027.868 ns | 98.27 |     584 B |