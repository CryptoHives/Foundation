| Description                                     | TestDataSize | Mean              | Error          | StdDev         | Code Size | Allocated |
|------------------------------------------------ |------------- |------------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |          41.13 ns |       0.033 ns |       0.031 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 4B           |          41.14 ns |       0.054 ns |       0.051 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |          41.58 ns |       0.047 ns |       0.044 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |          44.55 ns |       0.063 ns |       0.056 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |          45.18 ns |       0.055 ns |       0.052 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |          65.31 ns |       0.043 ns |       0.038 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |          67.20 ns |       0.032 ns |       0.030 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |          89.28 ns |       0.154 ns |       0.144 ns |  12,514 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |         728.51 ns |       1.164 ns |       1.088 ns |  12,360 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 64B          |          40.85 ns |       0.034 ns |       0.030 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |          41.26 ns |       0.031 ns |       0.029 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |          41.26 ns |       0.042 ns |       0.039 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |          44.90 ns |       0.051 ns |       0.043 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |          45.27 ns |       0.038 ns |       0.036 ns |   4,483 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |          47.26 ns |       0.079 ns |       0.074 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |          60.94 ns |       0.136 ns |       0.121 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |          85.35 ns |       0.210 ns |       0.196 ns |  12,505 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |         728.09 ns |       0.882 ns |       0.736 ns |  12,349 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 65B          |          90.75 ns |       0.067 ns |       0.062 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |          90.76 ns |       0.059 ns |       0.056 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |          90.77 ns |       0.067 ns |       0.063 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |          97.27 ns |       0.073 ns |       0.068 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |          97.28 ns |       0.058 ns |       0.054 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |         106.84 ns |       0.071 ns |       0.066 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         118.76 ns |       0.021 ns |       0.018 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |         180.49 ns |       0.250 ns |       0.222 ns |  12,514 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |       1,570.82 ns |       1.821 ns |       1.703 ns |  12,102 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |          90.63 ns |       0.055 ns |       0.046 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |          90.68 ns |       0.055 ns |       0.048 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 100B         |          90.71 ns |       0.067 ns |       0.063 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |          97.21 ns |       0.060 ns |       0.056 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |          97.22 ns |       0.086 ns |       0.080 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |         107.05 ns |       0.083 ns |       0.078 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         117.12 ns |       0.084 ns |       0.070 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |         174.97 ns |       0.210 ns |       0.196 ns |  12,507 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |       1,574.35 ns |       2.203 ns |       1.953 ns |  12,067 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |          90.70 ns |       0.044 ns |       0.037 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 128B         |          90.75 ns |       0.051 ns |       0.048 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |          90.75 ns |       0.102 ns |       0.096 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |          96.93 ns |       0.083 ns |       0.078 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |          97.02 ns |       0.068 ns |       0.063 ns |   4,686 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |         102.95 ns |       0.053 ns |       0.044 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         117.02 ns |       0.028 ns |       0.026 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |         172.39 ns |       0.297 ns |       0.263 ns |  12,505 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |       1,581.23 ns |       2.502 ns |       2.340 ns |  12,083 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |         139.85 ns |       0.094 ns |       0.088 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |         139.91 ns |       0.130 ns |       0.122 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 137B         |         140.14 ns |       0.158 ns |       0.148 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |         151.17 ns |       0.121 ns |       0.113 ns |   4,984 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |         151.22 ns |       0.132 ns |       0.117 ns |   4,984 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |         163.57 ns |       0.127 ns |       0.119 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |         180.01 ns |       0.058 ns |       0.054 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |         266.47 ns |       0.537 ns |       0.502 ns |  12,514 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |       2,331.26 ns |       6.890 ns |       5.753 ns |  12,064 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |         778.55 ns |       0.172 ns |       0.153 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |         778.61 ns |       0.308 ns |       0.273 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1000B        |         779.06 ns |       0.208 ns |       0.174 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |         831.93 ns |       0.222 ns |       0.197 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |         846.91 ns |       0.202 ns |       0.179 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |         846.93 ns |       0.379 ns |       0.336 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |         906.28 ns |       0.394 ns |       0.368 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |       1,376.15 ns |       1.708 ns |       1.514 ns |  12,507 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      11,740.41 ns |      14.862 ns |      13.902 ns |  12,079 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1KB          |         778.55 ns |       0.117 ns |       0.092 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |         778.66 ns |       0.281 ns |       0.235 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |         778.66 ns |       0.146 ns |       0.114 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |         831.89 ns |       0.324 ns |       0.287 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |         846.55 ns |       0.188 ns |       0.166 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |         846.66 ns |       0.171 ns |       0.142 ns |   4,986 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |         902.35 ns |       0.179 ns |       0.149 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |       1,374.11 ns |       2.201 ns |       2.059 ns |  12,505 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      11,016.93 ns |      13.907 ns |      13.008 ns |  12,047 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |         863.19 ns |       0.183 ns |       0.163 ns |   7,928 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |         870.41 ns |       0.253 ns |       0.237 ns |   7,928 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |         916.05 ns |       0.373 ns |       0.349 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1025B        |         920.46 ns |       0.279 ns |       0.261 ns |   7,291 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |         920.54 ns |       0.203 ns |       0.190 ns |   7,291 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |         920.85 ns |       0.232 ns |       0.206 ns |   7,291 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |       1,051.44 ns |       0.552 ns |       0.516 ns |   4,695 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |       1,559.50 ns |       2.217 ns |       2.074 ns |  10,874 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      12,451.61 ns |       6.460 ns |       5.394 ns |  19,011 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |         856.22 ns |       0.103 ns |       0.080 ns |   7,014 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 2KB          |         856.52 ns |       0.434 ns |       0.406 ns |   7,276 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |         856.96 ns |       0.215 ns |       0.190 ns |   7,276 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |         863.00 ns |       0.237 ns |       0.210 ns |   7,014 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |         869.34 ns |       0.361 ns |       0.320 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |       1,634.96 ns |       0.498 ns |       0.466 ns |   7,289 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |       1,916.08 ns |       1.189 ns |       1.112 ns |   4,685 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |       2,813.42 ns |       3.121 ns |       2.919 ns |  10,872 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |      22,174.89 ns |      29.852 ns |      27.923 ns |  18,927 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |       1,030.94 ns |       0.489 ns |       0.433 ns |  13,378 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |       1,032.22 ns |       0.396 ns |       0.351 ns |  13,364 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 3KB          |       1,075.78 ns |       0.871 ns |       0.815 ns |   8,127 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |       1,081.23 ns |       0.531 ns |       0.471 ns |   8,127 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |       1,316.86 ns |       1.136 ns |       1.007 ns |  13,170 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |       1,707.28 ns |       0.494 ns |       0.462 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |       2,945.33 ns |       0.853 ns |       0.798 ns |  11,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |       4,259.46 ns |       5.639 ns |       5.275 ns |  11,020 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |      34,912.74 ns |      72.936 ns |      68.224 ns |  18,927 B |     112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |       1,027.14 ns |       0.571 ns |       0.534 ns |  11,842 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |       1,029.05 ns |       0.234 ns |       0.195 ns |  11,842 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 4KB          |       1,115.77 ns |       0.796 ns |       0.745 ns |   8,103 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |       1,117.27 ns |       0.727 ns |       0.680 ns |   8,103 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |       1,121.96 ns |       0.428 ns |       0.358 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |       1,355.62 ns |       2.475 ns |       2.315 ns |  19,471 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |       3,850.96 ns |       1.407 ns |       1.247 ns |  11,551 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |       5,713.83 ns |       8.270 ns |       7.736 ns |  10,995 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |      45,965.96 ns |      74.173 ns |      65.752 ns |  18,922 B |     168 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |       1,311.05 ns |       0.719 ns |       0.637 ns |  15,579 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |       1,315.62 ns |       1.096 ns |       1.025 ns |  15,579 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 5KB          |       1,403.28 ns |       0.691 ns |       0.613 ns |  12,752 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |       1,407.61 ns |       1.413 ns |       1.322 ns |  12,752 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |       1,968.92 ns |       0.802 ns |       0.711 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |       2,182.43 ns |       2.654 ns |       2.353 ns |  21,075 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |       4,882.89 ns |       2.858 ns |       2.673 ns |  17,735 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |       7,161.23 ns |       9.582 ns |       8.963 ns |  11,019 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |      58,403.54 ns |      56.680 ns |      53.019 ns |  18,926 B |     224 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |       1,316.37 ns |       1.089 ns |       1.018 ns |  22,448 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |       1,330.14 ns |       1.193 ns |       1.116 ns |  22,448 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 6KB          |       1,448.97 ns |       0.834 ns |       0.780 ns |  12,728 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |       1,454.68 ns |       1.268 ns |       1.186 ns |  12,728 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |       2,010.11 ns |       0.654 ns |       0.612 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |       3,026.64 ns |       2.285 ns |       2.137 ns |  21,052 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |       5,799.02 ns |       2.906 ns |       2.719 ns |  17,749 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |       8,430.53 ns |       9.079 ns |       8.048 ns |  10,995 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |      69,224.15 ns |      75.044 ns |      62.665 ns |  18,941 B |     280 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |       1,286.01 ns |       0.866 ns |       0.811 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 8KB          |       1,324.42 ns |       0.359 ns |       0.336 ns |  17,963 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |       1,327.76 ns |       0.606 ns |       0.537 ns |  17,963 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |       1,345.02 ns |       1.421 ns |       1.259 ns |  22,286 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |       1,345.48 ns |       0.764 ns |       0.715 ns |  22,286 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |       1,581.21 ns |       1.121 ns |       1.048 ns |  12,726 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |       2,757.47 ns |       3.320 ns |       3.106 ns |  19,658 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      11,491.28 ns |      14.253 ns |      13.332 ns |  11,001 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |      94,042.37 ns |      89.545 ns |      83.760 ns |  18,941 B |     392 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |       2,133.77 ns |       0.734 ns |       0.650 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 9216B        |       2,160.40 ns |       0.800 ns |       0.709 ns |  19,567 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |       2,160.54 ns |       1.391 ns |       1.301 ns |  19,567 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |       2,201.41 ns |       1.825 ns |       1.707 ns |  27,502 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |       2,206.84 ns |       2.609 ns |       2.313 ns |  27,488 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |       2,633.52 ns |       1.850 ns |       1.731 ns |  19,238 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |       3,573.69 ns |       2.544 ns |       2.380 ns |  21,075 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      12,931.46 ns |       9.479 ns |       8.403 ns |  11,019 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     104,671.81 ns |     100.337 ns |      88.946 ns |  18,928 B |     448 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |       2,217.12 ns |       2.243 ns |       2.098 ns |  25,336 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |       2,223.95 ns |       1.100 ns |       0.919 ns |  25,339 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10000B       |       2,852.21 ns |       0.671 ns |       0.595 ns |  19,544 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |       2,853.21 ns |       0.590 ns |       0.523 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |       2,854.41 ns |       1.172 ns |       1.097 ns |  19,544 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |       3,369.34 ns |       1.424 ns |       1.189 ns |  19,242 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |       4,270.91 ns |       6.520 ns |       5.779 ns |  21,056 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      14,119.57 ns |      12.885 ns |      12.053 ns |  10,995 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     114,646.43 ns |     131.907 ns |     116.932 ns |  18,947 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |       2,182.79 ns |       0.674 ns |       0.598 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |       2,214.08 ns |       1.276 ns |       1.194 ns |  24,428 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10240B       |       2,222.13 ns |       0.913 ns |       0.854 ns |  19,530 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |       2,222.63 ns |       1.907 ns |       1.691 ns |  24,428 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |       2,224.09 ns |       1.546 ns |       1.446 ns |  19,530 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |       3,686.14 ns |       1.649 ns |       1.462 ns |  19,241 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |       4,409.79 ns |       3.510 ns |       3.111 ns |  21,056 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      14,115.99 ns |      14.237 ns |      13.317 ns |  10,995 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     117,303.55 ns |     127.217 ns |     118.998 ns |  18,941 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |       2,328.84 ns |       2.171 ns |       2.031 ns |  27,137 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |       2,329.79 ns |       2.846 ns |       2.663 ns |  27,137 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 11264B       |       2,443.26 ns |       1.807 ns |       1.690 ns |  20,233 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |       2,452.86 ns |       1.044 ns |       0.925 ns |  20,233 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |       3,002.71 ns |       0.566 ns |       0.529 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |       4,101.20 ns |       6.501 ns |       6.081 ns |  19,905 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |       4,462.64 ns |       1.726 ns |       1.615 ns |  19,241 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      15,805.70 ns |      25.359 ns |      22.480 ns |  10,995 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     128,750.13 ns |      94.403 ns |      78.830 ns |  18,943 B |     560 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |       2,213.14 ns |       3.676 ns |       3.438 ns |  24,972 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |       2,245.15 ns |       1.732 ns |       1.620 ns |  24,972 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |       2,417.16 ns |       0.621 ns |       0.551 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |       2,482.70 ns |       0.953 ns |       0.891 ns |  20,243 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 12288B       |       2,485.01 ns |       2.204 ns |       2.062 ns |  20,243 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |       4,119.67 ns |       6.919 ns |       6.133 ns |  19,658 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |       5,395.78 ns |       2.060 ns |       1.826 ns |  19,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      16,955.18 ns |      19.734 ns |      18.459 ns |  11,001 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     142,851.00 ns |     138.154 ns |     129.229 ns |  18,941 B |     616 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |       2,281.90 ns |       2.926 ns |       2.737 ns |  24,983 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |       2,318.07 ns |       1.604 ns |       1.422 ns |  24,983 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |       2,892.76 ns |       1.526 ns |       1.427 ns |  24,868 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 15360B       |       2,910.92 ns |       2.362 ns |       2.209 ns |  24,868 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |       4,001.36 ns |       1.332 ns |       1.246 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |       5,481.61 ns |       7.227 ns |       6.760 ns |  19,915 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |       8,204.75 ns |       4.316 ns |       4.037 ns |  13,044 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |      21,593.80 ns |      21.263 ns |      19.890 ns |  11,001 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     175,786.30 ns |     269.441 ns |     252.036 ns |  18,941 B |     784 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |       2,099.36 ns |       1.710 ns |       1.600 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |       2,158.45 ns |       2.568 ns |       2.402 ns |  23,517 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 16KB         |       2,160.42 ns |       1.465 ns |       1.371 ns |  18,312 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |       2,160.76 ns |       2.171 ns |       2.031 ns |  23,517 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |       2,530.89 ns |       3.994 ns |       3.335 ns |  18,632 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |       2,689.21 ns |       1.479 ns |       1.383 ns |  18,150 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |       5,516.87 ns |       5.152 ns |       4.302 ns |  19,668 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |      23,040.07 ns |      32.182 ns |      30.103 ns |  11,006 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     190,609.36 ns |     254.999 ns |     238.526 ns |  18,938 B |     840 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |       3,255.15 ns |      44.164 ns |      41.311 ns |  40,143 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |       8,018.49 ns |       5.101 ns |       4.522 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |       8,237.81 ns |       4.829 ns |       4.517 ns |  23,518 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 64KB         |       8,289.96 ns |       6.452 ns |       6.035 ns |  18,745 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |       9,617.30 ns |       5.202 ns |       4.866 ns |  18,319 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |      11,262.53 ns |       7.861 ns |       7.353 ns |  19,996 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |      20,486.38 ns |      22.125 ns |      19.613 ns |  19,827 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |      92,361.93 ns |      72.380 ns |      64.163 ns |  11,006 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |     752,000.16 ns |     901.526 ns |     843.288 ns |  18,944 B |    3528 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |       5,108.61 ns |      11.854 ns |      10.508 ns |  44,243 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |      13,315.56 ns |       3.933 ns |       3.486 ns |  28,285 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |      13,543.80 ns |       8.256 ns |       7.723 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 100000B      |      14,112.39 ns |       5.423 ns |       4.807 ns |  20,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |      16,175.25 ns |      24.600 ns |      23.011 ns |  20,297 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |      16,513.13 ns |       7.472 ns |       6.624 ns |  19,906 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |      33,027.91 ns |      40.172 ns |      35.612 ns |  21,414 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     141,132.55 ns |     186.442 ns |     174.398 ns |  11,001 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |   1,175,313.24 ns |   1,738.100 ns |   1,625.820 ns |  18,933 B |    5432 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |       5,593.00 ns |      18.147 ns |      16.087 ns |  40,314 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |      15,944.01 ns |       6.412 ns |       5.997 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |      16,552.42 ns |      10.245 ns |       9.082 ns |  23,518 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 128KB        |      16,696.39 ns |      13.341 ns |      12.479 ns |  18,932 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |      19,247.21 ns |      13.281 ns |      12.423 ns |  18,506 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |      21,370.12 ns |      12.106 ns |      11.324 ns |  19,980 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |      41,027.91 ns |      68.666 ns |      60.870 ns |  20,014 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |     185,081.82 ns |     282.131 ns |     263.905 ns |  11,006 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |   1,483,899.74 ns |   1,886.976 ns |   1,765.079 ns |  18,944 B |    7112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |      35,379.33 ns |      54.954 ns |      48.715 ns |  47,146 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |     121,719.02 ns |      49.119 ns |      45.946 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |     126,711.68 ns |     135.981 ns |     127.197 ns |  28,404 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 1MB          |     129,118.06 ns |      61.227 ns |      54.276 ns |  20,337 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |     149,135.97 ns |     112.103 ns |      99.377 ns |  19,911 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |     163,626.62 ns |     103.069 ns |      96.411 ns |  20,321 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |     314,922.39 ns |     461.310 ns |     431.510 ns |  21,419 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |   1,412,815.86 ns |   1,671.631 ns |   1,563.645 ns |  11,006 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  10,933,187.08 ns |  19,718.403 ns |  18,444.606 ns |  18,934 B |   54656 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |     348,637.18 ns |     500.316 ns |     443.517 ns |  47,299 B |     132 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |   1,223,129.58 ns |     453.058 ns |     423.790 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |   1,303,490.64 ns |   1,172.436 ns |   1,039.334 ns |  32,294 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F   | 10MB         |   1,326,348.87 ns |     881.394 ns |     824.456 ns |  27,045 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |   1,509,460.51 ns |     723.755 ns |     677.001 ns |  26,619 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |   1,666,365.26 ns |     605.289 ns |     505.444 ns |  20,283 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |   3,159,506.77 ns |   4,576.499 ns |   4,280.860 ns |  21,419 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  14,130,030.36 ns |  11,314.800 ns |  10,030.275 ns |  11,006 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 108,743,035.71 ns | 175,134.802 ns | 155,252.440 ns |  18,934 B |  546840 B |