```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description          | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|--------------------- |------------- |-----------:|----------:|----------:|----------:|
| Kmac128_BouncyCastle | 128B         |   2.142 μs | 0.0141 μs | 0.0117 μs |     160 B |
| Kmac128_CryptoHives  | 128B         |   2.401 μs | 0.0121 μs | 0.0113 μs |    2088 B |
| Kmac128_DotNet       | 128B         |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac128_BouncyCastle | 137B         |   2.144 μs | 0.0090 μs | 0.0085 μs |     160 B |
| Kmac128_CryptoHives  | 137B         |   2.392 μs | 0.0157 μs | 0.0139 μs |    2088 B |
| Kmac128_DotNet       | 137B         |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac128_CryptoHives  | 1KB          |   4.748 μs | 0.0149 μs | 0.0124 μs |    2088 B |
| Kmac128_BouncyCastle | 1KB          |   5.096 μs | 0.0162 μs | 0.0135 μs |     160 B |
| Kmac128_DotNet       | 1KB          |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac128_CryptoHives  | 1025B        |   4.753 μs | 0.0305 μs | 0.0270 μs |    2088 B |
| Kmac128_BouncyCastle | 1025B        |   5.102 μs | 0.0248 μs | 0.0220 μs |     160 B |
| Kmac128_DotNet       | 1025B        |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac128_CryptoHives  | 8KB          |  19.358 μs | 0.0587 μs | 0.0490 μs |    2088 B |
| Kmac128_BouncyCastle | 8KB          |  25.632 μs | 0.0520 μs | 0.0406 μs |     160 B |
| Kmac128_DotNet       | 8KB          |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac128_CryptoHives  | 128KB        | 275.698 μs | 0.6917 μs | 0.5776 μs |    2088 B |
| Kmac128_BouncyCastle | 128KB        | 379.076 μs | 1.0828 μs | 0.9599 μs |     160 B |
| Kmac128_DotNet       | 128KB        |         NA |        NA |        NA |        NA |

Benchmarks with issues:
  Kmac128Benchmark.Kmac128_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=128B]
  Kmac128Benchmark.Kmac128_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=137B]
  Kmac128Benchmark.Kmac128_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=1KB]
  Kmac128Benchmark.Kmac128_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=1025B]
  Kmac128Benchmark.Kmac128_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=8KB]
  Kmac128Benchmark.Kmac128_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=128KB]
