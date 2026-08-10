| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.864 ns |  0.64 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  9.203 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  9.251 ns |  1.01 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.676 ns |  1.49 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 24.142 ns |  2.62 |      96 B |