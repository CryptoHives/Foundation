| Description                                  | TestDataSize | Mean             | Error         | StdDev        | Allocated |
|--------------------------------------------- |------------- |-----------------:|--------------:|--------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         53.00 ns |      0.036 ns |      0.032 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         54.46 ns |      0.094 ns |      0.088 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         63.18 ns |      0.139 ns |      0.109 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         64.65 ns |      0.071 ns |      0.059 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         65.12 ns |      0.105 ns |      0.093 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        326.79 ns |      0.875 ns |      0.819 ns |         - |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        100.43 ns |      0.054 ns |      0.048 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        109.29 ns |      0.077 ns |      0.069 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        123.03 ns |      0.175 ns |      0.155 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        124.56 ns |      0.260 ns |      0.231 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        124.57 ns |      0.129 ns |      0.108 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        715.73 ns |      2.360 ns |      2.092 ns |         - |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        100.82 ns |      0.213 ns |      0.188 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        109.18 ns |      0.205 ns |      0.182 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        123.07 ns |      0.301 ns |      0.282 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        124.13 ns |      0.081 ns |      0.068 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        124.44 ns |      0.114 ns |      0.101 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        718.62 ns |      2.028 ns |      1.897 ns |         - |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        147.70 ns |      0.099 ns |      0.093 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        165.52 ns |      0.095 ns |      0.080 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        180.50 ns |      0.337 ns |      0.315 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        180.72 ns |      0.100 ns |      0.094 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        183.02 ns |      0.163 ns |      0.152 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,065.49 ns |      3.493 ns |      3.267 ns |         - |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        778.24 ns |      0.407 ns |      0.361 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |        896.92 ns |      1.539 ns |      1.440 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        900.76 ns |      1.679 ns |      1.571 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        903.95 ns |      1.567 ns |      1.466 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        971.28 ns |      0.722 ns |      0.676 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,440.58 ns |     10.972 ns |     10.264 ns |         - |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        777.28 ns |      0.437 ns |      0.408 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |        898.68 ns |      0.403 ns |      0.377 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        902.20 ns |      1.670 ns |      1.562 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        903.20 ns |      1.566 ns |      1.465 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |        970.71 ns |      0.708 ns |      0.591 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      5,415.90 ns |     15.182 ns |     14.201 ns |         - |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        877.36 ns |      0.686 ns |      0.642 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,024.98 ns |      0.674 ns |      0.630 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      1,037.81 ns |      0.807 ns |      0.755 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,039.48 ns |      0.422 ns |      0.395 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,141.33 ns |      4.170 ns |      3.901 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,156.11 ns |     10.293 ns |      9.628 ns |      56 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      1,598.67 ns |      0.943 ns |      0.882 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      1,873.47 ns |      2.297 ns |      2.036 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      1,876.09 ns |      3.882 ns |      3.631 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      1,947.88 ns |     11.742 ns |     10.983 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      2,056.00 ns |      7.109 ns |      6.650 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     11,169.36 ns |     37.806 ns |     33.514 ns |      56 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,716.47 ns |      5.869 ns |      5.490 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      1,989.89 ns |      5.170 ns |      4.583 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,077.39 ns |     13.148 ns |     12.298 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      3,081.70 ns |      8.964 ns |      8.385 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |      3,806.22 ns |      1.335 ns |      1.184 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     22,656.68 ns |     65.397 ns |     61.172 ns |     168 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |      3,279.30 ns |     10.262 ns |      9.599 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |      3,883.75 ns |     17.287 ns |     16.170 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |      4,134.45 ns |     18.593 ns |     17.392 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |      4,190.80 ns |     17.513 ns |     16.381 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |      5,735.74 ns |      2.391 ns |      1.997 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |     34,223.55 ns |    104.399 ns |     97.655 ns |     280 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,397.75 ns |     14.074 ns |     13.165 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,911.61 ns |     20.130 ns |     18.830 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |      4,257.87 ns |     17.720 ns |     16.576 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      5,209.47 ns |     25.549 ns |     23.899 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,658.06 ns |     18.796 ns |     17.582 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     45,765.55 ns |     85.011 ns |     79.519 ns |     392 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,783.76 ns |     29.657 ns |     26.290 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,631.57 ns |     12.301 ns |     10.905 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      5,987.25 ns |     16.951 ns |     15.856 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,134.47 ns |     19.187 ns |     17.947 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,434.37 ns |      3.898 ns |      3.647 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     56,274.31 ns |     87.787 ns |     82.116 ns |     504 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     26,897.40 ns |    121.650 ns |    113.791 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     30,901.58 ns |    139.030 ns |    130.049 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     34,502.61 ns |    121.423 ns |    107.639 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     35,131.39 ns |    136.074 ns |    127.284 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,669.89 ns |     79.719 ns |     74.570 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    367,973.91 ns |    602.929 ns |    563.980 ns |    3528 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     41,710.37 ns |    167.874 ns |    157.030 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |     48,005.16 ns |    105.898 ns |     99.057 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     51,084.84 ns |    186.817 ns |    174.749 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     53,061.35 ns |    198.177 ns |    185.375 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |     94,242.71 ns |     32.780 ns |     30.663 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    561,140.30 ns |  1,089.610 ns |  1,019.222 ns |    5432 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     53,898.46 ns |    129.109 ns |    120.768 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     61,858.86 ns |    126.669 ns |    105.775 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     66,972.53 ns |    341.751 ns |    319.674 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     69,462.00 ns |    215.040 ns |    201.149 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    123,434.03 ns |    277.067 ns |    259.168 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    736,167.44 ns |    853.280 ns |    798.159 ns |    7112 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    108,024.22 ns |    315.940 ns |    295.530 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    124,039.82 ns |    364.732 ns |    341.171 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    131,924.95 ns |    490.509 ns |    458.822 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |    138,200.32 ns |    374.070 ns |    312.365 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    247,839.72 ns |    166.252 ns |    155.512 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,473,718.46 ns |  1,965.098 ns |  1,838.154 ns |   14280 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    216,001.60 ns |    915.066 ns |    855.953 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    247,967.15 ns |    763.441 ns |    714.124 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    261,527.41 ns |  1,495.404 ns |  1,398.802 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |    275,614.31 ns |    915.304 ns |    856.176 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    495,721.46 ns |    343.993 ns |    321.771 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  2,954,383.20 ns |  3,533.620 ns |  3,305.350 ns |   28616 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    412,776.66 ns |  2,058.449 ns |  1,925.475 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    473,715.60 ns |  1,216.776 ns |  1,078.640 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    496,141.03 ns |  3,008.136 ns |  2,813.813 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    524,639.15 ns |  2,132.628 ns |  1,994.862 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |    946,109.68 ns |    539.585 ns |    478.328 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          |  5,636,968.03 ns |  7,466.008 ns |  6,983.708 ns |   54656 B |
|                                              |              |                  |               |               |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,128,383.81 ns | 13,427.105 ns | 11,902.779 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,740,555.78 ns |  9,221.888 ns |  8,174.964 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  4,959,240.92 ns | 23,679.292 ns | 22,149.625 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  5,251,388.56 ns | 15,482.254 ns | 14,482.110 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,468,812.76 ns |  3,750.708 ns |  3,508.414 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 56,454,643.20 ns | 88,459.757 ns | 82,745.312 ns |  548211 B |