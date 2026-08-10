| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0010 ns | 0.000 |         - | 
| Lock · Interlocked.Add · System           |  0.1764 ns | 0.021 |         - | 
| Lock · Interlocked.Inc · System           |  0.1925 ns | 0.023 |         - | 
| Lock · Interlocked.Exchange · System      |  0.5166 ns | 0.062 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8476 ns | 0.102 |         - | 
| Lock · Lock · System                      |  3.0566 ns | 0.368 |         - | 
| Lock · Lock.EnterScope · System           |  3.1459 ns | 0.379 |         - | 
| SpinLock · SpinLock · CryptoHives         |  3.2782 ns | 0.395 |         - | 
| Lock · lock() · System                    |  4.0113 ns | 0.483 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.0620 ns | 0.851 |         - | 
| LockAsync · AsyncLock · Pooled            |  8.3011 ns | 1.000 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 15.7214 ns | 1.894 |         - | 
| LockAsync · SemaphoreSlim · System        | 16.4273 ns | 1.979 |         - | 
| LockAsync · AsyncLock · RefImpl           | 17.8237 ns | 2.147 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 19.4962 ns | 2.349 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 37.5934 ns | 4.529 |     320 B | 
| SpinWait · SpinOnce · System              | 41.3498 ns | 4.981 |         - | 
| SpinLock · SpinLock · System              | 44.9287 ns | 5.412 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 55.3936 ns | 6.673 |     208 B |