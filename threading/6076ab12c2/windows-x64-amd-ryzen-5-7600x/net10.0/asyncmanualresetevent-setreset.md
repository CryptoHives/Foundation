| Description                                        | Mean       | Ratio  | Allocated | 
|--------------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   1.686 ns |   0.71 |         - | 
| SetReset · AsyncManualReset · Pooled               |   2.372 ns |   1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   6.318 ns |   2.66 |         - | 
| SetReset · AsyncManualReset · RefImpl              |  11.372 ns |   4.80 |      96 B | 
| SetReset · AsyncManualReset · DotNext              |  11.904 ns |   5.02 |         - | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  19.220 ns |   8.11 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 503.702 ns | 212.41 |         - |