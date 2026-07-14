| Description                                       | Mean     | Ratio | Allocated | 
|-------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       | 3.590 ns |  0.77 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) | 4.632 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    | 5.578 ns |  1.20 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 9.310 ns |  2.01 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 9.921 ns |  2.14 |         - |