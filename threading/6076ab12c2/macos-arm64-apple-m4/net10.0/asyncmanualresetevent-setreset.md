| Description                                        | Mean       | Ratio | Allocated | 
|--------------------------------------------------- |-----------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   1.006 ns |  0.63 |         - | 
| SetReset · AsyncManualReset · Pooled               |   1.598 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   6.668 ns |  4.17 |         - | 
| SetReset · AsyncManualReset · DotNext              |   7.524 ns |  4.71 |         - | 
| SetReset · AsyncManualReset · RefImpl              |   9.670 ns |  6.05 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  14.769 ns |  9.24 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 110.107 ns | 68.92 |         - |