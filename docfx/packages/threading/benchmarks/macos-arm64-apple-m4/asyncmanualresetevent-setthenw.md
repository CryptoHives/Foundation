| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  4.133 ns |  0.71 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  5.607 ns |  0.96 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  5.845 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.076 ns |  2.24 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 21.383 ns |  3.66 |      96 B |