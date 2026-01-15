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
| &#39;KMAC128 CryptoHives Incremental&#39;  |  6.059 μs | 0.1212 μs | 0.1075 μs |  5.969 μs |  6.287 μs |  6.014 μs | 0.3204 |   2.63 KB |
| &#39;KMAC128 BouncyCastle Incremental&#39; |  9.744 μs | 0.0996 μs | 0.0932 μs |  9.626 μs |  9.923 μs |  9.728 μs | 0.1526 |   1.37 KB |
| &#39;KMAC256 CryptoHives Incremental&#39;  |  7.152 μs | 0.1149 μs | 0.1075 μs |  7.045 μs |  7.361 μs |  7.101 μs | 0.3128 |   2.57 KB |
| &#39;KMAC256 BouncyCastle Incremental&#39; | 11.319 μs | 0.1363 μs | 0.1275 μs | 11.165 μs | 11.624 μs | 11.261 μs | 0.1678 |    1.4 KB |
