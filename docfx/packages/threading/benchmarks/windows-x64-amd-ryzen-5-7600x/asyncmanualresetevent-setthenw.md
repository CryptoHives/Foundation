| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.701 ns |  0.62 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  9.157 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  9.182 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.552 ns |  1.48 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 29.012 ns |  3.17 |      96 B |