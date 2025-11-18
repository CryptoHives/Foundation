```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4
  .NET 9.0 : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

Job=.NET 9.0  Runtime=.NET 9.0  Toolchain=net9.0  

```
| Method                        | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------:|----------:|------------:|
| NitoAsyncAutoResetEventSet    |   5.972 ns |  1.01 |         - |          NA |
| PooledAsyncAutoResetEventSet  |   4.128 ns |  0.70 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   5.937 ns |  1.00 |         - |          NA |
| AutoResetEventSet             | 236.624 ns | 39.86 |         - |          NA |
