| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.398 ns |  0.70 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.083 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 14.655 ns |  1.61 |         - | 
| WaitRelease · SemaphoreSlim · System        | 16.827 ns |  1.85 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 17.893 ns |  1.97 |         - |