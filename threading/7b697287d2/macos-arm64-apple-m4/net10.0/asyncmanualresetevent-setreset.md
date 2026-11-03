| Description                                        | Mean       | Ratio | Allocated | 
|--------------------------------------------------- |-----------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   1.118 ns |  0.70 |         - | 
| SetReset · AsyncManualReset · Pooled               |   1.599 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   6.348 ns |  3.97 |         - | 
| SetReset · AsyncManualReset · DotNext              |   7.652 ns |  4.79 |         - | 
| SetReset · AsyncManualReset · RefImpl              |   9.064 ns |  5.67 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  14.719 ns |  9.21 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 111.479 ns | 69.75 |         - |