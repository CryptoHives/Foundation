| Description                                         | Mean      | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.311 ns | 0.0260 ns | 0.0230 ns |  0.86 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  6.154 ns | 0.0127 ns | 0.0118 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  6.753 ns | 0.0177 ns | 0.0165 ns |  1.10 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 14.496 ns | 0.0276 ns | 0.0258 ns |  2.36 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 20.907 ns | 0.0492 ns | 0.0460 ns |  3.40 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 25.984 ns | 0.0784 ns | 0.0695 ns |  4.22 |      96 B |