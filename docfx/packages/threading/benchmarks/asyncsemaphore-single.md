| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.482 ns |  0.69 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.422 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 15.063 ns |  1.60 |         - | 
| WaitRelease · SemaphoreSlim · System        | 17.055 ns |  1.81 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 19.053 ns |  2.02 |         - |