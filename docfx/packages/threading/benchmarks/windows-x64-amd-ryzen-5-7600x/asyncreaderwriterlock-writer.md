| Description                               | Mean         | Ratio | Allocated | 
|------------------------------------------ |-------------:|------:|----------:|
| WriterLock · RWLockSlim · System          |     6.962 ns |  0.62 |         - | 
| WriterLock · AsyncRWLock · Proto.Promises |     8.709 ns |  0.78 |         - | 
| WriterLock · AsyncRWLock · Pooled         |    11.204 ns |  1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl        |    18.618 ns |  1.66 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx   |    56.077 ns |  5.01 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading   | 1,057.243 ns | 94.37 |     584 B |