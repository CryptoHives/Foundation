| Method                       | Mean      | Ratio | Allocated | 
|----------------------------- |----------:|------:|----------:|
| ReadLockReaderWriterLockSlim |  5.949 ns |  0.37 |         - | 
| ReaderLockPooledAsync        | 16.219 ns |  1.00 |         - | 
| ReaderLockRefImplAsync       | 16.825 ns |  1.04 |         - | 
| ReaderLockNitoAsync          | 39.086 ns |  2.41 |     320 B |