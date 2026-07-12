| Description                               | Mean         | Ratio | Allocated | 
|------------------------------------------ |-------------:|------:|----------:|
| WriterLock · RWLockSlim · System          |     6.894 ns |  0.67 |         - | 
| WriterLock · AsyncRWLock · Proto.Promises |     8.306 ns |  0.80 |         - | 
| WriterLock · AsyncRWLock · Pooled         |    10.363 ns |  1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl        |    17.718 ns |  1.71 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx   |    55.295 ns |  5.34 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading   | 1,027.376 ns | 99.14 |     584 B |