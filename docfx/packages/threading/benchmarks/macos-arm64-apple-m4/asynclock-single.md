| Description                               | Mean       | Ratio | Allocated | 
|------------------------------------------ |-----------:|------:|----------:|
| Lock · Interlocked.Exchange · System      |  0.0000 ns | 0.000 |         - | 
| Lock · Increment · System                 |  0.4337 ns | 0.063 |         - | 
| Lock · Interlocked.Add · System           |  0.4578 ns | 0.067 |         - | 
| Lock · Interlocked.Inc · System           |  0.4582 ns | 0.067 |         - | 
| Lock · Lock · System                      |  1.8203 ns | 0.266 |         - | 
| Lock · Lock.EnterScope · System           |  1.9060 ns | 0.279 |         - | 
| Lock · Interlocked.CmpX · System          |  2.4064 ns | 0.352 |         - | 
| SpinLock · SpinLock · CryptoHives         |  2.6685 ns | 0.390 |         - | 
| Lock · lock() · System                    |  3.0731 ns | 0.449 |         - | 
| LockAsync · AsyncLock · ProtoPromise      |  6.6047 ns | 0.966 |         - | 
| LockAsync · AsyncLock · Pooled            |  6.8407 ns | 1.001 |         - | 
| LockAsync · AsyncLock · RefImpl           | 11.7539 ns | 1.719 |         - | 
| LockAsync · AsyncSemaphore · VS.Threading | 11.8426 ns | 1.732 |         - | 
| LockAsync · SemaphoreSlim · System        | 12.2578 ns | 1.793 |         - | 
| LockAsync · AsyncLock · NonKeyed          | 16.0874 ns | 2.353 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx      | 40.7130 ns | 5.955 |     320 B | 
| SpinLock · SpinLock · System              | 45.9162 ns | 6.716 |         - | 
| SpinWait · SpinOnce · System              | 48.7972 ns | 7.137 |         - | 
| LockAsync · AsyncLock · NeoSmart          | 49.6744 ns | 7.266 |     208 B |