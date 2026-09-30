| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.983 ns |  0.92 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  6.487 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  9.806 ns |  1.51 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 16.560 ns |  2.55 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 18.513 ns |  2.85 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 22.863 ns |  3.52 |         - |