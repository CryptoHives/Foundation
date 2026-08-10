| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  4.945 ns |  0.77 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  6.412 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 11.604 ns |  1.81 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 11.697 ns |  1.82 |         - | 
| WaitRelease · SemaphoreSlim · System        | 12.635 ns |  1.97 |         - |