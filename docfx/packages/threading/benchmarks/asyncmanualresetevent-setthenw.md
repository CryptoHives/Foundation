| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.684 ns |  0.70 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  8.074 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  9.339 ns |  1.16 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.400 ns |  1.66 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 23.694 ns |  2.93 |      96 B |