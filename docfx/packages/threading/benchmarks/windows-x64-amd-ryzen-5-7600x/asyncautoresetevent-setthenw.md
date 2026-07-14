| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.351 ns |  0.60 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.343 ns |  0.94 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  8.874 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 13.598 ns |  1.53 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.582 ns |  1.76 |         - |