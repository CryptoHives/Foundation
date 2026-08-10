| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.294 ns |  0.84 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  6.303 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  7.069 ns |  1.12 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 13.545 ns |  2.15 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 14.940 ns |  2.37 |         - |