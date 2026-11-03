| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Increment              |  0.0004 ns | 0.000 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.2086 ns | 0.028 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.2109 ns | 0.028 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |  0.5912 ns | 0.079 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.7092 ns | 0.095 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  0.9889 ns | 0.132 |         - | 
| LockAsync · SyncLock · SpinLock               |  2.6320 ns | 0.352 |         - | 
| LockAsync · SyncLock · Lock                   |  3.5054 ns | 0.468 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  3.5399 ns | 0.473 |         - | 
| LockAsync · SyncLock · lock()                 |  4.4125 ns | 0.589 |         - | 
| LockAsync · AsyncLock · Pooled                |  7.4871 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  8.1594 ns | 1.090 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 18.2471 ns | 2.437 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 18.9568 ns | 2.532 |         - | 
| LockAsync · AsyncLock · RefImpl               | 20.5296 ns | 2.742 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 26.3130 ns | 3.514 |         - | 
| LockAsync · AsyncLock · DotNext               | 31.7746 ns | 4.244 |         - | 
| LockAsync · SyncLock · SpinOnce               | 45.7754 ns | 6.114 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 46.5022 ns | 6.211 |     320 B | 
| LockAsync · AsyncLock · NeoSmart              | 65.7693 ns | 8.784 |     208 B |