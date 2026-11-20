| Description                                     | TestDataSize | Mean              | Error          | StdDev         | Code Size | Allocated |
|------------------------------------------------ |------------- |------------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |          65.07 ns |       0.101 ns |       0.095 ns |   3,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |          65.46 ns |       0.056 ns |       0.052 ns |   3,907 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4B           |          66.67 ns |       0.164 ns |       0.153 ns |   5,864 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4B           |          66.79 ns |       0.115 ns |       0.107 ns |   5,864 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |          89.29 ns |       0.018 ns |       0.016 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |          91.03 ns |       0.021 ns |       0.018 ns |  12,348 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |         142.81 ns |       0.246 ns |       0.218 ns |  22,153 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |         763.13 ns |       3.765 ns |       3.522 ns |  22,731 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |          63.04 ns |       0.108 ns |       0.101 ns |   3,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |          63.88 ns |       0.216 ns |       0.202 ns |   3,907 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64B          |          66.90 ns |       0.051 ns |       0.039 ns |   9,707 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64B          |          71.00 ns |       0.096 ns |       0.089 ns |   9,707 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |          77.20 ns |       0.077 ns |       0.072 ns |  12,348 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |          85.56 ns |       0.115 ns |       0.108 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |         136.52 ns |       0.096 ns |       0.085 ns |  15,818 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |         743.07 ns |       0.774 ns |       0.605 ns |  16,396 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 65B          |         131.85 ns |       0.227 ns |       0.201 ns |  11,828 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 65B          |         134.66 ns |       0.182 ns |       0.161 ns |   7,985 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         155.80 ns |       0.046 ns |       0.043 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |         156.58 ns |       0.020 ns |       0.019 ns |  12,338 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |         264.40 ns |       0.219 ns |       0.195 ns |  22,153 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |         276.80 ns |       0.716 ns |       0.670 ns |   7,422 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |         281.85 ns |       0.647 ns |       0.605 ns |   7,422 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |       1,410.57 ns |       1.201 ns |       1.124 ns |  16,304 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100B         |         130.96 ns |       0.234 ns |       0.219 ns |   7,884 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100B         |         130.98 ns |       0.217 ns |       0.203 ns |  11,727 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |         153.74 ns |       0.036 ns |       0.032 ns |   6,003 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         154.08 ns |       0.075 ns |       0.070 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |         258.30 ns |       0.459 ns |       0.429 ns |  22,343 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |         277.24 ns |       0.063 ns |       0.052 ns |   7,422 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |         277.83 ns |       0.710 ns |       0.665 ns |   7,422 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |       1,389.92 ns |       0.904 ns |       0.846 ns |  16,304 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128B         |         130.16 ns |       0.252 ns |       0.236 ns |  11,911 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128B         |         131.55 ns |       0.086 ns |       0.080 ns |  11,828 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |         146.28 ns |       0.158 ns |       0.140 ns |  12,338 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         152.51 ns |       0.116 ns |       0.103 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |         251.42 ns |       0.133 ns |       0.118 ns |  22,343 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |         278.89 ns |       0.980 ns |       0.765 ns |   7,422 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |         280.09 ns |       1.455 ns |       1.361 ns |   7,422 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |       1,391.75 ns |       0.581 ns |       0.453 ns |  16,304 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 137B         |         192.13 ns |       0.129 ns |       0.121 ns |   7,878 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 137B         |         192.41 ns |       0.085 ns |       0.075 ns |  11,721 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |         219.65 ns |       0.063 ns |       0.056 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |         224.69 ns |       0.067 ns |       0.056 ns |  12,528 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |         293.99 ns |       0.078 ns |       0.069 ns |   9,573 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |         299.91 ns |       0.160 ns |       0.149 ns |   9,573 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |         381.28 ns |       0.266 ns |       0.222 ns |  15,818 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |       2,116.18 ns |       7.698 ns |       6.824 ns |  22,643 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1000B        |         994.27 ns |       0.776 ns |       0.726 ns |   7,884 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1000B        |         995.04 ns |       0.828 ns |       0.774 ns |  11,727 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |       1,003.36 ns |       1.253 ns |       1.172 ns |   6,585 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |       1,003.65 ns |       1.069 ns |       1.000 ns |   6,585 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |       1,042.26 ns |       0.448 ns |       0.397 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |       1,149.55 ns |       0.237 ns |       0.198 ns |  12,528 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |       1,882.84 ns |       2.738 ns |       2.286 ns |  15,818 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      10,190.15 ns |       4.571 ns |       4.275 ns |  22,657 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1KB          |         992.66 ns |       0.442 ns |       0.413 ns |   7,878 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1KB          |         993.35 ns |       0.371 ns |       0.310 ns |   7,985 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |         996.61 ns |       0.650 ns |       0.608 ns |   6,585 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |         997.95 ns |       0.609 ns |       0.569 ns |   6,585 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |       1,041.58 ns |       0.842 ns |       0.788 ns |     716 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |       1,143.62 ns |       0.965 ns |       0.856 ns |  12,528 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |       1,861.03 ns |       1.917 ns |       1.793 ns |  15,818 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      10,359.03 ns |       5.269 ns |       4.671 ns |  16,316 B |         - |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |       1,130.18 ns |       1.864 ns |       1.744 ns |  10,560 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |       1,130.43 ns |       1.376 ns |       1.287 ns |  15,616 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |       1,176.75 ns |       0.459 ns |       0.384 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1025B        |       1,178.69 ns |       0.682 ns |       0.570 ns |  16,213 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1025B        |       1,180.42 ns |       0.928 ns |       0.868 ns |   9,688 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |       1,331.07 ns |       0.482 ns |       0.451 ns |  13,807 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |       2,232.29 ns |      17.762 ns |      16.615 ns |  13,133 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      11,809.09 ns |       9.825 ns |       8.204 ns |  23,156 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |       1,092.44 ns |       0.521 ns |       0.488 ns |   6,957 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |       1,096.18 ns |       0.519 ns |       0.460 ns |   6,957 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 2KB          |       1,106.66 ns |       0.399 ns |       0.353 ns |  17,595 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |       1,108.91 ns |       0.627 ns |       0.587 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 2KB          |       2,103.87 ns |       4.102 ns |       3.837 ns |   9,688 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |       2,394.09 ns |       1.172 ns |       1.096 ns |  13,608 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |       4,076.23 ns |      17.573 ns |      16.438 ns |  13,133 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |      21,355.71 ns |       6.799 ns |       6.028 ns |  23,167 B |      56 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |       2,102.92 ns |       4.637 ns |       4.337 ns |  17,446 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |       2,105.98 ns |       4.012 ns |       3.752 ns |  17,446 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |       2,179.70 ns |       0.681 ns |       0.637 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 3KB          |       2,183.65 ns |       1.061 ns |       0.993 ns |  18,533 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |       3,775.84 ns |       0.881 ns |       0.824 ns |  18,942 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 3KB          |       3,871.33 ns |      26.342 ns |      24.640 ns |  26,788 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |       6,129.81 ns |      19.030 ns |      17.801 ns |  19,814 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |      32,186.49 ns |      10.538 ns |       9.342 ns |  23,158 B |     112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |       2,031.28 ns |       5.537 ns |       5.180 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |       2,160.59 ns |       3.728 ns |       3.487 ns |  17,459 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |       2,168.12 ns |       6.885 ns |       6.440 ns |  17,459 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 4KB          |       2,288.31 ns |       1.083 ns |       0.960 ns |  18,669 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 4KB          |       4,048.21 ns |      43.070 ns |      40.287 ns |  35,881 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |       5,068.77 ns |       0.910 ns |       0.807 ns |  25,838 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |       8,284.81 ns |      37.378 ns |      34.963 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |      41,683.21 ns |      16.993 ns |      15.895 ns |  23,174 B |     168 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 5KB          |       3,086.76 ns |       6.392 ns |       5.979 ns |  33,194 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |       3,096.85 ns |       3.585 ns |       3.353 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |       3,901.10 ns |       2.504 ns |       2.220 ns |  24,907 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |       3,962.47 ns |       8.874 ns |       8.301 ns |  24,907 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 5KB          |       5,125.77 ns |      22.795 ns |      21.323 ns |  38,402 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |       6,438.38 ns |       1.821 ns |       1.703 ns |  36,540 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      10,261.90 ns |      62.341 ns |      58.314 ns |  19,814 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |      52,357.57 ns |      25.823 ns |      24.155 ns |  23,158 B |     224 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 6KB          |       3,108.00 ns |      18.036 ns |      16.871 ns |  33,004 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |       3,155.45 ns |       9.318 ns |       8.716 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |       3,767.02 ns |       8.906 ns |       8.331 ns |  35,617 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |       3,996.03 ns |       9.900 ns |       9.260 ns |  35,617 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 6KB          |       6,199.40 ns |      14.024 ns |      13.118 ns |  29,345 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |       9,256.34 ns |       2.518 ns |       2.103 ns |  36,547 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      12,347.20 ns |      75.025 ns |      70.178 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |      62,563.40 ns |      18.320 ns |      14.303 ns |  23,186 B |     280 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |       2,464.49 ns |       1.243 ns |       1.163 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 8KB          |       3,084.33 ns |      11.791 ns |      11.029 ns |  30,231 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |       4,125.91 ns |       6.601 ns |       6.175 ns |  35,461 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |       5,239.70 ns |       4.576 ns |       4.281 ns |  35,477 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |       6,078.10 ns |      42.362 ns |      39.626 ns |  27,038 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 8KB          |       8,119.27 ns |      45.195 ns |      42.275 ns |  36,905 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      16,562.22 ns |      71.815 ns |      67.176 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |      87,713.88 ns |      90.425 ns |      80.159 ns |  23,182 B |     392 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |       3,577.93 ns |       1.760 ns |       1.560 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 9216B        |       4,309.15 ns |      21.670 ns |      20.270 ns |  32,942 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |       5,200.21 ns |       5.376 ns |       5.029 ns |  40,450 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |       5,228.63 ns |       6.359 ns |       5.948 ns |  40,450 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |       7,946.32 ns |      25.701 ns |      24.041 ns |  38,165 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 9216B        |       9,157.38 ns |      60.537 ns |      56.626 ns |  38,402 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      18,823.60 ns |     139.461 ns |     130.452 ns |  19,624 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |      97,278.62 ns |      31.636 ns |      26.418 ns |  23,188 B |     448 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10000B       |       4,453.37 ns |      29.448 ns |      27.546 ns |  34,341 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |       4,472.18 ns |       3.035 ns |       2.839 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |       5,408.63 ns |      12.699 ns |      11.879 ns |  46,279 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |       5,423.64 ns |       9.408 ns |       8.800 ns |  46,457 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |       8,905.12 ns |      21.376 ns |      19.996 ns |  31,645 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10000B       |      10,072.55 ns |      49.363 ns |      46.174 ns |  38,388 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      20,462.58 ns |     153.545 ns |     143.626 ns |  19,610 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     103,204.01 ns |      29.538 ns |      26.185 ns |  29,515 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |       3,640.82 ns |       1.773 ns |       1.571 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10240B       |       4,206.59 ns |      12.188 ns |      11.401 ns |  34,121 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |       4,791.49 ns |       2.437 ns |       2.160 ns |  37,611 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |       5,374.10 ns |       9.832 ns |       9.196 ns |  37,595 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |       8,700.49 ns |      33.928 ns |      31.737 ns |  38,175 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10240B       |      10,271.89 ns |      37.537 ns |      35.112 ns |  38,578 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      20,750.66 ns |      31.244 ns |      27.697 ns |  19,610 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     104,574.79 ns |      21.203 ns |      19.834 ns |  29,711 B |     504 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |       4,693.72 ns |       3.727 ns |       3.487 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 11264B       |       5,275.13 ns |      12.211 ns |      11.422 ns |  34,311 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |       5,789.76 ns |       5.925 ns |       5.542 ns |  42,119 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |       5,864.44 ns |       8.620 ns |       8.063 ns |  42,119 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      10,320.43 ns |      20.131 ns |      18.831 ns |  31,643 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 11264B       |      11,977.95 ns |      96.249 ns |      90.031 ns |  37,169 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      22,859.77 ns |      59.868 ns |      56.001 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     121,725.98 ns |      34.071 ns |      31.870 ns |  29,522 B |     560 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |       4,529.45 ns |       6.742 ns |       6.306 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 12288B       |       5,405.53 ns |      15.431 ns |      14.434 ns |  27,786 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |       5,853.80 ns |       5.589 ns |       5.228 ns |  42,116 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |       6,803.45 ns |      11.428 ns |      10.690 ns |  42,100 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      11,445.16 ns |      21.523 ns |      20.133 ns |  38,164 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 12288B       |      12,143.54 ns |      61.136 ns |      57.187 ns |  30,570 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |      25,049.62 ns |     124.474 ns |     116.433 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     130,056.21 ns |      46.480 ns |      43.478 ns |  29,517 B |     616 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 15360B       |       6,303.97 ns |      26.919 ns |      25.180 ns |  41,373 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |       6,575.95 ns |       8.390 ns |       7.437 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |       7,392.48 ns |      11.041 ns |      10.328 ns |  47,345 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |       8,712.22 ns |      14.076 ns |      13.166 ns |  47,345 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |      15,099.06 ns |      19.832 ns |      18.551 ns |  20,922 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 15360B       |      16,094.82 ns |      86.538 ns |      80.948 ns |  37,574 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |      31,341.48 ns |     275.994 ns |     258.165 ns |  19,610 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     162,190.07 ns |      80.484 ns |      75.285 ns |  29,707 B |     784 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |       4,772.39 ns |       4.221 ns |       3.948 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 16KB         |       6,187.42 ns |      18.324 ns |      17.140 ns |  24,920 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |       7,088.48 ns |       5.510 ns |       5.154 ns |  35,418 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |       7,176.12 ns |      10.682 ns |       9.992 ns |  35,418 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      12,711.24 ns |      39.075 ns |      36.550 ns |  27,149 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 16KB         |      16,251.97 ns |      93.876 ns |      87.812 ns |  36,905 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |      33,449.68 ns |     242.120 ns |     226.479 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     167,864.16 ns |      52.944 ns |      44.211 ns |  29,504 B |     840 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |      14,086.06 ns |     280.467 ns |     572.919 ns |  69,079 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |      18,803.08 ns |       7.725 ns |       7.226 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 64KB         |      23,239.82 ns |      87.830 ns |      82.156 ns |  30,587 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |      28,446.52 ns |      62.222 ns |      58.203 ns |  37,808 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |      50,383.41 ns |     179.956 ns |     159.526 ns |  27,149 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 64KB         |      62,715.62 ns |     620.785 ns |     580.682 ns |  36,427 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |     132,931.66 ns |   1,036.481 ns |     969.525 ns |  19,800 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |     668,367.15 ns |     879.760 ns |     734.640 ns |  23,233 B |    3528 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |      18,893.57 ns |      69.485 ns |      64.996 ns |  73,246 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |      30,293.38 ns |      12.775 ns |      11.324 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 100000B      |      40,010.40 ns |     229.508 ns |     214.682 ns |  34,887 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |      55,226.87 ns |      54.582 ns |      48.385 ns |  43,566 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |      78,459.68 ns |     107.635 ns |     100.682 ns |  27,264 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 100000B      |      97,706.29 ns |     510.301 ns |     426.124 ns |  38,934 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     204,088.33 ns |   1,016.086 ns |     950.447 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |   1,020,586.90 ns |     226.661 ns |     212.019 ns |  23,254 B |    5432 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |      21,736.64 ns |      70.510 ns |      62.505 ns |  73,208 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |      37,618.61 ns |      17.430 ns |      16.304 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 128KB        |      50,448.01 ns |     403.979 ns |     377.882 ns |  31,611 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |      56,623.05 ns |      88.814 ns |      78.731 ns |  37,808 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |      99,245.57 ns |     382.227 ns |     357.536 ns |  20,624 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 128KB        |     126,320.56 ns |   1,413.811 ns |   1,322.480 ns |  37,261 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |     268,459.14 ns |   2,290.304 ns |   2,142.352 ns |  19,610 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |   1,337,195.30 ns |     283.155 ns |     264.864 ns |  29,568 B |    7112 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |     161,403.69 ns |   2,913.913 ns |   2,725.676 ns |  78,304 B |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |     288,969.87 ns |     446.646 ns |     395.940 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 1MB          |     390,313.49 ns |   5,244.474 ns |   4,905.684 ns |  33,094 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |     514,655.32 ns |   1,226.237 ns |   1,147.023 ns |  37,389 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |     774,917.34 ns |   2,642.070 ns |   2,471.394 ns |  27,268 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 1MB          |     970,435.46 ns |   2,011.757 ns |   1,783.370 ns |  38,934 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |   2,040,663.18 ns |  19,455.503 ns |  18,198.689 ns |  19,800 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  10,598,590.73 ns |   4,955.576 ns |   4,635.449 ns |  23,160 B |   54656 B |
|                                                 |              |                   |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |   1,479,326.79 ns |  29,475.495 ns |  42,272.878 ns |  86,020 B |     144 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |   2,938,085.60 ns |   2,625.755 ns |   2,456.132 ns |     720 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2      | 10MB         |   4,210,408.26 ns |  32,459.999 ns |  28,774.943 ns |  35,405 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |   5,726,552.14 ns |  14,074.394 ns |  13,165.197 ns |  54,563 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |   7,516,159.17 ns |  44,068.226 ns |  41,221.446 ns |  20,924 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3     | 10MB         |  10,010,169.69 ns | 120,698.624 ns | 112,901.568 ns |  38,934 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  20,515,213.33 ns | 120,204.870 ns | 112,439.710 ns |  13,275 B |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 102,352,603.08 ns |  27,846.783 ns |  23,253.325 ns |  29,572 B |  546840 B |