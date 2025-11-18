```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4
  .NET 9.0 : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

Job=.NET 9.0  Runtime=.NET 9.0  Toolchain=net9.0  

```
| Method                                      | Mean     | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |---------:|------:|----------:|------------:|
| NitoAsyncAutoResetEventTaskWaitAsync        | 47.69 ns |  1.46 |     160 B |        1.67 |
| PooledAsyncAutoResetEventTaskWaitAsync      | 29.70 ns |  0.91 |         - |        0.00 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | 29.26 ns |  0.90 |         - |        0.00 |
| RefImplAsyncAutoResetEventTaskWaitAsync     | 32.62 ns |  1.00 |      96 B |        1.00 |
