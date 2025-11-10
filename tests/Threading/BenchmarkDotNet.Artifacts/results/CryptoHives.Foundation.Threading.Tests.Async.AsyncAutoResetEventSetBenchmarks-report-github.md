```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  .NET 8.0 : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

Job=.NET 8.0  Runtime=.NET 8.0  Toolchain=net8.0  

```
| Method                        | Mean       | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------------------------------ |-----------:|----------:|----------:|------:|--------:|----------:|------------:|
| NitoAsyncAutoResetEventSet    |   5.695 ns | 0.0230 ns | 0.0215 ns |  1.00 |    0.01 |         - |          NA |
| PooledAsyncAutoResetEventSet  |   5.777 ns | 0.0201 ns | 0.0188 ns |  1.02 |    0.01 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   5.667 ns | 0.0250 ns | 0.0222 ns |  1.00 |    0.01 |         - |          NA |
| AutoResetEventSet             | 231.564 ns | 1.4633 ns | 1.3688 ns | 40.86 |    0.28 |         - |          NA |
