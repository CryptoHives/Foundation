```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9445/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4

Method=AbsorbSqueeze  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Median       | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.709 μs | 0.0053 μs | 0.0047 μs |     1.709 μs |  10,510 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.876 μs | 0.0134 μs | 0.0119 μs |     1.880 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     2.199 μs | 0.0039 μs | 0.0037 μs |     2.200 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     2.200 μs | 0.0036 μs | 0.0032 μs |     2.201 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     2.201 μs | 0.0028 μs | 0.0024 μs |     2.200 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.578 μs | 0.0144 μs | 0.0135 μs |     2.581 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.814 μs | 0.0144 μs | 0.0120 μs |     2.816 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    19.684 μs | 0.0886 μs | 0.0786 μs |    19.655 μs |  28,661 B |      56 B |
|                                              |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     1.813 μs | 0.0358 μs | 0.0335 μs |     1.805 μs |  16,602 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.363 μs | 0.0176 μs | 0.0164 μs |     2.368 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.363 μs | 0.0125 μs | 0.0111 μs |     2.364 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.549 μs | 0.0166 μs | 0.0139 μs |     2.553 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.957 μs | 0.0166 μs | 0.0156 μs |     2.961 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     3.238 μs | 0.0639 μs | 0.1568 μs |     3.290 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     3.736 μs | 0.0184 μs | 0.0163 μs |     3.735 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.109 μs | 0.1834 μs | 0.1432 μs |    29.103 μs |  28,885 B |      56 B |
|                                              |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     3.446 μs | 0.0082 μs | 0.0077 μs |     3.444 μs |  16,845 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.754 μs | 0.0363 μs | 0.0321 μs |     3.764 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.810 μs | 0.0074 μs | 0.0066 μs |     3.811 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     7.921 μs | 0.0109 μs | 0.0097 μs |     7.922 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     8.929 μs | 0.0148 μs | 0.0139 μs |     8.931 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     9.185 μs | 0.0121 μs | 0.0108 μs |     9.181 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    11.094 μs | 0.0278 μs | 0.0260 μs |    11.084 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   102.365 μs | 0.1788 μs | 0.1673 μs |   102.343 μs |  28,638 B |      56 B |
|                                              |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    25.144 μs | 0.0300 μs | 0.0266 μs |    25.148 μs |  16,845 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    27.936 μs | 0.0423 μs | 0.0395 μs |    27.933 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    31.009 μs | 0.0788 μs | 0.0737 μs |    31.026 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    99.870 μs | 0.2323 μs | 0.2173 μs |    99.905 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |   109.840 μs | 0.1110 μs | 0.0984 μs |   109.872 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |   111.465 μs | 0.2060 μs | 0.1927 μs |   111.509 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   137.417 μs | 0.3083 μs | 0.2733 μs |   137.297 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,435.841 μs | 3.0096 μs | 2.6680 μs | 1,434.672 μs |  28,642 B |      56 B |
