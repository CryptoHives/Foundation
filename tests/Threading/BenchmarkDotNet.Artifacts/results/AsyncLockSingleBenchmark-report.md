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
| LockAsync · SyncLock · Increment              |  0.0098 ns | 0.002 |         - | 
| LockAsync · SyncLock · Interlocked.Add        |  0.1931 ns | 0.030 |         - | 
| LockAsync · SyncLock · Interlocked.Inc        |  0.1938 ns | 0.030 |         - | 
| LockAsync · SyncLock · Interlocked.Exchange   |  0.5059 ns | 0.078 |         - | 
| LockAsync · SyncLock · Interlocked.CmpX       |  0.8560 ns | 0.132 |         - | 
| LockAsync · SyncLock · Lock                   |  3.1610 ns | 0.486 |         - | 
| LockAsync · SyncLock · Lock.EnterScope        |  3.1672 ns | 0.487 |         - | 
| LockAsync · SyncLock · SpinLock (CryptoHives) |  3.5154 ns | 0.541 |         - | 
| LockAsync · SyncLock · lock()                 |  3.9141 ns | 0.602 |         - | 
| LockAsync · AsyncLock · Pooled                |  6.5025 ns | 1.000 |         - | 
| LockAsync · AsyncLock · ProtoPromise          |  7.3492 ns | 1.130 |         - | 
| LockAsync · AsyncLock · VS.Threading          | 16.3098 ns | 2.508 |         - | 
| LockAsync · AsyncLock · SemaphoreSlim         | 17.0451 ns | 2.621 |         - | 
| LockAsync · AsyncLock · RefImpl               | 18.0114 ns | 2.770 |         - | 
| LockAsync · AsyncLock · NonKeyed              | 20.3227 ns | 3.126 |         - | 
| LockAsync · AsyncLock · Nito.AsyncEx          | 37.9984 ns | 5.844 |     320 B | 
| LockAsync · SyncLock · SpinOnce               | 41.5706 ns | 6.393 |         - | 
| LockAsync · SyncLock · SpinLock               | 45.2113 ns | 6.953 |         - | 
| LockAsync · AsyncLock · NeoSmart              | 57.1906 ns | 8.796 |     208 B | 
