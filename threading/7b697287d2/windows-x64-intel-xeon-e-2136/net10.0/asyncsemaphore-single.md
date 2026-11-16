| Description                                  | Mean     | Ratio | Allocated | 
|--------------------------------------------- |---------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  | 25.55 ns |  0.84 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        | 30.47 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 47.15 ns |  1.55 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 47.21 ns |  1.55 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 50.47 ns |  1.66 |         - |