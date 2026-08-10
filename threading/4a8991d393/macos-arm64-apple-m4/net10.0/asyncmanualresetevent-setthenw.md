| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  4.021 ns |  0.70 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  5.296 ns |  0.93 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  5.718 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 12.750 ns |  2.23 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 21.827 ns |  3.82 |      96 B |