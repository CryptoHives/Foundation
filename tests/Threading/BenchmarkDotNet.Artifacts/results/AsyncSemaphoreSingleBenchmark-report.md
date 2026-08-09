```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                  | Mean      | Ratio | Allocated | 
|--------------------------------------------- |----------:|------:|----------:|
| WaitRelease · AsyncSemaphore · ProtoPromise  |  6.607 ns |  0.74 |         - | 
| WaitRelease · AsyncSemaphore · Pooled        |  8.922 ns |  1.00 |         - | 
| WaitRelease · AsyncSemaphore · Nito.AsyncEx  | 14.957 ns |  1.68 |         - | 
| WaitRelease · AsyncSemaphore · SemaphoreSlim | 17.163 ns |  1.92 |         - | 
| WaitRelease · AsyncSemaphore · RefImpl       | 18.109 ns |  2.03 |         - | 
