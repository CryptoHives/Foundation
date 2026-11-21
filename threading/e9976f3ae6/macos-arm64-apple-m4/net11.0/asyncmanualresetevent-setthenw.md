| Description                                         | Mean      | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  3.623 ns | 0.0092 ns | 0.0086 ns |  0.85 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  4.275 ns | 0.0053 ns | 0.0044 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  4.699 ns | 0.0142 ns | 0.0132 ns |  1.10 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 12.822 ns | 0.0692 ns | 0.0648 ns |  3.00 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 14.253 ns | 0.0123 ns | 0.0115 ns |  3.33 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 24.354 ns | 0.0412 ns | 0.0365 ns |  5.70 |      96 B |