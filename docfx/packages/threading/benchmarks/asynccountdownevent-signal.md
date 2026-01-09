```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                              | ParticipantCount | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------------ |----------------- |-----------:|------:|----------:|------------:|
| SignalAndWaitCountdownEventStandard | 1                |   7.818 ns |  0.40 |         - |          NA |
| SignalAndWaitRefImplAsync           | 1                |  19.262 ns |  0.98 |      96 B |          NA |
| SignalAndWaitPooledAsync            | 1                |  19.577 ns |  1.00 |         - |          NA |
| WaitAndSignalPooledAsync            | 1                |  59.275 ns |  3.03 |         - |          NA |
|                                     |                  |            |       |           |             |
| SignalAndWaitCountdownEventStandard | 10               |  22.099 ns |  0.31 |         - |          NA |
| SignalAndWaitRefImplAsync           | 10               |  32.415 ns |  0.46 |      96 B |          NA |
| SignalAndWaitPooledAsync            | 10               |  70.547 ns |  1.00 |         - |          NA |
| WaitAndSignalPooledAsync            | 10               | 111.704 ns |  1.58 |         - |          NA |
