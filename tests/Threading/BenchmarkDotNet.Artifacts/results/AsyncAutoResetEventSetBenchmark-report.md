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
| Set · AsyncAutoReset · ProtoPromise   |   0.5548 ns |   0.75 |         - | 
| Set · AsyncAutoReset · Pooled         |   0.7370 ns |   1.00 |         - | 
| Set · AsyncAutoReset · RefImpl        |   4.2014 ns |   5.70 |         - | 
| Set · AsyncAutoReset · Nito.AsyncEx   |   4.3196 ns |   5.86 |         - | 
| Set · AsyncAutoReset · AutoResetEvent | 216.5008 ns | 293.83 |         - | 
