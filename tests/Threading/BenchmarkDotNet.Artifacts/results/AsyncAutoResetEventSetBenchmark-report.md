```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                           | Mean        | Ratio  | Allocated | 
|-------------------------------------- |------------:|-------:|----------:|
| Set · AsyncAutoReset · ProtoPromise   |   0.5917 ns |   0.77 |         - | 
| Set · AsyncAutoReset · Pooled         |   0.7726 ns |   1.00 |         - | 
| Set · AsyncAutoReset · RefImpl        |   4.3108 ns |   5.58 |         - | 
| Set · AsyncAutoReset · Nito.AsyncEx   |   4.3306 ns |   5.61 |         - | 
| Set · AsyncAutoReset · AutoResetEvent | 218.9571 ns | 283.59 |         - | 
