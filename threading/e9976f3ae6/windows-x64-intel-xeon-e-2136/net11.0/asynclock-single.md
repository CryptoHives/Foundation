| Description                                   | Mean       | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------------- |-----------:|----------:|----------:|------:|----------:|
| LockAsync · SyncLock · Increment              |   1.523 ns | 0.0057 ns | 0.0106 ns |  0.09 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |   7.616 ns | 0.0030 ns | 0.0055 ns |  0.43 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |   7.618 ns | 0.0044 ns | 0.0079 ns |  0.43 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |   7.618 ns | 0.0137 ns | 0.0247 ns |  0.43 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |   8.252 ns | 0.0061 ns | 0.0117 ns |  0.46 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |   9.460 ns | 0.0140 ns | 0.0252 ns |  0.53 |         - | 
| LockAsync · SyncLock · SpinLock               |  12.553 ns | 0.0467 ns | 0.0830 ns |  0.70 |         - | 
| LockAsync · AsyncLock · Pooled                |  17.909 ns | 0.0752 ns | 0.1431 ns |  1.00 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  18.302 ns | 0.0070 ns | 0.0126 ns |  1.02 |         - | 
| LockAsync · SyncLock · Lock                   |  18.309 ns | 0.0097 ns | 0.0179 ns |  1.02 |         - | 
| LockAsync · SyncLock · lock()                 |  21.641 ns | 0.0082 ns | 0.0146 ns |  1.21 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  23.497 ns | 0.0103 ns | 0.0194 ns |  1.31 |         - | 
| LockAsync · AsyncLock · RefImpl               |  46.178 ns | 0.0504 ns | 0.0896 ns |  2.58 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         |  46.827 ns | 0.0326 ns | 0.0588 ns |  2.61 |         - | 
| LockAsync · AsyncLock · VS.Threading          |  48.173 ns | 0.0117 ns | 0.0210 ns |  2.69 |         - | 
| LockAsync · AsyncLock · NonKeyed              |  49.758 ns | 0.0249 ns | 0.0468 ns |  2.78 |         - | 
| LockAsync · AsyncLock · DotNext               |  52.335 ns | 0.7273 ns | 1.2927 ns |  2.92 |         - | 
| LockAsync · SyncLock · SpinOnce               |  59.667 ns | 0.1347 ns | 0.2496 ns |  3.33 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 121.445 ns | 0.8501 ns | 1.5967 ns |  6.78 |     312 B | 
| LockAsync · AsyncLock · NeoSmart              | 145.435 ns | 0.3354 ns | 0.6301 ns |  8.12 |     208 B |