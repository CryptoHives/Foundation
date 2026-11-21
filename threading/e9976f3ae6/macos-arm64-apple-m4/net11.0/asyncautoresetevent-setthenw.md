| Description                                       | Mean      | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  3.388 ns | 0.0026 ns | 0.0025 ns |  0.97 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  3.510 ns | 0.0023 ns | 0.0020 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  4.692 ns | 0.0061 ns | 0.0054 ns |  1.34 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 11.116 ns | 0.0178 ns | 0.0167 ns |  3.17 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 11.228 ns | 0.0210 ns | 0.0176 ns |  3.20 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 11.236 ns | 0.0137 ns | 0.0128 ns |  3.20 |         - |