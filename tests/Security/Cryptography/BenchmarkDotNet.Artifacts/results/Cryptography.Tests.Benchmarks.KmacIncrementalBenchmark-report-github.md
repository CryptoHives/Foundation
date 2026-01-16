```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7623/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                             | Mean      | Error     | StdDev    | Min       | Max       | Median    | Gen0   | Allocated |
|----------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| &#39;KMAC128 CryptoHives Incremental&#39;  |  6.041 μs | 0.0512 μs | 0.0479 μs |  5.983 μs |  6.130 μs |  6.041 μs | 0.3128 |   2.62 KB |
| &#39;KMAC128 BouncyCastle Incremental&#39; |  9.623 μs | 0.0446 μs | 0.0372 μs |  9.534 μs |  9.660 μs |  9.633 μs | 0.1526 |   1.37 KB |
| &#39;KMAC256 CryptoHives Incremental&#39;  |  7.189 μs | 0.0413 μs | 0.0366 μs |  7.122 μs |  7.261 μs |  7.194 μs | 0.3052 |   2.55 KB |
| &#39;KMAC256 BouncyCastle Incremental&#39; | 11.213 μs | 0.0848 μs | 0.0793 μs | 11.134 μs | 11.366 μs | 11.179 μs | 0.1678 |    1.4 KB |
