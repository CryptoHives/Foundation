| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  4.129 ns |  0.71 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  5.348 ns |  0.92 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  5.844 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 12.825 ns |  2.19 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 15.608 ns |  2.67 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 21.746 ns |  3.72 |      96 B |