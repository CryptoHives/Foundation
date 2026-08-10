| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  4.203 ns |  0.65 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  5.999 ns |  0.92 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  6.505 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 12.832 ns |  1.97 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 21.813 ns |  3.35 |      96 B |