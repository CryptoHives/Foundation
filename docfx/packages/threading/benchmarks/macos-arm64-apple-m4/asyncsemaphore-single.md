| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  4.826 ns |  0.77 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  6.236 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 11.658 ns |  1.87 |         - | 
| WaitRelease · SemaphoreSlim · System        | 11.848 ns |  1.90 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 12.085 ns |  1.94 |         - |