| Description                                   | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.45 ns |       0.251 ns |       0.210 ns |         56.39 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         61.99 ns |       0.321 ns |       0.284 ns |         61.97 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         62.29 ns |       0.484 ns |       0.453 ns |         62.10 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         62.29 ns |       0.345 ns |       0.306 ns |         62.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         62.56 ns |       1.018 ns |       0.903 ns |         62.41 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         76.31 ns |       1.348 ns |       1.443 ns |         76.13 ns |   5,115 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |         83.46 ns |       0.241 ns |       0.213 ns |         83.41 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        625.00 ns |       5.463 ns |       4.842 ns |        622.22 ns |  21,324 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         98.90 ns |       1.841 ns |       1.632 ns |         98.54 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        106.78 ns |       1.154 ns |       1.185 ns |        106.36 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        107.72 ns |       0.357 ns |       0.279 ns |        107.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        107.93 ns |       0.453 ns |       0.378 ns |        107.90 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        108.57 ns |       1.161 ns |       0.906 ns |        108.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        121.69 ns |       0.304 ns |       0.269 ns |        121.59 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        170.37 ns |       1.170 ns |       1.094 ns |        170.32 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,339.86 ns |      14.999 ns |      14.031 ns |      1,332.29 ns |  21,991 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         94.98 ns |       0.991 ns |       0.927 ns |         94.95 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        108.04 ns |       0.776 ns |       0.648 ns |        107.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        108.14 ns |       0.768 ns |       0.600 ns |        108.22 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        108.33 ns |       0.977 ns |       0.816 ns |        108.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        108.91 ns |       2.162 ns |       2.959 ns |        108.02 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |        118.17 ns |       0.203 ns |       0.180 ns |        118.16 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        170.86 ns |       0.520 ns |       0.461 ns |        170.80 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,330.69 ns |       4.485 ns |       3.745 ns |      1,330.19 ns |  21,985 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        153.50 ns |       2.787 ns |       4.807 ns |        151.41 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        161.27 ns |       1.167 ns |       0.974 ns |        161.07 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        161.62 ns |       1.470 ns |       1.375 ns |        161.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        162.75 ns |       1.299 ns |       1.215 ns |        162.80 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        162.97 ns |       1.850 ns |       1.731 ns |        162.36 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        169.45 ns |       0.747 ns |       0.699 ns |        169.55 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        249.13 ns |       3.678 ns |       3.440 ns |        248.98 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,952.93 ns |      17.890 ns |      15.859 ns |      1,954.12 ns |  21,985 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        769.75 ns |      15.207 ns |      13.481 ns |        764.12 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        791.19 ns |       6.738 ns |       5.973 ns |        790.49 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        828.11 ns |       6.665 ns |       5.566 ns |        828.37 ns |   3,544 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        846.68 ns |       4.912 ns |       4.102 ns |        845.47 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        849.23 ns |       8.198 ns |       7.268 ns |        847.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        851.39 ns |       9.592 ns |       8.010 ns |        848.80 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      1,294.98 ns |       6.564 ns |       5.819 ns |      1,293.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,559.96 ns |      56.626 ns |      50.197 ns |     10,532.07 ns |  22,003 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        754.21 ns |       2.697 ns |       2.523 ns |        754.91 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        787.34 ns |      15.305 ns |      13.567 ns |        786.83 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        819.64 ns |       4.433 ns |       3.702 ns |        818.20 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        841.39 ns |       1.874 ns |       1.565 ns |        841.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        842.00 ns |       2.831 ns |       2.210 ns |        842.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        844.88 ns |       7.668 ns |       6.403 ns |        843.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      1,293.98 ns |       4.021 ns |       3.565 ns |      1,293.28 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,806.23 ns |      17.996 ns |      15.953 ns |      9,806.67 ns |  22,012 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        829.04 ns |       1.378 ns |       1.151 ns |        828.99 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        943.43 ns |       3.735 ns |       3.311 ns |        943.60 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        955.06 ns |       5.254 ns |       4.657 ns |        954.90 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        993.77 ns |      12.113 ns |      11.331 ns |        988.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        996.02 ns |      14.525 ns |      12.129 ns |        992.89 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |      1,001.67 ns |      19.150 ns |      18.808 ns |        996.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      1,492.95 ns |       6.398 ns |       5.343 ns |      1,491.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     10,902.92 ns |      18.099 ns |      16.930 ns |     10,901.50 ns |  22,329 B |      56 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        779.42 ns |       1.781 ns |       1.666 ns |        779.30 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,218.63 ns |       3.063 ns |       2.392 ns |      1,218.54 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,228.33 ns |       7.200 ns |       6.012 ns |      1,227.66 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,667.06 ns |       4.913 ns |       4.595 ns |      1,666.28 ns |  11,378 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,735.85 ns |       8.453 ns |       7.058 ns |      1,733.50 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,774.14 ns |       8.875 ns |       7.867 ns |      1,774.07 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      2,711.83 ns |      34.803 ns |      29.062 ns |      2,698.16 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     20,863.59 ns |      49.935 ns |      41.698 ns |     20,873.10 ns |  22,238 B |      56 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,019.21 ns |       4.039 ns |       3.778 ns |      1,020.29 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,324.31 ns |       6.579 ns |       6.154 ns |      1,321.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,331.51 ns |       4.661 ns |       4.360 ns |      1,329.92 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      2,161.34 ns |      27.786 ns |      24.632 ns |      2,154.92 ns |  18,024 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,515.02 ns |       6.347 ns |       4.956 ns |      3,514.86 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,586.74 ns |      10.313 ns |       8.612 ns |      3,584.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |      5,478.68 ns |      23.093 ns |      21.601 ns |      5,472.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     40,480.55 ns |      45.565 ns |      38.049 ns |     40,478.88 ns |  22,233 B |     168 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,432.60 ns |       3.658 ns |       3.422 ns |      1,431.62 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,434.02 ns |       6.156 ns |       5.758 ns |      1,432.73 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,821.97 ns |       8.718 ns |       6.806 ns |      1,822.38 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      3,059.27 ns |      55.715 ns |      52.116 ns |      3,073.28 ns |  18,387 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,258.93 ns |      15.207 ns |      11.872 ns |      5,259.86 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      5,392.84 ns |      13.115 ns |      11.626 ns |      5,394.02 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |      8,259.75 ns |      20.424 ns |      17.055 ns |      8,255.29 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     61,267.04 ns |     339.617 ns |     301.061 ns |     61,225.55 ns |  22,255 B |     280 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,167.00 ns |       7.029 ns |       6.575 ns |      1,167.55 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,479.99 ns |       4.830 ns |       4.518 ns |      1,479.86 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,560.24 ns |      11.622 ns |      10.303 ns |      1,559.19 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,586.69 ns |      29.705 ns |      26.333 ns |      1,580.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      2,705.34 ns |      33.589 ns |      29.776 ns |      2,692.54 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,246.84 ns |      55.797 ns |      49.462 ns |      7,232.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     11,130.67 ns |     125.588 ns |     111.331 ns |     11,078.94 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     83,929.52 ns |     172.153 ns |     134.405 ns |     83,927.30 ns |  22,255 B |     392 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,594.90 ns |      30.663 ns |      25.605 ns |      2,590.62 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,078.80 ns |      11.615 ns |       9.068 ns |      3,076.62 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      3,278.97 ns |       8.013 ns |       7.104 ns |      3,277.27 ns |  18,537 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,287.03 ns |       5.498 ns |       4.874 ns |      3,288.17 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,363.49 ns |       8.190 ns |       7.661 ns |      3,362.55 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      8,951.64 ns |     138.817 ns |     123.057 ns |      8,905.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     13,529.51 ns |      20.561 ns |      18.227 ns |     13,526.66 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    100,929.20 ns |     472.507 ns |     394.564 ns |    100,848.46 ns |  22,267 B |     504 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,240.61 ns |      20.411 ns |      19.092 ns |      7,242.85 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      8,790.41 ns |      55.526 ns |      46.367 ns |      8,779.03 ns |   8,626 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |      9,865.82 ns |      45.994 ns |      38.407 ns |      9,851.40 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,722.54 ns |      62.176 ns |      48.543 ns |     11,727.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     13,907.48 ns |      59.531 ns |      52.773 ns |     13,895.35 ns |  18,195 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     58,028.15 ns |     146.403 ns |     129.783 ns |     58,038.04 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |     88,721.96 ns |     264.992 ns |     234.908 ns |     88,653.14 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    652,357.98 ns |     967.882 ns |     858.002 ns |    652,374.56 ns |  22,258 B |    3528 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,472.22 ns |     247.896 ns |     243.467 ns |     12,369.05 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |     16,402.29 ns |     193.571 ns |     171.595 ns |     16,439.17 ns |  30,572 B |    2315 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     16,537.84 ns |      86.772 ns |      67.746 ns |     16,539.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     16,883.47 ns |     109.009 ns |      91.027 ns |     16,874.55 ns |   8,923 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,961.23 ns |     242.662 ns |     226.986 ns |     17,857.39 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     88,788.63 ns |     256.113 ns |     213.866 ns |     88,786.56 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    135,758.13 ns |     685.466 ns |     607.648 ns |    135,455.33 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |  1,066,084.71 ns |  12,494.845 ns |  15,801.979 ns |  1,059,675.39 ns |  22,247 B |    5432 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,438.77 ns |      66.638 ns |      62.333 ns |     14,430.63 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     17,573.56 ns |      46.754 ns |      36.502 ns |     17,574.37 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     19,075.23 ns |     195.036 ns |     172.895 ns |     19,046.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |     19,527.38 ns |     128.519 ns |     120.217 ns |     19,575.31 ns |  30,636 B |    2608 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,085.10 ns |      91.130 ns |      71.149 ns |     22,095.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    116,436.78 ns |     304.254 ns |     269.713 ns |    116,385.04 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    180,896.74 ns |   3,055.462 ns |   3,137.735 ns |    180,181.65 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,368,966.05 ns |   4,604.635 ns |   3,845.078 ns |  1,367,000.98 ns |  22,258 B |    7112 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     25,408.19 ns |     118.709 ns |     111.041 ns |     25,410.42 ns |  30,315 B |    2901 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,693.49 ns |      91.179 ns |      85.289 ns |     28,694.48 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     36,569.59 ns |     127.947 ns |      99.893 ns |     36,566.56 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     38,649.51 ns |     123.712 ns |     109.667 ns |     38,631.11 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     42,801.44 ns |     462.382 ns |     386.110 ns |     42,681.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    235,793.01 ns |   1,582.208 ns |   1,235.284 ns |    235,830.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |    361,131.99 ns |   3,770.496 ns |   3,342.446 ns |    360,377.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,706,375.45 ns |  11,456.992 ns |   9,567.107 ns |  2,706,958.20 ns |  22,253 B |   14280 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     29,687.71 ns |     562.180 ns |     601.527 ns |     29,798.86 ns |  30,395 B |    3702 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     58,232.91 ns |     755.612 ns |     706.800 ns |     58,128.05 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     78,428.77 ns |   1,506.359 ns |   1,546.919 ns |     77,706.76 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     81,194.44 ns |   1,613.410 ns |   1,347.271 ns |     81,158.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     85,369.60 ns |   1,290.784 ns |   1,144.247 ns |     84,979.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    475,638.83 ns |   4,486.667 ns |   4,196.831 ns |    475,969.19 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |    723,335.57 ns |   6,011.876 ns |   5,329.371 ns |    722,454.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,330,130.73 ns |  12,088.034 ns |  11,307.155 ns |  5,329,415.62 ns |  22,258 B |   28616 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     39,156.01 ns |     453.972 ns |     424.646 ns |     39,218.29 ns |  29,898 B |    4152 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    112,612.83 ns |   2,150.522 ns |   2,112.101 ns |    111,815.59 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    139,946.76 ns |   1,733.943 ns |   1,621.932 ns |    139,041.16 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    149,597.23 ns |   2,198.326 ns |   1,948.759 ns |    148,520.67 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    161,596.51 ns |   2,910.118 ns |   2,579.744 ns |    160,766.53 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    897,281.70 ns |  15,630.968 ns |  13,052.566 ns |    891,093.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  1,365,291.17 ns |   8,843.890 ns |   7,385.048 ns |  1,363,510.94 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,873,685.94 ns |  68,449.689 ns |  60,678.867 ns |  9,846,896.09 ns |  22,244 B |   54656 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    330,173.81 ns |   6,810.990 ns |  19,867.978 ns |    321,363.26 ns |  37,368 B |    4012 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,142,286.28 ns |  22,477.944 ns |  36,931.909 ns |  1,126,411.33 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,402,412.53 ns |  25,170.636 ns |  40,645.889 ns |  1,386,830.18 ns |   8,899 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,457,125.95 ns |  28,514.142 ns |  44,393.087 ns |  1,451,406.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,645,578.05 ns |  32,641.124 ns |  40,086.235 ns |  1,635,156.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  9,008,076.56 ns | 113,775.949 ns |  95,008.070 ns |  8,999,889.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 13,868,526.61 ns | 181,567.506 ns | 169,838.358 ns | 13,835,546.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 97,979,373.85 ns | 545,675.739 ns | 455,663.956 ns | 97,854,980.00 ns |  22,599 B |  546840 B |