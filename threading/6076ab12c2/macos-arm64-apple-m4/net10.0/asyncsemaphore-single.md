| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  4.841 ns |  0.78 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  6.241 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 11.325 ns |  1.81 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 11.726 ns |  1.88 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 12.122 ns |  1.94 |         - |