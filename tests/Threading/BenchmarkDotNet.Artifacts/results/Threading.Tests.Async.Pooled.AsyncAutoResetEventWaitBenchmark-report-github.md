```

BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
cancellationToken=Syste(...)Token [34]  

```
| Method                                      | ct    | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |----------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventTaskWaitAsync     | None  |  24.84 ns |  1.00 |      96 B |        1.00 |
| PooledAsyncAutoResetEventTaskWaitAsync      | None  |  25.40 ns |  1.02 |         - |        0.00 |
| NitoAsyncAutoResetEventTaskWaitAsync        | None  |  31.20 ns |  1.26 |     160 B |        1.67 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | None  |  31.64 ns |  1.27 |         - |        0.00 |
|                                             |       |           |       |           |             |
| PooledAsyncAutoResetEventTaskWaitAsync      | Token |  49.35 ns |     ? |      64 B |           ? |
| PooledAsyncAutoResetEventValueTaskWaitAsync | Token |  49.83 ns |     ? |      64 B |           ? |
| NitoAsyncAutoResetEventTaskWaitAsync        | Token | 336.10 ns |     ? |     400 B |           ? |
