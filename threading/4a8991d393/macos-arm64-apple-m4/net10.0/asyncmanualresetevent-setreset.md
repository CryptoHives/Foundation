| Description                                        | Mean        | Ratio | Allocated | 
|--------------------------------------------------- |------------:|------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   0.9717 ns |  0.62 |         - | 
| SetReset · AsyncManualReset · Pooled               |   1.5564 ns |  1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   6.8539 ns |  4.40 |         - | 
| SetReset · AsyncManualReset · RefImpl              |   9.1826 ns |  5.90 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  14.9529 ns |  9.61 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 109.7345 ns | 70.51 |         - |