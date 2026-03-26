| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.407 ns |  0.71 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.047 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 15.286 ns |  1.69 |         - | 
| WaitRelease · SemaphoreSlim · System        | 16.991 ns |  1.88 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 18.945 ns |  2.09 |         - |