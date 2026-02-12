| Description                                 | Mean     | Ratio | Allocated | 
|-------------------------------------------- |---------:|------:|----------:|
| WaitRelease · AsyncSemaphore · Pooled       | 15.38 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 16.50 ns |  1.07 |         - | 
| WaitRelease · SemaphoreSlim · SemaphoreSlim | 17.30 ns |  1.12 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 17.35 ns |  1.13 |         - |