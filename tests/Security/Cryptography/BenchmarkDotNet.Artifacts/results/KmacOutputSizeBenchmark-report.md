```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description            | OutputSize | Mean     | Error     | StdDev    | Min      | Max      | Median   | Gen0   | Allocated |
|----------------------- |----------- |---------:|----------:|----------:|---------:|---------:|---------:|-------:|----------:|
| &#39;KMAC128 CryptoHives&#39;  | 16         | 4.724 μs | 0.0224 μs | 0.0199 μs | 4.701 μs | 4.763 μs | 4.722 μs | 0.4883 |   2.01 KB |
| &#39;KMAC128 CryptoHives&#39;  | 32         | 4.740 μs | 0.0222 μs | 0.0208 μs | 4.713 μs | 4.779 μs | 4.735 μs | 0.4959 |   2.04 KB |
| &#39;KMAC128 CryptoHives&#39;  | 64         | 4.788 μs | 0.0155 μs | 0.0137 μs | 4.767 μs | 4.811 μs | 4.786 μs | 0.5112 |    2.1 KB |
| &#39;KMAC256 CryptoHives&#39;  | 16         | 4.911 μs | 0.0182 μs | 0.0162 μs | 4.882 μs | 4.942 μs | 4.910 μs | 0.4501 |   1.85 KB |
| &#39;KMAC128 CryptoHives&#39;  | 128        | 4.918 μs | 0.0125 μs | 0.0097 μs | 4.902 μs | 4.933 μs | 4.920 μs | 0.5417 |   2.23 KB |
| &#39;KMAC256 CryptoHives&#39;  | 32         | 4.937 μs | 0.0193 μs | 0.0181 μs | 4.918 μs | 4.967 μs | 4.932 μs | 0.4578 |   1.88 KB |
| &#39;KMAC256 CryptoHives&#39;  | 64         | 5.007 μs | 0.0875 μs | 0.0731 μs | 4.953 μs | 5.185 μs | 4.969 μs | 0.4730 |   1.95 KB |
| &#39;KMAC256 CryptoHives&#39;  | 128        | 5.101 μs | 0.0208 μs | 0.0184 μs | 5.080 μs | 5.140 μs | 5.097 μs | 0.5035 |   2.07 KB |
| &#39;KMAC128 BouncyCastle&#39; | 32         | 7.060 μs | 0.0252 μs | 0.0224 μs | 7.025 μs | 7.104 μs | 7.060 μs | 0.3281 |   1.37 KB |
| &#39;KMAC128 BouncyCastle&#39; | 64         | 7.067 μs | 0.0267 μs | 0.0250 μs | 7.024 μs | 7.111 μs | 7.066 μs | 0.3357 |    1.4 KB |
| &#39;KMAC128 BouncyCastle&#39; | 16         | 7.098 μs | 0.0244 μs | 0.0216 μs | 7.066 μs | 7.150 μs | 7.092 μs | 0.3433 |   1.41 KB |
| &#39;KMAC128 BouncyCastle&#39; | 128        | 7.103 μs | 0.0254 μs | 0.0212 μs | 7.068 μs | 7.145 μs | 7.097 μs | 0.3510 |   1.46 KB |
| &#39;KMAC256 BouncyCastle&#39; | 128        | 7.498 μs | 0.0324 μs | 0.0270 μs | 7.456 μs | 7.540 μs | 7.493 μs | 0.3510 |   1.46 KB |
| &#39;KMAC256 BouncyCastle&#39; | 32         | 7.509 μs | 0.0316 μs | 0.0280 μs | 7.457 μs | 7.556 μs | 7.515 μs | 0.3510 |   1.45 KB |
| &#39;KMAC256 BouncyCastle&#39; | 64         | 7.516 μs | 0.0226 μs | 0.0189 μs | 7.487 μs | 7.551 μs | 7.521 μs | 0.3357 |    1.4 KB |
| &#39;KMAC256 BouncyCastle&#39; | 16         | 7.517 μs | 0.0187 μs | 0.0165 μs | 7.478 μs | 7.548 μs | 7.519 μs | 0.3510 |   1.44 KB |
| &#39;KMAC128 .NET&#39;         | 16         |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC128 .NET&#39;         | 32         |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC128 .NET&#39;         | 64         |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC128 .NET&#39;         | 128        |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC256 .NET&#39;         | 16         |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC256 .NET&#39;         | 32         |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC256 .NET&#39;         | 64         |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |
| &#39;KMAC256 .NET&#39;         | 128        |       NA |        NA |        NA |       NA |       NA |       NA |     NA |        NA |

Benchmarks with issues:
  KmacOutputSizeBenchmark.'KMAC128 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=16]
  KmacOutputSizeBenchmark.'KMAC128 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=32]
  KmacOutputSizeBenchmark.'KMAC128 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=64]
  KmacOutputSizeBenchmark.'KMAC128 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=128]
  KmacOutputSizeBenchmark.'KMAC256 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=16]
  KmacOutputSizeBenchmark.'KMAC256 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=32]
  KmacOutputSizeBenchmark.'KMAC256 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=64]
  KmacOutputSizeBenchmark.'KMAC256 .NET': .NET 10.0(Runtime=.NET 10.0, Toolchain=net10.0) [OutputSize=128]
