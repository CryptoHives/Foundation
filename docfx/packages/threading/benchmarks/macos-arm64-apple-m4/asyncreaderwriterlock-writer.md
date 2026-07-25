| Description                               | Mean         | Ratio  | Allocated | 
|------------------------------------------ |-------------:|-------:|----------:|
| WriterLock · RWLockSlim · System          |     4.635 ns |   0.61 |         - | 
| WriterLock · AsyncRWLock · Proto.Promises |     6.804 ns |   0.89 |         - | 
| WriterLock · AsyncRWLock · Pooled         |     7.614 ns |   1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl        |    12.101 ns |   1.59 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx   |    57.229 ns |   7.52 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading   | 1,382.823 ns | 181.62 |     584 B |