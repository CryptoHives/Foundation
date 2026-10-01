| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  7.164 ns |  0.69 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        | 10.313 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 17.709 ns |  1.72 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 19.188 ns |  1.86 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 21.179 ns |  2.05 |         - |