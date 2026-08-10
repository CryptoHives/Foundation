| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Increment              |  0.0072 ns | 0.001 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.1904 ns | 0.028 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.2010 ns | 0.030 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |  0.5064 ns | 0.076 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.6289 ns | 0.094 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  0.8558 ns | 0.128 |         - | 
| LockAsync · SyncLock · SpinLock               |  2.3023 ns | 0.344 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  3.1230 ns | 0.467 |         - | 
| LockAsync · SyncLock · Lock                   |  3.1615 ns | 0.472 |         - | 
| LockAsync · SyncLock · lock()                 |  4.6653 ns | 0.697 |         - | 
| LockAsync · AsyncLock · Pooled                |  6.6928 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  7.2922 ns | 1.090 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 16.5046 ns | 2.466 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 17.0535 ns | 2.548 |         - | 
| LockAsync · AsyncLock · RefImpl               | 18.0135 ns | 2.692 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 20.4511 ns | 3.056 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 40.8711 ns | 6.107 |     320 B | 
| LockAsync · SyncLock · SpinOnce               | 42.0012 ns | 6.276 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 57.2895 ns | 8.560 |     208 B |