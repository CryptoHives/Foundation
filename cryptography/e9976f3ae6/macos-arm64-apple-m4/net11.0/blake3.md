| Description                                     | TestDataSize | Mean             | Error          | StdDev         | Median           | Allocated |
|------------------------------------------------ |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4B           |         47.59 ns |       0.113 ns |       0.100 ns |         47.59 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4B           |         47.64 ns |       0.473 ns |       0.395 ns |         47.49 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4B           |         54.41 ns |       0.066 ns |       0.062 ns |         54.41 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4B           |         55.38 ns |       0.090 ns |       0.085 ns |         55.36 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 4B           |         62.29 ns |       0.142 ns |       0.132 ns |         62.31 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4B           |         62.37 ns |       0.091 ns |       0.085 ns |         62.40 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4B           |        372.05 ns |       0.463 ns |       0.386 ns |        372.01 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64B          |         45.82 ns |       0.094 ns |       0.088 ns |         45.84 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64B          |         45.86 ns |       0.100 ns |       0.093 ns |         45.86 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64B          |         52.48 ns |       0.053 ns |       0.050 ns |         52.50 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 64B          |         52.57 ns |       0.048 ns |       0.045 ns |         52.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64B          |         55.41 ns |       0.046 ns |       0.043 ns |         55.42 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64B          |         55.70 ns |       0.055 ns |       0.052 ns |         55.72 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64B          |        374.54 ns |       0.747 ns |       0.698 ns |        374.33 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 65B          |         95.56 ns |       0.242 ns |       0.214 ns |         95.56 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 65B          |         95.77 ns |       0.209 ns |       0.175 ns |         95.80 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 65B          |        101.17 ns |       0.172 ns |       0.153 ns |        101.15 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 65B          |        110.93 ns |       0.104 ns |       0.097 ns |        110.92 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 65B          |        111.98 ns |       0.380 ns |       0.355 ns |        112.17 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 65B          |        112.23 ns |       0.198 ns |       0.166 ns |        112.22 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 65B          |        759.29 ns |       1.301 ns |       1.154 ns |        759.61 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100B         |         96.32 ns |       0.317 ns |       0.297 ns |         96.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100B         |         96.40 ns |       0.396 ns |       0.370 ns |         96.28 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100B         |        101.29 ns |       0.205 ns |       0.182 ns |        101.27 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 100B         |        109.07 ns |       0.094 ns |       0.088 ns |        109.07 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100B         |        109.36 ns |       0.073 ns |       0.065 ns |        109.36 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100B         |        111.50 ns |       0.315 ns |       0.294 ns |        111.40 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100B         |        762.04 ns |       2.069 ns |       1.834 ns |        761.77 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128B         |         95.28 ns |       0.426 ns |       0.398 ns |         95.36 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128B         |         95.45 ns |       0.343 ns |       0.321 ns |         95.36 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128B         |        101.45 ns |       0.213 ns |       0.199 ns |        101.49 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 128B         |        105.02 ns |       0.290 ns |       0.271 ns |        105.06 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128B         |        105.14 ns |       0.279 ns |       0.261 ns |        105.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128B         |        111.66 ns |       0.367 ns |       0.343 ns |        111.54 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128B         |        761.21 ns |       1.621 ns |       1.517 ns |        761.41 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 137B         |        142.64 ns |       0.653 ns |       0.611 ns |        142.86 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 137B         |        142.79 ns |       0.595 ns |       0.557 ns |        142.73 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 137B         |        148.65 ns |       0.477 ns |       0.446 ns |        148.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 137B         |        162.11 ns |       0.435 ns |       0.407 ns |        162.25 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 137B         |        162.52 ns |       0.319 ns |       0.299 ns |        162.50 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 137B         |        167.58 ns |       0.745 ns |       0.697 ns |        167.36 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 137B         |      1,125.97 ns |       5.109 ns |       4.779 ns |      1,126.60 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1000B        |        759.71 ns |       2.862 ns |       2.537 ns |        760.09 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1000B        |        760.01 ns |       2.575 ns |       2.408 ns |        759.57 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1000B        |        776.17 ns |       2.096 ns |       1.960 ns |        776.50 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1000B        |        815.43 ns |       2.862 ns |       2.677 ns |        814.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1000B        |        815.89 ns |       1.893 ns |       1.771 ns |        815.76 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1000B        |        901.84 ns |       2.873 ns |       2.687 ns |        902.00 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1000B        |      5,680.62 ns |      21.405 ns |      20.022 ns |      5,679.13 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1KB          |        758.92 ns |       2.159 ns |       1.803 ns |        759.02 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1KB          |        760.05 ns |       3.592 ns |       3.360 ns |        759.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1KB          |        775.91 ns |       1.585 ns |       1.483 ns |        775.88 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1KB          |        812.64 ns |       2.692 ns |       2.518 ns |        812.62 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1KB          |        812.76 ns |       2.137 ns |       1.999 ns |        812.20 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1KB          |        904.31 ns |       2.629 ns |       2.459 ns |        904.41 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1KB          |      5,682.17 ns |      15.907 ns |      14.879 ns |      5,688.68 ns |         - |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1025B        |        856.17 ns |       3.112 ns |       2.911 ns |        856.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1025B        |        856.33 ns |       2.835 ns |       2.513 ns |        856.20 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1025B        |        878.15 ns |       2.597 ns |       2.429 ns |        877.66 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1025B        |        914.57 ns |       2.534 ns |       2.370 ns |        914.32 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1025B        |        915.30 ns |       2.272 ns |       2.125 ns |        915.06 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1025B        |      1,016.73 ns |       2.353 ns |       2.086 ns |      1,016.81 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1025B        |      6,479.54 ns |      16.000 ns |      14.967 ns |      6,484.36 ns |      56 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 2KB          |      1,566.85 ns |       6.636 ns |       6.208 ns |      1,565.78 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 2KB          |      1,568.95 ns |       4.945 ns |       4.625 ns |      1,569.55 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 2KB          |      1,591.07 ns |       1.905 ns |       1.591 ns |      1,591.11 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 2KB          |      1,646.42 ns |       3.588 ns |       3.356 ns |      1,647.93 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 2KB          |      1,647.40 ns |       5.150 ns |       4.818 ns |      1,649.04 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 2KB          |      1,867.69 ns |       3.318 ns |       3.103 ns |      1,868.89 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 2KB          |     11,735.64 ns |      53.171 ns |      49.737 ns |     11,726.91 ns |      56 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 3KB          |      1,712.05 ns |       7.075 ns |       6.618 ns |      1,712.74 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 3KB          |      1,719.83 ns |       7.028 ns |       6.574 ns |      1,720.55 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 3KB          |      1,759.29 ns |       5.717 ns |       5.348 ns |      1,759.04 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 3KB          |      2,411.31 ns |      11.587 ns |      10.838 ns |      2,411.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 3KB          |      2,492.56 ns |       6.590 ns |       6.165 ns |      2,492.81 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 3KB          |      2,899.50 ns |      10.435 ns |       9.761 ns |      2,897.32 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 3KB          |     17,737.10 ns |      81.465 ns |      76.203 ns |     17,740.66 ns |     112 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 4KB          |      1,698.27 ns |       5.296 ns |       4.954 ns |      1,698.63 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 4KB          |      1,761.79 ns |       5.226 ns |       4.888 ns |      1,761.81 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 4KB          |      1,765.07 ns |       5.378 ns |       5.030 ns |      1,765.77 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 4KB          |      1,824.40 ns |       3.159 ns |       2.800 ns |      1,824.19 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 4KB          |      1,979.93 ns |      14.290 ns |      13.367 ns |      1,974.81 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 4KB          |      3,334.77 ns |      11.713 ns |      10.956 ns |      3,334.12 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 4KB          |     23,809.45 ns |      50.871 ns |      47.585 ns |     23,800.87 ns |     168 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 5KB          |      2,450.50 ns |      12.334 ns |      11.537 ns |      2,445.78 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 5KB          |      2,507.36 ns |      17.410 ns |      16.286 ns |      2,507.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 5KB          |      2,514.01 ns |      13.555 ns |      12.679 ns |      2,517.42 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 5KB          |      2,648.31 ns |      12.268 ns |      11.475 ns |      2,649.47 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 5KB          |      2,959.62 ns |      11.818 ns |      11.055 ns |      2,960.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 5KB          |      4,186.21 ns |      16.211 ns |      15.163 ns |      4,191.22 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 5KB          |     29,968.58 ns |      71.581 ns |      66.957 ns |     29,978.43 ns |     224 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 6KB          |      3,250.91 ns |       9.651 ns |       9.028 ns |      3,251.40 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 6KB          |      3,298.56 ns |       7.824 ns |       7.319 ns |      3,297.52 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 6KB          |      3,304.87 ns |       9.264 ns |       8.666 ns |      3,306.89 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 6KB          |      3,502.17 ns |      10.348 ns |       9.680 ns |      3,502.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 6KB          |      3,851.43 ns |      32.685 ns |      30.574 ns |      3,854.17 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 6KB          |      5,029.72 ns |      18.777 ns |      16.645 ns |      5,031.97 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 6KB          |     35,943.91 ns |     108.921 ns |     101.885 ns |     35,957.48 ns |     280 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 8KB          |      3,360.10 ns |      10.955 ns |      10.247 ns |      3,360.17 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 8KB          |      3,498.32 ns |      13.551 ns |      12.675 ns |      3,499.87 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 8KB          |      3,503.59 ns |       8.596 ns |       8.041 ns |      3,502.96 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 8KB          |      3,699.79 ns |      10.264 ns |       9.099 ns |      3,702.03 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 8KB          |      3,884.54 ns |      27.222 ns |      25.464 ns |      3,889.67 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 8KB          |      6,728.10 ns |      18.651 ns |      17.446 ns |      6,730.88 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 8KB          |     48,032.26 ns |      91.949 ns |      86.010 ns |     48,040.27 ns |     392 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 9216B        |      4,099.41 ns |      19.521 ns |      18.260 ns |      4,100.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 9216B        |      4,246.15 ns |      15.079 ns |      14.105 ns |      4,250.41 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 9216B        |      4,248.98 ns |      18.129 ns |      16.958 ns |      4,249.97 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 9216B        |      4,508.34 ns |      18.222 ns |      17.045 ns |      4,506.71 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 9216B        |      4,849.31 ns |      24.565 ns |      22.979 ns |      4,850.74 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 9216B        |      7,578.61 ns |      18.384 ns |      17.196 ns |      7,581.97 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 9216B        |     53,907.76 ns |     151.517 ns |     141.729 ns |     53,918.26 ns |     448 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10000B       |      4,699.64 ns |      31.785 ns |      29.731 ns |      4,699.68 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10000B       |      4,860.54 ns |      20.688 ns |      18.340 ns |      4,859.62 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10000B       |      4,864.86 ns |      24.374 ns |      22.799 ns |      4,873.29 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10000B       |      5,186.06 ns |      26.241 ns |      24.546 ns |      5,177.41 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10000B       |      5,584.58 ns |      32.361 ns |      30.271 ns |      5,572.06 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10000B       |      8,283.64 ns |      27.743 ns |      25.951 ns |      8,286.16 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10000B       |     59,019.13 ns |     214.253 ns |     200.412 ns |     58,920.93 ns |     504 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10240B       |      4,849.56 ns |      23.672 ns |      22.143 ns |      4,848.94 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10240B       |      4,988.67 ns |      22.636 ns |      21.174 ns |      4,980.41 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10240B       |      5,002.91 ns |      23.992 ns |      22.442 ns |      5,001.78 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10240B       |      5,328.09 ns |      22.049 ns |      20.624 ns |      5,329.33 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10240B       |      5,744.03 ns |      16.769 ns |      15.686 ns |      5,745.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10240B       |      8,433.74 ns |      18.082 ns |      16.914 ns |      8,435.75 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10240B       |     60,174.98 ns |     198.227 ns |     175.723 ns |     60,206.28 ns |     504 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 11264B       |      5,238.30 ns |      20.194 ns |      18.890 ns |      5,244.84 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 11264B       |      5,250.44 ns |      18.564 ns |      16.456 ns |      5,256.94 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 11264B       |      5,525.96 ns |      25.834 ns |      24.165 ns |      5,529.30 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 11264B       |      5,639.08 ns |      14.035 ns |      12.442 ns |      5,641.34 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 11264B       |      6,660.38 ns |      27.497 ns |      24.375 ns |      6,661.83 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 11264B       |      9,280.61 ns |      22.890 ns |      21.411 ns |      9,286.93 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 11264B       |     66,011.22 ns |     398.666 ns |     372.912 ns |     65,961.60 ns |     560 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 12288B       |      5,019.51 ns |      22.656 ns |      21.193 ns |      5,018.53 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 12288B       |      5,221.24 ns |      16.604 ns |      14.719 ns |      5,223.46 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 12288B       |      5,222.75 ns |      21.331 ns |      18.910 ns |      5,222.92 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 12288B       |      5,562.16 ns |      25.319 ns |      23.683 ns |      5,557.79 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 12288B       |      5,814.74 ns |      18.667 ns |      17.461 ns |      5,816.15 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 12288B       |     10,111.12 ns |      32.305 ns |      30.218 ns |     10,119.53 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 12288B       |     72,265.45 ns |     374.970 ns |     350.748 ns |     72,198.32 ns |     616 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 15360B       |      6,958.33 ns |      13.204 ns |      12.351 ns |      6,955.10 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 15360B       |      6,972.60 ns |      17.668 ns |      16.526 ns |      6,965.95 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 15360B       |      7,218.01 ns |      26.276 ns |      24.578 ns |      7,215.77 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 15360B       |      7,362.42 ns |      19.666 ns |      18.395 ns |      7,362.48 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 15360B       |      8,501.84 ns |      46.811 ns |      43.787 ns |      8,502.36 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 15360B       |     12,621.50 ns |       9.305 ns |       8.704 ns |     12,622.88 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 15360B       |     89,901.77 ns |     331.194 ns |     293.595 ns |     89,954.23 ns |     784 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 16KB         |      6,637.52 ns |      13.594 ns |      12.715 ns |      6,636.78 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 16KB         |      6,923.15 ns |      13.483 ns |      12.612 ns |      6,920.32 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 16KB         |      6,939.46 ns |      15.170 ns |      14.190 ns |      6,939.75 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 16KB         |      7,432.51 ns |      13.720 ns |      12.833 ns |      7,429.73 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 16KB         |      7,681.26 ns |      39.260 ns |      36.724 ns |      7,676.16 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 16KB         |     13,461.34 ns |      16.679 ns |      15.602 ns |     13,466.02 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 16KB         |     95,865.04 ns |     193.039 ns |     180.569 ns |     95,849.08 ns |     840 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 64KB         |     15,848.14 ns |      56.131 ns |      49.759 ns |     15,855.86 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 64KB         |     26,443.90 ns |      55.158 ns |      51.594 ns |     26,446.75 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 64KB         |     27,727.67 ns |      66.803 ns |      62.487 ns |     27,711.36 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 64KB         |     27,967.07 ns |      59.967 ns |      56.093 ns |     27,976.44 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 64KB         |     30,603.91 ns |      70.064 ns |      65.538 ns |     30,600.88 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 64KB         |     53,980.47 ns |     115.018 ns |     107.588 ns |     54,010.14 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 64KB         |    386,880.32 ns |   1,649.772 ns |   1,543.198 ns |    386,756.82 ns |    3528 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 100000B      |     17,128.82 ns |     135.749 ns |     120.338 ns |     17,160.54 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 100000B      |     41,031.33 ns |     166.702 ns |     155.933 ns |     41,053.80 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 100000B      |     43,284.16 ns |      99.955 ns |      93.498 ns |     43,273.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 100000B      |     44,366.53 ns |     119.352 ns |     111.642 ns |     44,382.14 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 100000B      |     47,384.39 ns |      77.660 ns |      68.843 ns |     47,383.73 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 100000B      |     82,630.49 ns |      57.479 ns |      53.766 ns |     82,633.65 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 100000B      |    586,020.94 ns |   3,082.547 ns |   2,883.416 ns |    587,142.62 ns |    5432 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 128KB        |     20,542.53 ns |     189.257 ns |     167.771 ns |     20,596.93 ns |     128 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 128KB        |     52,970.16 ns |     143.340 ns |     134.080 ns |     52,948.24 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 128KB        |     55,885.80 ns |     244.447 ns |     228.656 ns |     55,842.69 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 128KB        |     56,005.63 ns |     118.173 ns |     110.539 ns |     56,010.92 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 128KB        |     61,270.34 ns |     151.388 ns |     141.608 ns |     61,282.70 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 128KB        |    108,140.93 ns |      55.841 ns |      52.234 ns |    108,143.67 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 128KB        |    768,332.79 ns |   1,624.902 ns |   1,519.934 ns |    767,721.39 ns |    7112 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 1MB          |     79,134.58 ns |   1,431.894 ns |   2,392.374 ns |     77,975.89 ns |     130 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 1MB          |    403,858.61 ns |   1,021.331 ns |     905.383 ns |    403,911.78 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 1MB          |    428,952.76 ns |     538.042 ns |     503.285 ns |    428,850.89 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 1MB          |    437,098.10 ns |   1,129.406 ns |   1,001.189 ns |    437,266.70 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 1MB          |    468,228.96 ns |     991.760 ns |     927.693 ns |    468,498.11 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 1MB          |    825,239.00 ns |   1,071.434 ns |     949.798 ns |    825,561.20 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 1MB          |  5,867,479.30 ns |  17,734.979 ns |  16,589.311 ns |  5,866,672.85 ns |   54656 B |
|                                                 |              |                  |                |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed        | 10MB         |    673,459.46 ns |  11,575.400 ns |  10,827.637 ns |    672,365.56 ns |     194 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native     | 10MB         |  4,084,993.82 ns |  21,368.332 ns |  19,987.951 ns |  4,089,251.30 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon      | 10MB         |  4,350,670.40 ns |  20,913.004 ns |  19,562.037 ns |  4,349,849.61 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed-Serial | 10MB         |  4,387,041.10 ns |  19,968.064 ns |  18,678.139 ns |  4,387,345.05 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed    | 10MB         |  4,719,213.78 ns |  26,294.319 ns |  24,595.722 ns |  4,720,503.26 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar    | 10MB         |  8,267,253.21 ns |   6,477.259 ns |   6,058.832 ns |  8,266,441.41 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle          | 10MB         | 59,342,929.33 ns | 290,968.504 ns | 272,172.119 ns | 59,354,712.89 ns |  546840 B |