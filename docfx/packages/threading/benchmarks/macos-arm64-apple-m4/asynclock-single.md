| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Interlocked.Exchange   |  0.0000 ns | 0.000 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.4732 ns | 0.068 |         - | 
| LockAsync · SyncLock · Increment              |  0.4750 ns | 0.068 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.4835 ns | 0.070 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.5299 ns | 0.076 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  1.7934 ns | 0.258 |         - | 
| LockAsync · SyncLock · Lock                   |  1.8000 ns | 0.259 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  2.4745 ns | 0.356 |         - | 
| LockAsync · SyncLock · lock()                 |  2.9681 ns | 0.427 |         - | 
| LockAsync · SyncLock · SpinLock               |  6.0481 ns | 0.871 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  6.5503 ns | 0.943 |         - | 
| LockAsync · AsyncLock · Pooled                |  6.9461 ns | 1.000 |         - | 
| LockAsync · AsyncLock · RefImpl               | 11.3625 ns | 1.636 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 11.6207 ns | 1.673 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 12.6993 ns | 1.828 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 16.1365 ns | 2.323 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 39.8629 ns | 5.739 |     320 B | 
| LockAsync · SyncLock · SpinOnce               | 45.7518 ns | 6.587 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 50.2907 ns | 7.240 |     208 B |