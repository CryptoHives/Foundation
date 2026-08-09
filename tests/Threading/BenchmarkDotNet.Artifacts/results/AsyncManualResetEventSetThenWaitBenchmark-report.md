```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                         | Mean      | Ratio | Allocated | 
|---------------------------------------------------- |----------:|------:|----------:|
| SetThenWait · AsyncManualReset · ProtoPromise       |  5.777 ns |  0.62 |         - | 
| SetThenWait · AsyncManualReset · Pooled (ValueTask) |  9.259 ns |  1.00 |         - | 
| SetThenWait · AsyncManualReset · Pooled (AsTask)    |  9.311 ns |  1.01 |         - | 
| SetThenWait · AsyncManualReset · RefImpl            | 13.812 ns |  1.49 |      96 B | 
| SetThenWait · AsyncManualReset · Nito.AsyncEx       | 28.247 ns |  3.05 |      96 B | 
