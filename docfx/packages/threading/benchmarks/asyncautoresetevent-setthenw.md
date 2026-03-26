| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.561 ns |  0.74 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  7.546 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.743 ns |  1.16 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 14.318 ns |  1.90 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.575 ns |  2.06 |         - |