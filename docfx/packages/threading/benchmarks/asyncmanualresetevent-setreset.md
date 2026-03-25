| Description                                | Mean       | Ratio  | Allocated | 
|------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.498 ns |   0.71 |         - | 
| SetReset · AsyncManualReset · Pooled       |   2.122 ns |   1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.698 ns |   2.69 |         - | 
| SetReset · AsyncManualReset · RefImpl      |  10.386 ns |   4.90 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  18.208 ns |   8.58 |      96 B | 
| SetReset · ManualResetEvent · System       | 429.410 ns | 202.39 |         - |