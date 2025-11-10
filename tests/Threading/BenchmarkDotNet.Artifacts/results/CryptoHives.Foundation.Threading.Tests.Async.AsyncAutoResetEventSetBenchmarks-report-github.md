```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  .NET 8.0 : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

Job=.NET 8.0  Runtime=.NET 8.0  Toolchain=net8.0  

```
| Method                        | Mean       | Error     | StdDev     | Median     | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |-----------:|----------:|-----------:|-----------:|------:|--------:|----------:|------------:|
| NitoAsyncAutoResetEventSet    |   5.773 ns | 0.0500 ns |  0.0467 ns |   5.758 ns |  1.02 |    0.01 |         - |          NA |
| PooledAsyncAutoResetEventSet  |   5.890 ns | 0.0274 ns |  0.0229 ns |   5.893 ns |  1.04 |    0.00 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   5.658 ns | 0.0164 ns |  0.0145 ns |   5.654 ns |  1.00 |    0.00 |         - |          NA |
| AutoResetEventSet             | 247.801 ns | 5.8377 ns | 17.2125 ns | 237.331 ns | 43.79 |    3.03 |         - |          NA |
