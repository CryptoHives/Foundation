| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  7.149 ns |  0.70 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        | 10.194 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 16.240 ns |  1.59 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 18.583 ns |  1.82 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 20.212 ns |  1.98 |         - |