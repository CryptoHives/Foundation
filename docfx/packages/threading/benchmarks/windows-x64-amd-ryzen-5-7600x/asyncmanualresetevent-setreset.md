| Description                                | Mean       | Ratio  | Allocated | 
|------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.431 ns |   0.71 |         - | 
| SetReset · AsyncManualReset · Pooled       |   2.026 ns |   1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.416 ns |   2.67 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.891 ns |   4.88 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  16.887 ns |   8.34 |      96 B | 
| SetReset · ManualResetEvent · System       | 431.385 ns | 212.98 |         - |