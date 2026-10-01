| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  3.904 ns |  0.67 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  5.230 ns |  0.90 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  5.796 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 12.902 ns |  2.23 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 15.373 ns |  2.65 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 21.408 ns |  3.69 |      96 B |