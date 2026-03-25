| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0166 ns | 0.002 |         - | 
| Lock · Interlocked.Inc · System           |  0.2124 ns | 0.023 |         - | 
| Lock · Interlocked.Add · System           |  0.2172 ns | 0.024 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8743 ns | 0.097 |         - | 
| Lock · Lock · System                      |  3.2814 ns | 0.362 |         - | 
| Lock · Lock.EnterScope · System           |  3.2932 ns | 0.364 |         - | 
| SpinLock · SpinLock · CryptoHives         |  3.5089 ns | 0.388 |         - | 
| Lock · lock() · System                    |  4.1281 ns | 0.456 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.6229 ns | 0.842 |         - | 
| LockAsync · AsyncLock · Pooled            |  9.0531 ns | 1.000 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 16.8130 ns | 1.857 |         - | 
| LockAsync · SemaphoreSlim · System        | 17.1491 ns | 1.894 |         - | 
| LockAsync · AsyncLock · RefImpl           | 18.3201 ns | 2.024 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 23.8203 ns | 2.631 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 41.4603 ns | 4.580 |     320 B | 
| SpinWait · SpinOnce · System              | 43.6106 ns | 4.818 |         - | 
| SpinLock · SpinLock · System              | 45.6359 ns | 5.041 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 58.9117 ns | 6.508 |     208 B |