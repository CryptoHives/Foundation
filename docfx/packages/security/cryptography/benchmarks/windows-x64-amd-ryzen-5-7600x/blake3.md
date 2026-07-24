| Description                                   | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.11 ns |       0.177 ns |       0.148 ns |         56.09 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         61.55 ns |       0.208 ns |       0.195 ns |         61.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         62.16 ns |       0.205 ns |       0.227 ns |         62.14 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         62.68 ns |       1.199 ns |       1.063 ns |         62.26 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         62.71 ns |       1.209 ns |       1.294 ns |         62.42 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         74.92 ns |       0.291 ns |       0.258 ns |         74.78 ns |   5,111 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |        305.14 ns |       2.522 ns |       2.106 ns |        304.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        624.45 ns |       4.655 ns |       4.127 ns |        622.59 ns |  21,324 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         97.87 ns |       0.786 ns |       0.657 ns |         97.79 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        106.94 ns |       0.932 ns |       0.779 ns |        106.83 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        108.55 ns |       1.112 ns |       0.986 ns |        108.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        108.88 ns |       1.470 ns |       1.303 ns |        108.73 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        108.93 ns |       1.206 ns |       1.069 ns |        108.72 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        121.75 ns |       0.363 ns |       0.322 ns |        121.75 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        602.70 ns |       9.700 ns |       8.598 ns |        599.05 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,321.92 ns |       3.653 ns |       3.417 ns |      1,320.71 ns |  21,991 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         94.57 ns |       1.157 ns |       1.083 ns |         94.27 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        106.64 ns |       1.102 ns |       0.977 ns |        106.10 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        108.47 ns |       0.892 ns |       0.791 ns |        108.63 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        111.29 ns |       2.125 ns |       5.369 ns |        109.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        122.75 ns |       1.291 ns |       1.208 ns |        122.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |        126.93 ns |       0.420 ns |       0.393 ns |        126.95 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        597.18 ns |       1.763 ns |       1.649 ns |        596.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,319.79 ns |       2.763 ns |       2.584 ns |      1,319.59 ns |  21,985 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        151.27 ns |       2.571 ns |       2.147 ns |        150.81 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        161.86 ns |       1.589 ns |       1.486 ns |        161.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        162.07 ns |       2.538 ns |       2.374 ns |        161.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        163.35 ns |       1.097 ns |       0.972 ns |        163.03 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        163.78 ns |       3.288 ns |       3.786 ns |        163.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        177.48 ns |       0.363 ns |       0.322 ns |        177.40 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        882.57 ns |       3.263 ns |       2.893 ns |        881.76 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,975.79 ns |       3.243 ns |       3.033 ns |      1,975.56 ns |  21,984 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        760.63 ns |       6.260 ns |       5.550 ns |        759.52 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        803.52 ns |       9.850 ns |       9.213 ns |        803.35 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        838.21 ns |      14.742 ns |      13.790 ns |        833.07 ns |   3,544 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        845.82 ns |       6.277 ns |       5.242 ns |        844.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        846.15 ns |       7.367 ns |       5.751 ns |        848.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        847.52 ns |       6.555 ns |       6.131 ns |        846.90 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      4,617.20 ns |      16.464 ns |      14.595 ns |      4,616.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,583.21 ns |      19.928 ns |      16.641 ns |     10,576.74 ns |  22,003 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        758.90 ns |       7.759 ns |       7.258 ns |        756.83 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        805.83 ns |      15.051 ns |      14.079 ns |        806.05 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        825.56 ns |       6.444 ns |       5.712 ns |        826.67 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        845.15 ns |       7.202 ns |       6.737 ns |        842.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        846.65 ns |       6.312 ns |       5.596 ns |        847.61 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        848.44 ns |       9.888 ns |       8.257 ns |        848.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      4,623.56 ns |      14.736 ns |      11.505 ns |      4,623.94 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,843.41 ns |      15.524 ns |      13.761 ns |      9,844.44 ns |  22,012 B |         - |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        836.01 ns |       7.645 ns |       7.152 ns |        836.06 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        942.92 ns |       3.787 ns |       3.357 ns |        941.91 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        964.28 ns |      18.141 ns |      15.149 ns |        957.78 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        994.71 ns |      17.827 ns |      14.886 ns |        989.61 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        994.88 ns |      14.021 ns |      12.429 ns |        990.10 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        998.26 ns |      17.123 ns |      15.180 ns |        995.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      5,237.16 ns |      18.728 ns |      15.639 ns |      5,237.41 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     11,041.45 ns |      30.712 ns |      25.646 ns |     11,034.76 ns |  22,323 B |      56 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        801.53 ns |      13.219 ns |      11.718 ns |        797.87 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,243.04 ns |      20.972 ns |      18.591 ns |      1,243.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,256.15 ns |      24.841 ns |      28.607 ns |      1,248.53 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,689.27 ns |       7.875 ns |       7.366 ns |      1,688.28 ns |  11,378 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,752.10 ns |      17.156 ns |      16.048 ns |      1,748.77 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,786.40 ns |      17.209 ns |      14.371 ns |      1,789.05 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      9,554.43 ns |      46.922 ns |      41.595 ns |      9,545.73 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     20,224.14 ns |      46.719 ns |      41.415 ns |     20,223.90 ns |  22,232 B |      56 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,022.52 ns |      12.342 ns |      11.544 ns |      1,016.14 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,336.83 ns |      12.363 ns |      11.564 ns |      1,332.49 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,342.82 ns |      17.332 ns |      15.364 ns |      1,339.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      2,176.40 ns |      29.252 ns |      25.931 ns |      2,170.19 ns |  17,781 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,508.02 ns |      21.227 ns |      19.856 ns |      3,512.82 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,619.59 ns |      38.449 ns |      34.084 ns |      3,617.87 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |     19,401.59 ns |      86.283 ns |      72.050 ns |     19,387.17 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     40,455.23 ns |     247.395 ns |     219.309 ns |     40,373.07 ns |  22,230 B |     168 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,448.84 ns |      15.275 ns |      14.288 ns |      1,442.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,451.43 ns |      12.523 ns |      11.714 ns |      1,446.71 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,835.98 ns |      15.752 ns |      13.964 ns |      1,834.49 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      3,093.98 ns |      36.816 ns |      34.438 ns |      3,094.35 ns |  18,387 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,309.53 ns |      51.208 ns |      42.761 ns |      5,295.49 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      5,547.15 ns |     110.825 ns |     123.182 ns |      5,524.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |     29,318.17 ns |      92.640 ns |      86.656 ns |     29,323.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     63,893.11 ns |     139.877 ns |     130.841 ns |     63,875.88 ns |  22,243 B |     280 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,220.84 ns |      23.616 ns |      19.720 ns |      1,219.69 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,473.76 ns |      18.154 ns |      22.959 ns |      1,475.32 ns |   6,416 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,558.80 ns |      12.942 ns |      11.472 ns |      1,557.03 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,578.48 ns |      16.678 ns |      14.785 ns |      1,579.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      2,491.85 ns |      32.914 ns |      29.177 ns |      2,485.15 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,426.07 ns |     143.561 ns |     147.427 ns |      7,402.38 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     39,484.42 ns |     178.294 ns |     158.053 ns |     39,452.16 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     85,415.26 ns |     623.115 ns |     520.329 ns |     85,237.80 ns |  22,243 B |     392 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,592.72 ns |      23.600 ns |      22.075 ns |      2,586.21 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,121.88 ns |      36.466 ns |      32.326 ns |      3,121.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,149.47 ns |      62.671 ns |     108.104 ns |      3,099.05 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      3,353.48 ns |      65.147 ns |     107.039 ns |      3,306.33 ns |  18,537 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,413.69 ns |      23.280 ns |      21.776 ns |      3,415.87 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      8,957.39 ns |     105.545 ns |      98.727 ns |      8,943.90 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     48,412.68 ns |     401.415 ns |     375.483 ns |     48,262.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    104,102.79 ns |     582.100 ns |     516.017 ns |    103,908.09 ns |  22,259 B |     504 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,338.54 ns |      62.818 ns |      55.686 ns |      7,333.82 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      9,750.23 ns |      92.402 ns |      86.433 ns |      9,717.23 ns |   8,622 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |     10,000.14 ns |     126.779 ns |     112.387 ns |      9,950.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     12,075.40 ns |     224.671 ns |     199.165 ns |     12,021.08 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     15,336.18 ns |     162.471 ns |     144.027 ns |     15,294.48 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     58,879.50 ns |     575.670 ns |     510.317 ns |     58,833.68 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |    319,308.67 ns |   4,627.827 ns |   6,783.409 ns |    316,881.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    668,565.69 ns |   1,418.309 ns |   1,257.294 ns |    668,546.78 ns |  22,258 B |    3528 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,351.73 ns |     139.104 ns |     123.312 ns |     12,305.61 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     14,839.47 ns |     114.433 ns |     107.040 ns |     14,820.69 ns |   8,912 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     15,186.70 ns |      78.663 ns |      65.687 ns |     15,163.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |     16,455.18 ns |     123.204 ns |     115.245 ns |     16,429.61 ns |  30,448 B |    2325 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,725.86 ns |     195.536 ns |     182.904 ns |     17,656.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     89,208.94 ns |     935.853 ns |     829.609 ns |     88,895.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    480,841.96 ns |   1,337.530 ns |   1,185.686 ns |    480,489.45 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |  1,014,272.63 ns |   2,057.453 ns |   1,823.879 ns |  1,013,262.70 ns |  22,247 B |    5432 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,454.10 ns |     105.464 ns |      93.491 ns |     14,433.71 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     17,538.20 ns |     262.630 ns |     232.814 ns |     17,446.16 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     18,755.18 ns |     228.555 ns |     213.791 ns |     18,693.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |     19,450.82 ns |     122.131 ns |     114.241 ns |     19,467.39 ns |  30,241 B |    2541 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,122.18 ns |     303.466 ns |     269.015 ns |     22,021.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    116,858.88 ns |   1,025.694 ns |     909.251 ns |    116,353.43 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    629,446.37 ns |   2,362.555 ns |   1,972.841 ns |    628,735.84 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,365,441.89 ns |   1,951.776 ns |   1,629.821 ns |  1,365,500.98 ns |  22,258 B |    7112 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     24,939.53 ns |     110.273 ns |     103.150 ns |     24,943.70 ns |  30,702 B |    2897 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,787.71 ns |     207.702 ns |     184.123 ns |     28,702.37 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     34,969.75 ns |     339.866 ns |     317.910 ns |     34,941.28 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     36,496.42 ns |     427.738 ns |     400.106 ns |     36,390.80 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     42,766.73 ns |     452.041 ns |     400.723 ns |     42,603.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    233,337.73 ns |   2,029.586 ns |   1,799.175 ns |    232,271.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |  1,258,237.64 ns |   5,150.047 ns |   4,300.522 ns |  1,257,916.60 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,680,445.06 ns |   5,676.065 ns |   5,031.684 ns |  2,679,564.84 ns |  22,257 B |   14280 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     27,880.54 ns |     431.337 ns |     382.369 ns |     27,828.25 ns |  30,674 B |    3729 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     57,443.55 ns |     469.243 ns |     415.972 ns |     57,319.94 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     69,756.15 ns |     709.673 ns |     592.609 ns |     69,605.52 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     79,724.46 ns |     756.714 ns |     670.808 ns |     79,706.58 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     83,984.49 ns |     640.138 ns |     598.786 ns |     83,890.95 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    468,171.83 ns |   3,616.308 ns |   3,205.763 ns |    467,968.07 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |  2,510,487.53 ns |   4,681.402 ns |   3,909.183 ns |  2,510,803.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,285,034.82 ns |  18,880.412 ns |  16,736.994 ns |  5,278,471.88 ns |  22,253 B |   28616 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     36,226.60 ns |      71.007 ns |      62.946 ns |     36,234.90 ns |  29,832 B |    4166 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    110,782.32 ns |     832.574 ns |     778.790 ns |    110,805.66 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    139,946.76 ns |   1,733.943 ns |   1,621.932 ns |    139,041.16 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    149,597.23 ns |   2,198.326 ns |   1,948.759 ns |    148,520.67 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    161,172.02 ns |   1,503.405 ns |   1,406.286 ns |    160,720.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    890,983.53 ns |   5,877.688 ns |   5,497.993 ns |    889,934.96 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  4,804,090.02 ns |  11,294.819 ns |   9,431.686 ns |  4,804,003.12 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,829,274.17 ns |  43,206.464 ns |  40,415.353 ns |  9,807,935.94 ns |  22,257 B |   54656 B |
|                                               |              |                  |                |                |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    299,213.67 ns |   4,226.637 ns |   3,953.598 ns |    297,217.24 ns |  37,415 B |    4026 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,109,232.09 ns |  10,192.592 ns |   9,035.467 ns |  1,106,532.42 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,375,500.16 ns |  13,664.276 ns |  12,781.573 ns |  1,371,934.18 ns |   8,903 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,576,841.76 ns |  10,942.733 ns |  10,235.839 ns |  1,575,215.82 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,588,587.71 ns |  13,816.098 ns |  11,537.067 ns |  1,584,183.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  8,924,181.46 ns |  75,779.912 ns |  70,884.576 ns |  8,896,704.69 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 47,992,124.24 ns |  83,165.656 ns |  77,793.206 ns | 47,999,509.09 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 96,623,280.00 ns | 259,756.158 ns | 242,976.072 ns | 96,606,820.00 ns |  22,282 B |  546840 B |