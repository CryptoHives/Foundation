| Description                           | Mean       | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------- |-----------:|----------:|----------:|------:|----------:|
| Set · AsyncAutoReset · DotNext        |   1.974 ns | 0.1115 ns | 0.1982 ns |  0.19 |         - | 
| Set · AsyncAutoReset · ProtoPromise   |   8.334 ns | 0.0328 ns | 0.0601 ns |  0.80 |         - | 
| Set · AsyncAutoReset · Pooled         |  10.365 ns | 0.0035 ns | 0.0064 ns |  1.00 |         - | 
| Set · AsyncAutoReset · RefImpl        |  19.905 ns | 0.0278 ns | 0.0509 ns |  1.92 |         - | 
| Set · AsyncAutoReset · Nito.AsyncEx   |  21.693 ns | 0.0068 ns | 0.0126 ns |  2.09 |         - | 
| Set · AsyncAutoReset · AutoResetEvent | 747.999 ns | 1.2730 ns | 2.4221 ns | 72.17 |         - |