| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Baseline · Increment               |  0.0019 ns | 0.000 |         - | 
| Lock · Interlocked · Interlocked          |  0.1777 ns | 0.014 |         - | 
| Lock · Lock · Lock.EnterScope             |  3.1339 ns | 0.254 |         - | 
| Lock · Lock · System.Lock                 |  3.2885 ns | 0.267 |         - | 
| Lock · Monitor · Monitor                  |  3.8157 ns | 0.310 |         - | 
| LockAsync · AsyncLock · Pooled            | 12.3146 ns | 1.000 |         - | 
| LockAsync · SemaphoreSlim · SemaphoreSlim | 17.4659 ns | 1.418 |         - | 
| LockAsync · AsyncLock · RefImpl           | 18.7052 ns | 1.519 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 21.2222 ns | 1.723 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 36.8141 ns | 2.990 |     320 B | 
| LockAsync · AsyncLock · NeoSmart          | 56.8822 ns | 4.619 |     208 B |