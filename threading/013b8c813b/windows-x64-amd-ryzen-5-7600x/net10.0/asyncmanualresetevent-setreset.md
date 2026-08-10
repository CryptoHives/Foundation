| Description                                | Mean       | Ratio  | Allocated | 
|------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.447 ns |   0.71 |         - | 
| SetReset · AsyncManualReset · Pooled       |   2.050 ns |   1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.438 ns |   2.65 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.979 ns |   4.87 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  17.013 ns |   8.30 |      96 B | 
| SetReset · ManualResetEvent · System       | 432.047 ns | 210.74 |         - |