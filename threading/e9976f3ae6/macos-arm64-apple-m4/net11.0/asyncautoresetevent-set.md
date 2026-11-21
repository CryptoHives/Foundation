| Description                           | Mean      | Error     | StdDev    | Ratio | Allocated | 
|-------------------------------------- |----------:|----------:|----------:|------:|----------:|
| Set · AsyncAutoReset · DotNext        | 0.9418 ns | 0.0036 ns | 0.0033 ns |  0.59 |         - | 
| Set · AsyncAutoReset · ProtoPromise   | 1.5327 ns | 0.0051 ns | 0.0048 ns |  0.96 |         - | 
| Set · AsyncAutoReset · Pooled         | 1.5960 ns | 0.0031 ns | 0.0029 ns |  1.00 |         - | 
| Set · AsyncAutoReset · Nito.AsyncEx   | 5.6426 ns | 0.0116 ns | 0.0108 ns |  3.54 |         - | 
| Set · AsyncAutoReset · RefImpl        | 5.7004 ns | 0.0063 ns | 0.0059 ns |  3.57 |         - | 
| Set · AsyncAutoReset · AutoResetEvent | 8.2752 ns | 0.0386 ns | 0.0361 ns |  5.18 |         - |