| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.449 ns |  0.71 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.134 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 14.832 ns |  1.62 |         - | 
| WaitRelease · SemaphoreSlim · System        | 16.707 ns |  1.83 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 18.014 ns |  1.97 |         - |