| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  6.779 ns |  0.64 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 10.529 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) | 10.581 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 15.626 ns |  1.48 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 25.240 ns |  2.39 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 27.604 ns |  2.61 |      96 B |