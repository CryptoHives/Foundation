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
| SetReset · AsyncManualReset · ProtoPromise         |   1.425 ns |   0.69 |         - | 
| SetReset · AsyncManualReset · Pooled               |   2.054 ns |   1.00 |         - | 
| SetReset · AsyncManualReset · ManualResetEventSlim |   5.591 ns |   2.72 |         - | 
| SetReset · AsyncManualReset · RefImpl              |  10.063 ns |   4.90 |      96 B | 
| SetReset · AsyncManualReset · Nito.AsyncEx         |  17.257 ns |   8.40 |      96 B | 
| SetReset · AsyncManualReset · ManualResetEvent     | 428.312 ns | 208.57 |         - | 
