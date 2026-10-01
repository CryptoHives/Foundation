| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Interlocked.Exchange   |  0.0000 ns | 0.000 |         - | 
| LockAsync · SyncLock · Increment              |  0.4400 ns | 0.067 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.4580 ns | 0.070 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.4998 ns | 0.076 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.5695 ns | 0.087 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  1.8312 ns | 0.279 |         - | 
| LockAsync · SyncLock · Lock                   |  1.8364 ns | 0.280 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  2.4175 ns | 0.369 |         - | 
| LockAsync · SyncLock · lock()                 |  2.7326 ns | 0.417 |         - | 
| LockAsync · SyncLock · SpinLock               |  5.8218 ns | 0.888 |         - | 
| LockAsync · AsyncLock · Pooled                |  6.5562 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  6.8603 ns | 1.047 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 10.9506 ns | 1.670 |         - | 
| LockAsync · AsyncLock · RefImpl               | 11.5445 ns | 1.761 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 12.1427 ns | 1.852 |         - | 
| LockAsync · AsyncLock · DotNext               | 13.8507 ns | 2.113 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 15.8825 ns | 2.423 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 40.1630 ns | 6.127 |     320 B | 
| LockAsync · SyncLock · SpinOnce               | 42.3129 ns | 6.455 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 50.7637 ns | 7.744 |     208 B |