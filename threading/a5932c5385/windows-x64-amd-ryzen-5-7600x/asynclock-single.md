| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Increment · System                 |  0.0057 ns | 0.001 |         - | 
| Lock · Interlocked.Inc · System           |  0.1969 ns | 0.022 |         - | 
| Lock · Interlocked.Add · System           |  0.2077 ns | 0.023 |         - | 
| Lock · Interlocked.Exchange · System      |  0.5198 ns | 0.059 |         - | 
| Lock · Interlocked.CmpX · System          |  0.8646 ns | 0.098 |         - | 
| Lock · Lock · System                      |  3.2511 ns | 0.367 |         - | 
| Lock · Lock.EnterScope · System           |  3.2787 ns | 0.370 |         - | 
| SpinLock · SpinLock · CryptoHives         |  3.5416 ns | 0.400 |         - | 
| Lock · lock() · System                    |  4.0188 ns | 0.454 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  7.6080 ns | 0.859 |         - | 
| LockAsync · AsyncLock · Pooled            |  8.8620 ns | 1.000 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 16.5497 ns | 1.868 |         - | 
| LockAsync · SemaphoreSlim · System        | 17.1878 ns | 1.940 |         - | 
| LockAsync · AsyncLock · RefImpl           | 18.3916 ns | 2.076 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 20.6801 ns | 2.334 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 39.5383 ns | 4.463 |     320 B | 
| SpinWait · SpinOnce · System              | 42.1165 ns | 4.754 |         - | 
| SpinLock · SpinLock · System              | 45.8585 ns | 5.176 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 62.5712 ns | 7.063 |     208 B |