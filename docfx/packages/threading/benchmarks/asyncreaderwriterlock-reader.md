| Description                                | Mean      | Ratio | Allocated | 
|------------------------------------------- |----------:|------:|----------:|
| ReaderLock · ReaderWriterLockSlim · System |  5.861 ns |  0.35 |         - | 
| ReaderLock · AsyncRWLock · RefImpl         | 15.885 ns |  0.95 |         - | 
| ReaderLock · AsyncRWLock · Pooled          | 16.649 ns |  1.00 |         - | 
| ReaderLock · AsyncRWLock · Nito.AsyncEx    | 37.094 ns |  2.23 |     320 B |