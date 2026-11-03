| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  6.440 ns |  0.62 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) | 10.382 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 10.778 ns |  1.04 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 15.602 ns |  1.50 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 24.844 ns |  2.39 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 27.172 ns |  2.62 |      96 B |