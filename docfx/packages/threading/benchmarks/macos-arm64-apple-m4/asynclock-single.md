| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Interlocked.Exchange · System      |  0.0000 ns | 0.000 |         - | 
| Lock · Increment · System                 |  0.4435 ns | 0.059 |         - | 
| Lock · Interlocked.Add · System           |  0.4573 ns | 0.060 |         - | 
| Lock · Interlocked.Inc · System           |  0.4583 ns | 0.061 |         - | 
| Lock · Interlocked.CmpX · System          |  2.4091 ns | 0.318 |         - | 
| Lock · Lock · System                      |  2.6142 ns | 0.345 |         - | 
| Lock · Lock.EnterScope · System           |  2.6513 ns | 0.350 |         - | 
| SpinLock · SpinLock · CryptoHives         |  2.7340 ns | 0.361 |         - | 
| Lock · lock() · System                    |  3.2074 ns | 0.423 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  6.6302 ns | 0.875 |         - | 
| LockAsync · AsyncLock · Pooled            |  7.5745 ns | 1.000 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 11.6188 ns | 1.534 |         - | 
| LockAsync · AsyncLock · RefImpl           | 11.7976 ns | 1.558 |         - | 
| LockAsync · SemaphoreSlim · System        | 12.7817 ns | 1.688 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 16.6770 ns | 2.202 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 40.3838 ns | 5.332 |     320 B | 
| SpinWait · SpinOnce · System              | 47.4733 ns | 6.268 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 49.8415 ns | 6.580 |     208 B | 
| SpinLock · SpinLock · System              | 53.7720 ns | 7.099 |         - |