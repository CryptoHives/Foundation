| Description                                | Mean       | Ratio  | Allocated | 
|------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.496 ns |   0.72 |         - | 
| SetReset · AsyncManualReset · Pooled       |   2.092 ns |   1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.658 ns |   2.71 |         - | 
| SetReset · AsyncManualReset · RefImpl      |  10.298 ns |   4.92 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  17.483 ns |   8.36 |      96 B | 
| SetReset · ManualResetEvent · System       | 435.467 ns | 208.23 |         - |