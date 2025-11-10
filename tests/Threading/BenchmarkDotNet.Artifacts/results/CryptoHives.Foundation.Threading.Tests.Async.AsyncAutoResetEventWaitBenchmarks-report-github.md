```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  .NET 8.0 : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

Job=.NET 8.0  Runtime=.NET 8.0  Toolchain=net8.0  

```
| Method                                  | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|---------------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| NitoAsyncAutoResetEventTaskWaitAsync    | 52.05 ns | 0.803 ns | 0.671 ns |  1.44 |    0.03 | 0.0191 | 0.0001 |     160 B |        1.67 |
| PooledAsyncAutoResetEventTaskWaitAsync  | 48.77 ns | 0.965 ns | 0.855 ns |  1.35 |    0.03 | 0.0095 |      - |      80 B |        0.83 |
| PooledAsyncAutoResetEventValueTaskWait  | 23.33 ns | 0.167 ns | 0.140 ns |  0.64 |    0.01 |      - |      - |         - |        0.00 |
| RefImplAsyncAutoResetEventTaskWaitAsync | 36.24 ns | 0.707 ns | 0.695 ns |  1.00 |    0.03 | 0.0114 |      - |      96 B |        1.00 |
