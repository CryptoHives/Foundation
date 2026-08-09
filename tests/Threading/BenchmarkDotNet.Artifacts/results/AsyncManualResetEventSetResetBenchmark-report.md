```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                        | Mean       | Ratio  | Allocated | 
|--------------------------------------------------- |-----------:|-------:|----------:|
| SetReset · AsyncManualReset · ProtoPromise         |   1.468 ns |   0.71 |         - | 
| SetReset · AsyncManualReset · Pooled               |   2.061 ns |   1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   5.565 ns |   2.70 |         - | 
| SetReset · AsyncManualReset · RefImpl              |  10.158 ns |   4.93 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  17.146 ns |   8.32 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 431.857 ns | 209.59 |         - | 
