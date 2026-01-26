```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                        | Mean     | Error    | StdDev   | Min      | Max      | Median   | Gen0   | Allocated |
|----------------------------------- |---------:|---------:|---------:|---------:|---------:|---------:|-------:|----------:|
| &#39;KMAC128 CryptoHives Incremental&#39;  | 10.22 μs | 0.021 μs | 0.018 μs | 10.19 μs | 10.25 μs | 10.22 μs | 0.6256 |   2.62 KB |
| &#39;KMAC256 CryptoHives Incremental&#39;  | 11.92 μs | 0.058 μs | 0.054 μs | 11.86 μs | 12.02 μs | 11.90 μs | 0.6104 |   2.55 KB |
| &#39;KMAC128 BouncyCastle Incremental&#39; | 14.61 μs | 0.043 μs | 0.040 μs | 14.54 μs | 14.68 μs | 14.63 μs | 0.3204 |   1.37 KB |
| &#39;KMAC256 BouncyCastle Incremental&#39; | 16.88 μs | 0.072 μs | 0.068 μs | 16.77 μs | 17.01 μs | 16.88 μs | 0.3357 |    1.4 KB |
