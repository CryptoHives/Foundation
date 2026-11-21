| Description                                   | Mean       | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------------- |-----------:|----------:|----------:|------:|----------:|
| LockAsync · SyncLock · Increment              |  0.9059 ns | 0.0010 ns | 0.0009 ns |  0.21 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  1.3509 ns | 0.0104 ns | 0.0098 ns |  0.31 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  1.3700 ns | 0.0091 ns | 0.0085 ns |  0.31 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  1.7260 ns | 0.0020 ns | 0.0016 ns |  0.39 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |  1.7329 ns | 0.0021 ns | 0.0019 ns |  0.39 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  2.0895 ns | 0.0060 ns | 0.0056 ns |  0.47 |         - | 
| LockAsync · SyncLock · SpinLock               |  3.6681 ns | 0.0037 ns | 0.0035 ns |  0.83 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  4.3164 ns | 0.0111 ns | 0.0098 ns |  0.98 |         - | 
| LockAsync · AsyncLock · Pooled                |  4.4102 ns | 0.0138 ns | 0.0108 ns |  1.00 |         - | 
| LockAsync · SyncLock · lock()                 |  5.1427 ns | 0.0120 ns | 0.0100 ns |  1.17 |         - | 
| LockAsync · SyncLock · Lock                   |  5.3364 ns | 0.0176 ns | 0.0165 ns |  1.21 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  5.9527 ns | 0.0307 ns | 0.0287 ns |  1.35 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 14.8332 ns | 0.0451 ns | 0.0377 ns |  3.36 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 15.6598 ns | 0.0567 ns | 0.0503 ns |  3.55 |         - | 
| LockAsync · AsyncLock · RefImpl               | 17.5496 ns | 0.0366 ns | 0.0342 ns |  3.98 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 18.3981 ns | 0.0886 ns | 0.0829 ns |  4.17 |         - | 
| LockAsync · AsyncLock · DotNext               | 19.7086 ns | 0.0798 ns | 0.0707 ns |  4.47 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 43.8696 ns | 0.1551 ns | 0.1451 ns |  9.95 |     312 B | 
| LockAsync · SyncLock · SpinOnce               | 48.9182 ns | 0.0838 ns | 0.0784 ns | 11.09 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 64.5946 ns | 0.2210 ns | 0.1960 ns | 14.65 |     208 B |