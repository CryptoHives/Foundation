```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                       | ParticipantCount | Mean         | Ratio  | Allocated | Alloc Ratio |
|----------------------------- |----------------- |-------------:|-------:|----------:|------------:|
| SignalAndWaitPooledAsync     | 1                |     13.77 ns |   1.00 |         - |          NA |
| SignalAndWaitBarrierStandard | 1                |    432.83 ns |  31.43 |     240 B |          NA |
| SignalAndWaitRefImplAsync    | 1                |  1,080.51 ns |  78.46 |    8326 B |          NA |
|                              |                  |              |        |           |             |
| SignalAndWaitPooledAsync     | 10               |    369.64 ns |   1.00 |         - |          NA |
| SignalAndWaitRefImplAsync    | 10               |  1,692.36 ns |   4.58 |    9567 B |          NA |
| SignalAndWaitBarrierStandard | 10               | 62,427.62 ns | 168.89 |    1456 B |          NA |
