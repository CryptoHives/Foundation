| Description                                         | Mean     | Error    | StdDev   | Ratio | Allocated | 
|---------------------------------------------------- |---------:|---------:|---------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       | 14.11 ns | 0.015 ns | 0.028 ns |  0.62 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    | 21.97 ns | 0.022 ns | 0.041 ns |  0.97 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) | 22.70 ns | 0.563 ns | 1.030 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 48.79 ns | 0.220 ns | 0.414 ns |  2.15 |      96 B | 
| SetThenWait · AsyncManualReset · DotNext            | 69.42 ns | 0.169 ns | 0.317 ns |  3.06 |         - | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 97.25 ns | 0.040 ns | 0.074 ns |  4.29 |      96 B |