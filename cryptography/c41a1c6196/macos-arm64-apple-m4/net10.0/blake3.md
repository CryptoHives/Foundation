| Description                                     | TestDataSize | Mean             | Error          | StdDev         | Allocated |
|------------------------------------------------ |------------- |-----------------:|---------------:|---------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |         45.92 ns |       0.126 ns |       0.118 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |         46.06 ns |       0.126 ns |       0.112 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |         52.77 ns |       0.049 ns |       0.046 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |         53.64 ns |       0.111 ns |       0.104 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 4B           |         60.74 ns |       0.098 ns |       0.092 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |         60.80 ns |       0.192 ns |       0.180 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |        381.92 ns |       1.267 ns |       1.185 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |         43.47 ns |       0.106 ns |       0.099 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |         43.60 ns |       0.135 ns |       0.126 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |         51.37 ns |       0.049 ns |       0.046 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 64B          |         51.69 ns |       0.057 ns |       0.053 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |         53.30 ns |       0.083 ns |       0.077 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |         53.92 ns |       0.123 ns |       0.115 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |        382.63 ns |       0.884 ns |       0.827 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |         92.47 ns |       0.197 ns |       0.175 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |         92.54 ns |       0.198 ns |       0.185 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |         98.88 ns |       0.119 ns |       0.099 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |        109.07 ns |       0.233 ns |       0.218 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 65B          |        110.63 ns |       0.118 ns |       0.110 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |        110.66 ns |       0.098 ns |       0.092 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |        757.04 ns |       2.099 ns |       1.963 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |         92.46 ns |       0.194 ns |       0.172 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |         92.58 ns |       0.280 ns |       0.262 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |         99.17 ns |       0.112 ns |       0.093 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 100B         |        107.46 ns |       0.202 ns |       0.189 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |        107.59 ns |       0.077 ns |       0.072 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |        108.70 ns |       0.179 ns |       0.167 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |        758.93 ns |       1.895 ns |       1.680 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |         91.57 ns |       0.177 ns |       0.148 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |         91.63 ns |       0.342 ns |       0.320 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |         99.07 ns |       0.174 ns |       0.163 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |        102.70 ns |       0.098 ns |       0.091 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 128B         |        102.70 ns |       0.119 ns |       0.112 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |        108.77 ns |       0.211 ns |       0.197 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |        758.89 ns |       2.420 ns |       2.264 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |        138.06 ns |       0.576 ns |       0.539 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |        138.17 ns |       0.552 ns |       0.516 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |        145.78 ns |       0.667 ns |       0.624 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |        160.19 ns |       0.261 ns |       0.204 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 137B         |        160.42 ns |       0.272 ns |       0.254 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |        164.59 ns |       0.421 ns |       0.394 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |      1,118.68 ns |       5.815 ns |       5.440 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |        744.19 ns |       2.345 ns |       1.958 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |        745.29 ns |       2.571 ns |       2.279 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |        764.34 ns |       2.385 ns |       2.114 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1000B        |        805.41 ns |       1.355 ns |       1.267 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |        805.93 ns |       0.506 ns |       0.473 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |        894.95 ns |       2.193 ns |       1.831 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      5,685.07 ns |      14.430 ns |      13.498 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |        743.81 ns |       1.888 ns |       1.766 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |        744.49 ns |       2.308 ns |       2.159 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |        763.48 ns |       2.456 ns |       2.298 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1KB          |        801.91 ns |       0.578 ns |       0.541 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |        802.51 ns |       0.650 ns |       0.576 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |        894.32 ns |       2.142 ns |       2.004 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      5,701.05 ns |      19.746 ns |      18.471 ns |         - |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |        840.35 ns |       2.986 ns |       2.793 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |        841.00 ns |       1.926 ns |       1.801 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |        864.84 ns |       1.877 ns |       1.756 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1025B        |        904.51 ns |       0.977 ns |       0.914 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |        907.48 ns |       0.922 ns |       0.817 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |      1,012.29 ns |       4.263 ns |       3.988 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      6,489.68 ns |      14.568 ns |      13.627 ns |      56 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |      1,535.69 ns |       1.449 ns |       1.210 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |      1,536.56 ns |       2.279 ns |       2.020 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |      1,569.91 ns |       6.026 ns |       5.637 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 2KB          |      1,630.46 ns |       1.424 ns |       1.189 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |      1,634.40 ns |       1.261 ns |       1.179 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |      1,859.22 ns |       4.346 ns |       4.066 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |     11,741.87 ns |      44.095 ns |      41.246 ns |      56 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |      1,682.16 ns |       3.888 ns |       3.637 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |      1,687.28 ns |       3.995 ns |       3.542 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 3KB          |      1,733.20 ns |       4.547 ns |       4.254 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |      2,378.87 ns |      15.010 ns |      14.040 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |      2,473.64 ns |       3.956 ns |       3.507 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |      2,882.97 ns |      11.118 ns |      10.400 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |     17,764.77 ns |      82.414 ns |      77.090 ns |     112 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |      1,670.75 ns |       2.365 ns |       2.212 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |      1,729.33 ns |       2.458 ns |       2.300 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |      1,730.80 ns |       2.950 ns |       2.759 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 4KB          |      1,794.14 ns |       3.679 ns |       3.441 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |      1,942.89 ns |      11.537 ns |      10.792 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |      3,317.24 ns |       1.735 ns |       1.449 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |     23,861.74 ns |      31.570 ns |      27.986 ns |     168 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |      2,412.67 ns |       9.213 ns |       8.618 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |      2,455.90 ns |      10.971 ns |      10.262 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |      2,457.86 ns |       8.881 ns |       8.308 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 5KB          |      2,601.35 ns |      11.146 ns |      10.426 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |      2,912.40 ns |       7.030 ns |       6.576 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      4,168.18 ns |      12.379 ns |      11.579 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |     29,855.87 ns |      98.006 ns |      91.675 ns |     224 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |      3,195.90 ns |       6.258 ns |       5.854 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |      3,229.78 ns |       8.592 ns |       8.037 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |      3,233.32 ns |       8.798 ns |       8.230 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 6KB          |      3,446.30 ns |       4.030 ns |       3.573 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |      3,806.77 ns |      10.922 ns |      10.216 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      4,994.35 ns |      12.236 ns |      11.446 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |     35,935.85 ns |     170.492 ns |     159.479 ns |     280 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |      3,316.15 ns |       3.912 ns |       3.267 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |      3,436.68 ns |       7.531 ns |       7.044 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |      3,439.31 ns |      11.869 ns |      11.102 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 8KB          |      3,640.32 ns |       5.194 ns |       4.858 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |      3,834.88 ns |      15.768 ns |      13.978 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      6,670.27 ns |      16.933 ns |      15.839 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |     48,135.39 ns |     149.729 ns |     140.057 ns |     392 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |      4,036.74 ns |      12.565 ns |      11.753 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |      4,140.70 ns |      16.843 ns |      15.755 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |      4,158.95 ns |      11.775 ns |      11.015 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 9216B        |      4,434.74 ns |      17.517 ns |      16.386 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |      4,763.06 ns |      20.952 ns |      17.496 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      7,515.09 ns |      10.643 ns |       9.956 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     54,017.24 ns |     135.957 ns |     127.175 ns |     448 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |      4,650.08 ns |      16.951 ns |      15.856 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |      4,745.50 ns |      18.508 ns |      15.455 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |      4,757.46 ns |      23.285 ns |      21.781 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10000B       |      5,105.78 ns |      21.699 ns |      20.298 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |      5,501.58 ns |      22.673 ns |      21.208 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      8,209.41 ns |      14.938 ns |      13.242 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     59,208.26 ns |      86.978 ns |      77.104 ns |     504 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |      4,777.41 ns |      19.158 ns |      17.920 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |      4,884.95 ns |      24.339 ns |      22.766 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |      4,888.80 ns |      21.815 ns |      20.406 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10240B       |      5,264.67 ns |      22.644 ns |      21.181 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |      5,664.59 ns |      16.260 ns |      15.209 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      8,348.62 ns |      11.032 ns |      10.320 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     60,205.31 ns |     151.154 ns |     141.389 ns |     504 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |      5,152.11 ns |      15.255 ns |      13.523 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |      5,154.22 ns |      16.290 ns |      15.238 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 11264B       |      5,433.29 ns |      13.712 ns |      12.827 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |      5,574.87 ns |      16.524 ns |      14.648 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      6,552.79 ns |      14.329 ns |      12.702 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      9,196.17 ns |       8.975 ns |       7.956 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     65,879.04 ns |     256.795 ns |     240.206 ns |     560 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |      4,937.56 ns |      16.426 ns |      15.365 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |      5,149.36 ns |      20.298 ns |      18.986 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |      5,151.30 ns |      17.877 ns |      16.722 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 12288B       |      5,483.43 ns |      16.810 ns |      15.724 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      5,728.52 ns |      16.788 ns |      15.703 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |     10,034.04 ns |      11.134 ns |      10.415 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     72,361.93 ns |     245.751 ns |     229.875 ns |     616 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |      6,897.42 ns |      23.639 ns |      22.112 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |      6,908.71 ns |      18.078 ns |      15.096 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |      7,173.85 ns |      29.870 ns |      27.941 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 15360B       |      7,305.43 ns |      24.170 ns |      22.608 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |      8,471.07 ns |      62.251 ns |      58.230 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |     12,605.38 ns |      39.878 ns |      37.301 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     90,553.77 ns |     463.478 ns |     410.861 ns |     784 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |      6,613.16 ns |      15.782 ns |      14.763 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |      6,911.77 ns |      25.740 ns |      24.077 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |      6,912.64 ns |      20.276 ns |      18.967 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 16KB         |      7,381.41 ns |      21.087 ns |      19.725 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      7,660.14 ns |      20.310 ns |      16.960 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |     13,448.25 ns |      24.864 ns |      23.258 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     97,115.78 ns |     279.171 ns |     261.136 ns |     840 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |     12,404.15 ns |      38.945 ns |      36.429 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |     26,393.92 ns |      80.215 ns |      75.033 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 64KB         |     27,697.07 ns |     139.950 ns |     130.909 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |     28,063.49 ns |     119.594 ns |     111.868 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |     30,518.52 ns |      88.933 ns |      83.188 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |     53,897.91 ns |     204.290 ns |     191.093 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |    388,705.22 ns |     973.467 ns |     862.953 ns |    3528 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |     14,941.28 ns |      46.572 ns |      43.564 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |     40,984.03 ns |     193.621 ns |     181.113 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |     43,942.12 ns |     177.766 ns |     166.283 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 100000B      |     44,340.19 ns |     195.867 ns |     183.214 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |     47,312.03 ns |     186.911 ns |     174.836 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     82,307.95 ns |     187.403 ns |     166.128 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |    593,962.07 ns |   2,979.329 ns |   2,786.867 ns |    5432 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |     16,145.57 ns |     130.265 ns |     210.353 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |     53,042.10 ns |     150.904 ns |     141.156 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 128KB        |     56,440.09 ns |     185.218 ns |     173.253 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |     56,881.13 ns |     129.895 ns |     121.504 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |     61,352.40 ns |     231.719 ns |     216.750 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |    108,081.80 ns |     185.031 ns |     173.078 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |    781,192.80 ns |   3,194.782 ns |   2,988.401 ns |    7112 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |     70,720.87 ns |     414.420 ns |     387.648 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |    405,218.37 ns |     908.310 ns |     849.634 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |    429,676.11 ns |     918.784 ns |     859.431 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1MB          |    432,932.74 ns |     968.587 ns |     906.017 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |    468,107.80 ns |   1,090.755 ns |   1,020.293 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |    825,106.21 ns |   2,229.764 ns |   1,976.627 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  5,958,572.78 ns |   7,114.318 ns |   5,554.392 ns |   54656 B |
|                                                 |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |    658,158.93 ns |   3,000.572 ns |   2,806.737 ns |     141 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |  4,044,720.99 ns |  12,053.310 ns |  11,274.674 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10MB         |  4,293,130.28 ns |  14,382.191 ns |  13,453.111 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |  4,351,223.28 ns |  24,704.499 ns |  23,108.604 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |  4,658,156.44 ns |  17,177.434 ns |  16,067.782 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  8,250,706.73 ns |  18,336.035 ns |  15,311.420 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 59,451,616.05 ns | 238,202.716 ns | 222,814.968 ns |  546840 B |