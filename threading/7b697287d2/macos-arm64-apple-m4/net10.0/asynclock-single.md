| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Interlocked.Exchange   |  0.0000 ns | 0.000 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.4380 ns | 0.066 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.4493 ns | 0.068 |         - | 
| LockAsync · SyncLock · Increment              |  0.4518 ns | 0.068 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.5522 ns | 0.083 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  1.8959 ns | 0.285 |         - | 
| LockAsync · SyncLock · Lock                   |  1.9010 ns | 0.286 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  2.4573 ns | 0.369 |         - | 
| LockAsync · SyncLock · lock()                 |  2.7788 ns | 0.418 |         - | 
| LockAsync · SyncLock · SpinLock               |  5.8426 ns | 0.878 |         - | 
| LockAsync · AsyncLock · Pooled                |  6.6538 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  6.6565 ns | 1.001 |         - | 
| LockAsync · AsyncLock · RefImpl               | 11.4164 ns | 1.716 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 11.4437 ns | 1.721 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 12.0764 ns | 1.816 |         - | 
| LockAsync · AsyncLock · DotNext               | 14.1801 ns | 2.132 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 16.6703 ns | 2.506 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 38.7263 ns | 5.822 |     320 B | 
| LockAsync · SyncLock · SpinOnce               | 48.1524 ns | 7.240 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 50.2478 ns | 7.555 |     208 B |