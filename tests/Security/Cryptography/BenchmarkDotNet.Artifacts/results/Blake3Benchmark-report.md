```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9445/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4

Method=TryComputeHash  Job=.NET 10.0  Affinity=010101010000  
Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                                         | TestDataSize | Mean              | Error          | StdDev         | Code Size | Allocated |
|---------------------------------------------------- |------------- |------------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4B           |          45.95 ns |       0.235 ns |       0.220 ns |   4,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4B           |          46.17 ns |       0.362 ns |       0.339 ns |   4,334 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4B           |          49.02 ns |       0.046 ns |       0.041 ns |   2,511 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4B           |          49.12 ns |       0.099 ns |       0.088 ns |   2,511 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4B           |          49.26 ns |       0.068 ns |       0.057 ns |   2,511 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4B           |          65.68 ns |       0.090 ns |       0.080 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4B           |          67.29 ns |       0.062 ns |       0.055 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4B           |         111.17 ns |       0.220 ns |       0.195 ns |   6,986 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4B           |         730.97 ns |       1.521 ns |       1.423 ns |  12,363 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100B         |          97.47 ns |       0.081 ns |       0.071 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100B         |          97.52 ns |       0.186 ns |       0.174 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100B         |         105.77 ns |       0.077 ns |       0.072 ns |   3,036 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100B         |         105.80 ns |       0.126 ns |       0.117 ns |   3,036 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100B         |         105.83 ns |       0.123 ns |       0.115 ns |   3,036 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100B         |         107.32 ns |       0.133 ns |       0.118 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100B         |         123.00 ns |       0.159 ns |       0.149 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100B         |         206.00 ns |       0.361 ns |       0.301 ns |   6,984 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100B         |       1,608.63 ns |       2.396 ns |       2.241 ns |  12,067 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128B         |          97.23 ns |       0.132 ns |       0.123 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128B         |          97.29 ns |       0.305 ns |       0.270 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128B         |         103.65 ns |       0.194 ns |       0.172 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128B         |         105.35 ns |       0.029 ns |       0.025 ns |   3,036 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128B         |         105.37 ns |       0.052 ns |       0.046 ns |   3,036 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128B         |         105.40 ns |       0.090 ns |       0.084 ns |   3,036 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128B         |         116.31 ns |       0.057 ns |       0.047 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128B         |         200.68 ns |       0.431 ns |       0.382 ns |   6,984 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128B         |       1,579.58 ns |       3.891 ns |       3.639 ns |  12,067 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 137B         |         152.65 ns |       0.224 ns |       0.210 ns |   4,837 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 137B         |         152.71 ns |       0.145 ns |       0.121 ns |   4,837 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 137B         |         164.48 ns |       0.306 ns |       0.272 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 137B         |         164.62 ns |       0.139 ns |       0.130 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 137B         |         164.64 ns |       0.112 ns |       0.099 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 137B         |         164.66 ns |       0.185 ns |       0.173 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 137B         |         179.94 ns |       0.158 ns |       0.140 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 137B         |         296.60 ns |       0.548 ns |       0.486 ns |   6,984 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 137B         |       2,292.95 ns |       5.080 ns |       4.752 ns |  12,063 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1000B        |         832.42 ns |       0.776 ns |       0.726 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1000B        |         840.86 ns |       0.227 ns |       0.190 ns |   4,837 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1000B        |         841.28 ns |       0.855 ns |       0.800 ns |   4,837 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1000B        |         908.04 ns |       0.895 ns |       0.837 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1000B        |         917.95 ns |       0.253 ns |       0.237 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1000B        |         919.22 ns |       0.280 ns |       0.249 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1000B        |         919.98 ns |       0.894 ns |       0.836 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1000B        |       1,473.69 ns |       4.057 ns |       3.596 ns |   6,984 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1000B        |      11,773.92 ns |       8.427 ns |       6.580 ns |  12,079 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1KB          |         832.84 ns |       0.238 ns |       0.186 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1KB          |         840.56 ns |       0.235 ns |       0.208 ns |   4,837 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1KB          |         841.19 ns |       0.850 ns |       0.795 ns |   4,837 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1KB          |         904.44 ns |       1.085 ns |       1.015 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1KB          |         918.67 ns |       0.250 ns |       0.209 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1KB          |         918.72 ns |       0.350 ns |       0.310 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1KB          |         919.19 ns |       0.847 ns |       0.751 ns |   3,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1KB          |       1,491.56 ns |      23.103 ns |      42.244 ns |   6,984 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1KB          |      11,373.73 ns |      15.846 ns |      14.822 ns |  12,047 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1025B        |         917.56 ns |       0.309 ns |       0.274 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1025B        |       1,008.09 ns |       0.491 ns |       0.460 ns |   5,671 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1025B        |       1,009.67 ns |       0.858 ns |       0.803 ns |   5,663 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1025B        |       1,053.81 ns |       0.391 ns |       0.366 ns |   4,687 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1025B        |       1,082.81 ns |       0.400 ns |       0.334 ns |   6,564 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1025B        |       1,095.53 ns |       0.410 ns |       0.384 ns |   6,562 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1025B        |       1,096.34 ns |       0.705 ns |       0.660 ns |   6,564 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1025B        |       1,702.96 ns |       4.537 ns |       4.244 ns |  13,933 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1025B        |      12,497.73 ns |      12.472 ns |      11.056 ns |  19,018 B |      56 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 2KB          |         858.73 ns |       0.191 ns |       0.149 ns |   6,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 2KB          |         859.49 ns |       0.732 ns |       0.685 ns |   6,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 2KB          |         862.76 ns |       0.281 ns |       0.263 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 2KB          |       1,003.04 ns |       0.139 ns |       0.123 ns |   6,128 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 2KB          |       1,016.45 ns |       0.415 ns |       0.388 ns |   6,128 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 2KB          |       1,920.98 ns |       0.768 ns |       0.719 ns |   4,685 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 2KB          |       1,963.53 ns |       0.681 ns |       0.604 ns |   6,580 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 2KB          |       3,070.23 ns |       7.170 ns |       6.707 ns |  13,951 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 2KB          |      22,654.77 ns |      29.295 ns |      25.969 ns |  18,921 B |      56 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4KB          |       1,084.88 ns |       0.356 ns |       0.315 ns |  12,295 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4KB          |       1,088.17 ns |       1.189 ns |       1.054 ns |  12,295 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4KB          |       1,128.84 ns |       1.453 ns |       1.359 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4KB          |       1,501.11 ns |       0.862 ns |       0.720 ns |  12,810 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4KB          |       1,517.40 ns |       2.547 ns |       2.382 ns |  12,810 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4KB          |       1,519.33 ns |       3.411 ns |       3.191 ns |  12,443 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4KB          |       3,870.52 ns |       0.361 ns |       0.282 ns |  11,551 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4KB          |       6,227.71 ns |       7.303 ns |       6.098 ns |  14,051 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4KB          |      45,201.09 ns |      76.841 ns |      71.877 ns |  18,919 B |     168 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 6KB          |       1,452.72 ns |       1.804 ns |       1.687 ns |  22,030 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 6KB          |       1,455.52 ns |       1.350 ns |       1.262 ns |  22,030 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 6KB          |       1,586.23 ns |       2.248 ns |       2.103 ns |  12,395 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 6KB          |       1,593.75 ns |       1.277 ns |       1.066 ns |  12,395 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 6KB          |       2,014.93 ns |       1.599 ns |       1.496 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 6KB          |       3,505.82 ns |       5.770 ns |       5.398 ns |  20,516 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 6KB          |       5,858.40 ns |       5.156 ns |       4.823 ns |  17,742 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 6KB          |       9,404.12 ns |      15.253 ns |      13.522 ns |  14,051 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 6KB          |      71,384.90 ns |     146.930 ns |     137.438 ns |  18,941 B |     280 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 8KB          |       1,287.81 ns |       0.565 ns |       0.528 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 8KB          |       1,496.56 ns |       1.115 ns |       1.043 ns |  21,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 8KB          |       1,505.11 ns |       1.306 ns |       1.158 ns |  21,820 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 8KB          |       1,583.41 ns |       1.889 ns |       1.767 ns |  12,726 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 8KB          |       1,659.22 ns |       1.055 ns |       0.936 ns |  11,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 8KB          |       1,694.92 ns |       1.990 ns |       1.862 ns |  11,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 8KB          |       3,043.17 ns |       6.420 ns |       6.005 ns |  19,255 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 8KB          |      12,495.85 ns |      18.742 ns |      15.651 ns |  14,057 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 8KB          |      94,365.34 ns |      99.456 ns |      93.031 ns |  18,941 B |     392 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 9216B        |       2,136.68 ns |       2.299 ns |       2.150 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 9216B        |       2,430.75 ns |       1.035 ns |       0.917 ns |  22,060 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 9216B        |       2,506.67 ns |       1.338 ns |       1.117 ns |  19,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 9216B        |       2,622.22 ns |       1.353 ns |       1.199 ns |  22,061 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 9216B        |       2,623.02 ns |       1.636 ns |       1.451 ns |  19,239 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 9216B        |       2,911.88 ns |       3.745 ns |       3.503 ns |  12,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 9216B        |       4,006.91 ns |       5.602 ns |       4.678 ns |  20,505 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 9216B        |      14,085.63 ns |      26.908 ns |      25.170 ns |  14,058 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 9216B        |     104,891.66 ns |     139.158 ns |     130.169 ns |  18,934 B |     448 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10000B       |       2,843.51 ns |       2.148 ns |       2.009 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10000B       |       3,313.91 ns |       1.515 ns |       1.265 ns |  22,057 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10000B       |       3,330.34 ns |       3.164 ns |       2.805 ns |  22,050 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10000B       |       3,342.34 ns |       3.809 ns |       3.563 ns |  19,222 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10000B       |       3,347.45 ns |       2.013 ns |       1.883 ns |  19,242 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10000B       |       3,466.52 ns |       4.200 ns |       3.929 ns |  13,869 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10000B       |       4,874.21 ns |      16.983 ns |      15.886 ns |  20,496 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10000B       |      15,425.86 ns |      39.244 ns |      36.709 ns |  14,049 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10000B       |     115,507.51 ns |     173.909 ns |     162.675 ns |  18,945 B |     504 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64KB         |       8,009.03 ns |       8.362 ns |       7.821 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64KB         |      10,745.51 ns |       5.603 ns |       4.678 ns |  21,517 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64KB         |      10,787.50 ns |       5.720 ns |       5.070 ns |  21,517 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64KB         |      10,788.56 ns |      11.049 ns |       9.795 ns |  19,996 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 64KB         |      11,644.45 ns |       4.707 ns |       4.403 ns |  18,396 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 64KB         |      13,357.77 ns |       6.769 ns |       5.652 ns |  17,981 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 64KB         |      24,326.63 ns |      34.254 ns |      30.365 ns |  19,255 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64KB         |     100,521.08 ns |     155.190 ns |     137.572 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64KB         |     751,553.86 ns |   1,387.303 ns |   1,297.684 ns |  18,944 B |    3528 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100000B      |       6,777.24 ns |      39.914 ns |      37.336 ns |  37,331 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100000B      |      13,608.20 ns |      15.827 ns |      14.804 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100000B      |      17,542.22 ns |      16.199 ns |      15.152 ns |  20,058 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100000B      |      17,835.65 ns |      38.916 ns |      36.402 ns |  22,745 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100000B      |      18,438.90 ns |      31.081 ns |      24.266 ns |  20,295 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100000B      |      18,811.86 ns |      45.814 ns |      42.855 ns |  19,482 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100000B      |      36,873.12 ns |     224.179 ns |     209.697 ns |  20,756 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100000B      |     155,824.15 ns |     631.352 ns |     559.677 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100000B      |   1,141,004.13 ns |   4,766.776 ns |   4,458.845 ns |  18,933 B |    5432 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128KB        |       7,552.04 ns |     148.846 ns |     152.854 ns |  37,253 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128KB        |      15,974.04 ns |      17.064 ns |      15.127 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128KB        |      21,416.54 ns |      29.061 ns |      25.762 ns |  18,811 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128KB        |      21,637.68 ns |      83.611 ns |      78.210 ns |  21,493 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128KB        |      22,463.11 ns |      66.247 ns |      61.967 ns |  19,980 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128KB        |      23,464.62 ns |      16.885 ns |      14.968 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128KB        |      47,365.57 ns |     131.594 ns |     123.093 ns |  19,509 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128KB        |     204,570.81 ns |   1,189.212 ns |   1,112.390 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128KB        |   1,520,256.99 ns |  16,583.737 ns |  15,512.438 ns |  18,939 B |    7112 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 256KB        |      13,691.29 ns |      48.606 ns |      45.466 ns |  36,906 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 256KB        |      31,924.20 ns |      83.896 ns |      74.371 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 256KB        |      42,817.77 ns |     105.759 ns |      93.752 ns |  19,982 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 256KB        |      43,118.67 ns |      57.632 ns |      53.909 ns |  18,811 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 256KB        |      43,125.44 ns |      47.497 ns |      44.429 ns |  21,503 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 256KB        |      45,489.33 ns |      83.957 ns |      78.533 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 256KB        |      93,135.29 ns |     350.024 ns |     327.413 ns |  19,509 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 256KB        |     410,262.94 ns |   1,490.676 ns |   1,394.380 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 256KB        |   3,039,875.49 ns |  11,195.052 ns |  10,471.858 ns |  18,939 B |   14280 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 512KB        |      25,982.45 ns |     121.110 ns |     113.286 ns |  36,028 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 512KB        |      63,637.14 ns |     100.185 ns |      93.713 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 512KB        |      85,512.84 ns |     261.871 ns |     244.954 ns |  19,980 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 512KB        |      86,048.94 ns |     282.702 ns |     264.440 ns |  21,285 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 512KB        |      86,351.96 ns |      82.673 ns |      73.287 ns |  18,811 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 512KB        |      89,332.48 ns |     139.259 ns |     123.449 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 512KB        |     184,364.04 ns |     516.745 ns |     483.364 ns |  19,509 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 512KB        |     821,866.50 ns |   3,143.533 ns |   2,454.264 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 512KB        |   6,011,141.02 ns |  22,417.361 ns |  19,872.406 ns |  18,944 B |   28616 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1MB          |      48,411.72 ns |     171.459 ns |     160.383 ns |  37,304 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1MB          |     122,351.04 ns |      57.002 ns |      50.531 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1MB          |     149,271.39 ns |     326.754 ns |     305.646 ns |  20,320 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1MB          |     151,216.92 ns |     375.182 ns |     350.946 ns |  20,058 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1MB          |     170,096.75 ns |     286.171 ns |     267.685 ns |  19,482 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1MB          |     188,350.41 ns |     246.375 ns |     230.459 ns |  22,288 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1MB          |     350,377.85 ns |   1,726.931 ns |   1,615.372 ns |  20,756 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1MB          |   1,565,858.59 ns |   5,535.166 ns |   4,906.780 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1MB          |  11,188,187.95 ns |  23,093.211 ns |  20,471.530 ns |  18,939 B |   54656 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10MB         |     477,063.83 ns |   1,350.045 ns |   1,262.833 ns |  46,306 B |     132 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10MB         |   1,230,170.40 ns |   1,623.929 ns |   1,519.024 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10MB         |   1,526,507.58 ns |   3,132.797 ns |   2,930.420 ns |  27,008 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10MB         |   1,705,221.15 ns |   1,890.712 ns |   1,768.574 ns |  26,432 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10MB         |   1,718,041.07 ns |   7,122.114 ns |   6,662.029 ns |  20,288 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10MB         |   1,819,599.45 ns |   7,466.113 ns |   6,983.807 ns |  30,013 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10MB         |   3,505,340.12 ns |   9,782.305 ns |   8,671.759 ns |  20,756 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10MB         |  15,644,341.71 ns |  60,363.856 ns |  50,406.554 ns |  14,055 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10MB         | 111,574,155.71 ns | 376,881.281 ns | 334,095.439 ns |  18,934 B |  546840 B |
