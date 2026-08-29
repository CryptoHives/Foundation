| Description                                  | TestDataSize | Mean             | Error         | StdDev         | Median           | Allocated |
|--------------------------------------------- |------------- |-----------------:|--------------:|---------------:|-----------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4B           |         52.66 ns |      0.032 ns |       0.027 ns |         52.66 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4B           |         54.22 ns |      0.016 ns |       0.013 ns |         54.23 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4B           |         64.68 ns |      1.899 ns |       4.834 ns |         64.85 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4B           |         64.97 ns |      0.064 ns |       0.060 ns |         64.97 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4B           |         65.04 ns |      0.226 ns |       0.200 ns |         64.97 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4B           |        351.16 ns |      0.083 ns |       0.078 ns |        351.16 ns |         - |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100B         |        100.25 ns |      0.130 ns |       0.121 ns |        100.25 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100B         |        108.60 ns |      0.044 ns |       0.041 ns |        108.60 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100B         |        115.67 ns |      0.059 ns |       0.055 ns |        115.67 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100B         |        125.51 ns |      0.200 ns |       0.187 ns |        125.44 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100B         |        125.79 ns |      0.204 ns |       0.181 ns |        125.81 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100B         |        752.86 ns |      0.792 ns |       0.741 ns |        752.97 ns |         - |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128B         |        100.30 ns |      0.050 ns |       0.045 ns |        100.31 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128B         |        108.58 ns |      0.028 ns |       0.025 ns |        108.59 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |        125.22 ns |      0.044 ns |       0.039 ns |        125.22 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |        125.22 ns |      0.045 ns |       0.037 ns |        125.21 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128B         |        127.01 ns |      4.686 ns |      11.927 ns |        126.69 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |        756.01 ns |      0.178 ns |       0.149 ns |        756.01 ns |         - |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 137B         |        147.87 ns |      1.647 ns |       1.460 ns |        148.87 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 137B         |        164.55 ns |      0.076 ns |       0.068 ns |        164.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 137B         |        179.68 ns |      0.238 ns |       0.211 ns |        179.71 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |        180.71 ns |      0.251 ns |       0.196 ns |        180.65 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |        180.74 ns |      0.064 ns |       0.057 ns |        180.73 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |      1,128.62 ns |      0.565 ns |       0.472 ns |      1,128.59 ns |         - |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1000B        |        774.69 ns |      0.246 ns |       0.192 ns |        774.72 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1000B        |        894.99 ns |      0.835 ns |       0.697 ns |        895.03 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1000B        |        895.57 ns |      0.186 ns |       0.174 ns |        895.59 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1000B        |        895.99 ns |      1.378 ns |       1.222 ns |        895.86 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1000B        |        955.26 ns |      0.747 ns |       0.699 ns |        955.15 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1000B        |      5,808.35 ns |      1.888 ns |       1.674 ns |      5,807.93 ns |         - |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1KB          |        773.90 ns |      0.230 ns |       0.204 ns |        773.91 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |        895.80 ns |      0.214 ns |       0.189 ns |        895.87 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |        895.89 ns |      0.258 ns |       0.229 ns |        895.99 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1KB          |        897.29 ns |      0.739 ns |       0.617 ns |        897.30 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1KB          |      1,062.22 ns |     11.293 ns |      10.011 ns |      1,067.05 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |      6,130.68 ns |     60.268 ns |      56.375 ns |      6,131.94 ns |         - |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1025B        |        874.69 ns |      0.426 ns |       0.356 ns |        874.62 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1025B        |      1,026.24 ns |      5.845 ns |       4.881 ns |      1,028.45 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |      1,034.21 ns |      0.293 ns |       0.274 ns |      1,034.29 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1025B        |      1,080.71 ns |      5.109 ns |       4.266 ns |      1,079.52 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |      2,863.97 ns |    661.397 ns |   1,950.145 ns |      1,205.62 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |      6,633.51 ns |     66.512 ns |      62.215 ns |      6,673.71 ns |      56 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 2KB          |      1,591.14 ns |      0.450 ns |       0.399 ns |      1,591.22 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 2KB          |      1,861.24 ns |      0.673 ns |       0.596 ns |      1,861.22 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 2KB          |      1,864.47 ns |      0.834 ns |       0.651 ns |      1,864.44 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 2KB          |      1,865.25 ns |      0.500 ns |       0.443 ns |      1,865.30 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 2KB          |      1,980.10 ns |      1.991 ns |       1.662 ns |      1,980.04 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 2KB          |     11,953.91 ns |      5.933 ns |       4.632 ns |     11,955.40 ns |      56 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 4KB          |      1,784.83 ns |      0.753 ns |       0.668 ns |      1,784.96 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 4KB          |      2,032.80 ns |      0.491 ns |       0.435 ns |      2,032.80 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 4KB          |      2,098.13 ns |      0.546 ns |       0.484 ns |      2,098.10 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 4KB          |      2,157.62 ns |      2.789 ns |       2.472 ns |      2,158.14 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 4KB          |      3,786.17 ns |      1.160 ns |       0.906 ns |      3,785.98 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 4KB          |     24,163.63 ns |      9.066 ns |       7.571 ns |     24,164.33 ns |     168 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 6KB          |      4,100.91 ns |      1.525 ns |       1.273 ns |      4,101.05 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 6KB          |      6,281.13 ns |    111.996 ns |      93.521 ns |      6,302.89 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 6KB          |     16,076.80 ns |      9.734 ns |       8.128 ns |     16,076.65 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 6KB          |     18,638.09 ns |      8.951 ns |       7.474 ns |     18,639.53 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 6KB          |     19,397.57 ns |     29.495 ns |      26.146 ns |     19,388.68 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 6KB          |    172,910.57 ns |    321.971 ns |     268.860 ns |    172,821.13 ns |     280 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 8KB          |      3,405.72 ns |     53.959 ns |      47.834 ns |      3,383.62 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 8KB          |      3,783.83 ns |     38.442 ns |      35.959 ns |      3,768.85 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 8KB          |      4,004.01 ns |     29.782 ns |      26.401 ns |      3,997.10 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |      7,819.86 ns |    133.698 ns |     320.333 ns |      7,729.97 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |     20,997.50 ns |     12.719 ns |       9.930 ns |     21,000.52 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |     48,319.37 ns |    180.209 ns |     150.483 ns |     48,300.13 ns |     392 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10000B       |      4,832.51 ns |     30.304 ns |      28.346 ns |      4,825.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10000B       |      5,720.72 ns |     25.263 ns |      22.395 ns |      5,716.35 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10000B       |      5,884.29 ns |     28.474 ns |      26.634 ns |      5,876.77 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10000B       |      6,052.96 ns |      4.677 ns |       3.905 ns |      6,053.21 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10000B       |      9,384.31 ns |      2.767 ns |       2.311 ns |      9,384.82 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10000B       |     59,968.14 ns |     26.152 ns |      23.183 ns |     59,967.32 ns |     504 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 64KB         |     27,780.57 ns |     20.924 ns |      19.572 ns |     27,776.58 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 64KB         |     31,462.23 ns |     14.978 ns |      13.278 ns |     31,463.89 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 64KB         |     33,964.49 ns |      9.479 ns |       8.867 ns |     33,962.12 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 64KB         |     35,259.66 ns |    129.814 ns |     121.428 ns |     35,230.42 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 64KB         |     61,389.15 ns |     17.660 ns |      15.655 ns |     61,391.28 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 64KB         |    390,794.99 ns |    123.801 ns |     115.804 ns |    390,839.38 ns |    3528 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 100000B      |     43,187.72 ns |     15.659 ns |      13.881 ns |     43,192.58 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 100000B      |     52,849.21 ns |     24.032 ns |      21.303 ns |     52,843.74 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 100000B      |     78,451.88 ns |  1,461.716 ns |   1,848.603 ns |     78,623.58 ns |    3346 B |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 100000B      |     93,726.44 ns |     24.527 ns |      22.942 ns |     93,726.09 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 100000B      |    233,027.50 ns |     45.145 ns |      35.246 ns |    233,028.82 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 100000B      |    633,340.46 ns | 12,433.329 ns |  18,224.613 ns |    639,789.67 ns |    5432 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 128KB        |     24,278.53 ns |    349.581 ns |     326.999 ns |     24,216.51 ns |    3570 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 128KB        |     53,646.86 ns |    212.373 ns |     188.263 ns |     53,632.82 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 128KB        |     62,186.76 ns |    322.028 ns |     268.908 ns |     62,155.32 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        |     69,031.33 ns |  1,332.394 ns |   2,074.376 ns |     69,050.13 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        |    123,742.82 ns |    927.012 ns |     821.772 ns |    123,477.98 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        |    776,032.59 ns |  2,255.390 ns |   1,999.345 ns |    776,287.37 ns |    7112 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 256KB        |     40,169.71 ns |    724.804 ns |     677.983 ns |     39,764.54 ns |    4084 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 256KB        |    111,450.45 ns |     61.389 ns |      51.263 ns |    111,451.49 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 256KB        |    125,938.02 ns |     40.894 ns |      34.148 ns |    125,948.64 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 256KB        |    136,013.16 ns |     78.862 ns |      65.853 ns |    136,024.69 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 256KB        |    246,617.89 ns |     55.166 ns |      51.602 ns |    246,634.01 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 256KB        |  1,564,523.37 ns |    551.011 ns |     460.119 ns |  1,564,557.29 ns |   14280 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 512KB        |     83,440.95 ns |  4,745.789 ns |  13,993.067 ns |     81,090.95 ns |    3825 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 512KB        |    211,054.90 ns |  1,302.992 ns |   1,218.819 ns |    211,256.44 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 512KB        |    247,350.48 ns |    921.870 ns |     862.318 ns |    247,410.77 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 512KB        |    269,852.57 ns |     77.520 ns |      72.512 ns |    269,879.56 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 512KB        |    493,690.20 ns |    199.102 ns |     176.498 ns |    493,651.29 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 512KB        |  3,318,185.63 ns | 75,087.820 ns | 193,825.655 ns |  3,312,784.26 ns |   28616 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 1MB          |    107,360.50 ns |  1,395.169 ns |   1,165.030 ns |    107,424.03 ns |    3836 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 1MB          |    425,332.70 ns |  7,616.404 ns |  15,034.039 ns |    423,558.76 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 1MB          |    464,557.69 ns |  2,709.852 ns |   2,402.213 ns |    464,537.23 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1MB          |    511,040.59 ns |    138.869 ns |     115.962 ns |    511,062.62 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1MB          |  4,653,851.45 ns | 23,512.144 ns |  20,842.903 ns |  4,657,484.54 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1MB          | 28,254,115.89 ns | 36,312.989 ns |  28,350.793 ns | 28,254,079.44 ns |   54656 B |
|                                              |              |                  |               |                |                  |           |
| TryComputeHash · BLAKE3 · Blake3.Managed     | 10MB         |  1,322,782.95 ns | 99,950.691 ns | 275,293.251 ns |  1,318,678.85 ns |    3838 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native  | 10MB         |  4,252,471.89 ns |  4,789.077 ns |   4,245.392 ns |  4,252,173.34 ns |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed | 10MB         |  4,808,282.98 ns |  1,275.060 ns |   1,064.733 ns |  4,808,559.57 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 10MB         |  5,100,956.21 ns |  2,927.832 ns |   2,738.696 ns |  5,100,905.27 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 10MB         |  9,420,395.92 ns |  3,570.868 ns |   3,165.482 ns |  9,421,465.81 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 10MB         | 59,826,813.82 ns | 18,035.099 ns |  15,987.645 ns | 59,829,909.67 ns |  546840 B |