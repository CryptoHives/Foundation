| Description                                     | TestDataSize | Mean              | Error            | StdDev            | Median            | Code Size | Allocated |
|------------------------------------------------ |------------- |------------------:|-----------------:|------------------:|------------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |          64.74 ns |         0.248 ns |          0.472 ns |          64.93 ns |   2,236 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |          66.76 ns |         0.639 ns |          1.217 ns |          67.54 ns |   2,236 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |          69.49 ns |         0.229 ns |          0.436 ns |          69.47 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |          70.31 ns |         0.469 ns |          0.893 ns |          69.79 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |          86.58 ns |         0.151 ns |          0.287 ns |          86.75 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |          91.87 ns |         2.166 ns |          4.122 ns |          89.19 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |         140.89 ns |         0.111 ns |          0.211 ns |         140.96 ns |  12,544 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |         758.55 ns |         2.243 ns |          4.102 ns |         759.27 ns |  12,464 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |          65.83 ns |         0.097 ns |          0.185 ns |          65.80 ns |   2,236 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |          66.15 ns |         0.607 ns |          1.154 ns |          66.70 ns |   2,236 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |          68.74 ns |         0.208 ns |          0.397 ns |          68.75 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |          68.79 ns |         0.177 ns |          0.337 ns |          68.74 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |          75.06 ns |         0.165 ns |          0.313 ns |          75.19 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |          81.71 ns |         0.203 ns |          0.381 ns |          81.80 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |         133.06 ns |         0.017 ns |          0.029 ns |         133.06 ns |  12,531 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |         760.19 ns |         2.532 ns |          4.817 ns |         759.07 ns |  12,452 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |         128.62 ns |         0.105 ns |          0.199 ns |         128.66 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |         130.35 ns |         0.171 ns |          0.325 ns |         130.38 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |         135.24 ns |         0.148 ns |          0.282 ns |         135.25 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |         135.40 ns |         0.156 ns |          0.298 ns |         135.40 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |         150.51 ns |         0.095 ns |          0.180 ns |         150.52 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         152.88 ns |         0.096 ns |          0.176 ns |         152.79 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |         263.46 ns |         0.132 ns |          0.245 ns |         263.46 ns |  12,544 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |       1,679.51 ns |        37.334 ns |         71.032 ns |       1,653.24 ns |  12,191 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |         128.82 ns |         0.094 ns |          0.179 ns |         128.89 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |         131.18 ns |         0.722 ns |          1.374 ns |         130.43 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |         134.93 ns |         0.128 ns |          0.241 ns |         134.96 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |         134.99 ns |         0.131 ns |          0.249 ns |         135.06 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |         151.93 ns |         0.570 ns |          1.085 ns |         151.29 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         152.14 ns |         0.625 ns |          1.175 ns |         151.85 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |         257.54 ns |         0.155 ns |          0.290 ns |         257.49 ns |  12,533 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |       1,690.37 ns |        19.183 ns |         36.031 ns |       1,666.37 ns |  12,177 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |         127.63 ns |         0.059 ns |          0.112 ns |         127.65 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |         129.08 ns |         0.085 ns |          0.162 ns |         129.12 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |         134.06 ns |         0.122 ns |          0.230 ns |         134.10 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |         134.26 ns |         0.171 ns |          0.325 ns |         134.25 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |         143.85 ns |         0.142 ns |          0.269 ns |         143.86 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         149.82 ns |         0.174 ns |          0.331 ns |         149.77 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |         250.20 ns |         0.129 ns |          0.239 ns |         250.18 ns |  12,531 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |       1,654.57 ns |         7.862 ns |         14.572 ns |       1,662.76 ns |  12,175 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |         190.39 ns |         0.145 ns |          0.266 ns |         190.41 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |         191.79 ns |         0.123 ns |          0.231 ns |         191.81 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |         201.96 ns |         0.066 ns |          0.126 ns |         201.99 ns |   5,036 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |         201.98 ns |         0.081 ns |          0.152 ns |         202.01 ns |   5,036 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |         216.80 ns |         0.099 ns |          0.186 ns |         216.73 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |         221.85 ns |         0.084 ns |          0.157 ns |         221.89 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |         381.75 ns |         0.175 ns |          0.333 ns |         381.77 ns |  12,544 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |       2,394.21 ns |         3.664 ns |          6.882 ns |       2,391.84 ns |  12,164 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |         995.36 ns |         1.296 ns |          2.402 ns |         994.63 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |         997.33 ns |         1.524 ns |          2.824 ns |         996.56 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |       1,035.51 ns |         0.654 ns |          1.245 ns |       1,035.38 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |       1,036.01 ns |         0.660 ns |          1.223 ns |       1,035.90 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |       1,038.80 ns |         0.627 ns |          1.193 ns |       1,038.74 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |       1,148.77 ns |         0.683 ns |          1.300 ns |       1,148.54 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |       1,878.62 ns |         0.689 ns |          1.293 ns |       1,878.87 ns |  12,533 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      11,968.35 ns |       204.608 ns |        379.254 ns |      11,894.27 ns |  12,178 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |         991.71 ns |         0.686 ns |          1.306 ns |         991.59 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |         994.65 ns |         1.289 ns |          2.452 ns |         994.61 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |       1,031.83 ns |         0.394 ns |          0.750 ns |       1,031.87 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |       1,032.91 ns |         1.112 ns |          2.061 ns |       1,032.34 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |       1,038.00 ns |         0.603 ns |          1.147 ns |       1,038.03 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |       1,143.11 ns |         1.515 ns |          2.808 ns |       1,142.08 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |       1,859.78 ns |         2.676 ns |          5.026 ns |       1,861.41 ns |  12,531 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      11,876.97 ns |       229.785 ns |        431.593 ns |      12,068.55 ns |  12,147 B |         - |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |       1,175.31 ns |         0.886 ns |          1.619 ns |       1,175.15 ns |   7,153 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |       1,175.53 ns |         1.123 ns |          2.025 ns |       1,174.53 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |       1,177.95 ns |         0.865 ns |          1.560 ns |       1,177.73 ns |   7,152 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |       1,224.27 ns |         1.292 ns |          2.457 ns |       1,224.79 ns |   8,672 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |       1,225.96 ns |         1.375 ns |          2.617 ns |       1,226.85 ns |   8,672 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |       1,324.67 ns |         0.531 ns |          1.010 ns |       1,324.30 ns |   4,818 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |       2,239.47 ns |         9.895 ns |         18.827 ns |       2,240.88 ns |  10,557 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      13,345.78 ns |        69.380 ns |        130.313 ns |      13,262.92 ns |  19,170 B |      56 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |       1,105.56 ns |         0.566 ns |          1.062 ns |       1,105.80 ns |   8,542 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |       1,106.57 ns |         0.914 ns |          1.739 ns |       1,106.75 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |       1,187.70 ns |         0.556 ns |          1.058 ns |       1,187.59 ns |   7,719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |       1,192.37 ns |         0.730 ns |          1.389 ns |       1,192.20 ns |   7,719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |       2,095.40 ns |         3.555 ns |          6.678 ns |       2,092.78 ns |   7,151 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |       2,395.40 ns |         0.968 ns |          1.818 ns |       2,395.35 ns |   4,816 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |       4,056.98 ns |        19.350 ns |         36.815 ns |       4,065.26 ns |  10,554 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |      23,266.95 ns |       382.934 ns |        709.793 ns |      22,851.58 ns |  19,101 B |      56 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |       2,166.03 ns |         2.610 ns |          4.965 ns |       2,167.42 ns |  16,016 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |       2,168.73 ns |        13.297 ns |         25.299 ns |       2,173.97 ns |  16,030 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |       2,178.22 ns |         1.159 ns |          2.178 ns |       2,178.22 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |       2,182.97 ns |         1.168 ns |          2.136 ns |       2,182.50 ns |   9,489 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |       3,785.54 ns |         3.939 ns |          7.495 ns |       3,787.18 ns |  16,030 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |       3,868.46 ns |        24.190 ns |         46.024 ns |       3,869.09 ns |  17,876 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |       6,139.69 ns |        28.380 ns |         53.996 ns |       6,145.77 ns |  10,710 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |      35,158.00 ns |       456.747 ns |        835.188 ns |      34,636.36 ns |  19,101 B |     112 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |       2,016.63 ns |         6.015 ns |         11.444 ns |       2,021.16 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |       2,212.59 ns |         7.435 ns |         14.145 ns |       2,218.02 ns |  16,034 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |       2,259.15 ns |         3.198 ns |          6.006 ns |       2,259.21 ns |  16,034 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |       2,288.10 ns |         2.275 ns |          4.329 ns |       2,288.84 ns |  16,309 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |       4,074.45 ns |        24.897 ns |         47.370 ns |       4,080.88 ns |  27,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |       5,071.45 ns |         2.889 ns |          5.427 ns |       5,072.61 ns |  16,641 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |       8,232.90 ns |        39.267 ns |         74.710 ns |       8,268.64 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |      47,965.58 ns |       668.883 ns |      1,239.818 ns |      48,443.20 ns |  19,084 B |     168 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |       3,103.04 ns |         9.181 ns |         17.243 ns |       3,098.00 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |       3,266.99 ns |        62.081 ns |        115.072 ns |       3,214.63 ns |  24,465 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |       3,793.84 ns |         4.600 ns |          8.641 ns |       3,796.74 ns |  21,173 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |       3,948.72 ns |       241.535 ns |        459.545 ns |       3,630.38 ns |  21,173 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |       5,154.72 ns |        22.643 ns |         43.080 ns |       5,154.87 ns |  29,931 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |       6,448.36 ns |         0.983 ns |          1.773 ns |       6,448.04 ns |  27,306 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      10,336.25 ns |        37.495 ns |         71.339 ns |      10,340.73 ns |  10,708 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |      60,302.58 ns |       943.327 ns |      1,748.517 ns |      61,402.06 ns |  19,092 B |     224 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |       3,154.98 ns |         6.292 ns |         11.970 ns |       3,158.03 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |       3,261.52 ns |        54.816 ns |        104.293 ns |       3,230.70 ns |  24,465 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |       3,879.84 ns |        31.958 ns |         60.803 ns |       3,909.22 ns |  32,046 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |       4,195.14 ns |       169.783 ns |        314.704 ns |       4,386.93 ns |  32,046 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |       6,273.68 ns |        16.166 ns |         30.364 ns |       6,279.82 ns |  29,919 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |       7,590.64 ns |         4.290 ns |          8.058 ns |       7,589.93 ns |  27,313 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      12,431.02 ns |        55.451 ns |        105.501 ns |      12,456.24 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |      73,169.57 ns |       109.106 ns |        207.586 ns |      73,226.40 ns |  19,098 B |     280 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |       2,461.79 ns |         2.024 ns |          3.701 ns |       2,462.08 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |       4,115.64 ns |       130.508 ns |        245.125 ns |       4,261.77 ns |  31,876 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |       4,161.97 ns |       231.448 ns |        440.354 ns |       3,895.43 ns |  31,874 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |       4,589.84 ns |     1,089.332 ns |      2,072.567 ns |       3,194.20 ns |  21,720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |       6,442.98 ns |       120.204 ns |        228.701 ns |       6,569.09 ns |  17,848 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |       8,095.97 ns |        44.298 ns |         84.282 ns |       8,128.14 ns |  28,400 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      16,558.11 ns |        78.329 ns |        149.029 ns |      16,599.91 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |      97,897.73 ns |       880.748 ns |      1,675.714 ns |      99,007.20 ns |  19,115 B |     392 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |       3,564.75 ns |         1.112 ns |          2.116 ns |       3,564.15 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |       4,223.02 ns |        24.661 ns |         46.920 ns |       4,230.03 ns |  24,284 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |       5,587.52 ns |        78.106 ns |        148.605 ns |       5,534.32 ns |  36,982 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |       5,766.07 ns |        83.345 ns |        158.573 ns |       5,800.16 ns |  36,972 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |       7,977.31 ns |        20.846 ns |         39.662 ns |       7,977.28 ns |  29,370 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |       9,182.25 ns |        43.627 ns |         83.005 ns |       9,217.58 ns |  29,931 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      18,680.49 ns |        94.312 ns |        179.439 ns |      18,722.98 ns |  10,708 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     107,793.65 ns |     1,475.231 ns |      2,622.221 ns |     106,918.17 ns |  19,099 B |     448 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |       4,465.65 ns |         2.591 ns |          4.929 ns |       4,465.09 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |       4,487.20 ns |        44.228 ns |         84.149 ns |       4,455.76 ns |  25,878 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |       5,413.03 ns |       188.192 ns |        353.471 ns |       5,585.53 ns |  35,016 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |       5,530.98 ns |       184.883 ns |        351.759 ns |       5,585.07 ns |  35,013 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |       8,964.28 ns |        26.983 ns |         51.338 ns |       8,976.82 ns |  29,370 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |      10,119.30 ns |        31.369 ns |         59.682 ns |      10,143.45 ns |  29,919 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      20,435.36 ns |        91.539 ns |        174.163 ns |      20,462.23 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     118,751.25 ns |       134.197 ns |        248.742 ns |     118,684.17 ns |  19,110 B |     504 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |       3,631.22 ns |         1.764 ns |          3.314 ns |       3,631.58 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |       4,428.71 ns |        52.939 ns |        100.722 ns |       4,415.17 ns |  25,663 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |       5,262.87 ns |       204.439 ns |        388.966 ns |       5,061.48 ns |  34,071 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |       5,620.41 ns |       112.742 ns |        211.756 ns |       5,488.79 ns |  34,071 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |       9,168.33 ns |        19.116 ns |         36.371 ns |       9,167.54 ns |  29,376 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |      10,250.88 ns |        42.193 ns |         80.276 ns |      10,271.56 ns |  29,919 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      20,767.84 ns |        97.315 ns |        185.152 ns |      20,816.13 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     117,146.23 ns |       160.143 ns |        288.772 ns |     117,034.79 ns |  19,106 B |     504 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |       4,680.72 ns |         3.545 ns |          6.571 ns |       4,678.18 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |       5,442.97 ns |        18.877 ns |         35.916 ns |       5,437.04 ns |  25,663 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |       5,996.16 ns |         6.709 ns |         12.764 ns |       5,999.70 ns |  38,706 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |       6,341.50 ns |       220.308 ns |        419.159 ns |       6,142.49 ns |  38,706 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      10,287.63 ns |        13.827 ns |         26.308 ns |      10,291.67 ns |  29,381 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |      12,140.35 ns |        68.808 ns |        130.914 ns |      12,125.38 ns |  28,664 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      22,944.28 ns |       100.420 ns |        191.059 ns |      23,037.09 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     128,814.10 ns |       145.523 ns |        262.407 ns |     128,663.28 ns |  19,108 B |     560 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |       4,517.46 ns |         5.484 ns |         10.434 ns |       4,519.78 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |       6,145.52 ns |         9.573 ns |         18.215 ns |       6,149.81 ns |  38,702 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |       6,265.87 ns |       145.793 ns |        277.387 ns |       6,176.80 ns |  38,702 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |       7,168.86 ns |     1,209.919 ns |      2,301.997 ns |       5,622.36 ns |  25,663 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      11,436.85 ns |        15.250 ns |         29.015 ns |      11,441.12 ns |  29,375 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |      12,309.66 ns |        58.505 ns |        111.311 ns |      12,308.91 ns |  28,400 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      25,083.39 ns |        82.442 ns |        156.855 ns |      25,143.76 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     146,456.79 ns |     2,109.776 ns |      3,910.606 ns |     149,060.16 ns |  19,094 B |     616 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |       6,568.11 ns |         4.998 ns |          9.012 ns |       6,570.19 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |       6,570.73 ns |        64.369 ns |        122.469 ns |       6,555.99 ns |  32,872 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |       7,698.32 ns |        71.409 ns |        134.124 ns |       7,772.83 ns |  43,847 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |       8,206.66 ns |       394.138 ns |        740.287 ns |       7,731.42 ns |  43,847 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |      14,730.14 ns |       109.944 ns |        203.788 ns |      14,626.92 ns |  18,588 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |      16,042.20 ns |        80.482 ns |        153.125 ns |      16,055.47 ns |  28,664 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |      31,209.85 ns |       153.155 ns |        291.393 ns |      31,235.13 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     179,696.95 ns |     2,860.043 ns |      5,229.751 ns |     176,092.20 ns |  19,108 B |     784 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |       4,777.46 ns |         2.572 ns |          4.894 ns |       4,778.77 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |       7,894.34 ns |       243.111 ns |        462.544 ns |       7,591.66 ns |  31,857 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |       7,958.06 ns |       226.354 ns |        430.662 ns |       8,243.94 ns |  31,857 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |       9,648.54 ns |     2,257.186 ns |      4,294.531 ns |       6,875.90 ns |  22,753 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      12,757.74 ns |        45.354 ns |         86.290 ns |      12,727.52 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |      16,204.45 ns |        92.362 ns |        175.729 ns |      16,261.48 ns |  28,400 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |      33,221.65 ns |       172.341 ns |        327.896 ns |      33,281.98 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     191,967.18 ns |     2,944.656 ns |      5,384.470 ns |     188,032.68 ns |  19,103 B |     840 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |      11,887.49 ns |       149.315 ns |        280.450 ns |      11,917.93 ns |  48,322 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |      18,789.07 ns |         8.104 ns |         15.022 ns |      18,786.57 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |      23,873.47 ns |       153.939 ns |        292.885 ns |      23,864.49 ns |  22,076 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |      48,642.49 ns |       725.141 ns |      1,361.990 ns |      49,484.85 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |      63,108.10 ns |       385.209 ns |        732.901 ns |      63,154.55 ns |  27,723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |      97,374.64 ns |    51,800.547 ns |     98,555.931 ns |      28,599.56 ns |  31,827 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |     136,207.99 ns |       598.358 ns |      1,138.437 ns |     136,553.93 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |     777,147.06 ns |     9,481.297 ns |     17,808.176 ns |     776,497.46 ns |  19,109 B |    3528 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |      20,064.07 ns |        99.949 ns |        185.261 ns |      20,066.20 ns |  51,078 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |      30,158.75 ns |         9.443 ns |         17.267 ns |      30,158.90 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |      38,796.40 ns |       223.521 ns |        425.271 ns |      38,912.65 ns |  26,234 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |      51,152.59 ns |     2,506.522 ns |      4,768.919 ns |      54,389.82 ns |  34,987 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |      73,589.93 ns |     1,500.128 ns |      2,854.150 ns |      71,932.39 ns |  18,567 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |      97,930.08 ns |       498.658 ns |        948.748 ns |      97,952.04 ns |  30,275 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     203,795.95 ns |       672.630 ns |      1,279.749 ns |     204,134.45 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |   1,139,494.99 ns |     2,389.633 ns |      4,369.580 ns |   1,136,690.33 ns |  19,098 B |    5432 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |      22,958.69 ns |       215.443 ns |        486.292 ns |      22,870.79 ns |  48,146 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |      37,500.83 ns |        22.050 ns |         41.415 ns |      37,500.92 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |      48,079.51 ns |       448.340 ns |        853.014 ns |      47,705.10 ns |  23,109 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |      61,641.03 ns |     1,621.112 ns |      3,004.836 ns |      63,645.19 ns |  31,839 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |      97,427.59 ns |     1,848.778 ns |      3,517.493 ns |      99,688.79 ns |  18,239 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |     125,938.45 ns |       614.891 ns |      1,169.893 ns |     126,299.05 ns |  28,756 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |     267,401.42 ns |     1,042.605 ns |      1,983.664 ns |     268,110.25 ns |  10,702 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |   1,511,813.53 ns |    14,879.591 ns |     27,947.481 ns |   1,493,752.73 ns |  19,109 B |    7112 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |     174,683.73 ns |     2,880.290 ns |     11,416.640 ns |     174,731.52 ns |  53,499 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |     300,555.17 ns |     4,551.069 ns |     14,514.189 ns |     293,866.11 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |     372,063.79 ns |     1,550.432 ns |      2,949.859 ns |     371,943.02 ns |  24,628 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |     550,048.15 ns |     8,029.017 ns |     14,882.298 ns |     554,381.74 ns |  36,938 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |     772,098.90 ns |     2,784.087 ns |      5,160.484 ns |     773,465.33 ns |  18,578 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |     978,417.29 ns |     5,372.621 ns |      9,958.499 ns |     976,065.92 ns |  30,275 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |   2,052,992.73 ns |     5,399.459 ns |     10,008.244 ns |   2,053,986.33 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  11,319,511.81 ns |   139,480.726 ns |    265,376.598 ns |  11,326,073.44 ns |  19,093 B |   54656 B |
|                                                 |              |                   |                  |                   |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |   1,572,468.16 ns |    26,944.847 ns |     52,553.858 ns |   1,591,895.90 ns |  60,155 B |     151 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |   2,945,960.77 ns |     4,315.511 ns |      8,210.708 ns |   2,947,550.00 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |   5,608,109.83 ns | 1,120,989.498 ns |  2,315,037.878 ns |   4,413,423.44 ns |  33,424 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |   5,610,909.31 ns |    98,291.262 ns |    187,009.355 ns |   5,586,851.56 ns |  46,129 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |  10,165,296.35 ns |    88,201.192 ns |    174,100.562 ns |  10,137,082.03 ns |  30,275 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |  17,588,433.92 ns | 7,103,089.814 ns | 13,166,033.448 ns |   8,121,150.00 ns |  18,556 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  20,701,783.10 ns |    93,714.367 ns |    176,018.310 ns |  20,693,368.75 ns |  10,696 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 111,393,768.72 ns |   649,201.569 ns |  1,137,024.269 ns | 112,058,600.00 ns |  19,095 B |  546840 B |