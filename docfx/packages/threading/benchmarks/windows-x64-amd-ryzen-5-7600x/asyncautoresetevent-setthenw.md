| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.451 ns |  0.92 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  5.905 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.369 ns |  1.42 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 13.819 ns |  2.34 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 18.866 ns |  3.20 |         - |