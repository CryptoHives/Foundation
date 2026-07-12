| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.698 ns |  0.63 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  9.093 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  9.186 ns |  1.01 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.566 ns |  1.49 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 23.935 ns |  2.63 |      96 B |