```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                       | Mean      | Ratio | Allocated | Alloc Ratio |
|----------------------------- |----------:|------:|----------:|------------:|
| ReadLockReaderWriterLockSlim |  6.181 ns |  0.35 |         - |          NA |
| ReaderLockRefImplAsync       | 16.246 ns |  0.92 |         - |          NA |
| ReaderLockPooledAsync        | 17.633 ns |  1.00 |         - |          NA |
| ReaderLockNitoAsync          | 41.139 ns |  2.33 |     320 B |          NA |
