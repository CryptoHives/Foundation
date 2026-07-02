| Description                                       | Mean     | Ratio | Allocated | 
|-------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       | 3.548 ns |  0.77 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) | 4.604 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    | 5.553 ns |  1.21 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 9.391 ns |  2.04 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 9.697 ns |  2.11 |         - |