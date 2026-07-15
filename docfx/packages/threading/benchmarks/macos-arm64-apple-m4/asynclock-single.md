| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Interlocked.Exchange · System      |  0.0000 ns | 0.000 |         - | 
| Lock · Increment · System                 |  0.4601 ns | 0.067 |         - | 
| Lock · Interlocked.Inc · System           |  0.4692 ns | 0.068 |         - | 
| Lock · Interlocked.Add · System           |  0.4771 ns | 0.069 |         - | 
| Lock · Lock · System                      |  1.7588 ns | 0.255 |         - | 
| Lock · Lock.EnterScope · System           |  1.7817 ns | 0.258 |         - | 
| Lock · Interlocked.CmpX · System          |  2.4232 ns | 0.351 |         - | 
| SpinLock · SpinLock · CryptoHives         |  2.6420 ns | 0.382 |         - | 
| Lock · lock() · System                    |  2.9387 ns | 0.425 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  6.6327 ns | 0.960 |         - | 
| LockAsync · AsyncLock · Pooled            |  6.9102 ns | 1.000 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 11.4114 ns | 1.651 |         - | 
| LockAsync · AsyncLock · RefImpl           | 11.7925 ns | 1.707 |         - | 
| LockAsync · SemaphoreSlim · System        | 12.4404 ns | 1.800 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 16.8037 ns | 2.432 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 40.1211 ns | 5.806 |     320 B | 
| SpinWait · SpinOnce · System              | 44.1741 ns | 6.393 |         - | 
| SpinLock · SpinLock · System              | 52.1762 ns | 7.551 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 60.4453 ns | 8.748 |     208 B |