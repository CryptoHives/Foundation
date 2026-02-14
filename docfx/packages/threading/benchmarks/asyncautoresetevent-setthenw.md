| Description                                       | Mean      | Ratio | Allocated | 
|-------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncAutoReset · Pooled (ValueTask) |  9.907 ns |  1.00 |         - | 
| SetThenWait · AsyncAutoReset · Pooled (AsTask)    | 10.957 ns |  1.11 |         - | 
| SetThenWait · AsyncAutoReset · Nito.AsyncEx       | 15.046 ns |  1.52 |         - | 
| SetThenWait · AsyncAutoReset · RefImpl            | 36.258 ns |  3.66 |         - |