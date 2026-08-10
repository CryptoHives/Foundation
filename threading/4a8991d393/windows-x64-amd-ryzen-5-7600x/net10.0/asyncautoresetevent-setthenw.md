| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.360 ns |  0.90 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  5.969 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.402 ns |  1.41 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 13.977 ns |  2.34 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.846 ns |  2.65 |         - |