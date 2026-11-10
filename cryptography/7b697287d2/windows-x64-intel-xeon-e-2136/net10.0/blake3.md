| Description                                     | TestDataSize | Mean              | Error          | StdDev         | Code Size | Allocated |
|------------------------------------------------ |------------- |------------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |          64.87 ns |       0.120 ns |       0.112 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |          65.20 ns |       0.064 ns |       0.056 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |          70.71 ns |       0.097 ns |       0.086 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |          70.72 ns |       0.100 ns |       0.089 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |          86.53 ns |       0.033 ns |       0.030 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |          88.20 ns |       0.044 ns |       0.042 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |         139.61 ns |       0.293 ns |       0.274 ns |  12,538 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |         757.00 ns |       0.853 ns |       0.713 ns |  12,469 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |          64.88 ns |       0.057 ns |       0.053 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |          65.08 ns |       0.035 ns |       0.033 ns |   2,230 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |          69.37 ns |       0.101 ns |       0.095 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |          70.00 ns |       0.077 ns |       0.064 ns |   4,571 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |          75.22 ns |       0.096 ns |       0.089 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |          81.51 ns |       0.039 ns |       0.037 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |         133.72 ns |       0.083 ns |       0.069 ns |  12,525 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |         759.24 ns |       1.015 ns |       0.899 ns |  12,450 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |         128.59 ns |       0.222 ns |       0.208 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |         131.74 ns |       0.149 ns |       0.132 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |         135.80 ns |       0.098 ns |       0.082 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |         136.03 ns |       0.131 ns |       0.116 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |         150.55 ns |       0.094 ns |       0.083 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         153.77 ns |       0.117 ns |       0.110 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |         261.70 ns |       0.161 ns |       0.150 ns |  12,538 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |       1,657.63 ns |       0.931 ns |       0.825 ns |  12,202 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |         129.70 ns |       0.084 ns |       0.078 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |         131.80 ns |       0.108 ns |       0.101 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |         135.35 ns |       0.121 ns |       0.107 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |         135.36 ns |       0.072 ns |       0.064 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |         151.01 ns |       0.062 ns |       0.055 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         151.95 ns |       0.078 ns |       0.069 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |         255.20 ns |       0.205 ns |       0.182 ns |  12,527 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |       1,600.65 ns |       1.356 ns |       1.268 ns |  12,178 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |         127.96 ns |       0.059 ns |       0.053 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |         131.50 ns |       0.098 ns |       0.087 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |         134.43 ns |       0.105 ns |       0.098 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |         135.12 ns |       0.109 ns |       0.102 ns |   4,772 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |         143.90 ns |       0.056 ns |       0.053 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         150.92 ns |       0.092 ns |       0.082 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |         250.17 ns |       0.143 ns |       0.134 ns |  12,525 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |       1,666.83 ns |       1.447 ns |       1.354 ns |  12,178 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |         191.95 ns |       0.160 ns |       0.125 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |         192.01 ns |       0.106 ns |       0.099 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |         202.47 ns |       0.163 ns |       0.144 ns |   5,036 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |         203.05 ns |       0.172 ns |       0.160 ns |   5,198 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |         217.60 ns |       0.089 ns |       0.083 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |         222.28 ns |       0.083 ns |       0.077 ns |   3,477 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |         380.05 ns |       0.298 ns |       0.264 ns |  12,538 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |       2,393.70 ns |       1.873 ns |       1.752 ns |  12,163 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |         993.19 ns |       0.954 ns |       0.892 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |         994.58 ns |       1.471 ns |       1.304 ns |   4,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |       1,037.98 ns |       1.075 ns |       1.006 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |       1,038.11 ns |       0.676 ns |       0.599 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |       1,041.80 ns |       0.767 ns |       0.717 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |       1,151.13 ns |       0.413 ns |       0.387 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |       1,881.65 ns |       0.950 ns |       0.888 ns |  12,527 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      11,481.68 ns |       4.554 ns |       4.037 ns |  12,179 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |         990.36 ns |       0.556 ns |       0.464 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |         990.47 ns |       0.601 ns |       0.533 ns |   4,367 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |       1,033.91 ns |       0.719 ns |       0.637 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |       1,039.11 ns |       0.658 ns |       0.615 ns |     719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |       1,040.64 ns |       1.233 ns |       1.093 ns |   5,117 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |       1,140.21 ns |       0.628 ns |       0.557 ns |   3,464 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |       1,866.91 ns |       1.040 ns |       0.922 ns |  12,525 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      11,933.11 ns |      11.434 ns |      10.695 ns |  12,148 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |       1,173.93 ns |       0.746 ns |       0.698 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |       1,174.82 ns |       1.528 ns |       1.355 ns |   6,961 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |       1,178.74 ns |       1.034 ns |       0.967 ns |   6,964 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |       1,227.84 ns |       0.835 ns |       0.781 ns |   8,672 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |       1,231.92 ns |       1.019 ns |       0.903 ns |   8,672 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |       1,333.56 ns |       0.919 ns |       0.860 ns |   4,818 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |       2,266.54 ns |       7.742 ns |       7.242 ns |  10,364 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      12,647.24 ns |       5.911 ns |       5.240 ns |  19,177 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |       1,097.64 ns |       0.619 ns |       0.579 ns |   6,911 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |       1,106.58 ns |       0.464 ns |       0.412 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |       1,190.90 ns |       0.499 ns |       0.466 ns |   7,719 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |       1,192.73 ns |       1.952 ns |       1.826 ns |   7,719 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |       2,093.39 ns |       1.465 ns |       1.224 ns |   6,958 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |       2,400.41 ns |       0.858 ns |       0.802 ns |   4,816 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |       4,057.58 ns |      16.291 ns |      15.238 ns |  10,362 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |      22,807.74 ns |      12.353 ns |      10.950 ns |  19,095 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |       2,180.23 ns |       1.562 ns |       1.385 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |       2,204.05 ns |       2.148 ns |       1.904 ns |  16,016 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |       2,204.17 ns |       1.254 ns |       1.047 ns |  16,030 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |       3,781.85 ns |       2.380 ns |       2.226 ns |  16,030 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |       3,881.38 ns |      24.100 ns |      22.543 ns |  16,865 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |       4,170.29 ns |      15.056 ns |      14.084 ns |  15,838 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |       6,226.87 ns |      33.032 ns |      25.790 ns |  10,510 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |      34,701.00 ns |      21.549 ns |      17.995 ns |  19,098 B |     112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |       2,028.31 ns |       5.776 ns |       5.403 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |       2,231.52 ns |       2.457 ns |       2.178 ns |  16,034 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |       2,381.09 ns |       4.346 ns |       4.065 ns |  16,022 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |       4,137.85 ns |      19.161 ns |      17.923 ns |  27,172 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |       4,475.71 ns |       9.573 ns |       8.954 ns |  15,814 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |       5,082.07 ns |       3.593 ns |       3.185 ns |  16,641 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |       8,320.77 ns |      20.462 ns |      17.087 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |      46,317.32 ns |      59.151 ns |      55.330 ns |  19,084 B |     168 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |       3,108.87 ns |       3.032 ns |       2.688 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |       3,685.05 ns |       3.497 ns |       3.100 ns |  21,173 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |       4,476.57 ns |       5.710 ns |       5.062 ns |  21,161 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |       4,481.81 ns |       9.878 ns |       8.249 ns |  15,838 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |       5,163.25 ns |      14.724 ns |      13.773 ns |  28,901 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |       6,454.99 ns |       3.277 ns |       3.065 ns |  27,308 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      10,432.23 ns |      20.041 ns |      18.747 ns |  10,508 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |      61,442.64 ns |     113.792 ns |     100.873 ns |  19,091 B |     224 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |       3,168.28 ns |       1.481 ns |       1.313 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |       3,792.81 ns |       2.219 ns |       1.967 ns |  32,041 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |       3,936.15 ns |       8.537 ns |       7.985 ns |  32,046 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |       4,500.20 ns |       9.637 ns |       9.015 ns |  15,814 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |       6,237.89 ns |       9.107 ns |       8.518 ns |  28,881 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |       7,612.66 ns |       2.817 ns |       2.635 ns |  27,320 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      12,513.85 ns |      16.908 ns |      14.989 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |      69,597.61 ns |      44.613 ns |      34.831 ns |  19,098 B |     280 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |       2,462.23 ns |       2.710 ns |       2.535 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |       3,990.48 ns |       5.432 ns |       4.815 ns |  24,575 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |       4,649.06 ns |       4.009 ns |       3.348 ns |  31,876 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |       4,743.98 ns |       7.143 ns |       6.332 ns |  31,874 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |       6,588.24 ns |       8.035 ns |       7.122 ns |  17,848 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |       8,310.14 ns |      34.853 ns |      32.602 ns |  27,359 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      16,625.36 ns |      33.667 ns |      29.845 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |      96,243.81 ns |     118.185 ns |     104.768 ns |  19,132 B |     392 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |       3,576.83 ns |       2.508 ns |       2.223 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |       4,900.17 ns |       2.362 ns |       1.972 ns |  36,982 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |       5,027.69 ns |       9.031 ns |       8.006 ns |  36,985 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |       5,047.33 ns |       5.523 ns |       5.167 ns |  26,306 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |       7,978.68 ns |      15.170 ns |      14.190 ns |  29,369 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |       9,279.96 ns |      20.370 ns |      19.054 ns |  28,904 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      18,851.62 ns |      45.384 ns |      42.452 ns |  10,508 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     112,134.61 ns |     133.901 ns |     125.251 ns |  19,093 B |     448 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |       4,480.81 ns |       3.843 ns |       3.595 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |       5,417.67 ns |       5.301 ns |       4.699 ns |  35,011 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |       5,418.82 ns |       6.589 ns |       5.841 ns |  35,011 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |       5,732.17 ns |       6.388 ns |       5.975 ns |  26,282 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |       9,005.56 ns |       9.229 ns |       8.633 ns |  29,366 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |      10,144.60 ns |      22.464 ns |      19.914 ns |  28,881 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      20,588.33 ns |      48.402 ns |      45.275 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     119,124.41 ns |     147.075 ns |     137.574 ns |  19,110 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |       3,647.29 ns |       2.053 ns |       1.820 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |       4,945.17 ns |       6.112 ns |       5.418 ns |  34,055 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |       5,539.60 ns |       3.381 ns |       3.163 ns |  26,234 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |       5,701.28 ns |       3.383 ns |       2.999 ns |  34,070 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |       9,226.47 ns |      16.342 ns |      15.286 ns |  29,381 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |      10,310.21 ns |      30.811 ns |      28.821 ns |  28,881 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      20,787.93 ns |      90.405 ns |      84.565 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     124,143.47 ns |     197.404 ns |     174.994 ns |  19,094 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |       4,691.53 ns |       3.416 ns |       2.852 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |       6,534.20 ns |       9.373 ns |       8.767 ns |  38,706 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |       6,884.24 ns |       6.475 ns |       5.740 ns |  38,706 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |       9,165.22 ns |      12.991 ns |      12.152 ns |  35,013 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      10,415.44 ns |      13.125 ns |      12.277 ns |  29,381 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |      12,162.44 ns |      24.133 ns |      22.574 ns |  27,606 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      23,079.48 ns |      38.573 ns |      36.081 ns |  10,485 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     137,750.26 ns |     221.344 ns |     207.046 ns |  19,108 B |     560 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |       4,534.55 ns |       7.431 ns |       6.588 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |       6,203.61 ns |      10.203 ns |       9.544 ns |  38,702 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |       6,883.01 ns |       7.776 ns |       7.274 ns |  38,702 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |       8,072.66 ns |      20.835 ns |      19.489 ns |  35,023 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      11,533.45 ns |      13.085 ns |      11.600 ns |  29,367 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |      12,478.49 ns |      62.966 ns |      58.899 ns |  27,359 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      25,182.90 ns |      36.851 ns |      32.667 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     140,259.33 ns |     202.149 ns |     179.200 ns |  19,106 B |     616 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |       6,585.57 ns |       8.114 ns |       7.590 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |       7,743.12 ns |      14.387 ns |      12.753 ns |  43,848 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |       7,772.18 ns |      13.985 ns |      11.678 ns |  43,848 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |       8,998.61 ns |      11.269 ns |       9.990 ns |  35,023 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |      15,152.66 ns |       8.419 ns |       7.875 ns |  18,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |      16,253.86 ns |      43.664 ns |      40.843 ns |  27,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |      31,782.43 ns |     199.921 ns |     177.225 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     188,758.44 ns |     805.274 ns |     713.854 ns |  19,108 B |     784 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |       4,781.67 ns |       4.461 ns |       3.954 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |       8,005.28 ns |       7.578 ns |       7.089 ns |  24,760 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |       8,968.51 ns |      11.107 ns |      10.389 ns |  31,857 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |       9,206.44 ns |      13.370 ns |      12.507 ns |  31,857 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      12,952.52 ns |      17.904 ns |      16.747 ns |  18,235 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |      16,673.19 ns |     109.282 ns |     102.222 ns |  27,369 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |      33,413.70 ns |      66.992 ns |      59.387 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     198,356.88 ns |     462.875 ns |     410.326 ns |  19,103 B |     840 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |      11,610.95 ns |     133.541 ns |     124.915 ns |  48,535 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |      18,886.14 ns |      17.936 ns |      14.977 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |      30,223.51 ns |     239.991 ns |     224.487 ns |  24,929 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |      32,555.87 ns |      57.099 ns |      53.410 ns |  31,839 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |      49,721.74 ns |      82.807 ns |      77.458 ns |  18,239 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |      63,611.01 ns |     173.918 ns |     154.174 ns |  27,528 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |     137,756.78 ns |     403.728 ns |     377.647 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |     795,411.43 ns |     875.628 ns |     776.221 ns |  19,109 B |    3528 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |      19,347.16 ns |     105.264 ns |      87.900 ns |  51,234 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |      30,341.15 ns |      27.463 ns |      25.689 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |      47,644.88 ns |      70.741 ns |      66.171 ns |  26,644 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |      55,849.77 ns |      73.049 ns |      68.330 ns |  34,987 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |      72,693.55 ns |     131.193 ns |     116.299 ns |  18,567 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |      98,395.29 ns |     226.940 ns |     212.280 ns |  29,243 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     204,772.92 ns |     367.891 ns |     344.125 ns |  10,491 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |   1,153,097.14 ns |     890.892 ns |     833.341 ns |  19,098 B |    5432 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |      21,771.35 ns |     434.652 ns |     714.146 ns |  48,690 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |      37,535.66 ns |      30.477 ns |      27.017 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |      58,965.98 ns |      82.040 ns |      72.726 ns |  25,116 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |      59,698.84 ns |      90.303 ns |      84.470 ns |  31,827 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |     100,443.83 ns |     191.232 ns |     178.879 ns |  18,237 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |     127,576.19 ns |     195.880 ns |     183.227 ns |  27,715 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |     267,980.70 ns |     637.943 ns |     596.733 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |   1,507,687.57 ns |   2,273.840 ns |   2,126.951 ns |  19,109 B |    7112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |     153,131.72 ns |   2,116.957 ns |   1,980.203 ns |  53,139 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |     289,104.72 ns |     522.191 ns |     488.458 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |     452,824.11 ns |   1,257.275 ns |   1,176.056 ns |  36,938 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |     464,897.43 ns |     967.540 ns |     905.037 ns |  26,649 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |     761,791.09 ns |   1,386.678 ns |   1,297.099 ns |  18,578 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |     974,521.44 ns |   3,854.887 ns |   3,605.863 ns |  29,248 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |   2,051,521.85 ns |   4,322.027 ns |   4,042.827 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  11,183,502.57 ns |  10,129.353 ns |   8,979.407 ns |  19,104 B |   54656 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |   1,578,674.45 ns |  27,229.078 ns |  25,470.097 ns |  62,018 B |     143 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |   2,970,575.68 ns |  12,391.526 ns |  11,591.041 ns |     723 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |   4,829,090.68 ns |  79,114.811 ns |  74,004.044 ns |  36,902 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |   6,005,737.62 ns |  89,566.657 ns |  74,792.215 ns |  46,134 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |   7,606,885.10 ns |  49,550.230 ns |  46,349.316 ns |  18,552 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |  10,404,393.33 ns |  89,541.634 ns |  83,757.300 ns |  29,248 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  20,661,873.12 ns |  44,322.722 ns |  41,459.502 ns |  10,496 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 109,791,222.86 ns | 159,628.009 ns | 141,506.072 ns |  19,095 B |  546840 B |