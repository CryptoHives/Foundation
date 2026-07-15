| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0057 ns | 0.001 |         - | 
| Lock · Interlocked.Add · System           |  0.1939 ns | 0.030 |         - | 
| Lock · Interlocked.Inc · System           |  0.1952 ns | 0.030 |         - | 
| Lock · Interlocked.Exchange · System      |  0.5068 ns | 0.078 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8521 ns | 0.132 |         - | 
| Lock · Lock · System                      |  3.1394 ns | 0.485 |         - | 
| Lock · Lock.EnterScope · System           |  3.1720 ns | 0.490 |         - | 
| SpinLock · SpinLock · CryptoHives         |  3.3182 ns | 0.513 |         - | 
| Lock · lock() · System                    |  3.9953 ns | 0.617 |         - | 
| LockAsync · AsyncLock · Pooled            |  6.4720 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.3760 ns | 1.140 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 16.1348 ns | 2.493 |         - | 
| LockAsync · SemaphoreSlim · System        | 16.3141 ns | 2.521 |         - | 
| LockAsync · AsyncLock · RefImpl           | 17.8354 ns | 2.756 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 19.9833 ns | 3.088 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 39.0541 ns | 6.034 |     320 B | 
| SpinWait · SpinOnce · System              | 42.1704 ns | 6.516 |         - | 
| SpinLock · SpinLock · System              | 45.3120 ns | 7.001 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 56.5801 ns | 8.742 |     208 B |