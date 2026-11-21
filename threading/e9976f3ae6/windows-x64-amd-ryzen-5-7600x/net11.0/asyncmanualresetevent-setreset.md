| Description                                        | Mean       | Error     | StdDev    | Ratio  | Allocated | 
|--------------------------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   2.403 ns | 0.0036 ns | 0.0030 ns |   0.69 |         - | 
| SetReset · AsyncManualReset · Pooled               |   3.471 ns | 0.0098 ns | 0.0091 ns |   1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   3.713 ns | 0.0076 ns | 0.0071 ns |   1.07 |         - | 
| SetReset · AsyncManualReset · RefImpl              |  11.974 ns | 0.0598 ns | 0.0559 ns |   3.45 |      96 B | 
| SetReset · AsyncManualReset · DotNext              |  12.486 ns | 0.0425 ns | 0.0398 ns |   3.60 |         - | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  17.909 ns | 0.1468 ns | 0.1302 ns |   5.16 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 492.804 ns | 0.6408 ns | 0.5994 ns | 141.99 |         - |