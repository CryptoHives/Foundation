| Description                                         | Mean     | Ratio | Allocated | 
|---------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncManualReset · RefImpl            | 13.20 ns |  0.85 |      96 B | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) | 15.57 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 16.11 ns |  1.03 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 23.73 ns |  1.52 |      96 B |