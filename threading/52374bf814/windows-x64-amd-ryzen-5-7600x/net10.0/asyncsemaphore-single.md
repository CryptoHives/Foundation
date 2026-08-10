| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.506 ns |  0.71 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.162 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 14.745 ns |  1.61 |         - | 
| WaitRelease · SemaphoreSlim · System        | 16.958 ns |  1.85 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 18.116 ns |  1.98 |         - |