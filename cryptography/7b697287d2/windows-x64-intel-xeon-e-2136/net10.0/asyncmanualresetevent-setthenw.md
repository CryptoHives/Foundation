| Description                                         | Mean     | Ratio | Allocated | 
|---------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       | 16.68 ns |  0.65 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 24.93 ns |  0.98 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) | 25.51 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 51.71 ns |  2.03 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 70.54 ns |  2.77 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 96.74 ns |  3.79 |      96 B |