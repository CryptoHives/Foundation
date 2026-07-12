| Description                                 | Mean      | Ratio | Allocated | 
|-------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise |  6.438 ns |  0.71 |         - | 
| WaitRelease · AsyncSemaphore · Pooled       |  9.013 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 14.622 ns |  1.62 |         - | 
| WaitRelease · SemaphoreSlim · System        | 16.759 ns |  1.86 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 18.722 ns |  2.08 |         - |