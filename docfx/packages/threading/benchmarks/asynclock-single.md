| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0030 ns | 0.000 |         - | 
| Lock · Interlocked.Add · System           |  0.1826 ns | 0.021 |         - | 
| Lock · Interlocked.Inc · System           |  0.1845 ns | 0.021 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8459 ns | 0.096 |         - | 
| Lock · Lock.EnterScope · System           |  3.0876 ns | 0.349 |         - | 
| Lock · Lock · System                      |  3.0923 ns | 0.349 |         - | 
| Lock · lock() · System                    |  3.9061 ns | 0.441 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.1325 ns | 0.806 |         - | 
| LockAsync · AsyncLock · Pooled            |  8.8494 ns | 1.000 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 16.3319 ns | 1.846 |         - | 
| LockAsync · AsyncLock · RefImpl           | 17.5526 ns | 1.984 |         - | 
| LockAsync · SemaphoreSlim · System        | 18.0962 ns | 2.045 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 19.6203 ns | 2.217 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 38.0820 ns | 4.303 |     320 B | 
| LockAsync · AsyncLock · NeoSmart          | 55.6606 ns | 6.290 |     208 B |