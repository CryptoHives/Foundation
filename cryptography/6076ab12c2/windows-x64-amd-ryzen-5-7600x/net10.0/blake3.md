| Description                                         | TestDataSize | Mean              | Error          | StdDev         | Code Size | Allocated |
|---------------------------------------------------- |------------- |------------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4B           |          41.17 ns |       0.051 ns |       0.043 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4B           |          41.17 ns |       0.056 ns |       0.052 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4B           |          41.50 ns |       0.051 ns |       0.048 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4B           |          45.07 ns |       0.254 ns |       0.237 ns |   4,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4B           |          45.07 ns |       0.377 ns |       0.352 ns |   4,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4B           |          65.43 ns |       0.029 ns |       0.025 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4B           |          67.22 ns |       0.030 ns |       0.028 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4B           |          89.38 ns |       0.288 ns |       0.269 ns |  12,514 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4B           |         743.93 ns |       0.934 ns |       0.828 ns |  12,360 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 64B          |          41.17 ns |       0.197 ns |       0.185 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 64B          |          41.33 ns |       0.322 ns |       0.301 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 64B          |          41.43 ns |       0.175 ns |       0.164 ns |   2,194 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64B          |          44.80 ns |       0.801 ns |       1.149 ns |   4,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64B          |          45.83 ns |       0.287 ns |       0.255 ns |   4,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64B          |          47.95 ns |       0.489 ns |       0.457 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64B          |          61.39 ns |       0.259 ns |       0.230 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64B          |          86.06 ns |       0.813 ns |       0.760 ns |  12,505 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64B          |         743.49 ns |       6.739 ns |       6.304 ns |  12,349 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 65B          |          91.31 ns |       0.306 ns |       0.286 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 65B          |          91.31 ns |       0.291 ns |       0.258 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 65B          |          91.41 ns |       0.329 ns |       0.308 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 65B          |          97.24 ns |       0.086 ns |       0.081 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 65B          |          97.25 ns |       0.070 ns |       0.065 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 65B          |         106.83 ns |       0.084 ns |       0.074 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 65B          |         118.94 ns |       0.197 ns |       0.184 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 65B          |         180.98 ns |       1.698 ns |       1.589 ns |  12,514 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 65B          |       1,580.38 ns |      14.290 ns |      13.367 ns |  12,102 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100B         |          90.63 ns |       0.052 ns |       0.048 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100B         |          90.63 ns |       0.060 ns |       0.054 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100B         |          90.75 ns |       0.073 ns |       0.068 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100B         |          97.33 ns |       0.061 ns |       0.054 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100B         |          97.39 ns |       0.082 ns |       0.077 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100B         |         107.16 ns |       0.064 ns |       0.060 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100B         |         117.06 ns |       0.065 ns |       0.061 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100B         |         175.03 ns |       0.230 ns |       0.203 ns |  12,507 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100B         |       1,600.36 ns |       1.407 ns |       1.099 ns |  12,078 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128B         |          90.91 ns |       0.091 ns |       0.085 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128B         |          91.26 ns |       0.080 ns |       0.075 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128B         |          93.13 ns |       0.079 ns |       0.074 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128B         |          96.93 ns |       0.074 ns |       0.061 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128B         |          96.97 ns |       0.054 ns |       0.051 ns |   4,537 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128B         |         103.04 ns |       0.084 ns |       0.079 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128B         |         117.13 ns |       0.056 ns |       0.052 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128B         |         172.88 ns |       0.284 ns |       0.266 ns |  12,505 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128B         |       1,607.78 ns |       3.027 ns |       2.831 ns |  12,067 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 137B         |         139.85 ns |       0.073 ns |       0.061 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 137B         |         139.88 ns |       0.092 ns |       0.086 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 137B         |         139.91 ns |       0.146 ns |       0.137 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 137B         |         152.45 ns |       0.119 ns |       0.105 ns |   4,856 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 137B         |         152.52 ns |       0.126 ns |       0.118 ns |   4,856 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 137B         |         164.01 ns |       0.143 ns |       0.134 ns |   3,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 137B         |         170.03 ns |       0.120 ns |       0.112 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 137B         |         264.70 ns |       0.367 ns |       0.344 ns |  12,514 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 137B         |       2,301.99 ns |       3.626 ns |       3.392 ns |  12,063 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1000B        |         778.73 ns |       0.314 ns |       0.294 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1000B        |         778.88 ns |       0.396 ns |       0.370 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1000B        |         779.91 ns |       0.200 ns |       0.177 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1000B        |         831.56 ns |       0.328 ns |       0.306 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1000B        |         840.30 ns |       0.261 ns |       0.244 ns |   4,856 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1000B        |         841.35 ns |       0.417 ns |       0.390 ns |   4,856 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1000B        |         906.59 ns |       0.256 ns |       0.227 ns |   3,334 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1000B        |       1,376.23 ns |       1.867 ns |       1.655 ns |  12,507 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1000B        |      11,736.46 ns |      16.359 ns |      15.302 ns |  12,079 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1KB          |         778.89 ns |       0.343 ns |       0.321 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1KB          |         778.99 ns |       0.215 ns |       0.190 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1KB          |         779.00 ns |       0.436 ns |       0.408 ns |   4,225 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1KB          |         832.94 ns |       0.504 ns |       0.472 ns |     710 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1KB          |         839.86 ns |       0.220 ns |       0.205 ns |   4,856 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1KB          |         840.05 ns |       0.409 ns |       0.382 ns |   4,856 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1KB          |         903.69 ns |       0.420 ns |       0.393 ns |   3,332 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1KB          |       1,372.18 ns |       1.507 ns |       1.336 ns |  12,505 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1KB          |      11,218.21 ns |      11.627 ns |      10.876 ns |  12,047 B |         - |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1025B        |         917.04 ns |       0.558 ns |       0.522 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1025B        |         918.65 ns |       0.338 ns |       0.316 ns |   7,156 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1025B        |         919.23 ns |       0.269 ns |       0.252 ns |   7,153 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1025B        |         920.63 ns |       0.350 ns |       0.311 ns |   7,156 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1025B        |       1,007.91 ns |       0.620 ns |       0.580 ns |   5,661 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1025B        |       1,008.44 ns |       0.634 ns |       0.593 ns |   5,661 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1025B        |       1,056.65 ns |       0.702 ns |       0.622 ns |   4,687 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1025B        |       1,531.04 ns |       1.578 ns |       1.476 ns |  10,739 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1025B        |      12,630.15 ns |      12.021 ns |      10.656 ns |  19,018 B |      56 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 2KB          |         856.21 ns |       0.454 ns |       0.424 ns |   7,138 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 2KB          |         856.91 ns |       0.292 ns |       0.273 ns |   7,138 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 2KB          |         858.14 ns |       0.321 ns |       0.301 ns |   6,561 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 2KB          |         858.47 ns |       0.446 ns |       0.417 ns |   6,561 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 2KB          |         862.50 ns |       0.599 ns |       0.560 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 2KB          |       1,633.41 ns |       0.618 ns |       0.548 ns |   7,154 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 2KB          |       1,919.24 ns |       0.983 ns |       0.821 ns |   4,685 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 2KB          |       2,750.54 ns |       3.131 ns |       2.615 ns |  10,737 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 2KB          |      22,715.08 ns |      23.046 ns |      21.557 ns |  18,926 B |      56 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 3KB          |       1,039.96 ns |       0.852 ns |       0.797 ns |  12,399 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 3KB          |       1,040.18 ns |       0.427 ns |       0.378 ns |  12,399 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 3KB          |       1,074.75 ns |       0.604 ns |       0.504 ns |   7,989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 3KB          |       1,075.23 ns |       0.772 ns |       0.722 ns |   7,989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 3KB          |       1,316.86 ns |       1.437 ns |       1.344 ns |  13,032 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 3KB          |       1,709.35 ns |       1.738 ns |       1.625 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 3KB          |       2,947.78 ns |       1.800 ns |       1.684 ns |  11,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 3KB          |       4,173.00 ns |       9.273 ns |       8.674 ns |  10,885 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 3KB          |      34,813.67 ns |      36.350 ns |      34.002 ns |  18,933 B |     112 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 4KB          |       1,083.88 ns |       0.832 ns |       0.778 ns |  12,392 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 4KB          |       1,085.39 ns |       0.687 ns |       0.643 ns |  12,392 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 4KB          |       1,117.16 ns |       0.757 ns |       0.671 ns |   7,966 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 4KB          |       1,118.97 ns |       0.711 ns |       0.665 ns |   7,966 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 4KB          |       1,121.64 ns |       0.898 ns |       0.840 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 4KB          |       1,349.65 ns |       2.151 ns |       2.012 ns |  19,333 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 4KB          |       3,884.36 ns |       2.719 ns |       2.544 ns |  11,551 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 4KB          |       5,585.22 ns |       4.683 ns |       4.380 ns |  10,870 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 4KB          |      45,908.21 ns |      41.972 ns |      39.261 ns |  18,919 B |     168 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 5KB          |       1,338.07 ns |       0.981 ns |       0.918 ns |  15,246 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 5KB          |       1,398.88 ns |       0.834 ns |       0.739 ns |  12,614 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 5KB          |       1,400.93 ns |       1.029 ns |       0.962 ns |  12,614 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 5KB          |       1,464.38 ns |       1.001 ns |       0.887 ns |  15,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 5KB          |       1,968.40 ns |       0.981 ns |       0.870 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 5KB          |       2,181.98 ns |       0.688 ns |       0.610 ns |  20,940 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 5KB          |       4,881.69 ns |       2.281 ns |       2.022 ns |  17,735 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 5KB          |       7,012.34 ns |       6.678 ns |       6.247 ns |  10,883 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 5KB          |      57,690.65 ns |      55.091 ns |      48.837 ns |  18,933 B |     224 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 6KB          |       1,456.17 ns |       1.188 ns |       1.053 ns |  12,591 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 6KB          |       1,469.02 ns |       0.581 ns |       0.543 ns |  22,120 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 6KB          |       1,471.62 ns |       1.406 ns |       1.315 ns |  12,591 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 6KB          |       1,480.50 ns |       0.696 ns |       0.651 ns |  22,120 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 6KB          |       2,009.33 ns |       0.899 ns |       0.840 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 6KB          |       3,015.03 ns |       2.298 ns |       2.037 ns |  20,927 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 6KB          |       5,819.68 ns |       2.653 ns |       2.216 ns |  17,742 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 6KB          |       8,425.39 ns |      15.916 ns |      14.887 ns |  10,870 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 6KB          |      71,390.47 ns |     116.580 ns |     109.049 ns |  18,921 B |     280 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 8KB          |       1,286.92 ns |       0.901 ns |       0.843 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 8KB          |       1,325.09 ns |       0.695 ns |       0.616 ns |  17,825 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 8KB          |       1,329.82 ns |       0.608 ns |       0.508 ns |  17,825 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 8KB          |       1,356.76 ns |       0.843 ns |       0.748 ns |  21,930 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 8KB          |       1,373.09 ns |       0.978 ns |       0.915 ns |  21,930 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 8KB          |       1,581.58 ns |       1.176 ns |       1.100 ns |  12,726 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 8KB          |       2,734.12 ns |       3.147 ns |       2.790 ns |  19,521 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 8KB          |      11,252.05 ns |      11.936 ns |      11.165 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 8KB          |      92,044.09 ns |      63.349 ns |      56.157 ns |  18,929 B |     392 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 9216B        |       2,139.76 ns |       4.973 ns |       4.651 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 9216B        |       2,157.23 ns |       1.008 ns |       0.842 ns |  19,432 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 9216B        |       2,157.79 ns |       2.661 ns |       2.489 ns |  19,432 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 9216B        |       2,349.53 ns |      16.621 ns |      15.548 ns |  22,166 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 9216B        |       2,355.58 ns |       7.982 ns |       7.467 ns |  22,167 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 9216B        |       2,889.95 ns |       3.370 ns |       2.814 ns |  19,234 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 9216B        |       3,571.95 ns |       2.211 ns |       1.960 ns |  20,940 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 9216B        |      12,685.17 ns |      15.498 ns |      13.738 ns |  10,883 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 9216B        |     105,931.76 ns |      75.130 ns |      70.277 ns |  18,934 B |     448 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10000B       |       2,846.33 ns |       5.513 ns |       5.157 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10000B       |       2,861.86 ns |       5.594 ns |       5.233 ns |  19,419 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10000B       |       2,865.56 ns |       8.180 ns |       7.651 ns |  19,419 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10000B       |       3,071.50 ns |      10.620 ns |       9.934 ns |  22,159 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10000B       |       3,164.16 ns |      10.632 ns |       9.945 ns |  22,157 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10000B       |       3,387.65 ns |      12.440 ns |      11.636 ns |  19,242 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10000B       |       4,339.93 ns |      24.630 ns |      23.039 ns |  20,934 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10000B       |      14,038.86 ns |     150.482 ns |     133.399 ns |  10,870 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10000B       |     115,909.61 ns |     431.662 ns |     403.777 ns |  18,945 B |     504 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10240B       |       2,185.20 ns |       3.074 ns |       2.875 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10240B       |       2,228.60 ns |       7.087 ns |       6.630 ns |  19,393 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10240B       |       2,229.82 ns |       7.849 ns |       7.342 ns |  19,393 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10240B       |       2,265.46 ns |      12.057 ns |      11.278 ns |  23,063 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10240B       |       2,450.88 ns |       9.232 ns |       8.184 ns |  23,063 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10240B       |       3,618.85 ns |      10.635 ns |       9.948 ns |  19,236 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10240B       |       4,446.25 ns |      21.694 ns |      18.116 ns |  20,934 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10240B       |      14,280.47 ns |     113.684 ns |     106.340 ns |  10,870 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10240B       |     117,559.10 ns |     873.592 ns |     817.158 ns |  18,941 B |     504 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 11264B       |       2,451.99 ns |       8.024 ns |       7.506 ns |  20,096 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 11264B       |       2,457.49 ns |      11.896 ns |      11.127 ns |  20,096 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 11264B       |       2,492.42 ns |      11.797 ns |      11.035 ns |  25,760 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 11264B       |       2,574.22 ns |      18.155 ns |      16.982 ns |  25,742 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 11264B       |       3,010.25 ns |       4.726 ns |       4.421 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 11264B       |       4,147.21 ns |      40.762 ns |      38.129 ns |  19,768 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 11264B       |       4,501.33 ns |      10.694 ns |      10.003 ns |  19,236 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 11264B       |      15,667.74 ns |     145.094 ns |     135.721 ns |  10,870 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 11264B       |     128,718.29 ns |   1,064.991 ns |     996.194 ns |  18,943 B |     560 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 12288B       |       2,424.16 ns |       3.253 ns |       3.042 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 12288B       |       2,479.29 ns |      17.669 ns |      16.528 ns |  25,754 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 12288B       |       2,495.57 ns |      13.197 ns |      12.345 ns |  25,736 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 12288B       |       2,498.14 ns |      12.821 ns |      11.993 ns |  20,119 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 12288B       |       2,498.39 ns |       9.301 ns |       8.700 ns |  20,119 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 12288B       |       4,184.22 ns |      25.907 ns |      24.234 ns |  19,521 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 12288B       |       5,412.44 ns |      13.428 ns |      12.561 ns |  19,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 12288B       |      17,164.56 ns |      88.617 ns |      82.893 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 12288B       |     141,974.55 ns |     896.734 ns |     838.805 ns |  18,941 B |     616 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 15360B       |       2,797.08 ns |      18.486 ns |      17.292 ns |  28,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 15360B       |       2,894.85 ns |      16.698 ns |      15.619 ns |  24,744 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 15360B       |       2,895.97 ns |      12.063 ns |      11.284 ns |  24,744 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 15360B       |       2,998.81 ns |      17.730 ns |      16.584 ns |  28,618 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 15360B       |       4,008.01 ns |       4.901 ns |       4.584 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 15360B       |       5,593.73 ns |      52.475 ns |      49.085 ns |  19,791 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 15360B       |       8,241.07 ns |      12.269 ns |      11.477 ns |  13,044 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 15360B       |      21,409.33 ns |     142.965 ns |     133.730 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 15360B       |     176,801.89 ns |   1,187.515 ns |   1,052.701 ns |  18,943 B |     784 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 16KB         |       2,110.42 ns |       8.230 ns |       7.698 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 16KB         |       2,193.19 ns |       9.929 ns |       9.287 ns |  18,174 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 16KB         |       2,242.63 ns |      12.806 ns |      11.979 ns |  19,643 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 16KB         |       2,258.74 ns |       8.938 ns |       8.361 ns |  19,625 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 16KB         |       2,705.30 ns |       9.813 ns |       9.179 ns |  18,013 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 16KB         |       2,816.69 ns |       9.357 ns |       8.752 ns |  18,634 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 16KB         |       5,576.19 ns |      29.690 ns |      24.793 ns |  19,544 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 16KB         |      22,844.98 ns |     188.537 ns |     167.133 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 16KB         |     187,427.47 ns |   1,401.266 ns |   1,310.745 ns |  18,950 B |     840 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 64KB         |       3,299.88 ns |      12.722 ns |      11.901 ns |  34,424 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 64KB         |       8,015.57 ns |      13.231 ns |      12.376 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 64KB         |       8,301.69 ns |      27.563 ns |      25.782 ns |  18,607 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 64KB         |       8,587.60 ns |      43.563 ns |      40.749 ns |  19,643 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 64KB         |       9,655.34 ns |      25.589 ns |      23.936 ns |  18,181 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 64KB         |      10,854.77 ns |      42.212 ns |      39.485 ns |  19,996 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 64KB         |      20,718.58 ns |     148.182 ns |     138.610 ns |  19,689 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 64KB         |      91,606.37 ns |     675.370 ns |     598.698 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 64KB         |     750,224.88 ns |   5,712.085 ns |   5,343.088 ns |  18,944 B |    3528 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 100000B      |       5,312.48 ns |      19.607 ns |      18.340 ns |  35,975 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 100000B      |      13,563.87 ns |       7.843 ns |       7.337 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 100000B      |      14,174.16 ns |      38.422 ns |      35.940 ns |  20,213 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 100000B      |      14,365.79 ns |       7.770 ns |       7.268 ns |  22,035 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 100000B      |      16,291.65 ns |      10.732 ns |       9.514 ns |  20,272 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 100000B      |      16,480.20 ns |      10.806 ns |       9.579 ns |  19,787 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 100000B      |      33,130.38 ns |      45.295 ns |      42.369 ns |  21,295 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 100000B      |     141,442.66 ns |     118.300 ns |     110.658 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 100000B      |   1,176,486.37 ns |   1,760.241 ns |   1,646.531 ns |  18,933 B |    5432 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 128KB        |       5,762.42 ns |      20.468 ns |      15.980 ns |  34,278 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 128KB        |      15,880.62 ns |       8.958 ns |       8.380 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 128KB        |      16,628.83 ns |      16.153 ns |      15.110 ns |  18,795 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 128KB        |      16,941.11 ns |      17.643 ns |      16.503 ns |  19,643 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 128KB        |      19,283.98 ns |      13.557 ns |      12.681 ns |  18,369 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 128KB        |      22,860.77 ns |      17.799 ns |      15.778 ns |  19,980 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 128KB        |      41,079.79 ns |      67.626 ns |      63.257 ns |  19,877 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 128KB        |     184,840.04 ns |     342.854 ns |     286.299 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 128KB        |   1,530,666.09 ns |   2,077.932 ns |   1,943.699 ns |  18,939 B |    7112 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 1MB          |      36,140.93 ns |      91.834 ns |      76.686 ns |  36,320 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 1MB          |     121,779.79 ns |      64.108 ns |      59.967 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 1MB          |     129,918.76 ns |     123.382 ns |     109.375 ns |  20,213 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 1MB          |     130,596.75 ns |     217.820 ns |     203.749 ns |  21,658 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 1MB          |     149,307.76 ns |     116.918 ns |     109.365 ns |  19,787 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 1MB          |     169,661.59 ns |     136.068 ns |     120.621 ns |  20,321 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 1MB          |     316,308.99 ns |     549.351 ns |     513.863 ns |  21,295 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 1MB          |   1,413,656.99 ns |   2,377.746 ns |   2,224.145 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 1MB          |  10,875,050.73 ns |  12,757.375 ns |  11,933.257 ns |  18,934 B |   54656 B |
|                                                     |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed            | 10MB         |     355,046.28 ns |     396.694 ns |     331.257 ns |  44,613 B |     129 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native         | 10MB         |   1,221,482.71 ns |     578.952 ns |     541.552 ns |     714 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F       | 10MB         |   1,327,226.28 ns |     802.070 ns |     750.257 ns |  26,921 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed (1 thread) | 10MB         |   1,334,798.02 ns |   1,043.239 ns |     975.847 ns |  29,369 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed        | 10MB         |   1,507,415.25 ns |   1,288.781 ns |   1,205.527 ns |  20,279 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2          | 10MB         |   1,510,305.86 ns |   1,144.264 ns |   1,070.345 ns |  26,495 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3         | 10MB         |   3,169,437.73 ns |   3,339.681 ns |   3,123.940 ns |  21,295 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar        | 10MB         |  14,135,327.71 ns |  11,423.437 ns |  10,685.490 ns |  10,882 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle              | 10MB         | 110,999,081.67 ns | 167,673.631 ns | 130,908.542 ns |  18,934 B |  546840 B |