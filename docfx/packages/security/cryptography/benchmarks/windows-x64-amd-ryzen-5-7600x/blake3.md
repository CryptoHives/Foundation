| Description                                   | TestDataSize | Mean             | Error            | StdDev         | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|-----------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.00 ns |         0.086 ns |       0.076 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         61.26 ns |         0.361 ns |       0.302 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         61.86 ns |         0.190 ns |       0.168 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         62.15 ns |         0.261 ns |       0.244 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         62.35 ns |         0.163 ns |       0.153 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         74.65 ns |         0.271 ns |       0.241 ns |   5,115 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |         81.72 ns |         0.477 ns |       0.423 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        602.95 ns |         2.120 ns |       1.771 ns |  21,324 B |         - |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         98.12 ns |         0.720 ns |       0.673 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        104.99 ns |         0.403 ns |       0.377 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        117.67 ns |         0.257 ns |       0.215 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        117.94 ns |         0.441 ns |       0.368 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        119.98 ns |         0.589 ns |       0.522 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        121.63 ns |         0.254 ns |       0.212 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        167.53 ns |         0.718 ns |       0.599 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,316.20 ns |         5.185 ns |       4.597 ns |  21,991 B |         - |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         94.64 ns |         0.867 ns |       0.769 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        105.36 ns |         0.324 ns |       0.303 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        117.83 ns |         0.605 ns |       0.536 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |        117.96 ns |         0.209 ns |       0.185 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        117.98 ns |         0.760 ns |       0.711 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        117.99 ns |         0.891 ns |       0.790 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        167.83 ns |         1.214 ns |       1.135 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,314.43 ns |         7.668 ns |       7.173 ns |  21,984 B |         - |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        149.91 ns |         1.475 ns |       1.380 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        161.60 ns |         0.596 ns |       0.528 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        168.61 ns |         0.496 ns |       0.464 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        170.84 ns |         0.772 ns |       0.603 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        171.18 ns |         1.124 ns |       1.052 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        171.29 ns |         1.147 ns |       1.016 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        248.11 ns |         1.721 ns |       1.610 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      1,946.23 ns |        11.103 ns |       9.843 ns |  21,985 B |         - |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        755.83 ns |         6.880 ns |       6.435 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        789.00 ns |         6.933 ns |       6.485 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        824.85 ns |        10.735 ns |       9.516 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        851.81 ns |         5.452 ns |       4.833 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        852.82 ns |         7.690 ns |       6.817 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        859.92 ns |        15.845 ns |      16.954 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      1,273.76 ns |         5.922 ns |       4.945 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,182.22 ns |        46.492 ns |      41.214 ns |  22,003 B |         - |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        753.80 ns |         6.390 ns |       5.664 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        787.84 ns |         9.296 ns |       8.695 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        820.44 ns |         6.991 ns |       6.539 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        851.75 ns |         5.324 ns |       4.980 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        852.73 ns |         5.885 ns |       5.504 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        853.66 ns |         7.085 ns |       6.281 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      1,279.33 ns |         7.220 ns |       6.753 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,639.72 ns |        40.311 ns |      35.734 ns |  22,012 B |         - |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        832.42 ns |         7.096 ns |       6.290 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        943.71 ns |         3.264 ns |       3.053 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        956.12 ns |         7.716 ns |       6.840 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        984.93 ns |        11.767 ns |      11.007 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        985.42 ns |        10.552 ns |       9.354 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        997.91 ns |        19.894 ns |      29.776 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      1,477.26 ns |         5.483 ns |       5.129 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     10,840.54 ns |        30.351 ns |      26.905 ns |  22,329 B |      56 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        789.04 ns |         5.037 ns |       4.711 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,223.29 ns |         7.222 ns |       6.031 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,232.99 ns |        12.073 ns |      10.703 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,666.02 ns |         4.952 ns |       4.390 ns |  11,384 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,738.88 ns |        13.761 ns |      12.872 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,770.55 ns |        12.585 ns |      11.772 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      2,666.56 ns |        10.491 ns |       8.191 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     20,063.30 ns |       170.440 ns |     151.090 ns |  22,238 B |      56 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,019.26 ns |        11.620 ns |      10.870 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,332.96 ns |        10.024 ns |       9.376 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,334.54 ns |        10.933 ns |      10.227 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      2,120.38 ns |        23.072 ns |      21.581 ns |  18,024 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,498.91 ns |        25.246 ns |      23.615 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      3,605.61 ns |        36.459 ns |      32.320 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |      5,442.42 ns |        26.958 ns |      23.898 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     40,407.38 ns |       161.952 ns |     143.567 ns |  22,230 B |     168 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,452.52 ns |         9.720 ns |       9.092 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,464.58 ns |        21.495 ns |      20.106 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,826.56 ns |        13.615 ns |      12.070 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      3,056.87 ns |        34.055 ns |      31.855 ns |  18,387 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,277.62 ns |        41.919 ns |      39.211 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      5,421.93 ns |        43.644 ns |      36.445 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |      8,223.55 ns |        91.116 ns |     111.899 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     61,581.27 ns |       223.069 ns |     197.745 ns |  22,255 B |     280 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,168.09 ns |        11.434 ns |      10.696 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,451.29 ns |        13.906 ns |      12.328 ns |   6,420 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,555.29 ns |        14.968 ns |      13.269 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,567.91 ns |        12.696 ns |      11.876 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      2,484.78 ns |         8.916 ns |       8.340 ns |  18,438 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      7,226.11 ns |        50.516 ns |      47.253 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     10,950.78 ns |        68.700 ns |      60.900 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     82,366.85 ns |       516.414 ns |     431.229 ns |  22,243 B |     392 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,579.23 ns |        21.721 ns |      20.318 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,076.23 ns |        25.087 ns |      22.239 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,172.63 ns |        22.672 ns |      20.098 ns |   7,773 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      3,227.05 ns |        17.223 ns |      14.382 ns |  18,537 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,389.90 ns |        29.188 ns |      25.874 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      8,903.02 ns |        90.271 ns |      84.440 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     13,513.89 ns |        56.741 ns |      53.075 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    101,885.67 ns |       544.045 ns |     454.303 ns |  22,259 B |     504 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,301.56 ns |        59.927 ns |      53.124 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      8,856.11 ns |       104.337 ns |      97.597 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |      9,859.77 ns |       142.026 ns |     132.851 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,985.51 ns |       101.096 ns |      89.619 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     14,179.59 ns |        73.723 ns |      65.354 ns |  18,195 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     58,256.59 ns |       465.511 ns |     412.664 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |     88,633.16 ns |       572.673 ns |     507.660 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    670,798.52 ns |     4,542.041 ns |   4,248.628 ns |  22,273 B |    3528 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,331.76 ns |        94.296 ns |      88.204 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     14,850.17 ns |       106.871 ns |      99.967 ns |   8,921 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     15,193.39 ns |        97.763 ns |      86.664 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |     15,948.95 ns |       102.354 ns |      95.742 ns |  30,401 B |    2335 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,683.72 ns |       188.840 ns |     176.641 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     88,747.45 ns |       907.450 ns |     757.762 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    135,064.97 ns |       985.151 ns |     822.646 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |  1,043,403.75 ns |     3,675.443 ns |   3,258.184 ns |  22,247 B |    5432 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,459.90 ns |       153.323 ns |     128.032 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     17,647.99 ns |       163.128 ns |     144.609 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |     19,181.89 ns |        76.676 ns |      71.723 ns |  30,228 B |    2620 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     20,512.83 ns |       228.500 ns |     213.739 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,073.83 ns |       185.776 ns |     164.685 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    116,615.77 ns |       902.434 ns |     799.984 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    177,289.63 ns |     1,269.292 ns |   1,187.297 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,316,933.19 ns |     9,025.624 ns |   8,442.574 ns |  22,258 B |    7112 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     24,758.74 ns |        84.965 ns |      75.319 ns |  30,249 B |    2919 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,750.60 ns |       239.095 ns |     211.952 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     34,841.40 ns |       190.784 ns |     148.952 ns |   8,618 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     40,182.77 ns |       386.209 ns |     361.260 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     43,238.06 ns |       517.198 ns |     483.788 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |    233,188.09 ns |     1,795.894 ns |   1,592.013 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |    353,375.32 ns |     1,612.118 ns |   1,507.976 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,674,078.12 ns |    11,696.318 ns |   9,766.955 ns |  22,258 B |   14280 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     29,440.59 ns |       311.161 ns |     291.060 ns |  30,672 B |    3712 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     57,458.67 ns |       578.616 ns |     512.928 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     77,436.81 ns |       614.307 ns |     574.623 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     79,791.95 ns |       842.294 ns |     746.672 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     84,462.44 ns |       519.867 ns |     486.284 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    467,325.23 ns |     2,756.837 ns |   2,443.864 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |    707,067.00 ns |     5,432.625 ns |   4,815.881 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,395,219.81 ns |    39,583.115 ns |  35,089.400 ns |  22,253 B |   28616 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     37,594.96 ns |        72.164 ns |      63.972 ns |  29,882 B |    4168 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    110,841.32 ns |       835.557 ns |     740.699 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    135,786.88 ns |     1,715.619 ns |   1,604.791 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    138,977.93 ns |     2,212.991 ns |   1,961.759 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    159,034.09 ns |     1,608.094 ns |   1,504.212 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    892,115.21 ns |     6,421.278 ns |   6,006.467 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  1,353,101.88 ns |     7,804.055 ns |   6,918.091 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,524,182.21 ns |    31,639.752 ns |  26,420.626 ns |  22,249 B |   54656 B |
|                                               |              |                  |                  |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    301,385.67 ns |     5,379.417 ns |   4,492.057 ns |  37,441 B |    4009 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,107,444.27 ns |    11,868.967 ns |  11,102.239 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,401,052.21 ns |    17,579.178 ns |  14,679.410 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,548,702.21 ns |    15,511.519 ns |  14,509.484 ns |   8,898 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,592,658.78 ns |     9,793.390 ns |   9,160.744 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  8,924,192.75 ns |   110,668.713 ns |  98,104.931 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 13,528,998.12 ns |    86,313.033 ns |  80,737.265 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 97,434,836.67 ns | 1,124,467.444 ns | 877,910.216 ns |  22,595 B |  546840 B |