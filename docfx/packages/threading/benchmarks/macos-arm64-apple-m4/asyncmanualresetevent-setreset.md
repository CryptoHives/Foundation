| Description                                | Mean       | Ratio | Allocated | 
|------------------------------------------- |-----------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.009 ns |  0.62 |         - | 
| SetReset · AsyncManualReset · Pooled       |   1.616 ns |  1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   6.662 ns |  4.12 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.369 ns |  5.80 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  15.199 ns |  9.40 |      96 B | 
| SetReset · ManualResetEvent · System       | 108.067 ns | 66.87 |         - |