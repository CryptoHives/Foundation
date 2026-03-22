| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.343 ns |  0.67 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  7.968 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.606 ns |  1.08 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 13.925 ns |  1.75 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.777 ns |  1.98 |         - |