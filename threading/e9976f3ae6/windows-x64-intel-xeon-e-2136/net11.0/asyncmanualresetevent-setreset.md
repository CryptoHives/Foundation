| Description                                        | Mean        | Error    | StdDev   | Ratio | Allocated | 
|--------------------------------------------------- |------------:|---------:|---------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |    10.38 ns | 0.002 ns | 0.003 ns |  0.55 |         - | 
| SetReset · AsyncManualReset · Pooled               |    18.90 ns | 0.005 ns | 0.009 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |    19.52 ns | 0.002 ns | 0.003 ns |  1.03 |         - | 
| SetReset · AsyncManualReset · DotNext              |    43.90 ns | 0.011 ns | 0.021 ns |  2.32 |         - | 
| SetReset · AsyncManualReset · RefImpl              |    48.70 ns | 0.046 ns | 0.085 ns |  2.58 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |    72.64 ns | 0.629 ns | 1.135 ns |  3.84 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 1,476.27 ns | 1.197 ns | 2.128 ns | 78.13 |         - |