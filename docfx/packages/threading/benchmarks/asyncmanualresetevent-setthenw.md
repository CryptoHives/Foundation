| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.858 ns |  0.78 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  7.558 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  8.947 ns |  1.18 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 14.100 ns |  1.87 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 25.265 ns |  3.34 |      96 B |