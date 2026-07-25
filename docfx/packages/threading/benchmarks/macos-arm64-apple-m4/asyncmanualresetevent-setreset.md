| Description                                | Mean        | Ratio | Allocated | 
|------------------------------------------- |------------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   0.9164 ns |  0.60 |         - | 
| SetReset · AsyncManualReset · Pooled       |   1.5384 ns |  1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   6.8272 ns |  4.44 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.2011 ns |  5.98 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  14.8942 ns |  9.68 |      96 B | 
| SetReset · ManualResetEvent · System       | 112.0806 ns | 72.86 |         - |