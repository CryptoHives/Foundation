| Description                                       | Mean      | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  4.730 ns | 0.0171 ns | 0.0143 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · ProtoPromise       |  4.909 ns | 0.0384 ns | 0.0359 ns |  1.04 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  7.013 ns | 0.0300 ns | 0.0280 ns |  1.48 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 12.467 ns | 0.0541 ns | 0.0452 ns |  2.64 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 12.651 ns | 0.0446 ns | 0.0395 ns |  2.67 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 17.493 ns | 0.0883 ns | 0.0826 ns |  3.70 |         - |