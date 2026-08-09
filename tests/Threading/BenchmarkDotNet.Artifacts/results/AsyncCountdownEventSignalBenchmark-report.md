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
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |  7.004 ns |  0.92 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |  7.638 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |  7.756 ns |  1.02 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                | 16.916 ns |  2.22 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                | 19.203 ns |  2.52 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                | 48.554 ns |  6.36 |         - | 
|                                                      |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               | 17.717 ns |  0.78 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               | 20.431 ns |  0.90 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               | 22.745 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               | 28.944 ns |  1.27 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               | 29.565 ns |  1.30 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               | 63.142 ns |  2.78 |         - | 
