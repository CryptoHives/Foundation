| Description                                     | TestDataSize | Mean              | Error          | StdDev         | Median            | Code Size | Allocated |
|------------------------------------------------ |------------- |------------------:|---------------:|---------------:|------------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |          41.43 ns |       0.057 ns |       0.051 ns |          41.42 ns |   2,200 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |          41.47 ns |       0.067 ns |       0.052 ns |          41.48 ns |   2,200 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 4B           |          41.88 ns |       0.065 ns |       0.051 ns |          41.89 ns |   2,200 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |          46.04 ns |       0.115 ns |       0.107 ns |          46.04 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |          46.04 ns |       0.116 ns |       0.097 ns |          46.03 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |          67.96 ns |       0.041 ns |       0.032 ns |          67.97 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |          72.29 ns |       0.050 ns |       0.044 ns |          72.30 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |          90.66 ns |       0.316 ns |       0.295 ns |          90.62 ns |  12,520 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |         738.95 ns |       1.570 ns |       1.392 ns |         738.86 ns |  12,360 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |          41.07 ns |       0.044 ns |       0.039 ns |          41.09 ns |   2,200 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |          41.30 ns |       0.055 ns |       0.049 ns |          41.29 ns |   2,200 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 64B          |          41.74 ns |       0.079 ns |       0.074 ns |          41.73 ns |   2,200 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |          44.91 ns |       0.092 ns |       0.086 ns |          44.88 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |          45.21 ns |       0.117 ns |       0.097 ns |          45.21 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |          49.63 ns |       0.318 ns |       0.282 ns |          49.51 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |          66.88 ns |       0.072 ns |       0.061 ns |          66.89 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |          85.85 ns |       0.205 ns |       0.160 ns |          85.85 ns |  12,511 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |         738.22 ns |       1.983 ns |       1.758 ns |         738.19 ns |  12,349 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 65B          |          91.00 ns |       0.383 ns |       0.299 ns |          90.88 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |          91.43 ns |       0.218 ns |       0.204 ns |          91.42 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |          91.95 ns |       1.394 ns |       1.432 ns |          91.29 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |          97.57 ns |       0.102 ns |       0.095 ns |          97.56 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |          97.57 ns |       0.114 ns |       0.095 ns |          97.58 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |         107.64 ns |       0.867 ns |       0.724 ns |         107.39 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         119.19 ns |       0.095 ns |       0.089 ns |         119.15 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |         180.55 ns |       0.612 ns |       0.511 ns |         180.37 ns |  12,520 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |       1,591.38 ns |       3.290 ns |       2.748 ns |       1,590.07 ns |  12,091 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |          90.70 ns |       0.120 ns |       0.106 ns |          90.71 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 100B         |          90.73 ns |       0.117 ns |       0.098 ns |          90.74 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |          91.25 ns |       0.231 ns |       0.205 ns |          91.20 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |          97.75 ns |       0.095 ns |       0.080 ns |          97.73 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |          98.14 ns |       0.183 ns |       0.153 ns |          98.11 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |         108.32 ns |       0.411 ns |       0.384 ns |         108.17 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         118.02 ns |       0.162 ns |       0.152 ns |         118.01 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |         176.95 ns |       0.461 ns |       0.431 ns |         176.94 ns |  12,513 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |       1,614.32 ns |       2.442 ns |       1.907 ns |       1,614.77 ns |  12,067 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |          91.33 ns |       0.186 ns |       0.174 ns |          91.29 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 128B         |          91.58 ns |       0.141 ns |       0.118 ns |          91.54 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |          91.64 ns |       0.149 ns |       0.139 ns |          91.64 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |          97.80 ns |       0.148 ns |       0.131 ns |          97.77 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |          97.91 ns |       0.114 ns |       0.106 ns |          97.91 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |         104.03 ns |       0.279 ns |       0.261 ns |         104.05 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         117.43 ns |       0.077 ns |       0.068 ns |         117.43 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |         176.84 ns |       1.697 ns |       1.587 ns |         176.10 ns |  12,511 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |       1,616.29 ns |       3.512 ns |       3.114 ns |       1,616.68 ns |  12,078 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 137B         |         140.53 ns |       0.185 ns |       0.164 ns |         140.54 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |         140.54 ns |       0.148 ns |       0.115 ns |         140.56 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |         141.04 ns |       0.154 ns |       0.137 ns |         141.03 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |         152.44 ns |       0.209 ns |       0.174 ns |         152.42 ns |   4,984 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |         152.58 ns |       0.234 ns |       0.219 ns |         152.56 ns |   4,984 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |         165.45 ns |       0.275 ns |       0.244 ns |         165.43 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |         180.65 ns |       0.102 ns |       0.095 ns |         180.64 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |         355.52 ns |      20.096 ns |      59.255 ns |         360.24 ns |  12,520 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |       2,344.62 ns |       3.952 ns |       3.503 ns |       2,344.37 ns |  12,064 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1000B        |         780.54 ns |       0.405 ns |       0.359 ns |         780.49 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |         782.99 ns |       0.351 ns |       0.311 ns |         783.06 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |         783.64 ns |       0.650 ns |       0.608 ns |         783.75 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |         835.19 ns |       0.330 ns |       0.275 ns |         835.14 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |         849.96 ns |       1.421 ns |       1.187 ns |         850.54 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |         864.34 ns |       2.375 ns |       2.106 ns |         864.42 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |         911.99 ns |       4.087 ns |       3.823 ns |         909.99 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |       1,396.23 ns |       2.088 ns |       1.743 ns |       1,396.14 ns |  12,513 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      11,721.94 ns |      35.567 ns |      33.270 ns |      11,714.42 ns |  12,079 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |         784.24 ns |       1.291 ns |       1.145 ns |         784.24 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1KB          |         789.12 ns |       7.704 ns |       7.206 ns |         785.16 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |         789.18 ns |       3.137 ns |       2.935 ns |         790.21 ns |   4,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |         840.04 ns |       8.306 ns |       7.769 ns |         833.71 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |         850.13 ns |       1.420 ns |       1.328 ns |         850.01 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |         850.96 ns |       1.821 ns |       1.703 ns |         850.93 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |         904.67 ns |       0.617 ns |       0.547 ns |         904.44 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |       1,402.92 ns |       3.005 ns |       2.664 ns |       1,402.02 ns |  12,511 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      11,216.72 ns |      40.540 ns |      35.938 ns |      11,195.72 ns |  12,047 B |         - |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |         867.33 ns |       1.650 ns |       1.543 ns |         867.50 ns |   7,928 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |         869.39 ns |       4.788 ns |       4.479 ns |         868.70 ns |   7,928 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |         921.28 ns |       2.270 ns |       2.123 ns |         920.03 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |         927.79 ns |       0.402 ns |       0.336 ns |         927.88 ns |   7,559 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1025B        |         941.75 ns |       5.893 ns |       5.224 ns |         940.02 ns |   7,559 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |         943.88 ns |       5.923 ns |       5.540 ns |         943.65 ns |   7,559 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |       1,058.15 ns |       2.079 ns |       1.945 ns |       1,057.41 ns |   4,687 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |       1,579.38 ns |       5.088 ns |       4.510 ns |       1,578.63 ns |  11,142 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      12,812.22 ns |     229.354 ns |     425.122 ns |      12,609.68 ns |  19,018 B |      56 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |         858.87 ns |       0.210 ns |       0.186 ns |         858.81 ns |   7,014 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |         860.04 ns |       1.370 ns |       1.282 ns |         860.77 ns |   7,014 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |         866.74 ns |       0.602 ns |       0.503 ns |         866.74 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |         872.51 ns |       1.216 ns |       1.138 ns |         872.71 ns |   8,716 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 2KB          |         878.89 ns |      12.636 ns |      11.201 ns |         880.63 ns |   8,714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |       1,690.01 ns |      15.259 ns |      14.274 ns |       1,692.87 ns |  13,310 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |       1,918.57 ns |       1.245 ns |       1.164 ns |       1,918.38 ns |   4,685 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |       3,234.35 ns |     123.321 ns |     363.614 ns |       3,131.59 ns |  11,140 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |      23,490.26 ns |      87.080 ns |      81.454 ns |      23,492.47 ns |  18,921 B |      56 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |       1,037.08 ns |       5.490 ns |       4.584 ns |       1,035.84 ns |  13,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |       1,046.07 ns |      11.529 ns |      10.785 ns |       1,042.24 ns |  13,378 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 3KB          |       1,069.04 ns |       1.674 ns |       1.566 ns |       1,068.35 ns |  10,281 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |       1,074.64 ns |       1.081 ns |       0.958 ns |       1,074.32 ns |  10,281 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |       1,316.44 ns |       1.542 ns |       1.367 ns |       1,316.29 ns |  14,196 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |       1,710.08 ns |       1.213 ns |       1.013 ns |       1,710.32 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |       2,938.70 ns |      11.258 ns |      10.531 ns |       2,944.06 ns |  11,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |       4,246.97 ns |      82.530 ns |      77.199 ns |       4,202.24 ns |  11,297 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |      35,416.72 ns |     688.498 ns |     644.022 ns |      35,098.32 ns |  18,933 B |     112 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |       1,030.63 ns |       0.714 ns |       0.633 ns |       1,030.55 ns |  11,842 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |       1,038.01 ns |       1.172 ns |       0.979 ns |       1,037.86 ns |  11,842 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |       1,099.01 ns |       5.443 ns |       5.091 ns |       1,096.54 ns |  15,036 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 4KB          |       1,105.24 ns |       8.735 ns |       7.294 ns |       1,106.03 ns |  15,036 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |       1,119.69 ns |       0.908 ns |       0.805 ns |       1,119.70 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |       1,361.92 ns |      11.173 ns |       8.723 ns |       1,359.69 ns |  19,742 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |       3,852.50 ns |       6.274 ns |       5.239 ns |       3,850.55 ns |  11,551 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |       5,765.40 ns |      59.468 ns |      49.659 ns |       5,740.41 ns |  11,292 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |      45,283.18 ns |     316.843 ns |     264.578 ns |      45,206.97 ns |  18,922 B |     168 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |       1,315.71 ns |       1.963 ns |       1.836 ns |       1,315.81 ns |  15,579 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |       1,318.93 ns |       3.103 ns |       2.903 ns |       1,319.29 ns |  15,579 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |       1,394.78 ns |       1.959 ns |       1.736 ns |       1,394.81 ns |  20,666 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 5KB          |       1,411.42 ns |       2.223 ns |       1.971 ns |       1,411.23 ns |  20,666 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |       1,971.92 ns |       2.851 ns |       2.667 ns |       1,971.51 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |       2,188.63 ns |       5.537 ns |       4.908 ns |       2,187.50 ns |  22,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |       4,889.57 ns |       4.673 ns |       4.371 ns |       4,889.32 ns |  17,735 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |       7,163.96 ns |      17.463 ns |      16.334 ns |       7,155.04 ns |  11,295 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |      58,875.23 ns |     122.792 ns |     108.852 ns |      58,872.61 ns |  18,926 B |     224 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |       1,310.74 ns |       2.175 ns |       2.034 ns |       1,310.95 ns |  22,448 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |       1,314.05 ns |       1.395 ns |       1.236 ns |       1,313.70 ns |  22,448 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 6KB          |       1,418.82 ns |       2.635 ns |       2.336 ns |       1,418.58 ns |  20,666 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |       1,443.21 ns |       2.666 ns |       2.494 ns |       1,443.56 ns |  20,668 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |       2,017.69 ns |       1.904 ns |       1.781 ns |       2,017.07 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |       2,634.74 ns |       3.008 ns |       2.666 ns |       2,634.53 ns |  20,978 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |       5,819.22 ns |       4.273 ns |       3.788 ns |       5,818.56 ns |  17,742 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |       8,622.33 ns |      33.555 ns |      29.746 ns |       8,611.87 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |      69,310.61 ns |     100.902 ns |      89.447 ns |      69,322.17 ns |  18,933 B |     280 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |       1,285.50 ns |       0.621 ns |       0.551 ns |       1,285.22 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |       1,333.38 ns |       2.815 ns |       2.495 ns |       1,332.49 ns |  18,231 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 8KB          |       1,340.41 ns |       1.103 ns |       1.032 ns |       1,340.57 ns |  18,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |       1,353.44 ns |       3.341 ns |       3.125 ns |       1,352.93 ns |  22,286 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |       1,355.23 ns |       2.213 ns |       1.848 ns |       1,354.65 ns |  22,286 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |       1,585.34 ns |       3.083 ns |       2.733 ns |       1,584.79 ns |  12,726 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |       2,755.81 ns |       6.747 ns |       5.981 ns |       2,754.64 ns |  20,714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      11,504.96 ns |      14.664 ns |      12.999 ns |      11,506.66 ns |  11,292 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |      94,116.13 ns |     116.706 ns |     103.457 ns |      94,090.74 ns |  18,929 B |     392 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 9216B        |       2,126.61 ns |       2.646 ns |       2.209 ns |       2,127.56 ns |  20,917 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |       2,140.25 ns |       3.295 ns |       3.082 ns |       2,141.07 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |       2,175.58 ns |       5.268 ns |       4.927 ns |       2,173.47 ns |  20,606 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |       2,200.41 ns |       5.875 ns |       5.495 ns |       2,198.93 ns |  27,488 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |       2,201.16 ns |       1.433 ns |       1.271 ns |       2,201.29 ns |  27,502 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |       2,639.98 ns |       4.480 ns |       3.971 ns |       2,639.71 ns |  19,238 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |       3,582.92 ns |      10.542 ns |       9.346 ns |       3,583.63 ns |  22,117 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      13,022.51 ns |      50.125 ns |      44.435 ns |      13,007.49 ns |  11,294 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     105,062.97 ns |     240.480 ns |     213.180 ns |     105,065.82 ns |  18,928 B |     448 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10000B       |       2,196.01 ns |       2.812 ns |       2.630 ns |       2,196.17 ns |  21,061 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |       2,219.44 ns |       2.296 ns |       2.035 ns |       2,219.43 ns |  25,339 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |       2,232.49 ns |       2.292 ns |       2.144 ns |       2,232.45 ns |  25,339 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |       2,279.18 ns |       2.353 ns |       2.201 ns |       2,279.19 ns |  21,956 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |       2,842.92 ns |       1.195 ns |       1.118 ns |       2,842.81 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |       3,375.85 ns |       4.230 ns |       3.957 ns |       3,375.77 ns |  19,242 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |       4,269.47 ns |       4.689 ns |       4.386 ns |       4,268.90 ns |  22,115 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      14,160.98 ns |      18.597 ns |      16.486 ns |      14,162.24 ns |  11,292 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     116,180.08 ns |     125.914 ns |     105.144 ns |     116,221.68 ns |  18,930 B |     504 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10240B       |       2,139.10 ns |       1.426 ns |       1.191 ns |       2,138.53 ns |  20,917 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |       2,181.83 ns |       0.614 ns |       0.480 ns |       2,181.70 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |       2,214.74 ns |       2.218 ns |       1.966 ns |       2,213.88 ns |  24,414 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |       2,215.10 ns |       3.032 ns |       2.688 ns |       2,214.36 ns |  24,428 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |       2,235.36 ns |       3.633 ns |       3.398 ns |       2,236.14 ns |  21,750 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |       3,553.71 ns |       2.708 ns |       2.401 ns |       3,554.18 ns |  19,236 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |       4,026.98 ns |      14.451 ns |      13.517 ns |       4,022.75 ns |  20,978 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      14,452.33 ns |      62.119 ns |      58.106 ns |      14,455.04 ns |  11,292 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     116,234.49 ns |     313.011 ns |     292.791 ns |     116,231.23 ns |  18,941 B |     504 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 11264B       |       2,180.93 ns |       2.120 ns |       1.983 ns |       2,180.86 ns |  20,904 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |       2,328.90 ns |       4.079 ns |       3.406 ns |       2,328.01 ns |  27,135 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |       2,332.95 ns |       3.823 ns |       3.192 ns |       2,331.71 ns |  27,135 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |       2,440.14 ns |       4.422 ns |       4.136 ns |       2,439.53 ns |  22,431 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |       3,017.25 ns |       5.369 ns |       5.022 ns |       3,018.56 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |       4,087.21 ns |      10.418 ns |       9.235 ns |       4,086.17 ns |  20,978 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |       4,475.65 ns |       3.538 ns |       3.310 ns |       4,474.25 ns |  19,236 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      15,864.60 ns |      24.802 ns |      21.986 ns |      15,872.48 ns |  11,292 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     129,616.23 ns |     274.794 ns |     243.598 ns |     129,577.94 ns |  18,943 B |     560 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 12288B       |       2,175.41 ns |       2.093 ns |       1.958 ns |       2,174.82 ns |  20,917 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |       2,214.90 ns |       3.266 ns |       2.895 ns |       2,213.64 ns |  24,972 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |       2,249.54 ns |       3.442 ns |       3.219 ns |       2,249.02 ns |  24,972 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |       2,421.80 ns |       1.160 ns |       1.085 ns |       2,421.70 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |       2,463.73 ns |       2.140 ns |       2.002 ns |       2,462.80 ns |  22,431 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |       4,133.46 ns |       6.887 ns |       6.105 ns |       4,135.24 ns |  20,714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |       5,421.07 ns |       5.726 ns |       5.356 ns |       5,422.80 ns |  19,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      16,985.41 ns |      41.467 ns |      36.760 ns |      16,980.50 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     140,592.85 ns |     243.394 ns |     227.671 ns |     140,512.82 ns |  18,941 B |     616 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 15360B       |       2,244.59 ns |       2.052 ns |       1.919 ns |       2,243.81 ns |  20,904 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |       2,309.81 ns |       3.912 ns |       3.054 ns |       2,309.35 ns |  24,983 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |       2,312.62 ns |       2.445 ns |       2.167 ns |       2,312.95 ns |  24,983 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |       2,807.99 ns |       9.963 ns |       8.319 ns |       2,803.99 ns |  27,175 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |       4,023.38 ns |      16.273 ns |      15.222 ns |       4,021.26 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |       5,500.77 ns |      12.443 ns |      11.639 ns |       5,496.50 ns |  20,978 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |       8,258.30 ns |      24.804 ns |      23.202 ns |       8,259.25 ns |  13,044 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |      21,876.93 ns |     112.238 ns |      99.496 ns |      21,878.64 ns |  11,292 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     181,643.53 ns |   2,608.797 ns |   2,440.270 ns |     181,427.83 ns |  18,943 B |     784 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |       2,104.32 ns |       2.265 ns |       2.119 ns |       2,103.52 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 16KB         |       2,151.83 ns |       2.471 ns |       2.312 ns |       2,151.14 ns |  19,040 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |       2,169.21 ns |       3.804 ns |       3.558 ns |       2,169.52 ns |  23,517 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |       2,193.66 ns |       2.366 ns |       2.213 ns |       2,193.44 ns |  23,517 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |       2,695.61 ns |       3.275 ns |       3.064 ns |       2,694.58 ns |  19,203 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |       2,796.83 ns |       4.404 ns |       4.119 ns |       2,798.41 ns |  18,634 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |       5,526.61 ns |      14.899 ns |      13.936 ns |       5,525.56 ns |  20,714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |      23,087.86 ns |      41.169 ns |      34.378 ns |      23,080.38 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     190,320.85 ns |     367.842 ns |     344.080 ns |     190,299.88 ns |  18,948 B |     840 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |       3,276.57 ns |      44.250 ns |      41.392 ns |       3,271.92 ns |  41,218 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |       8,016.95 ns |       5.269 ns |       4.671 ns |       8,016.62 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 64KB         |       8,264.28 ns |       7.483 ns |       6.999 ns |       8,261.48 ns |  19,513 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |       8,326.71 ns |      12.523 ns |      11.714 ns |       8,322.40 ns |  23,518 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |       9,615.22 ns |      11.530 ns |      10.786 ns |       9,614.65 ns |  18,587 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |       9,675.99 ns |       9.731 ns |       8.626 ns |       9,672.67 ns |  19,994 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |      20,705.98 ns |      27.074 ns |      25.325 ns |      20,708.37 ns |  20,098 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |      90,784.21 ns |     129.436 ns |     114.742 ns |      90,745.81 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |     765,226.16 ns |   1,581.633 ns |   1,479.461 ns |     765,008.79 ns |  18,944 B |    3528 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |       5,149.15 ns |      11.714 ns |      10.958 ns |       5,146.36 ns |  45,084 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |      13,336.22 ns |      15.485 ns |      14.485 ns |      13,337.80 ns |  28,259 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |      13,601.90 ns |      23.516 ns |      18.360 ns |      13,605.88 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 100000B      |      13,615.71 ns |      14.294 ns |      13.371 ns |      13,612.39 ns |  23,238 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |      15,991.83 ns |      19.595 ns |      18.329 ns |      15,988.74 ns |  22,312 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |      16,360.30 ns |      27.574 ns |      25.793 ns |      16,362.97 ns |  20,326 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |      33,063.00 ns |      94.664 ns |      83.917 ns |      33,059.08 ns |  22,461 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     141,242.79 ns |     144.255 ns |     134.936 ns |     141,277.22 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |   1,129,256.98 ns |   2,034.798 ns |   1,903.351 ns |   1,128,995.12 ns |  18,933 B |    5432 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |       5,652.76 ns |      22.957 ns |      20.351 ns |       5,650.53 ns |  41,009 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |      15,875.24 ns |       6.554 ns |       5.117 ns |      15,876.56 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |      16,459.77 ns |      19.884 ns |      17.626 ns |      16,454.80 ns |  23,518 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 128KB        |      16,556.56 ns |       7.981 ns |       6.665 ns |      16,556.38 ns |  20,485 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |      19,255.67 ns |      19.710 ns |      18.437 ns |      19,246.86 ns |  19,559 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |      19,290.45 ns |      19.669 ns |      17.436 ns |      19,291.78 ns |  19,982 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |      41,247.07 ns |     158.109 ns |     132.028 ns |      41,230.83 ns |  21,070 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |     184,871.95 ns |     139.877 ns |     116.804 ns |     184,898.95 ns |  11,288 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |   1,483,109.96 ns |   1,487.971 ns |   1,319.047 ns |   1,482,841.89 ns |  18,944 B |    7112 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |      35,426.91 ns |     133.230 ns |     124.623 ns |      35,384.69 ns |  46,775 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |     121,571.08 ns |      91.472 ns |      85.563 ns |     121,549.48 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |     127,743.24 ns |     229.662 ns |     214.826 ns |     127,644.12 ns |  28,404 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1MB          |     128,757.98 ns |      86.788 ns |      81.182 ns |     128,749.34 ns |  21,876 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |     148,611.33 ns |     282.295 ns |     250.248 ns |     148,591.94 ns |  20,320 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |     149,768.66 ns |     298.156 ns |     278.895 ns |     149,733.74 ns |  20,950 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |     315,355.77 ns |     297.674 ns |     248.571 ns |     315,240.67 ns |  22,461 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |   1,412,898.77 ns |   1,277.777 ns |   1,132.716 ns |   1,412,722.85 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  11,277,852.34 ns |  18,373.282 ns |  16,287.436 ns |  11,275,125.78 ns |  18,930 B |   54656 B |
|                                                 |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |     349,075.24 ns |     876.739 ns |     820.103 ns |     348,864.16 ns |  47,079 B |     132 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |   1,222,803.89 ns |     536.208 ns |     447.758 ns |   1,222,890.43 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |   1,307,227.20 ns |   1,022.640 ns |     956.578 ns |   1,307,167.77 ns |  32,292 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10MB         |   1,324,353.52 ns |     570.163 ns |     533.331 ns |   1,324,250.98 ns |  28,648 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |   1,509,276.21 ns |   1,340.924 ns |   1,188.694 ns |   1,509,197.36 ns |  27,722 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |   1,665,776.53 ns |   2,545.081 ns |   2,125.258 ns |   1,665,188.67 ns |  20,283 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |   3,161,512.50 ns |   2,952.386 ns |   2,617.213 ns |   3,160,209.38 ns |  22,461 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  14,159,729.02 ns |  19,162.401 ns |  16,986.969 ns |  14,152,078.12 ns |  11,282 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 108,231,329.23 ns | 131,205.841 ns | 109,562.820 ns | 108,229,020.00 ns |  18,934 B |  546840 B |