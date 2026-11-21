| Description                                        | Mean      | Error     | StdDev    | Ratio | Allocated | 
|--------------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |  2.134 ns | 0.0047 ns | 0.0044 ns |  0.75 |         - | 
| SetReset · AsyncManualReset · Pooled               |  2.859 ns | 0.0069 ns | 0.0061 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |  3.551 ns | 0.0049 ns | 0.0041 ns |  1.24 |         - | 
| SetReset · AsyncManualReset · DotNext              |  8.707 ns | 0.0080 ns | 0.0071 ns |  3.05 |         - | 
| SetReset · AsyncManualReset · RefImpl              | 11.197 ns | 0.0111 ns | 0.0086 ns |  3.92 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 15.645 ns | 0.0796 ns | 0.0744 ns |  5.47 |         - | 
| SetReset · AsyncManualReset · Nito.AsyncEx         | 18.353 ns | 0.0178 ns | 0.0158 ns |  6.42 |      96 B |