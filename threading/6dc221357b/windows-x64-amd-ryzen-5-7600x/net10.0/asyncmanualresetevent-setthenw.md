| Description                                         | Mean     | Ratio | Allocated | 
|---------------------------------------------------- |---------:|------:|----------:|
| SetThenWait · AsyncManualReset · RefImpl            | 13.30 ns |  0.85 |      96 B | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) | 15.72 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 16.11 ns |  1.02 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 23.46 ns |  1.49 |      96 B |