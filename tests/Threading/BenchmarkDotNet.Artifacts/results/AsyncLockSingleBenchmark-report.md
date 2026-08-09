```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                   | Mean       | Ratio | Allocated | 
|---------------------------------------------- |-----------:|------:|----------:|
| LockAsync · SyncLock · Increment              |  0.0032 ns | 0.000 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.1885 ns | 0.027 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.2143 ns | 0.031 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |  0.5189 ns | 0.075 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  0.6732 ns | 0.097 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  0.8655 ns | 0.124 |         - | 
| LockAsync · SyncLock · SpinLock               |  2.3236 ns | 0.334 |         - | 
| LockAsync · SyncLock · Lock                   |  3.2182 ns | 0.463 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  3.2570 ns | 0.468 |         - | 
| LockAsync · SyncLock · lock()                 |  4.0023 ns | 0.576 |         - | 
| LockAsync · AsyncLock · Pooled                |  6.9543 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  9.4512 ns | 1.359 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 16.5711 ns | 2.383 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 17.3477 ns | 2.495 |         - | 
| LockAsync · AsyncLock · RefImpl               | 19.4911 ns | 2.803 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 20.5711 ns | 2.958 |         - | 
| LockAsync · SyncLock · SpinOnce               | 41.9135 ns | 6.027 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 43.2724 ns | 6.223 |     320 B | 
| LockAsync · AsyncLock · NeoSmart              | 59.0656 ns | 8.494 |     208 B | 
