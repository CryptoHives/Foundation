| Description                                  | Mean      | Error     | StdDev    | Ratio | Allocated | 
|--------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  3.735 ns | 0.0095 ns | 0.0089 ns |  0.73 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  5.086 ns | 0.0039 ns | 0.0037 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 12.320 ns | 0.0102 ns | 0.0091 ns |  2.42 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 12.998 ns | 0.0112 ns | 0.0099 ns |  2.56 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 13.211 ns | 0.0123 ns | 0.0115 ns |  2.60 |         - |