| Description                                  | Mean      | Error     | StdDev    | Ratio | Allocated | 
|--------------------------------------------- |----------:|----------:|----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  4.942 ns | 0.0207 ns | 0.0194 ns |  0.72 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  6.830 ns | 0.0400 ns | 0.0375 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 14.557 ns | 0.0633 ns | 0.0592 ns |  2.13 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 15.839 ns | 0.0525 ns | 0.0466 ns |  2.32 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 16.771 ns | 0.0733 ns | 0.0686 ns |  2.46 |         - |