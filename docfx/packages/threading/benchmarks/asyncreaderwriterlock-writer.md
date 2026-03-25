| Description                              | Mean         | Ratio  | Allocated | 
|----------------------------------------- |-------------:|-------:|----------:|
| WriterLock · RWLockSlim · System         |     7.092 ns |   0.71 |         - | 
| WriterLock · AsyncRWLock · ProtoPromises |     8.337 ns |   0.84 |         - | 
| WriterLock · AsyncRWLock · Pooled        |     9.974 ns |   1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl       |    18.909 ns |   1.90 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx  |    55.084 ns |   5.52 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading  | 1,024.959 ns | 102.77 |     584 B |