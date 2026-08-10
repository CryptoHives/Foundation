| Description                                       | Mean     | Ratio | Allocated | 
|-------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) | 10.03 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    | 11.03 ns |  1.10 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 14.70 ns |  1.47 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 15.96 ns |  1.59 |         - |