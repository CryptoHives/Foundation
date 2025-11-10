```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  .NET 8.0 : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

Job=.NET 8.0  Runtime=.NET 8.0  Toolchain=net8.0  

```
| Method                            | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|---------------------------------- |---------:|---------:|---------:|------:|----------:|------------:|
| NitoAsyncAutoResetEventSetWait    | 17.53 ns | 0.053 ns | 0.047 ns |  0.95 |         - |          NA |
| PooledAsyncAutoResetEventSetWait  | 15.56 ns | 0.115 ns | 0.107 ns |  0.84 |         - |          NA |
| RefImplAsyncAutoResetEventSetWait | 18.55 ns | 0.079 ns | 0.074 ns |  1.00 |         - |          NA |
