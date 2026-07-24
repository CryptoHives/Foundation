| Description                                   | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.38 ns |       0.112 ns |       0.105 ns |         56.37 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         61.03 ns |       0.298 ns |       0.278 ns |         60.97 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         62.18 ns |       0.432 ns |       0.361 ns |         62.11 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         62.42 ns |       0.306 ns |       0.287 ns |         62.41 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         62.56 ns |       0.396 ns |       0.309 ns |         62.53 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         75.94 ns |       0.355 ns |       0.332 ns |         75.93 ns |   5,115 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |        308.41 ns |       3.349 ns |       2.969 ns |        308.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        613.01 ns |       6.542 ns |       5.799 ns |        613.97 ns |  21,320 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         97.85 ns |       0.458 ns |       0.382 ns |         97.88 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        106.20 ns |       0.682 ns |       0.604 ns |        105.91 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        108.18 ns |       0.424 ns |       0.354 ns |        108.12 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        108.65 ns |       0.473 ns |       0.442 ns |        108.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        108.93 ns |       1.104 ns |       1.033 ns |        108.61 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        121.58 ns |       0.383 ns |       0.358 ns |        121.60 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        600.37 ns |       4.288 ns |       4.011 ns |        599.39 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,308.33 ns |       4.917 ns |       4.359 ns |      1,307.27 ns |  21,991 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         93.90 ns |       0.423 ns |       0.331 ns |         93.92 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        106.47 ns |       1.009 ns |       0.895 ns |        106.03 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        107.55 ns |       0.297 ns |       0.232 ns |        107.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        108.09 ns |       0.372 ns |       0.311 ns |        108.03 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        109.08 ns |       2.073 ns |       2.768 ns |        107.98 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |        117.55 ns |       0.237 ns |       0.198 ns |        117.49 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        590.02 ns |       2.185 ns |       1.937 ns |        589.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,325.50 ns |       1.729 ns |       1.533 ns |      1,325.32 ns |  21,985 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        149.09 ns |       0.618 ns |       0.516 ns |        149.15 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        160.22 ns |       0.575 ns |       0.510 ns |        160.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        160.64 ns |       1.201 ns |       1.065 ns |        160.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        160.74 ns |       0.697 ns |       0.618 ns |        161.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        162.46 ns |       0.839 ns |       0.655 ns |        162.38 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        167.93 ns |       0.375 ns |       0.293 ns |        167.96 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        877.74 ns |       2.606 ns |       2.310 ns |        877.47 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,965.04 ns |       6.422 ns |       5.693 ns |      1,965.53 ns |  21,984 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        766.14 ns |      14.256 ns |      13.335 ns |        759.24 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        788.82 ns |       4.122 ns |       3.856 ns |        787.51 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        828.08 ns |       2.932 ns |       2.448 ns |        827.73 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        842.45 ns |       4.126 ns |       3.221 ns |        841.77 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        845.15 ns |       3.953 ns |       3.301 ns |        844.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        845.39 ns |       5.016 ns |       4.188 ns |        845.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      4,612.73 ns |      39.379 ns |      34.908 ns |      4,602.72 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,318.56 ns |      33.128 ns |      29.367 ns |     10,305.93 ns |  22,003 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        756.43 ns |       4.196 ns |       3.504 ns |        755.90 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        798.19 ns |      12.197 ns |      11.409 ns |        797.17 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        820.29 ns |       5.200 ns |       4.343 ns |        819.07 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        844.60 ns |       3.748 ns |       3.130 ns |        843.41 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        845.96 ns |       5.178 ns |       4.324 ns |        844.60 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        853.90 ns |      16.309 ns |      15.255 ns |        845.22 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      4,683.36 ns |      30.511 ns |      25.478 ns |      4,672.29 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,913.68 ns |      28.098 ns |      23.463 ns |      9,913.31 ns |  22,012 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        831.51 ns |       1.929 ns |       1.611 ns |        831.93 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        939.07 ns |       3.526 ns |       3.126 ns |        938.26 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        958.30 ns |       4.936 ns |       4.122 ns |        957.20 ns |   4,883 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        982.92 ns |       3.074 ns |       2.725 ns |        982.17 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        982.97 ns |       3.909 ns |       3.264 ns |        981.97 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        983.69 ns |       5.544 ns |       4.629 ns |        982.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      5,215.37 ns |      23.075 ns |      20.455 ns |      5,210.65 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     11,127.90 ns |      15.060 ns |      12.576 ns |     11,130.88 ns |  22,329 B |      56 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        789.86 ns |       2.780 ns |       2.601 ns |        789.86 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,220.41 ns |       3.772 ns |       3.150 ns |      1,220.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,222.63 ns |       4.262 ns |       3.559 ns |      1,223.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,669.26 ns |       9.569 ns |       8.951 ns |      1,668.19 ns |  11,378 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,760.01 ns |      34.571 ns |      38.426 ns |      1,739.88 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,775.77 ns |       8.519 ns |       7.113 ns |      1,774.83 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      9,482.73 ns |      18.731 ns |      16.604 ns |      9,479.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     19,967.02 ns |      37.344 ns |      33.104 ns |     19,959.60 ns |  22,238 B |      56 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,030.80 ns |       3.258 ns |       2.888 ns |      1,030.92 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,333.42 ns |       7.987 ns |       7.471 ns |      1,331.89 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,350.33 ns |      25.496 ns |      23.849 ns |      1,337.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      2,183.85 ns |      18.104 ns |      16.934 ns |      2,186.36 ns |  18,024 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,503.06 ns |      20.986 ns |      18.604 ns |      3,497.41 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,601.69 ns |       9.755 ns |       8.647 ns |      3,600.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |     19,277.32 ns |      27.534 ns |      24.408 ns |     19,276.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     41,767.55 ns |      50.250 ns |      44.545 ns |     41,769.42 ns |  22,230 B |     168 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,444.60 ns |       6.153 ns |       5.138 ns |      1,444.77 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,463.21 ns |      16.632 ns |      14.744 ns |      1,458.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,823.78 ns |       4.996 ns |       3.900 ns |      1,823.25 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      3,100.99 ns |      42.241 ns |      37.446 ns |      3,115.07 ns |  18,387 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,268.28 ns |      18.028 ns |      16.864 ns |      5,266.50 ns |   7,592 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      5,428.89 ns |      30.694 ns |      28.711 ns |      5,431.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |     29,011.31 ns |      63.670 ns |      53.167 ns |     28,991.71 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     59,908.60 ns |     113.141 ns |     100.296 ns |     59,910.97 ns |  22,243 B |     280 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,172.29 ns |       4.857 ns |       4.544 ns |      1,171.87 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,452.49 ns |       6.730 ns |       5.620 ns |      1,452.12 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,545.86 ns |       4.045 ns |       3.377 ns |      1,546.22 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,554.16 ns |       5.864 ns |       4.897 ns |      1,553.05 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      2,469.58 ns |      15.076 ns |      12.589 ns |      2,465.46 ns |  18,195 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,215.13 ns |      26.509 ns |      24.797 ns |      7,216.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     38,798.87 ns |      83.917 ns |      74.391 ns |     38,793.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     83,352.83 ns |     165.735 ns |     129.395 ns |     83,321.69 ns |  22,255 B |     392 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,602.59 ns |      49.908 ns |      38.965 ns |      2,589.04 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,037.24 ns |      12.184 ns |      11.397 ns |      3,037.98 ns |   7,764 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,086.45 ns |      11.063 ns |       9.807 ns |      3,088.08 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,147.57 ns |      12.849 ns |      11.390 ns |      3,143.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      3,436.54 ns |      20.077 ns |      15.675 ns |      3,440.25 ns |  18,537 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      8,912.12 ns |      70.117 ns |      58.551 ns |      8,901.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     47,757.79 ns |     172.482 ns |     161.339 ns |     47,683.54 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    102,707.17 ns |     582.847 ns |     486.704 ns |    102,488.17 ns |  22,261 B |     504 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,285.17 ns |      35.505 ns |      29.648 ns |      7,275.23 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |      9,774.65 ns |     155.791 ns |     138.105 ns |      9,722.72 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      9,799.22 ns |      40.923 ns |      38.280 ns |      9,790.10 ns |   8,622 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,893.23 ns |      43.977 ns |      41.136 ns |     11,899.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     13,897.19 ns |      39.081 ns |      32.634 ns |     13,898.93 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     58,100.80 ns |     162.674 ns |     144.207 ns |     58,090.71 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |    312,733.99 ns |   1,337.248 ns |   1,185.435 ns |    312,338.38 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    661,321.16 ns |   1,941.729 ns |   1,721.293 ns |    661,067.72 ns |  22,258 B |    3528 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,284.39 ns |      26.327 ns |      21.984 ns |     12,286.37 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     16,537.20 ns |     107.573 ns |     100.624 ns |     16,506.33 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     16,749.81 ns |      61.164 ns |      54.221 ns |     16,754.67 ns |   8,943 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |     17,507.16 ns |     210.523 ns |     196.924 ns |     17,532.07 ns |  30,940 B |    2309 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,804.18 ns |     178.021 ns |     157.811 ns |     17,784.79 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     88,957.29 ns |     363.559 ns |     340.073 ns |     88,871.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    477,716.38 ns |     825.677 ns |     689.478 ns |    477,488.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |  1,017,525.78 ns |   2,928.281 ns |   2,739.116 ns |  1,016,946.48 ns |  22,247 B |    5432 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,644.38 ns |     186.342 ns |     155.604 ns |     14,647.62 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     18,788.32 ns |     125.994 ns |     111.690 ns |     18,762.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     19,647.61 ns |     307.871 ns |     257.086 ns |     19,516.27 ns |   8,621 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |     19,959.49 ns |      92.898 ns |      86.897 ns |     19,976.52 ns |  30,243 B |    2593 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,410.87 ns |     289.880 ns |     271.154 ns |     22,305.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    116,811.20 ns |     457.288 ns |     427.748 ns |    116,720.76 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    628,414.19 ns |   1,149.865 ns |     960.189 ns |    627,935.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,351,912.08 ns |  10,235.057 ns |   9,073.111 ns |  1,349,564.26 ns |  22,258 B |    7112 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     25,251.67 ns |     253.910 ns |     237.508 ns |     25,214.40 ns |  30,303 B |    2895 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,833.34 ns |     325.635 ns |     288.667 ns |     28,708.55 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     35,190.17 ns |     387.916 ns |     362.857 ns |     35,078.28 ns |   8,614 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     40,963.35 ns |     673.191 ns |     826.739 ns |     40,707.05 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     43,880.78 ns |     459.064 ns |     383.339 ns |     43,906.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    239,735.73 ns |   3,341.201 ns |   2,790.054 ns |    238,669.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |  1,257,744.38 ns |   6,889.679 ns |   5,753.194 ns |  1,256,295.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,691,146.01 ns |   9,293.619 ns |   8,238.551 ns |  2,688,453.32 ns |  22,258 B |   14280 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     29,410.84 ns |     549.292 ns |     513.808 ns |     29,348.48 ns |  30,377 B |    3567 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     59,284.94 ns |   1,091.717 ns |   1,021.193 ns |     59,021.17 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     72,138.46 ns |   1,198.686 ns |   1,515.954 ns |     71,935.11 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     82,145.51 ns |   1,634.411 ns |   2,988.613 ns |     80,697.02 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     84,452.00 ns |     840.552 ns |     786.253 ns |     84,748.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    469,801.55 ns |   3,954.767 ns |   3,699.291 ns |    469,340.38 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |  2,506,514.03 ns |  14,540.041 ns |  12,141.593 ns |  2,502,550.39 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,300,102.29 ns |  20,791.538 ns |  18,431.157 ns |  5,298,855.08 ns |  22,249 B |   28616 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     38,580.26 ns |     489.494 ns |     457.873 ns |     38,403.87 ns |  29,900 B |    4132 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    112,064.81 ns |   1,242.307 ns |   1,101.273 ns |    112,526.17 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    152,071.69 ns |   2,016.242 ns |   1,885.994 ns |    152,416.03 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    155,271.00 ns |   2,879.216 ns |   2,693.220 ns |    155,054.74 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    163,418.08 ns |   3,131.505 ns |   2,929.211 ns |    164,322.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    912,903.42 ns |  15,059.380 ns |  12,575.264 ns |    913,684.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  4,896,425.67 ns |  81,871.807 ns | 117,418.109 ns |  4,850,513.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,813,437.86 ns |  19,251.030 ns |  16,075.482 ns |  9,812,460.94 ns |  22,248 B |   54656 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    333,586.76 ns |   6,568.918 ns |  14,418.936 ns |    331,811.33 ns |  37,351 B |    3925 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,145,292.22 ns |  21,675.133 ns |  22,258.766 ns |  1,141,166.41 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,447,261.22 ns |  28,585.756 ns |  52,985.536 ns |  1,434,678.71 ns |   8,894 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,633,466.81 ns |  32,210.271 ns |  62,823.665 ns |  1,622,274.80 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,683,254.97 ns |  32,848.206 ns |  39,103.456 ns |  1,669,657.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  9,037,504.48 ns | 124,919.960 ns | 116,850.208 ns |  9,042,079.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 47,983,048.70 ns | 132,827.942 ns | 117,748.511 ns | 47,955,000.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 98,401,130.00 ns | 256,642.983 ns | 200,369.960 ns | 98,395,760.00 ns |  22,370 B |  546840 B |