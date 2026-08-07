```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                          | ParticipantCount | Mean      | Ratio | Allocated | 
|----------------------------------------------------- |----------------- |----------:|------:|----------:|
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |  6.790 ns |  0.89 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |  7.590 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |  7.592 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                | 16.344 ns |  2.15 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                | 20.672 ns |  2.72 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                | 47.804 ns |  6.30 |         - | 
|                                                      |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               | 17.219 ns |  0.75 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               | 20.474 ns |  0.89 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               | 22.925 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               | 28.643 ns |  1.25 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               | 28.938 ns |  1.26 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               | 62.884 ns |  2.74 |         - | 
