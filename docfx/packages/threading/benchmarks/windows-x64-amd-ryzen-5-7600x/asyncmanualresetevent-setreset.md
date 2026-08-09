| Description                                        | Mean       | Ratio  | Allocated | 
|--------------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   1.472 ns |   0.72 |         - | 
| SetReset · AsyncManualReset · Pooled               |   2.053 ns |   1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   5.731 ns |   2.79 |         - | 
| SetReset · AsyncManualReset · RefImpl              |  10.001 ns |   4.87 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  17.127 ns |   8.34 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 428.263 ns | 208.65 |         - |