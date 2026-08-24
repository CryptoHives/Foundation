| Description                                   | TestDataSize | Mean             | Error          | StdDev        | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|---------------:|--------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         55.89 ns |       0.069 ns |      0.061 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         56.53 ns |       0.043 ns |      0.040 ns |   4,012 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         60.83 ns |       0.157 ns |      0.139 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         61.66 ns |       0.059 ns |      0.046 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         61.77 ns |       0.109 ns |      0.102 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         61.85 ns |       0.099 ns |      0.088 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |         82.34 ns |       0.301 ns |      0.282 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        596.61 ns |       0.867 ns |      0.811 ns |  21,324 B |         - |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         97.11 ns |       0.528 ns |      0.468 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        100.92 ns |       0.075 ns |      0.067 ns |   4,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        105.37 ns |       0.334 ns |      0.296 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        117.71 ns |       0.232 ns |      0.206 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        117.79 ns |       0.297 ns |      0.248 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        117.84 ns |       0.259 ns |      0.230 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        168.47 ns |       0.362 ns |      0.339 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,308.33 ns |       2.445 ns |      2.042 ns |  22,002 B |         - |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         93.59 ns |       0.168 ns |      0.149 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |         96.80 ns |       0.131 ns |      0.109 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        106.28 ns |       1.362 ns |      2.120 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        117.63 ns |       0.306 ns |      0.271 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        117.63 ns |       0.268 ns |      0.238 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        118.52 ns |       0.470 ns |      0.392 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        168.70 ns |       0.388 ns |      0.344 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,284.27 ns |       1.782 ns |      1.580 ns |  21,996 B |         - |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        147.35 ns |       0.392 ns |      0.348 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        148.52 ns |       0.922 ns |      0.770 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        162.11 ns |       0.465 ns |      0.435 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        170.14 ns |       0.309 ns |      0.274 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        170.30 ns |       0.371 ns |      0.310 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        170.56 ns |       0.464 ns |      0.434 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        248.37 ns |       1.399 ns |      1.240 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,940.28 ns |       3.964 ns |      3.514 ns |  21,985 B |         - |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        750.53 ns |       1.861 ns |      1.650 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        798.68 ns |       1.862 ns |      1.651 ns |   4,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        819.10 ns |       2.552 ns |      2.131 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        848.29 ns |       1.590 ns |      1.328 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        848.59 ns |       1.599 ns |      1.495 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        848.82 ns |       1.579 ns |      1.400 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      1,281.06 ns |       1.956 ns |      1.633 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,279.04 ns |      23.225 ns |     19.394 ns |  22,003 B |         - |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        751.36 ns |       1.543 ns |      1.444 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        793.41 ns |       2.302 ns |      2.041 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        815.29 ns |       1.557 ns |      1.380 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        847.55 ns |       0.990 ns |      0.773 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        848.52 ns |       2.147 ns |      2.009 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        848.57 ns |       2.342 ns |      1.956 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      1,280.23 ns |       1.814 ns |      1.608 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,774.41 ns |     123.815 ns |    109.759 ns |  22,012 B |         - |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        826.58 ns |       2.174 ns |      1.816 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        911.97 ns |      16.484 ns |     14.612 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        951.86 ns |       5.343 ns |      4.998 ns |   4,875 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        977.13 ns |       3.520 ns |      3.120 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        977.72 ns |       1.355 ns |      1.268 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        978.57 ns |       2.927 ns |      2.738 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      1,481.55 ns |       3.747 ns |      3.322 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     11,276.94 ns |      15.513 ns |     13.751 ns |  22,329 B |      56 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        788.19 ns |       1.383 ns |      1.226 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,217.19 ns |       4.077 ns |      3.614 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,223.23 ns |      18.754 ns |     26.896 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,660.41 ns |       4.429 ns |      3.927 ns |   3,465 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,734.36 ns |      10.158 ns |      7.930 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,763.76 ns |       3.966 ns |      3.516 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      2,682.06 ns |       2.749 ns |      2.571 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     19,455.40 ns |      44.296 ns |     39.267 ns |  22,241 B |      56 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,012.53 ns |       2.894 ns |      2.707 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      1,219.65 ns |       3.171 ns |      2.811 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,320.75 ns |       3.778 ns |      3.349 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,323.59 ns |       4.387 ns |      3.889 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,496.49 ns |       9.492 ns |      7.926 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,569.60 ns |      12.804 ns |      9.996 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |      5,460.83 ns |      10.059 ns |      8.400 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     42,201.12 ns |      50.850 ns |     45.077 ns |  22,230 B |     168 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,434.01 ns |       4.366 ns |      3.646 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,436.36 ns |       4.406 ns |      3.906 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,815.89 ns |       5.336 ns |      4.456 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      2,854.87 ns |      11.288 ns |     10.559 ns |   4,386 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,243.71 ns |      16.369 ns |     13.669 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      5,382.58 ns |      14.591 ns |     12.184 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |      8,263.61 ns |      20.467 ns |     18.143 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     61,492.47 ns |      49.617 ns |     43.984 ns |  22,243 B |     280 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,159.35 ns |       3.257 ns |      2.887 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      1,402.71 ns |       3.584 ns |      3.177 ns |   4,374 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,473.42 ns |       7.615 ns |      6.359 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,541.72 ns |       8.104 ns |      6.327 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,542.62 ns |       4.147 ns |      3.676 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,191.92 ns |       9.817 ns |      8.198 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     11,041.64 ns |      28.156 ns |     24.960 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     81,046.36 ns |     132.893 ns |    117.806 ns |  22,243 B |     392 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,564.21 ns |       8.523 ns |      7.556 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      2,924.99 ns |       7.318 ns |      6.111 ns |   3,902 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,080.04 ns |       8.366 ns |      7.826 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,106.59 ns |       9.664 ns |      8.070 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,130.64 ns |      14.680 ns |     12.258 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      8,834.21 ns |      20.007 ns |     17.736 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     13,579.77 ns |      44.507 ns |     39.455 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    101,757.84 ns |      90.218 ns |     79.975 ns |  22,261 B |     504 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,241.77 ns |      25.221 ns |     21.060 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      9,694.53 ns |      32.991 ns |     29.245 ns |   8,630 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |      9,802.18 ns |      22.444 ns |     19.896 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     10,185.25 ns |      74.480 ns |     62.194 ns |   4,622 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,730.83 ns |      34.910 ns |     27.255 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     57,888.92 ns |     161.366 ns |    143.047 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |     88,851.74 ns |     115.934 ns |    102.772 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    676,950.37 ns |     999.798 ns |    834.877 ns |  22,258 B |    3528 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |      6,618.13 ns |      25.207 ns |     23.578 ns |   6,800 B |    3111 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,221.65 ns |      28.101 ns |     26.285 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     14,640.96 ns |      29.603 ns |     24.720 ns |   8,912 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     16,387.10 ns |      59.892 ns |     56.023 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,671.58 ns |      96.366 ns |     85.426 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     88,511.74 ns |     381.381 ns |    356.744 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    135,933.98 ns |     606.422 ns |    473.454 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |    999,508.23 ns |   1,705.807 ns |  1,512.154 ns |  22,247 B |    5432 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |      7,379.01 ns |      19.586 ns |     18.321 ns |   6,798 B |    3340 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,367.86 ns |      51.377 ns |     45.544 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     18,722.81 ns |     100.347 ns |     88.955 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     19,903.59 ns |      69.621 ns |     65.124 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,034.32 ns |      80.905 ns |     71.720 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    115,841.64 ns |     305.676 ns |    285.929 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    177,798.52 ns |     418.769 ns |    349.691 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,343,724.07 ns |   2,250.157 ns |  1,994.706 ns |  22,253 B |    7112 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     10,703.06 ns |      53.082 ns |     44.326 ns |   6,779 B |    4210 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,531.13 ns |      57.552 ns |     48.058 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     34,709.68 ns |     160.890 ns |    150.496 ns |   8,614 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     36,257.31 ns |     154.135 ns |    144.178 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     42,476.11 ns |     197.289 ns |    164.746 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    231,622.43 ns |     380.877 ns |    337.638 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |    356,141.45 ns |     440.652 ns |    390.627 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,669,988.79 ns |   5,835.727 ns |  4,873.096 ns |  22,257 B |   14280 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     19,279.65 ns |      28.391 ns |     23.707 ns |   6,782 B |    4193 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     57,055.00 ns |     105.421 ns |     88.031 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     68,920.51 ns |     219.769 ns |    194.819 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     72,803.52 ns |     198.077 ns |    154.645 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     83,239.21 ns |     219.025 ns |    204.876 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    463,610.01 ns |   1,370.867 ns |  1,215.238 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |    712,789.88 ns |   1,511.782 ns |  1,340.155 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,325,893.69 ns |  10,640.367 ns |  9,432.408 ns |  22,248 B |   28616 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     30,962.28 ns |     309.061 ns |    273.975 ns |   6,770 B |    4029 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    109,919.11 ns |     256.470 ns |    227.354 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    134,021.95 ns |     499.384 ns |    442.691 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    150,595.72 ns |     488.979 ns |    433.467 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    158,684.73 ns |     608.336 ns |    507.988 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    884,017.42 ns |   2,908.925 ns |  2,271.097 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  1,359,188.16 ns |   1,926.655 ns |  1,802.194 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,673,929.35 ns |  22,283.962 ns | 19,754.151 ns |  22,248 B |   54656 B |
|                                               |              |                  |                |               |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    316,418.32 ns |   1,714.166 ns |  1,431.406 ns |   6,801 B |    4035 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,111,640.49 ns |   4,181.162 ns |  3,911.062 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,365,526.56 ns |   8,045.530 ns |  6,281.420 ns |   8,894 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,513,294.53 ns |   5,044.722 ns |  3,938.587 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,595,864.96 ns |   3,670.072 ns |  3,432.988 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  8,853,800.42 ns |  24,265.860 ns | 20,263.092 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 13,597,141.63 ns |  35,668.169 ns | 31,618.903 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 98,750,455.00 ns | 125,563.665 ns | 98,031.850 ns |  22,282 B |  546840 B |