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
| Kmac256_BouncyCastle | 128B         |   2.127 μs | 0.0064 μs | 0.0054 μs |     160 B |
| Kmac256_CryptoHives  | 128B         |   2.383 μs | 0.0138 μs | 0.0122 μs |    1992 B |
| Kmac256_DotNet       | 128B         |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac256_BouncyCastle | 137B         |   2.566 μs | 0.0128 μs | 0.0114 μs |     160 B |
| Kmac256_CryptoHives  | 137B         |   2.964 μs | 0.0124 μs | 0.0110 μs |    1992 B |
| Kmac256_DotNet       | 137B         |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac256_CryptoHives  | 1KB          |   4.958 μs | 0.0184 μs | 0.0154 μs |    1992 B |
| Kmac256_BouncyCastle | 1KB          |   5.540 μs | 0.0154 μs | 0.0120 μs |     160 B |
| Kmac256_DotNet       | 1KB          |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac256_CryptoHives  | 1025B        |   4.970 μs | 0.0084 μs | 0.0066 μs |    1992 B |
| Kmac256_BouncyCastle | 1025B        |   5.583 μs | 0.0212 μs | 0.0198 μs |     160 B |
| Kmac256_DotNet       | 1025B        |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac256_CryptoHives  | 8KB          |  23.575 μs | 0.0841 μs | 0.0787 μs |    1992 B |
| Kmac256_BouncyCastle | 8KB          |  31.036 μs | 0.1271 μs | 0.1189 μs |     160 B |
| Kmac256_DotNet       | 8KB          |         NA |        NA |        NA |        NA |
|                      |              |            |           |           |           |
| Kmac256_CryptoHives  | 128KB        | 336.386 μs | 1.2903 μs | 1.2070 μs |    1992 B |
| Kmac256_BouncyCastle | 128KB        | 463.032 μs | 1.4375 μs | 1.2743 μs |     160 B |
| Kmac256_DotNet       | 128KB        |         NA |        NA |        NA |        NA |

Benchmarks with issues:
  Kmac256Benchmark.Kmac256_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=128B]
  Kmac256Benchmark.Kmac256_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=137B]
  Kmac256Benchmark.Kmac256_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=1KB]
  Kmac256Benchmark.Kmac256_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=1025B]
  Kmac256Benchmark.Kmac256_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=8KB]
  Kmac256Benchmark.Kmac256_DotNet: .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [TestDataSize=128KB]
