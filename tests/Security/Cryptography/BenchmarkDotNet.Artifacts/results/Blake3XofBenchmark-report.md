```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9168/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4

Method=AbsorbSqueeze  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                  | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.789 μs |  0.0342 μs |  0.0320 μs |  10,510 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.905 μs |  0.0372 μs |  0.0457 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     2.215 μs |  0.0442 μs |  0.0620 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     2.234 μs |  0.0377 μs |  0.0352 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     2.249 μs |  0.0445 μs |  0.0594 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.360 μs |  0.0466 μs |  0.0697 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     3.014 μs |  0.0503 μs |  0.0470 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    21.430 μs |  0.3895 μs |  0.3643 μs |  28,670 B |      56 B |
|                                              |              |              |            |            |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     1.859 μs |  0.0361 μs |  0.0354 μs |  16,602 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.423 μs |  0.0467 μs |  0.0607 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.450 μs |  0.0467 μs |  0.0591 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.615 μs |  0.0511 μs |  0.0716 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     3.015 μs |  0.0601 μs |  0.0738 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     3.193 μs |  0.0628 μs |  0.0816 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     4.197 μs |  0.0399 μs |  0.0373 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    30.633 μs |  0.5790 μs |  0.5416 μs |  28,880 B |      56 B |
|                                              |              |              |            |            |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     3.445 μs |  0.0682 μs |  0.0978 μs |  16,845 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.864 μs |  0.0717 μs |  0.0635 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.880 μs |  0.0776 μs |  0.0923 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     8.084 μs |  0.1562 μs |  0.1918 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     9.145 μs |  0.1822 μs |  0.2025 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     9.247 μs |  0.1813 μs |  0.2420 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    11.904 μs |  0.1437 μs |  0.1344 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   108.846 μs |  1.8862 μs |  1.7644 μs |  28,638 B |      56 B |
|                                              |              |              |            |            |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    25.913 μs |  0.5158 μs |  0.6334 μs |  16,845 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    29.191 μs |  0.5713 μs |  0.7017 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    33.615 μs |  0.6704 μs |  1.1742 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |   102.021 μs |  2.0310 μs |  2.9771 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |   112.492 μs |  2.1793 μs |  3.1255 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |   114.353 μs |  2.2756 μs |  2.3369 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   146.364 μs |  2.2009 μs |  2.0587 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,466.126 μs | 22.9626 μs | 21.4792 μs |  28,652 B |      56 B |
