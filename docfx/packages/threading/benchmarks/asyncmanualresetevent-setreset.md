| Description                                | Mean       | Ratio | Allocated | 
|------------------------------------------- |-----------:|------:|----------:|
| SetReset · ManualResetEventSlim · Slim     |   5.617 ns |  0.76 |         - | 
| SetReset · AsyncManualReset · Pooled       |   7.433 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · RefImpl      |   9.681 ns |  1.30 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx |  17.034 ns |  2.29 |      96 B | 
| SetReset · ManualResetEvent · Standard     | 433.172 ns | 58.28 |         - |