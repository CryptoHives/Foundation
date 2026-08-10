| Description                                  | TestDataSize | Mean             | Error          | StdDev         | Allocated |
|--------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         52.89 ns |       0.036 ns |       0.034 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         54.44 ns |       0.124 ns |       0.116 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         63.37 ns |       0.659 ns |       0.648 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         65.65 ns |       0.121 ns |       0.113 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         65.87 ns |       0.083 ns |       0.077 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        333.04 ns |       0.820 ns |       0.767 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        100.52 ns |       0.210 ns |       0.197 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        109.31 ns |       0.072 ns |       0.067 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        122.57 ns |       0.131 ns |       0.110 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        125.34 ns |       0.118 ns |       0.110 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        125.89 ns |       0.462 ns |       0.432 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        722.80 ns |       0.880 ns |       0.823 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        100.71 ns |       0.217 ns |       0.203 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        109.28 ns |       0.263 ns |       0.246 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        123.20 ns |       0.117 ns |       0.109 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        125.46 ns |       0.407 ns |       0.381 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        125.82 ns |       0.143 ns |       0.134 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        723.10 ns |       1.511 ns |       1.413 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        147.87 ns |       0.093 ns |       0.087 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        165.91 ns |       0.071 ns |       0.066 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        181.16 ns |       0.427 ns |       0.378 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        181.52 ns |       0.493 ns |       0.461 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        182.83 ns |       0.601 ns |       0.562 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,076.50 ns |       2.618 ns |       2.449 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        779.43 ns |       0.718 ns |       0.672 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        901.12 ns |       2.805 ns |       2.486 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |        901.23 ns |       0.504 ns |       0.471 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        902.86 ns |       0.345 ns |       0.322 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        972.15 ns |       0.486 ns |       0.454 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,487.71 ns |       7.014 ns |       6.561 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        777.23 ns |       2.089 ns |       1.954 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        899.96 ns |       2.293 ns |       2.145 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |        902.25 ns |       0.308 ns |       0.288 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        903.53 ns |       1.762 ns |       1.649 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        972.12 ns |       0.845 ns |       0.790 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      5,459.65 ns |       8.130 ns |       7.605 ns |         - |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        879.39 ns |       0.471 ns |       0.441 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,020.59 ns |       0.525 ns |       0.465 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,043.27 ns |       0.708 ns |       0.662 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      1,043.92 ns |       0.397 ns |       0.352 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,141.12 ns |       6.380 ns |       5.968 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,194.01 ns |       9.343 ns |       8.739 ns |      56 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      1,601.67 ns |       0.932 ns |       0.872 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      1,873.55 ns |       4.199 ns |       3.928 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      1,877.44 ns |       1.194 ns |       1.117 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      1,879.44 ns |       0.574 ns |       0.537 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      2,067.98 ns |      11.749 ns |      10.990 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     11,246.44 ns |      22.976 ns |      21.491 ns |      56 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,730.04 ns |       5.106 ns |       4.776 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      2,001.68 ns |       5.292 ns |       4.950 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,113.41 ns |      11.975 ns |      10.615 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      3,109.35 ns |      11.080 ns |      10.364 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |      3,806.20 ns |       8.873 ns |       8.300 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     22,826.24 ns |      32.515 ns |      30.415 ns |     168 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |      3,313.16 ns |      15.424 ns |      14.428 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |      3,912.85 ns |      12.726 ns |      11.904 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |      4,052.81 ns |      16.321 ns |      15.267 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |      4,218.18 ns |      16.057 ns |      15.019 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |      5,743.02 ns |       2.795 ns |       2.614 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |     34,453.86 ns |      32.692 ns |      30.580 ns |     280 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,421.73 ns |      12.295 ns |      11.501 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,962.89 ns |      13.685 ns |      12.801 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,290.51 ns |      19.402 ns |      18.149 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      5,246.87 ns |      13.445 ns |      12.577 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,667.99 ns |      19.221 ns |      17.979 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     45,834.98 ns |      55.234 ns |      51.666 ns |     392 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,814.29 ns |      24.379 ns |      22.805 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,668.36 ns |      14.360 ns |      13.433 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      6,027.06 ns |      23.927 ns |      22.381 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,169.10 ns |      24.010 ns |      22.459 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,430.32 ns |      26.123 ns |      24.435 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     56,614.36 ns |      42.904 ns |      40.132 ns |     504 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     27,110.75 ns |      77.901 ns |      72.868 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     31,112.54 ns |      77.385 ns |      72.386 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     34,719.77 ns |     194.166 ns |     181.623 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     35,339.97 ns |     102.781 ns |      96.141 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,725.88 ns |      59.004 ns |      55.193 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    368,526.61 ns |     978.063 ns |     914.881 ns |    3528 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     42,019.59 ns |     201.290 ns |     188.287 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |     48,272.22 ns |      77.688 ns |      64.873 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     51,458.72 ns |     229.538 ns |     214.710 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     53,275.35 ns |     137.093 ns |     128.237 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |     94,268.81 ns |      64.377 ns |      60.218 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    564,241.73 ns |     467.579 ns |     437.373 ns |    5432 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     54,344.30 ns |     166.023 ns |     155.298 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     62,223.62 ns |     180.593 ns |     168.927 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     67,402.18 ns |     315.581 ns |     295.195 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     69,786.30 ns |     200.335 ns |     187.393 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    123,429.61 ns |     298.565 ns |     279.278 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    739,527.02 ns |     702.313 ns |     656.944 ns |    7112 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    108,799.43 ns |     362.588 ns |     339.165 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    124,692.15 ns |     340.576 ns |     318.575 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    132,935.22 ns |     563.877 ns |     527.451 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |    138,752.15 ns |     315.900 ns |     295.493 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    247,707.85 ns |     106.770 ns |      94.649 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,478,651.59 ns |   3,783.347 ns |   3,538.945 ns |   14280 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    217,412.34 ns |     609.045 ns |     569.701 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    249,207.62 ns |     891.399 ns |     833.815 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    263,132.67 ns |   1,157.773 ns |   1,082.981 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |    276,519.66 ns |     467.242 ns |     437.058 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    495,534.46 ns |     249.800 ns |     233.663 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  2,962,840.38 ns |   1,797.831 ns |   1,501.270 ns |   28616 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    415,347.85 ns |   1,005.866 ns |     940.888 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    475,669.54 ns |   1,449.375 ns |   1,355.746 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    499,192.07 ns |   2,186.000 ns |   2,044.786 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    526,377.86 ns |     642.923 ns |     536.870 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |    945,487.34 ns |   1,865.519 ns |   1,745.008 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          |  5,669,308.73 ns |   6,310.922 ns |   5,903.240 ns |   54656 B |
|                                              |              |                  |                |                |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,162,937.35 ns |  14,417.773 ns |  13,486.394 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,758,308.20 ns |   9,286.094 ns |   8,231.881 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  4,993,758.31 ns |  18,101.549 ns |  16,932.200 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  5,274,051.41 ns |   9,307.048 ns |   8,705.819 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,462,640.84 ns |   3,406.959 ns |   3,186.871 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 56,611,772.87 ns | 128,402.875 ns | 120,108.129 ns |  546840 B |