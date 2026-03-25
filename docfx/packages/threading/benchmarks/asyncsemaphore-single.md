| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.545 ns |  0.71 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.157 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 16.358 ns |  1.79 |         - | 
| WaitRelease · SemaphoreSlim · System        | 16.652 ns |  1.82 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 19.333 ns |  2.11 |         - |