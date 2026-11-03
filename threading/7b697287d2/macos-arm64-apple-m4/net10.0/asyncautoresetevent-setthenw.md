| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · ProtoPromise       |  3.739 ns |  0.80 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  4.661 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    |  5.903 ns |  1.27 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       |  8.970 ns |  1.92 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            |  9.946 ns |  2.13 |         - | 
| SetThenWait · AsyncAutoReset · DotNext            | 12.426 ns |  2.67 |         - |