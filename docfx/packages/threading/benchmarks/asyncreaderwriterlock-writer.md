| Method                        | Mean      | Ratio | Allocated | 
|------------------------------ |----------:|------:|----------:|
| WriteLockReaderWriterLockSlim |  7.466 ns |  0.49 |         - | 
| WriterLockPooledAsync         | 15.287 ns |  1.00 |         - | 
| WriterLockRefImplAsync        | 18.999 ns |  1.24 |         - | 
| WriterLockNitoAsync           | 51.303 ns |  3.36 |     496 B |