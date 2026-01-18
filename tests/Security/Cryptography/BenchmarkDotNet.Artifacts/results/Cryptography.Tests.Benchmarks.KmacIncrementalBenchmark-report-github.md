```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.4770/24H2/2024Update/HudsonValley)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                             | Mean      | Error     | StdDev    | Min       | Max       | Median    | Gen0   | Allocated |
|----------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| &#39;KMAC128 CryptoHives Incremental&#39;  |  5.805 μs | 0.0209 μs | 0.0175 μs |  5.781 μs |  5.842 μs |  5.806 μs | 0.1526 |   2.62 KB |
| &#39;KMAC128 BouncyCastle Incremental&#39; |  9.287 μs | 0.0619 μs | 0.0549 μs |  9.219 μs |  9.414 μs |  9.276 μs | 0.0763 |   1.37 KB |
| &#39;KMAC256 CryptoHives Incremental&#39;  |  6.769 μs | 0.0152 μs | 0.0127 μs |  6.749 μs |  6.788 μs |  6.772 μs | 0.1526 |   2.55 KB |
| &#39;KMAC256 BouncyCastle Incremental&#39; | 10.770 μs | 0.1303 μs | 0.1088 μs | 10.652 μs | 11.052 μs | 10.754 μs | 0.0763 |    1.4 KB |
