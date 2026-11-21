| Description                                   | Mean       | Error     | StdDev    | Ratio | Allocated | 
|---------------------------------------------- |-----------:|----------:|----------:|------:|----------:|
| LockAsync · SyncLock · Interlocked.Exchange   |  0.8472 ns | 0.0037 ns | 0.0033 ns |  0.24 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  1.6458 ns | 0.0026 ns | 0.0024 ns |  0.47 |         - | 
| LockAsync · SyncLock · Increment              |  1.6612 ns | 0.0053 ns | 0.0049 ns |  0.47 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  1.6624 ns | 0.0037 ns | 0.0031 ns |  0.47 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  1.7846 ns | 0.0091 ns | 0.0085 ns |  0.51 |         - | 
| LockAsync · AsyncLock · Pooled                |  3.5154 ns | 0.0099 ns | 0.0093 ns |  1.00 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  3.6888 ns | 0.0101 ns | 0.0095 ns |  1.05 |         - | 
| LockAsync · SyncLock · Lock                   |  3.7751 ns | 0.0299 ns | 0.0280 ns |  1.07 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  3.7802 ns | 0.0623 ns | 0.0583 ns |  1.08 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  4.1844 ns | 0.0210 ns | 0.0197 ns |  1.19 |         - | 
| LockAsync · SyncLock · lock()                 |  5.6466 ns | 0.0118 ns | 0.0110 ns |  1.61 |         - | 
| LockAsync · SyncLock · SpinLock               |  7.1780 ns | 0.0088 ns | 0.0083 ns |  2.04 |         - | 
| LockAsync · AsyncLock · DotNext               | 12.3784 ns | 0.0298 ns | 0.0279 ns |  3.52 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 12.5616 ns | 0.0272 ns | 0.0254 ns |  3.57 |         - | 
| LockAsync · AsyncLock · RefImpl               | 12.9063 ns | 0.0523 ns | 0.0489 ns |  3.67 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 13.2127 ns | 0.0125 ns | 0.0117 ns |  3.76 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 15.0416 ns | 0.0595 ns | 0.0556 ns |  4.28 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 42.3435 ns | 0.0727 ns | 0.0607 ns | 12.05 |     312 B | 
| LockAsync · SyncLock · SpinOnce               | 46.4854 ns | 0.1416 ns | 0.1183 ns | 13.22 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 55.3068 ns | 0.2098 ns | 0.1963 ns | 15.73 |     208 B |