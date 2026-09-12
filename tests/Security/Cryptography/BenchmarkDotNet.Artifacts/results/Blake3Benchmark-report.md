```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9168/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v4

Method=TryComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                         | TestDataSize | Mean              | Error          | StdDev         | Median            | Code Size | Allocated |
|---------------------------------------------------- |------------- |------------------:|---------------:|---------------:|------------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4B           |          41.49 ns |       0.570 ns |       0.720 ns |          41.56 ns |   4,631 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4B           |          45.89 ns |       0.915 ns |       2.684 ns |          46.02 ns |   4,631 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4B           |          58.55 ns |       1.084 ns |       1.014 ns |          58.65 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4B           |          67.63 ns |       1.359 ns |       1.271 ns |          67.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4B           |          67.94 ns |       1.367 ns |       2.465 ns |          68.23 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4B           |          69.08 ns |       1.340 ns |       1.646 ns |          69.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4B           |          70.02 ns |       1.407 ns |       2.744 ns |          69.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4B           |         107.95 ns |       3.602 ns |      10.278 ns |         103.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4B           |         639.82 ns |       9.961 ns |       9.317 ns |         637.82 ns |  21,535 B |         - |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100B         |          91.92 ns |       1.621 ns |       1.517 ns |          91.75 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100B         |          93.18 ns |       1.806 ns |       1.689 ns |          93.15 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100B         |         108.05 ns |       2.135 ns |       2.700 ns |         108.14 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100B         |         115.83 ns |       2.324 ns |       3.618 ns |         116.09 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100B         |         121.90 ns |       2.223 ns |       1.970 ns |         122.11 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100B         |         122.11 ns |       2.216 ns |       1.965 ns |         121.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100B         |         122.80 ns |       2.455 ns |       2.922 ns |         122.49 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100B         |         196.23 ns |       3.499 ns |       2.922 ns |         196.10 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100B         |       1,389.13 ns |      25.966 ns |      24.289 ns |       1,380.45 ns |  22,213 B |         - |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128B         |          88.34 ns |       1.724 ns |       1.613 ns |          87.88 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128B         |          89.50 ns |       1.799 ns |       1.767 ns |          89.86 ns |   4,802 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128B         |         107.81 ns |       1.784 ns |       1.581 ns |         107.82 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128B         |         112.02 ns |       2.266 ns |       2.783 ns |         112.12 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128B         |         122.80 ns |       2.472 ns |       2.428 ns |         122.86 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128B         |         124.11 ns |       2.383 ns |       2.340 ns |         123.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128B         |         127.01 ns |       2.542 ns |       4.836 ns |         127.78 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128B         |         187.92 ns |       2.824 ns |       2.503 ns |         188.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128B         |       1,401.85 ns |      26.342 ns |      24.640 ns |       1,406.85 ns |  22,196 B |         - |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 137B         |         134.45 ns |       1.874 ns |       1.565 ns |         134.23 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 137B         |         138.13 ns |       2.532 ns |       3.866 ns |         137.36 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 137B         |         176.10 ns |       3.533 ns |       9.182 ns |         179.32 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 137B         |         176.91 ns |       0.946 ns |       0.885 ns |         177.00 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 137B         |         198.92 ns |       3.936 ns |       4.211 ns |         197.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 137B         |         200.64 ns |       3.916 ns |       4.952 ns |         201.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 137B         |         200.74 ns |       3.919 ns |       4.813 ns |         200.12 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 137B         |         279.72 ns |       4.700 ns |       4.396 ns |         280.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 137B         |       2,059.07 ns |      39.256 ns |      36.720 ns |       2,043.34 ns |  22,195 B |         - |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1000B        |         888.69 ns |      16.685 ns |      16.387 ns |         891.27 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1000B        |         895.37 ns |       4.835 ns |       4.286 ns |         894.45 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1000B        |         895.54 ns |       4.841 ns |       4.528 ns |         894.67 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1000B        |         957.07 ns |      19.071 ns |      53.789 ns |         965.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1000B        |         975.55 ns |       6.903 ns |       6.457 ns |         975.48 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1000B        |         995.08 ns |      19.694 ns |      37.943 ns |       1,008.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1000B        |       1,006.14 ns |       5.208 ns |       4.871 ns |       1,007.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1000B        |       1,306.92 ns |       7.241 ns |       6.419 ns |       1,308.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1000B        |      10,444.92 ns |      72.238 ns |      67.571 ns |      10,441.44 ns |  22,214 B |         - |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1KB          |         888.10 ns |      17.016 ns |      16.712 ns |         892.43 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1KB          |         891.39 ns |       8.182 ns |       7.653 ns |         892.98 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1KB          |         894.53 ns |       4.227 ns |       3.954 ns |         894.87 ns |   5,102 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1KB          |         968.16 ns |       3.988 ns |       3.730 ns |         969.30 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1KB          |         979.12 ns |      19.422 ns |      50.481 ns |       1,003.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1KB          |         990.20 ns |      19.479 ns |      24.634 ns |         998.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1KB          |       1,000.46 ns |       3.711 ns |       3.471 ns |       1,000.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1KB          |       1,295.62 ns |       6.784 ns |       6.346 ns |       1,295.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1KB          |       9,781.10 ns |      43.029 ns |      40.249 ns |       9,773.08 ns |  22,223 B |         - |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1025B        |         880.41 ns |      16.137 ns |      13.475 ns |         874.71 ns |   5,490 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1025B        |         886.98 ns |      14.661 ns |      15.056 ns |         879.52 ns |   5,490 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1025B        |         976.92 ns |      18.858 ns |      20.178 ns |         983.39 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1025B        |       1,136.00 ns |       8.158 ns |       7.631 ns |       1,137.10 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1025B        |       1,159.79 ns |       4.529 ns |       4.236 ns |       1,160.49 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1025B        |       1,172.51 ns |       5.304 ns |       4.961 ns |       1,172.71 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1025B        |       1,175.05 ns |       3.884 ns |       3.633 ns |       1,174.33 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1025B        |       1,475.74 ns |       5.956 ns |       5.280 ns |       1,476.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1025B        |      11,113.02 ns |      31.572 ns |      29.532 ns |      11,115.54 ns |  22,540 B |      56 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 2KB          |         905.32 ns |       2.540 ns |       2.376 ns |         905.68 ns |   6,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 2KB          |         906.37 ns |       4.228 ns |       3.955 ns |         908.15 ns |   6,911 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 2KB          |         927.97 ns |       2.458 ns |       2.299 ns |         928.32 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 2KB          |       1,067.54 ns |       3.239 ns |       3.030 ns |       1,068.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 2KB          |       1,076.71 ns |      10.243 ns |       9.582 ns |       1,081.63 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 2KB          |       2,055.96 ns |       9.177 ns |       8.584 ns |       2,057.49 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 2KB          |       2,109.02 ns |       8.105 ns |       7.581 ns |       2,110.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 2KB          |       2,673.83 ns |      12.819 ns |      11.364 ns |       2,676.88 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 2KB          |      19,711.39 ns |      48.048 ns |      40.122 ns |      19,705.03 ns |  22,452 B |      56 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4KB          |       1,191.53 ns |      21.231 ns |      23.598 ns |       1,184.26 ns |  14,354 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4KB          |       1,200.89 ns |      22.981 ns |      19.190 ns |       1,194.22 ns |  14,354 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4KB          |       1,206.53 ns |       4.370 ns |       4.088 ns |       1,207.79 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4KB          |       1,575.17 ns |       3.371 ns |       2.988 ns |       1,574.77 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4KB          |       1,583.27 ns |       3.030 ns |       2.835 ns |       1,582.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4KB          |       1,586.00 ns |       3.218 ns |       3.010 ns |       1,586.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4KB          |       4,122.70 ns |      25.864 ns |      24.193 ns |       4,122.27 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4KB          |       5,456.94 ns |      31.965 ns |      29.901 ns |       5,456.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4KB          |      41,903.98 ns |     173.067 ns |     161.887 ns |      41,880.53 ns |  22,441 B |     168 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 6KB          |       1,565.01 ns |       6.684 ns |       6.252 ns |       1,565.82 ns |  15,052 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 6KB          |       1,568.87 ns |       4.159 ns |       3.890 ns |       1,568.58 ns |  15,052 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 6KB          |       1,705.80 ns |       2.538 ns |       2.374 ns |       1,705.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 6KB          |       1,749.21 ns |       1.542 ns |       1.442 ns |       1,749.41 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 6KB          |       2,156.84 ns |      11.475 ns |      10.734 ns |       2,161.49 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 6KB          |       3,685.21 ns |      20.388 ns |      19.071 ns |       3,690.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 6KB          |       6,239.23 ns |      26.462 ns |      24.753 ns |       6,246.29 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 6KB          |       8,226.21 ns |      59.512 ns |      55.668 ns |       8,212.83 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 6KB          |      62,279.67 ns |     244.199 ns |     228.424 ns |      62,219.21 ns |  22,454 B |     280 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 8KB          |       1,385.27 ns |       4.147 ns |       3.879 ns |       1,386.20 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 8KB          |       1,608.20 ns |       5.908 ns |       5.526 ns |       1,607.65 ns |  14,831 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 8KB          |       1,723.04 ns |       2.597 ns |       2.429 ns |       1,723.06 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 8KB          |       1,729.72 ns |       4.699 ns |       4.396 ns |       1,727.57 ns |  14,834 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 8KB          |       1,829.14 ns |       8.251 ns |       7.718 ns |       1,831.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 8KB          |       1,845.58 ns |       1.780 ns |       1.665 ns |       1,845.49 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 8KB          |       3,177.77 ns |       6.609 ns |       6.182 ns |       3,178.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 8KB          |      10,975.94 ns |      64.978 ns |      60.781 ns |      10,956.78 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 8KB          |      80,797.66 ns |     262.570 ns |     232.761 ns |      80,694.23 ns |  22,466 B |     392 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10000B       |       3,059.43 ns |       9.214 ns |       8.619 ns |       3,058.43 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10000B       |       3,329.36 ns |      37.779 ns |      35.339 ns |       3,331.83 ns |  14,479 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10000B       |       3,431.86 ns |      17.227 ns |      16.114 ns |       3,435.23 ns |  14,475 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10000B       |       3,600.98 ns |      12.060 ns |      10.691 ns |       3,603.78 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10000B       |       3,665.70 ns |       8.942 ns |       8.364 ns |       3,665.92 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10000B       |       3,735.93 ns |       6.392 ns |       5.979 ns |       3,737.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10000B       |       5,095.30 ns |      11.986 ns |      11.212 ns |       5,097.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10000B       |      13,531.92 ns |      59.838 ns |      55.972 ns |      13,516.12 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10000B       |     103,081.57 ns |     406.331 ns |     380.083 ns |     103,053.56 ns |  22,470 B |     504 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64KB         |       8,694.84 ns |      25.859 ns |      24.189 ns |       8,703.22 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64KB         |      11,661.53 ns |      44.584 ns |      41.704 ns |      11,649.80 ns |  14,712 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64KB         |      11,680.33 ns |      31.129 ns |      29.118 ns |      11,688.15 ns |   8,626 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 64KB         |      11,745.96 ns |      13.446 ns |      12.577 ns |      11,743.11 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64KB         |      13,115.75 ns |      56.985 ns |      53.304 ns |      13,119.33 ns |  14,712 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 64KB         |      14,104.48 ns |      55.343 ns |      51.768 ns |      14,117.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 64KB         |      25,362.85 ns |      89.727 ns |      79.541 ns |      25,391.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64KB         |      89,029.56 ns |     562.576 ns |     526.234 ns |      88,878.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64KB         |     685,913.93 ns |   1,407.974 ns |   1,175.722 ns |     685,710.79 ns |  22,469 B |    3528 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100000B      |       5,967.54 ns |      68.646 ns |      64.212 ns |       5,963.17 ns |   6,231 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100000B      |      14,634.51 ns |      45.728 ns |      42.774 ns |      14,650.12 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100000B      |      18,863.19 ns |      88.214 ns |      82.515 ns |      18,886.97 ns |  15,165 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100000B      |      19,143.24 ns |      69.604 ns |      65.108 ns |      19,140.27 ns |   8,914 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100000B      |      19,749.20 ns |      81.658 ns |      76.383 ns |      19,762.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100000B      |      21,034.72 ns |      57.877 ns |      54.138 ns |      21,032.62 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100000B      |      37,938.97 ns |     130.615 ns |     122.177 ns |      37,940.29 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100000B      |     137,160.33 ns |   1,234.766 ns |   1,155.001 ns |     137,006.13 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100000B      |   1,001,736.52 ns |   4,055.498 ns |   3,595.094 ns |   1,000,195.21 ns |  22,458 B |    5432 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128KB        |       6,480.43 ns |      37.799 ns |      35.357 ns |       6,479.51 ns |   6,238 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128KB        |      17,224.49 ns |      67.579 ns |      63.214 ns |      17,227.40 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128KB        |      21,293.28 ns |      48.620 ns |      45.479 ns |      21,309.84 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128KB        |      22,876.92 ns |     451.892 ns |   1,125.369 ns |      23,352.36 ns |  14,706 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128KB        |      24,524.21 ns |      59.418 ns |      49.617 ns |      24,542.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128KB        |      26,536.83 ns |      49.993 ns |      46.763 ns |      26,541.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128KB        |      46,746.89 ns |     931.837 ns |   1,945.090 ns |      45,871.10 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128KB        |     183,583.11 ns |   1,678.450 ns |   1,487.902 ns |     182,898.14 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128KB        |   1,375,380.26 ns |   4,626.257 ns |   4,101.056 ns |   1,374,620.70 ns |  22,464 B |    7112 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 256KB        |      10,355.16 ns |      24.678 ns |      23.084 ns |      10,346.17 ns |   6,215 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 256KB        |      34,348.74 ns |     114.861 ns |     107.441 ns |      34,351.85 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 256KB        |      42,149.49 ns |     135.370 ns |     126.625 ns |      42,203.35 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 256KB        |      42,349.62 ns |     210.225 ns |     196.645 ns |      42,328.44 ns |  14,505 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 256KB        |      44,068.52 ns |     121.917 ns |     114.041 ns |      44,088.35 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 256KB        |      51,527.22 ns |     497.587 ns |     465.443 ns |      51,488.02 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 256KB        |      89,156.84 ns |     914.691 ns |     855.603 ns |      89,124.76 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 256KB        |     362,840.25 ns |   2,333.286 ns |   2,182.558 ns |     362,024.51 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 256KB        |   2,741,383.54 ns |  10,057.173 ns |   8,915.422 ns |   2,738,339.84 ns |  22,464 B |   14280 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 512KB        |      16,764.59 ns |     140.661 ns |     124.692 ns |      16,752.40 ns |   6,263 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 512KB        |      70,324.79 ns |   1,381.324 ns |   1,844.028 ns |      70,309.03 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 512KB        |      87,550.57 ns |     241.977 ns |     226.345 ns |      87,585.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 512KB        |      92,853.17 ns |   1,843.363 ns |   2,759.059 ns |      92,105.77 ns |  14,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 512KB        |      94,906.77 ns |   1,851.941 ns |   1,981.556 ns |      94,392.96 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 512KB        |     100,992.19 ns |     631.370 ns |     527.223 ns |     101,108.53 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 512KB        |     187,028.82 ns |   3,691.239 ns |   7,111.766 ns |     186,646.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 512KB        |     769,475.81 ns |  15,254.644 ns |  14,982.100 ns |     769,604.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 512KB        |   5,650,178.12 ns | 107,025.142 ns | 114,515.703 ns |   5,663,811.72 ns |  22,469 B |   28616 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1MB          |      30,768.17 ns |     206.045 ns |     182.654 ns |      30,722.93 ns |   6,251 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1MB          |     132,597.35 ns |     795.546 ns |     744.154 ns |     132,674.68 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1MB          |     163,251.21 ns |     408.936 ns |     382.519 ns |     163,213.96 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1MB          |     166,030.85 ns |   1,008.250 ns |     943.118 ns |     166,032.28 ns |  14,710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1MB          |     191,822.19 ns |   1,893.953 ns |   1,581.537 ns |     191,924.88 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1MB          |     192,080.55 ns |     543.694 ns |     508.572 ns |     192,141.04 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1MB          |     333,235.58 ns |   3,795.663 ns |   3,550.466 ns |     332,506.54 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1MB          |   1,393,042.49 ns |   3,920.749 ns |   3,475.642 ns |   1,391,722.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1MB          |   9,938,537.92 ns |  38,889.107 ns |  36,376.895 ns |   9,935,685.94 ns |  22,459 B |   54656 B |
|                                                     |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10MB         |     272,936.60 ns |   1,454.413 ns |   1,135.510 ns |     272,553.00 ns |   6,230 B |     129 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10MB         |   1,410,900.99 ns |  28,167.199 ns |  34,591.853 ns |   1,409,166.02 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10MB         |   1,721,344.77 ns |  14,572.271 ns |  12,168.506 ns |   1,724,347.66 ns |   8,899 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10MB         |   1,872,009.86 ns |   3,901.639 ns |   3,458.701 ns |   1,872,472.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10MB         |   1,921,853.10 ns |   7,058.363 ns |   6,602.397 ns |   1,923,363.28 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10MB         |   2,475,811.39 ns | 118,142.318 ns | 340,867.626 ns |   2,443,598.83 ns |  22,435 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10MB         |   3,378,835.60 ns |  59,851.344 ns |  55,984.984 ns |   3,379,396.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10MB         |  13,996,660.83 ns |  66,593.263 ns |  59,033.193 ns |  13,988,773.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10MB         | 100,447,844.62 ns | 963,563.941 ns | 804,619.531 ns | 100,340,200.00 ns |  22,581 B |  546840 B |
