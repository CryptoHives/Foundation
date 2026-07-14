| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0055 ns | 0.001 |         - | 
| Lock · Interlocked.Add · System           |  0.1941 ns | 0.030 |         - | 
| Lock · Interlocked.Inc · System           |  0.1962 ns | 0.030 |         - | 
| Lock · Interlocked.Exchange · System      |  0.5114 ns | 0.078 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8485 ns | 0.129 |         - | 
| Lock · Lock · System                      |  3.1710 ns | 0.483 |         - | 
| Lock · Lock.EnterScope · System           |  3.1792 ns | 0.484 |         - | 
| SpinLock · SpinLock · CryptoHives         |  3.4198 ns | 0.521 |         - | 
| Lock · lock() · System                    |  4.0252 ns | 0.613 |         - | 
| LockAsync · AsyncLock · Pooled            |  6.5671 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.3639 ns | 1.122 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 16.1748 ns | 2.464 |         - | 
| LockAsync · SemaphoreSlim · System        | 16.9281 ns | 2.578 |         - | 
| LockAsync · AsyncLock · RefImpl           | 18.0751 ns | 2.753 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 20.1124 ns | 3.063 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 38.8548 ns | 5.918 |     320 B | 
| SpinWait · SpinOnce · System              | 41.9097 ns | 6.384 |         - | 
| SpinLock · SpinLock · System              | 45.3896 ns | 6.914 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 57.9707 ns | 8.830 |     208 B |