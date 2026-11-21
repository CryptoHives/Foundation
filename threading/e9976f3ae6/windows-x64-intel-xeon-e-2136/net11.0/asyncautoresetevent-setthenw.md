| Description                                       | Mean     | Error    | StdDev   | Ratio | Allocated | 
|-------------------------------------------------- |---------:|---------:|---------:|------:|----------:|
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) | 19.87 ns | 0.014 ns | 0.025 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · ProtoPromise       | 19.91 ns | 0.016 ns | 0.030 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    | 21.91 ns | 0.086 ns | 0.161 ns |  1.10 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 45.23 ns | 0.020 ns | 0.038 ns |  2.28 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 45.60 ns | 0.023 ns | 0.044 ns |  2.29 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 51.88 ns | 0.229 ns | 0.425 ns |  2.61 |         - |