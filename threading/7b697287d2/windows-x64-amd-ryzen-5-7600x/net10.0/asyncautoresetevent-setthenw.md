| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  5.989 ns |  0.92 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  6.484 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  9.747 ns |  1.50 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 15.649 ns |  2.41 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 17.187 ns |  2.65 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 22.292 ns |  3.44 |         - |