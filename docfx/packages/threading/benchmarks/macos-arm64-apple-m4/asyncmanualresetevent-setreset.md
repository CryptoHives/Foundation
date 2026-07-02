| Description                                | Mean        | Ratio | Allocated | 
|------------------------------------------- |------------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise |   0.9943 ns |  0.62 |         - | 
| SetReset · AsyncManualReset · Pooled       |   1.5984 ns |  1.00 |         - | 
| SetReset · ManualResetEventSlim · System   |   6.5702 ns |  4.11 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.3634 ns |  5.86 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  15.2066 ns |  9.52 |      96 B | 
| SetReset · ManualResetEvent · System       | 109.1403 ns | 68.32 |         - |