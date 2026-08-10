| Description                              | Mean         | Ratio  | Allocated | 
|----------------------------------------- |-------------:|-------:|----------:|
| WriterLock · RWLockSlim · System         |     6.947 ns |   0.68 |         - | 
| WriterLock · AsyncRWLock · ProtoPromises |     8.378 ns |   0.82 |         - | 
| WriterLock · AsyncRWLock · Pooled        |    10.164 ns |   1.00 |         - | 
| WriterLock · AsyncRWLock · RefImpl       |    19.056 ns |   1.87 |         - | 
| WriterLock · AsyncRWLock · Nito.AsyncEx  |    53.690 ns |   5.28 |     496 B | 
| WriterLock · AsyncRWLock · VS.Threading  | 1,103.223 ns | 108.54 |     584 B |