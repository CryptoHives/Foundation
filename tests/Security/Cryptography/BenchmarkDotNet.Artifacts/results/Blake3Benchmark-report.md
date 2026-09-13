```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9445/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4

Method=TryComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                         | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated |
|---------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4B           |         38.61 ns |       0.464 ns |       0.434 ns |         38.38 ns |   4,631 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4B           |         39.01 ns |       0.461 ns |       0.385 ns |         38.81 ns |   4,631 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4B           |         56.88 ns |       0.166 ns |       0.155 ns |         56.88 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4B           |         61.42 ns |       0.275 ns |       0.257 ns |         61.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4B           |         62.08 ns |       0.464 ns |       0.387 ns |         62.02 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4B           |         62.17 ns |       0.279 ns |       0.261 ns |         62.22 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4B           |         72.16 ns |       0.749 ns |       0.701 ns |         72.42 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4B           |         96.31 ns |       0.321 ns |       0.284 ns |         96.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4B           |        599.06 ns |       2.305 ns |       1.925 ns |        598.24 ns |  21,535 B |         - |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100B         |        103.41 ns |       0.586 ns |       0.548 ns |        103.37 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100B         |        103.75 ns |       0.425 ns |       0.398 ns |        103.63 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100B         |        114.96 ns |       0.177 ns |       0.165 ns |        114.98 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100B         |        124.63 ns |       1.353 ns |       1.265 ns |        124.97 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100B         |        136.41 ns |       0.480 ns |       0.449 ns |        136.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100B         |        136.68 ns |       0.537 ns |       0.502 ns |        136.71 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100B         |        136.71 ns |       0.366 ns |       0.343 ns |        136.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100B         |        179.87 ns |       0.273 ns |       0.228 ns |        179.93 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100B         |      1,290.16 ns |       2.583 ns |       2.157 ns |      1,289.24 ns |  22,202 B |         - |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128B         |        103.38 ns |       0.452 ns |       0.423 ns |        103.49 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128B         |        103.53 ns |       0.281 ns |       0.263 ns |        103.53 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128B         |        110.94 ns |       0.097 ns |       0.086 ns |        110.94 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128B         |        124.71 ns |       0.883 ns |       0.826 ns |        124.95 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128B         |        132.41 ns |       0.433 ns |       0.405 ns |        132.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128B         |        132.47 ns |       0.369 ns |       0.327 ns |        132.49 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128B         |        132.50 ns |       0.324 ns |       0.303 ns |        132.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128B         |        173.98 ns |       0.360 ns |       0.301 ns |        173.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128B         |      1,305.23 ns |       8.083 ns |       7.165 ns |      1,301.29 ns |  22,196 B |         - |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 137B         |        162.64 ns |       0.629 ns |       0.525 ns |        162.80 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 137B         |        162.67 ns |       0.684 ns |       0.640 ns |        162.88 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 137B         |        176.41 ns |       0.157 ns |       0.147 ns |        176.40 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 137B         |        192.74 ns |       0.582 ns |       0.544 ns |        192.55 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 137B         |        199.55 ns |       1.734 ns |       1.537 ns |        199.89 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 137B         |        199.73 ns |       0.486 ns |       0.454 ns |        199.77 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 137B         |        199.86 ns |       0.434 ns |       0.406 ns |        199.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 137B         |        258.79 ns |       0.540 ns |       0.479 ns |        258.71 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 137B         |      1,925.80 ns |       2.973 ns |       2.635 ns |      1,925.43 ns |  22,195 B |         - |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1000B        |        893.76 ns |       1.329 ns |       1.243 ns |        893.96 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1000B        |        898.74 ns |       2.010 ns |       1.881 ns |        898.90 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1000B        |        898.76 ns |       2.697 ns |       2.523 ns |        899.58 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1000B        |        970.07 ns |       5.939 ns |       5.555 ns |        972.37 ns |   3,545 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1000B        |      1,003.16 ns |       2.399 ns |       2.244 ns |      1,003.97 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1000B        |      1,003.91 ns |       2.757 ns |       2.579 ns |      1,004.34 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1000B        |      1,004.55 ns |       1.139 ns |       1.010 ns |      1,004.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1000B        |      1,282.96 ns |       2.373 ns |       1.982 ns |      1,283.30 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1000B        |     10,204.64 ns |      56.030 ns |      52.411 ns |     10,201.10 ns |  22,214 B |         - |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1KB          |        893.55 ns |       2.333 ns |       2.182 ns |        893.99 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1KB          |        897.20 ns |       3.747 ns |       3.505 ns |        898.23 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1KB          |        897.54 ns |       3.182 ns |       2.976 ns |        898.40 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1KB          |        967.16 ns |       2.218 ns |       2.075 ns |        967.79 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1KB          |        998.44 ns |       3.274 ns |       3.062 ns |        999.93 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1KB          |        999.51 ns |       3.782 ns |       3.538 ns |      1,000.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1KB          |      1,000.64 ns |       2.136 ns |       1.998 ns |      1,001.03 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1KB          |      1,276.72 ns |       5.438 ns |       4.541 ns |      1,275.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1KB          |      9,778.44 ns |      38.924 ns |      36.410 ns |      9,764.39 ns |  22,223 B |         - |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1025B        |        977.58 ns |      10.712 ns |      10.020 ns |        981.91 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1025B        |      1,067.26 ns |       7.348 ns |       6.873 ns |      1,065.82 ns |   5,490 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1025B        |      1,071.92 ns |       3.670 ns |       3.433 ns |      1,072.76 ns |   5,490 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1025B        |      1,129.17 ns |       2.606 ns |       2.438 ns |      1,129.26 ns |   4,875 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1025B        |      1,158.42 ns |       1.107 ns |       1.035 ns |      1,158.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1025B        |      1,161.49 ns |       3.432 ns |       3.211 ns |      1,162.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1025B        |      1,174.22 ns |       4.476 ns |       4.187 ns |      1,175.54 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1025B        |      1,477.84 ns |       7.818 ns |       7.313 ns |      1,476.94 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1025B        |     10,794.94 ns |      86.493 ns |      76.674 ns |     10,756.85 ns |  22,534 B |      56 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 2KB          |        906.62 ns |       4.399 ns |       4.115 ns |        907.76 ns |   6,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 2KB          |        912.02 ns |      13.220 ns |      12.366 ns |        907.55 ns |   6,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 2KB          |        925.98 ns |       3.899 ns |       3.647 ns |        926.53 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 2KB          |      1,063.32 ns |       2.688 ns |       2.514 ns |      1,063.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 2KB          |      1,078.01 ns |       1.853 ns |       1.733 ns |      1,077.95 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 2KB          |      2,051.43 ns |      10.760 ns |      10.065 ns |      2,053.67 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 2KB          |      2,096.82 ns |      16.834 ns |      15.746 ns |      2,103.84 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 2KB          |      2,681.34 ns |      32.773 ns |      27.367 ns |      2,671.60 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 2KB          |     20,521.61 ns |     373.409 ns |     887.447 ns |     20,158.59 ns |  22,443 B |      56 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4KB          |      1,173.10 ns |       2.448 ns |       1.911 ns |      1,173.12 ns |  14,354 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4KB          |      1,178.26 ns |       8.056 ns |       6.727 ns |      1,174.80 ns |  14,354 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4KB          |      1,217.38 ns |      22.859 ns |      22.451 ns |      1,205.54 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4KB          |      1,321.09 ns |       6.134 ns |       4.789 ns |      1,321.56 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4KB          |      1,322.00 ns |      21.070 ns |      19.709 ns |      1,312.17 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4KB          |      1,322.85 ns |       5.789 ns |       5.132 ns |      1,323.13 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4KB          |      4,178.60 ns |      78.273 ns |      73.217 ns |      4,145.67 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4KB          |      5,497.55 ns |      42.801 ns |      37.942 ns |      5,494.22 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4KB          |     39,227.01 ns |     230.640 ns |     215.741 ns |     39,131.39 ns |  22,444 B |     168 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 6KB          |      1,555.81 ns |       9.075 ns |       8.489 ns |      1,557.01 ns |  15,034 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 6KB          |      1,683.69 ns |       5.570 ns |       5.210 ns |      1,686.14 ns |  15,052 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 6KB          |      1,717.92 ns |       6.657 ns |       5.559 ns |      1,717.78 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 6KB          |      1,784.41 ns |      24.406 ns |      22.830 ns |      1,770.35 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 6KB          |      2,161.34 ns |       3.938 ns |       3.683 ns |      2,161.81 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 6KB          |      3,650.30 ns |      72.988 ns |     129.737 ns |      3,730.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 6KB          |      6,213.27 ns |      20.287 ns |      18.977 ns |      6,217.42 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 6KB          |      8,239.51 ns |     106.912 ns |      94.775 ns |      8,201.90 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 6KB          |     59,854.52 ns |     160.339 ns |     133.891 ns |     59,843.02 ns |  22,466 B |     280 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 8KB          |      1,383.26 ns |       3.596 ns |       3.363 ns |      1,384.25 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 8KB          |      1,595.12 ns |      11.045 ns |      10.331 ns |      1,599.88 ns |  14,836 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 8KB          |      1,699.36 ns |       3.666 ns |       3.429 ns |      1,698.52 ns |   6,416 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 8KB          |      1,772.65 ns |       5.708 ns |       5.339 ns |      1,773.04 ns |  14,818 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 8KB          |      1,797.19 ns |       1.857 ns |       1.737 ns |      1,797.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 8KB          |      1,798.44 ns |       1.878 ns |       1.757 ns |      1,798.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 8KB          |      2,642.00 ns |      41.182 ns |      34.389 ns |      2,628.77 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 8KB          |     11,098.44 ns |      78.234 ns |      69.352 ns |     11,102.63 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 8KB          |     81,716.42 ns |     286.611 ns |     239.333 ns |     81,616.11 ns |  22,454 B |     392 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10000B       |      3,050.50 ns |       6.688 ns |       6.256 ns |      3,051.26 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10000B       |      3,365.87 ns |      19.770 ns |      18.493 ns |      3,367.91 ns |  14,479 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10000B       |      3,371.61 ns |      12.039 ns |      11.261 ns |      3,372.68 ns |  14,477 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10000B       |      3,583.39 ns |       4.912 ns |       4.595 ns |      3,584.72 ns |   7,764 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10000B       |      3,615.75 ns |       4.187 ns |       3.917 ns |      3,616.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10000B       |      3,729.66 ns |       6.999 ns |       6.547 ns |      3,730.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10000B       |      5,138.55 ns |      40.586 ns |      37.965 ns |      5,140.53 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10000B       |     13,593.72 ns |      50.587 ns |      44.844 ns |     13,607.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10000B       |    102,697.23 ns |     312.923 ns |     261.305 ns |    102,611.74 ns |  22,455 B |     504 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64KB         |      8,620.46 ns |      18.602 ns |      17.400 ns |      8,624.34 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64KB         |     11,584.20 ns |      20.034 ns |      16.729 ns |     11,588.40 ns |   8,626 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 64KB         |     11,589.68 ns |      21.899 ns |      20.485 ns |     11,590.55 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64KB         |     12,987.75 ns |      28.573 ns |      26.727 ns |     12,992.96 ns |  14,712 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64KB         |     13,096.19 ns |      49.805 ns |      46.587 ns |     13,113.85 ns |  14,694 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 64KB         |     13,547.25 ns |      22.944 ns |      21.462 ns |     13,542.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 64KB         |     21,316.44 ns |     200.941 ns |     187.960 ns |     21,308.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64KB         |     88,951.08 ns |     584.845 ns |     547.064 ns |     88,633.03 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64KB         |    686,857.02 ns |   2,535.881 ns |   2,117.575 ns |    687,176.27 ns |  22,469 B |    3528 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100000B      |      6,081.92 ns |     118.803 ns |     105.316 ns |      6,051.04 ns |   6,237 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100000B      |     14,558.07 ns |      25.791 ns |      24.125 ns |     14,559.26 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100000B      |     18,920.86 ns |      87.677 ns |      82.014 ns |     18,950.69 ns |  15,165 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100000B      |     19,542.48 ns |      45.345 ns |      42.416 ns |     19,544.28 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100000B      |     19,837.07 ns |      48.045 ns |      44.942 ns |     19,834.61 ns |   8,941 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100000B      |     20,324.16 ns |      56.598 ns |      52.942 ns |     20,340.51 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100000B      |     31,749.69 ns |     365.882 ns |     342.246 ns |     31,622.55 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100000B      |    135,430.71 ns |   1,116.775 ns |     871.905 ns |    135,228.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100000B      |  1,023,042.22 ns |   2,469.560 ns |   2,062.194 ns |  1,022,397.07 ns |  22,455 B |    5432 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128KB        |      6,582.77 ns |     129.182 ns |     114.517 ns |      6,535.64 ns |   6,258 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128KB        |     17,117.06 ns |      43.105 ns |      40.320 ns |     17,111.99 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128KB        |     20,863.72 ns |      60.940 ns |      57.003 ns |     20,879.20 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128KB        |     23,027.07 ns |      86.686 ns |      81.086 ns |     23,023.27 ns |  14,706 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128KB        |     25,125.39 ns |      65.588 ns |      61.351 ns |     25,137.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128KB        |     25,423.75 ns |      55.355 ns |      51.779 ns |     25,424.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128KB        |     41,165.97 ns |     232.081 ns |     205.734 ns |     41,108.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128KB        |    178,188.09 ns |   1,333.723 ns |   1,247.565 ns |    178,457.10 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128KB        |  1,870,578.33 ns |  19,831.620 ns |  18,550.509 ns |  1,862,997.46 ns |  22,469 B |    7112 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 256KB        |     10,033.55 ns |      59.196 ns |      55.372 ns |     10,023.54 ns |   6,215 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 256KB        |     34,140.42 ns |     147.639 ns |     123.286 ns |     34,148.28 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 256KB        |     41,463.88 ns |      73.227 ns |      68.497 ns |     41,460.62 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 256KB        |     43,357.21 ns |     129.335 ns |     120.980 ns |     43,384.75 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 256KB        |     49,111.87 ns |      83.040 ns |      77.676 ns |     49,087.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 256KB        |     50,897.86 ns |     500.636 ns |     468.295 ns |     51,057.09 ns |  14,505 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 256KB        |     81,272.50 ns |   1,008.855 ns |     943.684 ns |     81,320.86 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 256KB        |    357,865.08 ns |   2,293.031 ns |   2,144.903 ns |    357,834.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 256KB        |  2,652,102.49 ns |  26,629.357 ns |  22,236.719 ns |  2,644,097.27 ns |  22,464 B |   14280 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 512KB        |     16,364.69 ns |     157.408 ns |     147.239 ns |     16,335.93 ns |   6,223 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 512KB        |     67,731.14 ns |     133.800 ns |     111.729 ns |     67,759.63 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 512KB        |     81,997.96 ns |     166.068 ns |     155.340 ns |     81,985.33 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 512KB        |     85,696.76 ns |     199.709 ns |     186.808 ns |     85,659.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 512KB        |     91,431.13 ns |     236.858 ns |     221.557 ns |     91,466.66 ns |  14,244 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 512KB        |     95,967.96 ns |     913.724 ns |     854.698 ns |     96,209.83 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 512KB        |    159,059.08 ns |     996.279 ns |     931.920 ns |    158,697.07 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 512KB        |    705,307.27 ns |   2,403.965 ns |   2,248.670 ns |    704,756.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 512KB        |  5,367,720.48 ns |  10,324.074 ns |   9,152.023 ns |  5,365,612.11 ns |  22,459 B |   28616 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1MB          |     29,948.18 ns |     132.552 ns |     117.504 ns |     29,930.32 ns |   6,209 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1MB          |    130,387.30 ns |     305.602 ns |     285.860 ns |    130,383.84 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1MB          |    162,499.21 ns |     216.952 ns |     202.937 ns |    162,444.51 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1MB          |    182,141.72 ns |     134.917 ns |     119.600 ns |    182,145.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1MB          |    186,493.22 ns |     290.597 ns |     271.825 ns |    186,462.33 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1MB          |    193,462.62 ns |   1,212.446 ns |   1,134.123 ns |    193,804.76 ns |  14,710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1MB          |    300,864.45 ns |     693.851 ns |     615.081 ns |    300,847.80 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1MB          |  1,348,950.45 ns |   5,592.945 ns |   4,670.362 ns |  1,347,848.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1MB          |  9,623,660.04 ns |  24,000.483 ns |  21,275.803 ns |  9,619,627.34 ns |  22,458 B |   54656 B |
|                                                     |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10MB         |    271,613.61 ns |   2,430.048 ns |   2,154.174 ns |    271,343.38 ns |   6,230 B |     136 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10MB         |  1,329,073.30 ns |   2,295.869 ns |   2,035.228 ns |  1,329,059.18 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10MB         |  1,611,607.37 ns |   2,183.247 ns |   1,935.392 ns |  1,611,498.73 ns |   8,896 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10MB         |  1,646,489.47 ns |   3,553.715 ns |   3,324.147 ns |  1,646,330.08 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10MB         |  1,818,008.05 ns |   4,408.502 ns |   4,123.715 ns |  1,817,214.36 ns |  22,435 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10MB         |  1,837,655.05 ns |   2,139.208 ns |   2,001.016 ns |  1,837,120.61 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10MB         |  3,015,724.40 ns |   4,001.759 ns |   3,341.650 ns |  3,015,005.47 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10MB         | 13,430,326.20 ns |  31,274.393 ns |  26,115.534 ns | 13,422,848.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10MB         | 95,398,350.00 ns | 233,269.250 ns | 182,121.287 ns | 95,386,080.00 ns |  22,577 B |  546840 B |
