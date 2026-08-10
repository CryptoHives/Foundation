| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  6.416 ns |  0.72 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  8.970 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 14.724 ns |  1.64 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 16.906 ns |  1.88 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 18.065 ns |  2.01 |         - |