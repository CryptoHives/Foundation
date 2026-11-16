| Description                                        | Mean         | Ratio | Allocated | 
|--------------------------------------------------- |-------------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |     8.448 ns |  0.50 |         - | 
| SetReset · AsyncManualReset · Pooled               |    16.966 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |    23.692 ns |  1.40 |         - | 
| SetReset · AsyncManualReset · DotNext              |    45.950 ns |  2.71 |         - | 
| SetReset · AsyncManualReset · RefImpl              |    46.272 ns |  2.73 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |    71.342 ns |  4.21 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 1,469.685 ns | 86.63 |         - |