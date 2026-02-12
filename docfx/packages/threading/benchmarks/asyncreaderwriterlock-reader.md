| Description                                    | Mean      | Ratio | Allocated | 
|----------------------------------------------- |----------:|------:|----------:|
| ReaderLock · ReaderWriterLockSlim · RWLockSlim |  5.870 ns |  0.15 |         - | 
| ReaderLock · AsyncRWLock · RefImpl             | 15.499 ns |  0.38 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx        | 36.934 ns |  0.91 |     320 B | 
| ReaderLock · AsyncRWLock · Pooled              | 40.418 ns |  1.00 |         - |