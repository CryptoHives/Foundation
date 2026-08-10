| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  3.628 ns |  0.77 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  4.714 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  5.894 ns |  1.25 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            |  9.885 ns |  2.10 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 10.082 ns |  2.14 |         - |