| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  4.114 ns |  0.72 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  5.260 ns |  0.93 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  5.684 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 12.428 ns |  2.19 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 21.419 ns |  3.77 |      96 B |