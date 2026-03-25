| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.256 ns |  0.71 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  7.357 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  8.475 ns |  1.15 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 13.501 ns |  1.84 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.247 ns |  2.07 |         - |