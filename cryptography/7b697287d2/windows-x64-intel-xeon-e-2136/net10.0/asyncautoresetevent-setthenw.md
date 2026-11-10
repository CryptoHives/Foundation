| Description                                       | Mean     | Ratio | Allocated | 
|-------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       | 22.60 ns |  0.97 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) | 23.20 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    | 25.01 ns |  1.08 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 44.90 ns |  1.94 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 45.06 ns |  1.94 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 53.39 ns |  2.30 |         - |