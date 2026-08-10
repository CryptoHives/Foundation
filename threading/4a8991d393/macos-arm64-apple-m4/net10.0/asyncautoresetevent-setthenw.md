| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  3.577 ns |  0.77 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  4.643 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  5.620 ns |  1.21 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            |  9.919 ns |  2.14 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 10.642 ns |  2.29 |         - |