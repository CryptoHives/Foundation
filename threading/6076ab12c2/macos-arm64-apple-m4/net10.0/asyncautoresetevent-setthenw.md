| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  3.710 ns |  0.80 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  4.643 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  5.838 ns |  1.26 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       |  9.200 ns |  1.98 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            |  9.779 ns |  2.11 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 12.371 ns |  2.66 |         - |