| Description                                        | Mean       | Ratio  | Allocated | 
|--------------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   1.565 ns |   0.68 |         - | 
| SetReset · AsyncManualReset · Pooled               |   2.308 ns |   1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   6.152 ns |   2.67 |         - | 
| SetReset · AsyncManualReset · RefImpl              |  11.148 ns |   4.83 |      96 B | 
| SetReset · AsyncManualReset · DotNext              |  11.722 ns |   5.08 |         - | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  18.917 ns |   8.20 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 500.826 ns | 217.01 |         - |