| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Increment              |  0.0020 ns | 0.000 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.2266 ns | 0.029 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.2296 ns | 0.030 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |  0.6061 ns | 0.078 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.7337 ns | 0.095 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  1.0016 ns | 0.129 |         - | 
| LockAsync · SyncLock · SpinLock               |  2.6565 ns | 0.342 |         - | 
| LockAsync · SyncLock · Lock                   |  3.5852 ns | 0.462 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  3.6017 ns | 0.464 |         - | 
| LockAsync · SyncLock · lock()                 |  4.5607 ns | 0.588 |         - | 
| LockAsync · AsyncLock · Pooled                |  7.7626 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  8.4283 ns | 1.086 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 19.7617 ns | 2.546 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 19.7879 ns | 2.550 |         - | 
| LockAsync · AsyncLock · RefImpl               | 21.6915 ns | 2.795 |         - | 
| LockAsync · AsyncLock · DotNext               | 22.8107 ns | 2.939 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 23.9784 ns | 3.090 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 44.2069 ns | 5.696 |     320 B | 
| LockAsync · SyncLock · SpinOnce               | 46.0174 ns | 5.929 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 66.5084 ns | 8.569 |     208 B |