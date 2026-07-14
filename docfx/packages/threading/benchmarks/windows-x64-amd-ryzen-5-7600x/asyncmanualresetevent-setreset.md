| Description                                | Mean       | Ratio  | Allocated | 
|------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.429 ns |   0.70 |         - | 
| SetReset · AsyncManualReset · Pooled       |   2.031 ns |   1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.398 ns |   2.66 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.901 ns |   4.87 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  17.414 ns |   8.57 |      96 B | 
| SetReset · ManualResetEvent · System       | 432.439 ns | 212.91 |         - |