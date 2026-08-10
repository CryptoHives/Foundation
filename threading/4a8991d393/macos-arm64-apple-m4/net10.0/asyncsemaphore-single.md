| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  4.828 ns |  0.78 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  6.216 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 11.487 ns |  1.85 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 11.701 ns |  1.88 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 11.884 ns |  1.91 |         - |