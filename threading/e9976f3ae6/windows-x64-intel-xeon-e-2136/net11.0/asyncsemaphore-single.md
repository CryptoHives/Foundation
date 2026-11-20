| Description                                  | Mean     | Error    | StdDev   | Ratio | Allocated | 
|--------------------------------------------- |---------:|---------:|---------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  | 19.83 ns | 0.097 ns | 0.180 ns |  0.77 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        | 25.72 ns | 0.161 ns | 0.303 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 45.76 ns | 0.036 ns | 0.066 ns |  1.78 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 45.99 ns | 0.032 ns | 0.059 ns |  1.79 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 47.07 ns | 0.045 ns | 0.083 ns |  1.83 |         - |