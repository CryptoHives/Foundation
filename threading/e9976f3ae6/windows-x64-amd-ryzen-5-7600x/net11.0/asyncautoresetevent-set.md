| Description                           | Mean       | Error     | StdDev    | Ratio  | Allocated | 
|-------------------------------------- |-----------:|----------:|----------:|-------:|----------:|
| Set · AsyncAutoReset · DotNext        |   1.128 ns | 0.0036 ns | 0.0032 ns |   0.65 |         - | 
| Set · AsyncAutoReset · Pooled         |   1.743 ns | 0.0024 ns | 0.0020 ns |   1.00 |         - | 
| Set · AsyncAutoReset · ProtoPromise   |   1.780 ns | 0.0019 ns | 0.0017 ns |   1.02 |         - | 
| Set · AsyncAutoReset · RefImpl        |   5.643 ns | 0.0167 ns | 0.0148 ns |   3.24 |         - | 
| Set · AsyncAutoReset · Nito.AsyncEx   |   5.662 ns | 0.0243 ns | 0.0228 ns |   3.25 |         - | 
| Set · AsyncAutoReset · AutoResetEvent | 256.189 ns | 0.4629 ns | 0.4104 ns | 146.97 |         - |