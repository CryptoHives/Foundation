| Description                                     | TestDataSize | Mean             | Error            | StdDev           | Code Size | Allocated |
|------------------------------------------------ |------------- |-----------------:|-----------------:|-----------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |         50.07 ns |         0.611 ns |         0.571 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |         50.09 ns |         0.648 ns |         0.606 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |         53.50 ns |         0.757 ns |         0.708 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |         54.47 ns |         0.682 ns |         0.638 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |         66.61 ns |         0.712 ns |         0.666 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |         68.26 ns |         0.921 ns |         0.861 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |        106.51 ns |         1.121 ns |         1.049 ns |  12,538 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |        576.08 ns |         9.117 ns |         8.528 ns |  12,464 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |         49.77 ns |         0.478 ns |         0.447 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |         50.25 ns |         0.837 ns |         0.783 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |         52.82 ns |         0.832 ns |         0.778 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |         52.88 ns |         0.675 ns |         0.631 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |         57.91 ns |         0.207 ns |         0.184 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |         62.02 ns |         0.760 ns |         0.711 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |        102.10 ns |         1.318 ns |         1.233 ns |  12,525 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |        577.76 ns |         6.892 ns |         6.447 ns |  12,450 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |         98.02 ns |         1.156 ns |         1.081 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |         98.34 ns |         1.308 ns |         1.223 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |        103.58 ns |         1.348 ns |         1.261 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |        103.63 ns |         1.413 ns |         1.322 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |        114.82 ns |         1.392 ns |         1.302 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |        118.18 ns |         1.558 ns |         1.458 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |        200.21 ns |         2.303 ns |         2.155 ns |  12,538 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |      1,279.82 ns |        16.750 ns |        15.668 ns |  12,191 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |         99.03 ns |         1.123 ns |         1.051 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |         99.33 ns |         0.834 ns |         0.780 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |        102.57 ns |         1.663 ns |         1.556 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |        102.85 ns |         1.523 ns |         1.425 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |        115.13 ns |         1.642 ns |         1.535 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |        115.62 ns |         1.719 ns |         1.608 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |        195.41 ns |         2.035 ns |         1.903 ns |  12,527 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |      1,312.72 ns |        15.450 ns |        14.452 ns |  12,178 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |         97.47 ns |         1.467 ns |         1.372 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |         98.84 ns |         1.466 ns |         1.371 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |        102.52 ns |         1.442 ns |         1.349 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |        102.78 ns |         1.591 ns |         1.488 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |        109.95 ns |         1.416 ns |         1.325 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |        114.43 ns |         1.725 ns |         1.613 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |        191.30 ns |         2.739 ns |         2.562 ns |  12,525 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |      1,243.41 ns |        16.803 ns |        15.717 ns |  12,178 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |        145.49 ns |         1.781 ns |         1.666 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |        146.15 ns |         2.289 ns |         2.141 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |        154.46 ns |         1.667 ns |         1.559 ns |   5,052 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |        156.16 ns |         2.302 ns |         2.153 ns |   5,052 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |        165.88 ns |         1.811 ns |         1.694 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |        168.75 ns |         2.677 ns |         2.504 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |        288.97 ns |         4.143 ns |         3.876 ns |  12,538 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |      1,789.40 ns |        22.972 ns |        21.488 ns |  12,171 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |        757.85 ns |        11.701 ns |        10.946 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |        760.60 ns |         7.026 ns |         6.572 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |        789.53 ns |        10.799 ns |        10.102 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |        792.26 ns |        11.721 ns |        10.964 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |        796.15 ns |        10.962 ns |        10.254 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |        873.79 ns |        12.752 ns |        11.929 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |      1,433.21 ns |        21.006 ns |        19.649 ns |  12,527 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      8,818.49 ns |        78.364 ns |        73.301 ns |  12,179 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |        757.99 ns |        10.235 ns |         9.574 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |        760.14 ns |         8.935 ns |         8.358 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |        784.56 ns |        12.573 ns |        11.760 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |        789.64 ns |         9.416 ns |         8.808 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |        795.89 ns |         9.585 ns |         8.966 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |        870.40 ns |        12.076 ns |        11.296 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |      1,428.10 ns |        18.805 ns |        17.590 ns |  12,525 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      9,001.56 ns |       113.951 ns |       106.589 ns |  12,148 B |         - |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |        895.37 ns |        12.460 ns |        11.655 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |        897.15 ns |        11.643 ns |        10.891 ns |   6,961 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |        898.46 ns |        10.285 ns |         9.620 ns |   6,960 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |        934.96 ns |        12.747 ns |        11.924 ns |   8,672 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |        937.61 ns |        11.917 ns |        11.147 ns |   8,672 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |      1,010.52 ns |        15.066 ns |        14.093 ns |   4,822 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |      1,732.90 ns |        24.856 ns |        23.251 ns |  10,361 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      9,701.57 ns |       120.220 ns |       112.454 ns |  19,177 B |      56 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |        839.46 ns |        12.998 ns |        11.522 ns |   6,911 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |        840.76 ns |        11.558 ns |        10.811 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |        884.97 ns |         2.268 ns |         2.010 ns |   7,719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |        885.68 ns |         2.288 ns |         2.140 ns |   7,719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |      1,598.20 ns |        21.370 ns |        19.989 ns |   6,959 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |      1,783.68 ns |         3.011 ns |         2.817 ns |   4,816 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |      3,147.00 ns |        31.365 ns |        29.339 ns |  10,362 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |     17,471.02 ns |       191.341 ns |       178.980 ns |  19,092 B |      56 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |      1,613.28 ns |         3.948 ns |         3.500 ns |  16,028 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |      1,619.22 ns |         4.404 ns |         4.119 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |      1,710.08 ns |         4.346 ns |         3.852 ns |  16,018 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |      2,813.38 ns |         6.530 ns |         6.108 ns |  16,030 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |      2,956.28 ns |        10.795 ns |         9.569 ns |  16,865 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |      3,073.19 ns |        23.068 ns |        19.263 ns |  15,838 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |      4,591.12 ns |        12.737 ns |        11.914 ns |  10,510 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |     25,744.76 ns |        42.883 ns |        40.113 ns |  19,098 B |     112 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |      1,504.73 ns |         2.447 ns |         2.169 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |      1,653.68 ns |         3.151 ns |         2.948 ns |  16,034 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |      1,679.24 ns |         2.455 ns |         2.050 ns |  16,034 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |      3,078.04 ns |         5.801 ns |         4.844 ns |  27,172 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |      3,138.47 ns |         7.975 ns |         7.460 ns |  15,814 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |      3,802.29 ns |        15.207 ns |        14.225 ns |  16,641 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |      6,129.20 ns |        11.976 ns |        11.203 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |     34,469.88 ns |        96.921 ns |        85.918 ns |  19,084 B |     168 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |      2,294.15 ns |        11.009 ns |         9.760 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |      3,313.21 ns |         3.877 ns |         3.238 ns |  21,173 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |      3,344.12 ns |         6.071 ns |         5.679 ns |  21,161 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |      3,363.74 ns |         8.787 ns |         7.337 ns |  15,838 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |      3,879.56 ns |        18.922 ns |        15.801 ns |  28,904 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |      4,754.44 ns |         8.825 ns |         7.369 ns |  27,308 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      7,716.96 ns |        18.211 ns |        15.207 ns |  10,508 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |     46,154.13 ns |        47.230 ns |        36.874 ns |  19,098 B |     224 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |      2,432.19 ns |         4.994 ns |         4.671 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |      3,052.29 ns |        34.597 ns |        32.362 ns |  32,033 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |      3,214.03 ns |        35.483 ns |        33.191 ns |  32,041 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |      3,348.26 ns |         5.910 ns |         5.239 ns |  15,814 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |      4,667.89 ns |         8.070 ns |         7.549 ns |  28,881 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |      5,802.64 ns |        45.955 ns |        40.738 ns |  27,313 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      9,486.91 ns |       183.051 ns |       210.801 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |     53,152.17 ns |       709.882 ns |       664.024 ns |  19,094 B |     280 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |      1,875.63 ns |        19.624 ns |        18.356 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |      2,863.61 ns |        34.144 ns |        31.938 ns |  24,573 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |      3,502.81 ns |        29.380 ns |        27.483 ns |  31,876 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |      3,632.07 ns |        39.688 ns |        37.125 ns |  31,874 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |      4,669.64 ns |        46.139 ns |        43.159 ns |  17,846 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |      6,288.65 ns |        59.473 ns |        55.631 ns |  27,359 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |     12,795.78 ns |       150.983 ns |       141.230 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |     71,464.84 ns |       831.178 ns |       777.484 ns |  19,094 B |     392 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |      2,712.95 ns |        42.718 ns |        39.958 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |      3,742.61 ns |        59.272 ns |        55.443 ns |  36,985 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |      3,833.31 ns |        43.063 ns |        40.281 ns |  26,305 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |      4,394.11 ns |        69.470 ns |        64.982 ns |  36,982 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |      5,736.28 ns |        82.796 ns |        77.447 ns |  29,369 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |      7,052.84 ns |        90.735 ns |        84.874 ns |  28,905 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |     14,398.07 ns |       178.378 ns |       166.855 ns |  10,508 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     85,505.75 ns |     1,272.319 ns |     1,190.128 ns |  19,099 B |     448 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |      3,409.50 ns |        46.498 ns |        43.494 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |      3,784.54 ns |        70.380 ns |        65.834 ns |  34,999 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |      3,869.09 ns |        54.919 ns |        51.371 ns |  35,013 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |      4,451.03 ns |        74.530 ns |        69.715 ns |  26,282 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |      6,425.76 ns |        96.705 ns |        90.458 ns |  29,361 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |      7,858.01 ns |       147.749 ns |       164.223 ns |  28,881 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |     15,525.84 ns |       283.069 ns |       264.783 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     90,180.87 ns |     1,471.275 ns |     1,376.232 ns |  19,118 B |     504 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |      2,766.38 ns |        42.448 ns |        39.706 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |      3,738.04 ns |        42.389 ns |        39.650 ns |  34,071 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |      3,753.58 ns |        36.177 ns |        33.840 ns |  34,071 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |      3,896.88 ns |        71.883 ns |        67.240 ns |  26,234 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |      6,909.94 ns |       108.629 ns |       101.612 ns |  29,381 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |      7,963.31 ns |       124.062 ns |       116.048 ns |  28,881 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |     15,792.48 ns |       259.656 ns |       242.883 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     94,465.04 ns |     1,486.303 ns |     1,390.288 ns |  19,108 B |     504 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |      3,574.31 ns |        41.589 ns |        38.903 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |      4,549.37 ns |        61.907 ns |        57.908 ns |  38,706 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |      4,708.35 ns |        58.565 ns |        54.782 ns |  38,706 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |      6,041.49 ns |        91.338 ns |        85.438 ns |  35,013 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      7,878.48 ns |       120.730 ns |       112.931 ns |  29,376 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |      9,251.76 ns |       150.479 ns |       140.758 ns |  27,606 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |     17,446.57 ns |       272.463 ns |       254.862 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |    104,679.82 ns |     1,821.941 ns |     1,704.245 ns |  19,108 B |     560 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |      3,446.64 ns |        42.533 ns |        39.786 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |      4,945.02 ns |        21.282 ns |        19.907 ns |  38,702 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |      4,999.72 ns |        55.548 ns |        46.385 ns |  38,702 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |      6,577.82 ns |        88.212 ns |        82.514 ns |  35,023 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      8,383.11 ns |       123.011 ns |       115.065 ns |  29,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |      9,534.68 ns |       123.577 ns |       115.594 ns |  27,359 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |     20,601.27 ns |       288.975 ns |       270.307 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |    106,486.41 ns |     1,671.952 ns |     1,563.945 ns |  19,106 B |     616 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |      5,011.24 ns |        71.015 ns |        66.427 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |      5,920.72 ns |        72.485 ns |        67.802 ns |  43,848 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |      7,087.73 ns |        85.832 ns |        80.288 ns |  35,023 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |     11,166.94 ns |       148.297 ns |       138.717 ns |  18,590 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |     12,413.86 ns |       200.159 ns |       187.229 ns |  27,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |     24,126.79 ns |       348.028 ns |       325.545 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |     26,294.47 ns |       329.689 ns |       308.391 ns |  43,848 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |    135,080.70 ns |     1,438.858 ns |     1,345.909 ns |  19,094 B |     784 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |      3,666.53 ns |        51.061 ns |        47.763 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |      5,791.87 ns |        91.088 ns |        85.204 ns |  31,857 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |      6,054.79 ns |        92.888 ns |        86.887 ns |  24,760 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |      7,003.19 ns |        81.740 ns |        72.460 ns |  31,857 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      9,842.17 ns |       142.669 ns |       133.453 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |     12,598.34 ns |       158.373 ns |       148.142 ns |  27,369 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |     25,559.77 ns |       419.032 ns |       391.963 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |    143,928.25 ns |     2,106.596 ns |     1,970.511 ns |  19,103 B |     840 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |      9,483.80 ns |       187.863 ns |       223.638 ns |  48,256 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |     14,343.34 ns |       146.668 ns |       137.193 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |     21,111.38 ns |       341.172 ns |       319.132 ns |  24,929 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |     27,684.80 ns |       333.646 ns |       312.093 ns |  31,839 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |     38,719.26 ns |       513.081 ns |       479.937 ns |  18,239 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |     48,447.76 ns |       777.312 ns |       727.098 ns |  27,528 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |    104,755.64 ns |     1,546.554 ns |     1,446.647 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |    612,263.87 ns |     4,353.707 ns |     4,072.460 ns |  19,109 B |    3528 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |     15,163.27 ns |       175.924 ns |       164.559 ns |  50,364 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |     22,927.85 ns |       362.656 ns |       339.229 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |     34,753.32 ns |       540.592 ns |       505.670 ns |  26,644 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |     42,196.49 ns |       624.580 ns |       584.233 ns |  34,987 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |     61,433.51 ns |     1,016.156 ns |       950.513 ns |  18,565 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |     75,265.80 ns |       980.957 ns |       917.587 ns |  29,243 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |    156,110.07 ns |     2,448.706 ns |     2,290.521 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |    873,074.51 ns |    14,073.637 ns |    13,164.489 ns |  19,098 B |    5432 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |     18,681.72 ns |       359.065 ns |       335.869 ns |  48,232 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |     28,563.65 ns |       420.509 ns |       393.344 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |     45,696.66 ns |       131.592 ns |       123.091 ns |  31,839 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |     48,523.39 ns |       788.852 ns |       737.893 ns |  25,116 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |     75,172.44 ns |     1,369.903 ns |     1,281.408 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |    117,919.25 ns |       374.151 ns |       349.981 ns |  27,715 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |    204,706.71 ns |     2,737.111 ns |     2,560.295 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |  1,190,611.33 ns |     7,317.256 ns |     6,844.566 ns |  19,109 B |    7112 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |    115,312.29 ns |     2,081.295 ns |     1,946.845 ns |  53,484 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |    222,126.95 ns |     2,443.712 ns |     2,285.850 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |    374,842.66 ns |     6,531.654 ns |     6,109.713 ns |  26,649 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |    416,230.66 ns |     5,399.637 ns |     5,050.824 ns |  36,938 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |    582,474.39 ns |     9,853.518 ns |     9,216.987 ns |  18,574 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |    744,051.95 ns |     8,829.504 ns |     8,259.123 ns |  29,248 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |  1,569,884.87 ns |    22,030.441 ns |    20,607.288 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  8,513,543.33 ns |   145,095.102 ns |   135,722.048 ns |  19,095 B |   54656 B |
|                                                 |              |                  |                  |                  |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |  1,316,659.78 ns |    25,971.106 ns |    55,905.550 ns |  63,028 B |     141 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |  2,279,083.85 ns |    40,469.678 ns |    37,855.362 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |  3,709,403.38 ns |    70,974.900 ns |    81,734.801 ns |  36,936 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |  3,745,949.16 ns |    73,399.299 ns |   114,273.876 ns |  46,129 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |  6,240,629.69 ns |   123,132.654 ns |   120,932.730 ns |  18,550 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |  7,872,495.57 ns |   131,231.052 ns |   122,753.608 ns |  29,248 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         | 15,731,026.25 ns |   241,107.915 ns |   225,532.493 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 83,107,998.89 ns | 1,573,449.325 ns | 1,471,805.475 ns |  19,099 B |  546840 B |