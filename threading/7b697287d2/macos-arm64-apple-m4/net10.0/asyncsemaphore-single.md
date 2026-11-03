| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  5.004 ns |  0.79 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  6.375 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 11.199 ns |  1.76 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 11.428 ns |  1.79 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 12.033 ns |  1.89 |         - |