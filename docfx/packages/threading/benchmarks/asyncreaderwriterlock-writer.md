| Description                              | Mean         | Ratio  | Allocated | 
|----------------------------------------- |-------------:|-------:|----------:|
| WriterLock · RWLockSlim · System         |     6.977 ns |   0.71 |         - | 
| WriterLock · AsyncRWLock · ProtoPromises |     8.206 ns |   0.84 |         - | 
| WriterLock · AsyncRWLock · Pooled        |     9.788 ns |   1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl       |    18.564 ns |   1.90 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx  |    53.068 ns |   5.43 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading  | 1,094.265 ns | 111.90 |     584 B |