```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                        | ParticipantCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------- |----------------- |------------:|------:|----------:|
| PostPhase · AsyncBarrier · Pooled (no action)      | 1                |    14.35 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 1                |    39.66 ns |  2.76 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 1                |   426.61 ns | 29.72 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 1                |   873.20 ns | 60.84 |     240 B | 
|                                                    |                  |             |       |           | 
| PostPhase · AsyncBarrier · Pooled (empty action)   | 10               |   349.19 ns |  0.95 |         - | 
| PostPhase · AsyncBarrier · Pooled (no action)      | 10               |   367.12 ns |  1.00 |         - | 
| PostPhase · AsyncBarrier · Pooled (working action) | 10               |   702.77 ns |  1.91 |         - | 
| PostPhase · AsyncBarrier · Barrier                 | 10               | 8,583.75 ns | 23.38 |    1395 B | 
