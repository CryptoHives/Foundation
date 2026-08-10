| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  6.682 ns |  0.74 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  9.084 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  9.449 ns |  1.04 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.706 ns |  1.51 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 25.320 ns |  2.79 |      96 B |