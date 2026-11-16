| Description                                   | Mean        | Ratio | Allocated | 
|---------------------------------------------- |------------:|------:|----------:|
| LockAsync · SyncLock · Increment              |   0.0005 ns | 0.000 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |   5.6570 ns | 0.233 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |   5.6582 ns | 0.233 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |   5.6591 ns | 0.233 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |   6.2925 ns | 0.259 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |   7.4883 ns | 0.308 |         - | 
| LockAsync · SyncLock · SpinLock               |  10.5637 ns | 0.435 |         - | 
| LockAsync · SyncLock · Lock                   |  16.6401 ns | 0.685 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  16.6409 ns | 0.685 |         - | 
| LockAsync · SyncLock · lock()                 |  18.5008 ns | 0.762 |         - | 
| LockAsync · AsyncLock · Pooled                |  24.2779 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  30.7293 ns | 1.266 |         - | 
| LockAsync · AsyncLock · RefImpl               |  48.7828 ns | 2.009 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         |  50.0364 ns | 2.061 |         - | 
| LockAsync · AsyncLock · VS.Threading          |  51.2519 ns | 2.111 |         - | 
| LockAsync · AsyncLock · DotNext               |  53.5539 ns | 2.206 |         - | 
| LockAsync · SyncLock · SpinOnce               |  54.3646 ns | 2.239 |         - | 
| LockAsync · AsyncLock · NonKeyed              |  59.0048 ns | 2.430 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 122.9801 ns | 5.066 |     320 B | 
| LockAsync · AsyncLock · NeoSmart              | 151.8886 ns | 6.256 |     208 B |