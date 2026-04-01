| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  6.566 ns |  0.87 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  7.536 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  8.976 ns |  1.19 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 14.156 ns |  1.88 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 24.939 ns |  3.31 |      96 B |
