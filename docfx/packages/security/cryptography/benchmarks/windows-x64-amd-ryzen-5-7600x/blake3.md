| Description                                   | TestDataSize | Mean             | Error          | StdDev         | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.02 ns |       0.267 ns |       0.236 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         60.90 ns |       0.503 ns |       0.471 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         62.05 ns |       0.593 ns |       0.495 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         62.09 ns |       0.752 ns |       0.703 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         62.23 ns |       0.405 ns |       0.339 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         81.15 ns |       0.653 ns |       0.611 ns |   5,111 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |        297.94 ns |       2.052 ns |       1.713 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        593.04 ns |       5.110 ns |       4.780 ns |  21,324 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         97.29 ns |       0.804 ns |       0.712 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        105.80 ns |       0.532 ns |       0.498 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        107.23 ns |       0.799 ns |       0.667 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        107.27 ns |       0.638 ns |       0.597 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        107.30 ns |       0.636 ns |       0.564 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        121.28 ns |       0.768 ns |       0.719 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        581.49 ns |       3.883 ns |       3.443 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,277.40 ns |       5.844 ns |       4.880 ns |  21,990 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         94.26 ns |       1.309 ns |       1.160 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        105.49 ns |       0.465 ns |       0.435 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        107.32 ns |       0.615 ns |       0.545 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        107.64 ns |       0.896 ns |       0.794 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        107.84 ns |       1.229 ns |       1.150 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |        117.54 ns |       0.467 ns |       0.437 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        581.85 ns |       4.500 ns |       3.989 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,290.91 ns |       8.395 ns |       7.442 ns |  21,985 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        148.67 ns |       1.006 ns |       0.941 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        159.73 ns |       0.977 ns |       0.913 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        159.79 ns |       0.628 ns |       0.556 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        160.09 ns |       1.164 ns |       1.032 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        167.66 ns |       0.492 ns |       0.411 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        168.48 ns |       1.522 ns |       1.423 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        859.76 ns |       5.371 ns |       5.024 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,904.13 ns |       9.573 ns |       8.955 ns |  21,985 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        752.34 ns |       6.004 ns |       5.322 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        817.75 ns |       1.948 ns |       1.521 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        818.83 ns |       5.101 ns |       4.771 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        837.53 ns |       4.794 ns |       4.484 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        837.61 ns |       4.087 ns |       3.823 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        837.86 ns |       5.393 ns |       4.781 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      4,503.81 ns |      31.960 ns |      29.896 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |      9,869.41 ns |      45.506 ns |      42.566 ns |  22,003 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        749.99 ns |       1.959 ns |       1.832 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        812.18 ns |       2.024 ns |       1.794 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        813.22 ns |       4.867 ns |       4.552 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        836.79 ns |       4.133 ns |       3.664 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        837.73 ns |       4.058 ns |       3.597 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        837.74 ns |       5.178 ns |       4.590 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      4,500.55 ns |      10.472 ns |       8.745 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,626.31 ns |      25.461 ns |      22.571 ns |  22,012 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        824.81 ns |       2.378 ns |       2.224 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        947.03 ns |       3.464 ns |       2.893 ns |   4,875 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        962.86 ns |      18.586 ns |      22.826 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        976.42 ns |       3.309 ns |       3.095 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        977.03 ns |       4.652 ns |       4.124 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        977.70 ns |       3.163 ns |       2.959 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      5,081.12 ns |      20.181 ns |      18.877 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     10,638.37 ns |      36.184 ns |      33.846 ns |  22,309 B |      56 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,010.91 ns |       3.685 ns |       3.267 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,362.57 ns |      15.447 ns |      12.899 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,366.15 ns |       9.333 ns |       8.274 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      2,171.62 ns |      25.887 ns |      24.215 ns |  18,024 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,499.30 ns |      10.728 ns |      10.035 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,602.99 ns |      49.453 ns |      64.303 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |     19,095.37 ns |     106.980 ns |      94.835 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     40,960.54 ns |     147.706 ns |     138.164 ns |  22,230 B |     168 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,162.13 ns |       6.791 ns |       5.671 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,440.08 ns |       6.331 ns |       5.922 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,544.59 ns |       3.593 ns |       3.361 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,553.68 ns |       7.987 ns |       7.081 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      2,462.76 ns |      12.719 ns |      11.897 ns |  18,201 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,248.38 ns |      86.470 ns |      84.925 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     38,557.41 ns |     283.820 ns |     265.485 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     80,786.79 ns |     350.150 ns |     327.530 ns |  22,243 B |     392 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,567.59 ns |      13.471 ns |      11.249 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,045.20 ns |      16.977 ns |      15.050 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,056.09 ns |      12.318 ns |      10.920 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,184.66 ns |      11.104 ns |      10.386 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      3,244.94 ns |      18.556 ns |      17.357 ns |  18,539 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      8,879.39 ns |      41.979 ns |      37.213 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     47,261.66 ns |     269.870 ns |     252.436 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |     98,847.49 ns |     503.168 ns |     470.664 ns |  22,269 B |     504 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,240.93 ns |      22.845 ns |      19.076 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      9,698.18 ns |      39.709 ns |      35.201 ns |   8,630 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |     10,643.38 ns |      56.154 ns |      46.891 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,945.45 ns |      44.394 ns |      41.526 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     14,130.37 ns |      39.670 ns |      35.167 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     57,909.93 ns |     202.675 ns |     169.243 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |    309,927.53 ns |   2,020.673 ns |   1,890.138 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    645,816.48 ns |   2,465.811 ns |   2,306.521 ns |  22,258 B |    3528 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,241.68 ns |      43.577 ns |      38.630 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     14,695.49 ns |      61.080 ns |      51.004 ns |   8,950 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     16,481.48 ns |      81.203 ns |      75.957 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |     17,307.93 ns |     150.737 ns |     141.000 ns |  30,473 B |    2255 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,664.26 ns |     111.092 ns |      98.480 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     88,438.41 ns |     383.640 ns |     358.858 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    472,464.23 ns |   1,536.438 ns |   1,282.996 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |    993,272.75 ns |   6,415.753 ns |   6,001.300 ns |  22,244 B |    5432 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,369.43 ns |      66.264 ns |      61.984 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     17,464.67 ns |      81.984 ns |      68.461 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     18,688.06 ns |      47.935 ns |      40.028 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |     19,035.58 ns |      59.495 ns |      49.681 ns |  30,268 B |    2611 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,169.80 ns |     109.820 ns |     102.726 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    115,886.21 ns |     656.346 ns |     613.947 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    620,703.00 ns |   3,520.813 ns |   2,940.039 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,296,233.44 ns |   7,726.865 ns |   6,452.282 ns |  22,257 B |    7112 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     25,052.19 ns |     318.607 ns |     298.025 ns |  30,680 B |    2912 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,540.43 ns |      88.846 ns |      74.190 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     34,787.50 ns |     185.432 ns |     154.844 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     39,898.00 ns |     208.620 ns |     174.207 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     42,450.01 ns |     225.915 ns |     188.649 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    231,978.00 ns |     758.081 ns |     709.110 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |  1,243,375.29 ns |   5,094.159 ns |   4,253.853 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,626,321.07 ns |   7,726.893 ns |   6,849.689 ns |  22,257 B |   14280 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     29,659.77 ns |     490.772 ns |     435.057 ns |  30,229 B |    3688 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     57,077.97 ns |     215.404 ns |     190.950 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     72,054.00 ns |     235.991 ns |     197.063 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     76,883.36 ns |     436.072 ns |     364.140 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     84,334.14 ns |     399.980 ns |     354.572 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    464,429.21 ns |   1,458.496 ns |   1,364.278 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |  2,483,128.58 ns |  10,531.160 ns |   8,793.995 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,284,109.21 ns |  17,480.610 ns |  15,496.105 ns |  22,244 B |   28616 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     37,762.19 ns |     186.771 ns |     155.962 ns |  29,903 B |    4121 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    110,670.90 ns |     404.293 ns |     378.176 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    135,296.69 ns |     840.861 ns |     786.542 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    138,439.90 ns |     829.736 ns |     776.136 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    157,280.75 ns |     367.244 ns |     306.665 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    885,601.14 ns |   2,585.105 ns |   2,291.628 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  4,734,139.29 ns |  24,782.167 ns |  21,968.745 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,723,584.04 ns |  74,151.756 ns |  65,733.600 ns |  22,244 B |   54656 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    299,292.47 ns |   2,363.306 ns |   2,210.638 ns |  37,360 B |    4032 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,102,535.48 ns |   5,440.191 ns |   4,542.806 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,401,352.41 ns |  21,064.999 ns |  16,446.166 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,497,424.04 ns |   7,683.362 ns |   7,187.021 ns |   8,894 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,587,805.38 ns |   7,355.582 ns |   6,142.244 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  8,881,492.92 ns |  52,379.823 ns |  48,996.119 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 47,499,029.70 ns | 397,539.632 ns | 371,858.819 ns |        NA |    1121 B |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 96,380,864.29 ns | 572,373.585 ns | 507,394.275 ns |  22,370 B |  546840 B |