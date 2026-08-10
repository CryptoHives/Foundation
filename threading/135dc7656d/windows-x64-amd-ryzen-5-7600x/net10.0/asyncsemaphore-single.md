| Description                                 | Mean     | Ratio | Allocated | 
|-------------------------------------------- |---------:|------:|----------:|
| WaitRelease · AsyncSemaphore · Pooled       | 15.55 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx | 16.12 ns |  1.04 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl      | 17.35 ns |  1.12 |         - | 
| WaitRelease · SemaphoreSlim · System        | 17.38 ns |  1.12 |         - |