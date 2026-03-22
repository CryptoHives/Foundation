| Description                                | Mean       | Ratio | Allocated | 
|------------------------------------------- |-----------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   1.414 ns |  0.28 |         - | 
| SetReset · AsyncManualReset · Pooled       |   4.994 ns |  1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   5.646 ns |  1.13 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.754 ns |  1.95 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  16.735 ns |  3.35 |      96 B | 
| SetReset · ManualResetEvent · System       | 428.036 ns | 85.71 |         - |