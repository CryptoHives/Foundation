| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0045 ns | 0.001 |         - | 
| Lock · Interlocked.Add · System           |  0.1903 ns | 0.029 |         - | 
| Lock · Interlocked.Inc · System           |  0.1909 ns | 0.030 |         - | 
| Lock · Interlocked.Exchange · System      |  0.5103 ns | 0.079 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8490 ns | 0.131 |         - | 
| Lock · Lock · System                      |  3.1395 ns | 0.486 |         - | 
| Lock · Lock.EnterScope · System           |  3.1440 ns | 0.487 |         - | 
| SpinLock · SpinLock · CryptoHives         |  3.3041 ns | 0.512 |         - | 
| Lock · lock() · System                    |  4.0182 ns | 0.622 |         - | 
| LockAsync · AsyncLock · Pooled            |  6.4579 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.3175 ns | 1.133 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 16.1519 ns | 2.501 |         - | 
| LockAsync · SemaphoreSlim · System        | 16.5987 ns | 2.570 |         - | 
| LockAsync · AsyncLock · RefImpl           | 17.8179 ns | 2.759 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 19.5094 ns | 3.021 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 38.5159 ns | 5.964 |     320 B | 
| SpinWait · SpinOnce · System              | 41.7213 ns | 6.461 |         - | 
| SpinLock · SpinLock · System              | 45.2280 ns | 7.004 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 57.1795 ns | 8.855 |     208 B |