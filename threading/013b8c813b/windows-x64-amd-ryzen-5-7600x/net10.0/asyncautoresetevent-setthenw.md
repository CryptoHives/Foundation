| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.450 ns |  0.90 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  6.083 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.694 ns |  1.43 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 14.165 ns |  2.33 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.447 ns |  2.54 |         - |