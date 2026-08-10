| Description                                | Mean       | Ratio  | Allocated | 
|------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.424 ns |   0.70 |         - | 
| SetReset · AsyncManualReset · Pooled       |   2.043 ns |   1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.633 ns |   2.76 |         - | 
| SetReset · AsyncManualReset · RefImpl      |  10.499 ns |   5.14 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  17.007 ns |   8.33 |      96 B | 
| SetReset · ManualResetEvent · System       | 426.864 ns | 208.98 |         - |