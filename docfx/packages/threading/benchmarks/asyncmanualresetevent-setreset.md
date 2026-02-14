| Description                                | Mean       | Ratio | Allocated | 
|------------------------------------------- |-----------:|------:|----------:|
| SetReset · ManualResetEventSlim · System   |   5.385 ns |  0.72 |         - | 
| SetReset · AsyncManualReset · Pooled       |   7.497 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.584 ns |  1.28 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  17.018 ns |  2.27 |      96 B | 
| SetReset · ManualResetEvent · System       | 432.592 ns | 57.71 |         - |