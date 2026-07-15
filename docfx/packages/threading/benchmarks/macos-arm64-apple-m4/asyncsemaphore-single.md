| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  4.777 ns |  0.77 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  6.203 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 11.378 ns |  1.83 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 11.417 ns |  1.84 |         - | 
| WaitRelease · SemaphoreSlim · System        | 12.665 ns |  2.04 |         - |