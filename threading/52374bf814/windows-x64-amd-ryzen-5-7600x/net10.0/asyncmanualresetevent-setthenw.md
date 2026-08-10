| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  6.130 ns |  0.71 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  8.679 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 10.352 ns |  1.19 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 14.084 ns |  1.62 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 24.532 ns |  2.83 |      96 B |