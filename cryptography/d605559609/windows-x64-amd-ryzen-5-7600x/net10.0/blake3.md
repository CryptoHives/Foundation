| Description                                   | TestDataSize | Mean             | Error          | StdDev         | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |         55.64 ns |       0.111 ns |       0.104 ns |   4,012 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |         56.44 ns |       0.234 ns |       0.207 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |         61.61 ns |       0.237 ns |       0.222 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |         61.71 ns |       0.210 ns |       0.197 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |         61.88 ns |       0.228 ns |       0.214 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |         61.97 ns |       0.237 ns |       0.198 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |         83.19 ns |       0.439 ns |       0.389 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |        608.33 ns |       1.622 ns |       1.355 ns |  21,324 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |         98.90 ns |       1.411 ns |       1.178 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |        101.72 ns |       0.196 ns |       0.173 ns |   4,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |        106.62 ns |       0.597 ns |       0.529 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |        107.51 ns |       1.106 ns |       0.981 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |        107.64 ns |       1.221 ns |       1.082 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |        108.06 ns |       0.769 ns |       0.682 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |        171.75 ns |       2.065 ns |       1.612 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |      1,314.00 ns |       5.442 ns |       5.090 ns |  22,001 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |         94.38 ns |       0.395 ns |       0.350 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |         98.61 ns |       0.226 ns |       0.176 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |        105.96 ns |       0.519 ns |       0.433 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |        106.74 ns |       0.440 ns |       0.412 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |        106.82 ns |       0.388 ns |       0.303 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |        107.15 ns |       0.820 ns |       0.726 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |        171.17 ns |       1.445 ns |       1.419 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |      1,336.20 ns |      10.748 ns |       8.391 ns |  21,996 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |        149.06 ns |       0.631 ns |       0.590 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |        150.07 ns |       1.080 ns |       1.010 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |        159.37 ns |       1.641 ns |       1.454 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |        159.87 ns |       0.899 ns |       0.751 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |        160.92 ns |       2.686 ns |       2.381 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |        164.42 ns |       1.455 ns |       1.215 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |        251.63 ns |       1.310 ns |       1.023 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |      2,001.74 ns |      30.468 ns |      28.500 ns |  21,985 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |        758.57 ns |       9.266 ns |       7.738 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |        798.59 ns |       4.869 ns |       4.316 ns |   4,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |        824.33 ns |       3.685 ns |       3.266 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |        842.85 ns |       2.644 ns |       2.064 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |        843.44 ns |       4.054 ns |       3.792 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |        861.74 ns |      16.329 ns |      24.440 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |      1,304.61 ns |       6.052 ns |       5.365 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |     10,387.21 ns |      50.189 ns |      46.947 ns |  22,003 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |        764.90 ns |      14.852 ns |      19.827 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |        802.13 ns |       5.588 ns |       4.363 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |        818.99 ns |       3.682 ns |       3.264 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |        842.86 ns |       3.884 ns |       3.443 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |        846.96 ns |      14.099 ns |      11.773 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |        854.98 ns |       2.696 ns |       2.251 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |      1,303.37 ns |       6.820 ns |       6.379 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      9,998.94 ns |      16.889 ns |      14.972 ns |  22,012 B |         - |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |        830.46 ns |       1.702 ns |       1.509 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |        902.82 ns |      13.754 ns |      12.865 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |        958.77 ns |       8.600 ns |       6.714 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |        980.14 ns |       2.782 ns |       2.323 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |        982.06 ns |       3.458 ns |       3.065 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |        983.59 ns |       6.029 ns |       5.034 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |      1,512.07 ns |      29.544 ns |      23.066 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |     11,321.29 ns |      21.519 ns |      19.076 ns |  22,329 B |      56 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |        783.93 ns |       2.549 ns |       2.384 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |      1,221.40 ns |       5.393 ns |       4.780 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |      1,225.05 ns |      12.604 ns |      10.525 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |      1,656.28 ns |      14.123 ns |      12.520 ns |   3,465 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |      1,736.21 ns |       3.959 ns |       3.306 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |      1,766.61 ns |       6.740 ns |       5.628 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |      2,723.80 ns |      11.048 ns |       9.225 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |     20,073.63 ns |     100.150 ns |      83.630 ns |  22,232 B |      56 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |      1,018.71 ns |       6.655 ns |       5.900 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |      1,227.17 ns |       6.264 ns |       4.890 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |      1,322.20 ns |       5.647 ns |       4.715 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |      1,324.87 ns |       7.573 ns |       6.324 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |      1,325.46 ns |       5.366 ns |       4.481 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |      3,496.38 ns |      11.872 ns |      10.524 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |      5,537.48 ns |      16.622 ns |      13.880 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |     42,888.41 ns |      91.697 ns |      81.287 ns |  22,233 B |     168 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |      1,431.99 ns |       5.691 ns |       4.752 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |      1,435.09 ns |      13.410 ns |      10.470 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |      1,821.88 ns |       8.142 ns |       6.357 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |      2,866.06 ns |      34.126 ns |      28.497 ns |   4,391 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |      3,115.92 ns |       7.860 ns |       6.563 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |      5,277.83 ns |      26.822 ns |      20.940 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |      8,377.39 ns |      19.375 ns |      17.176 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |     61,084.86 ns |     103.499 ns |      91.749 ns |  22,247 B |     280 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |      1,169.04 ns |       7.132 ns |       6.671 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |      1,439.82 ns |      11.920 ns |       9.953 ns |   6,420 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |      1,552.60 ns |      12.274 ns |      10.249 ns |   4,369 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |      1,553.38 ns |      10.874 ns |       8.490 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |      1,570.29 ns |      18.255 ns |      15.244 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |      2,662.99 ns |      11.074 ns |       8.646 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |     11,255.94 ns |     221.861 ns |     173.214 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |     81,788.61 ns |     255.291 ns |     213.179 ns |  22,243 B |     392 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |      2,581.97 ns |      35.066 ns |      27.378 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |      2,948.98 ns |      44.489 ns |      37.151 ns |   3,902 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |      3,049.89 ns |      12.498 ns |      11.079 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |      3,070.16 ns |      23.574 ns |      18.405 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |      3,120.81 ns |      15.004 ns |      12.529 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |      4,296.28 ns |      18.211 ns |      17.035 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |     13,736.12 ns |      62.317 ns |      52.037 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |    102,655.82 ns |   1,624.444 ns |   1,440.028 ns |  22,244 B |     504 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |      7,230.74 ns |      17.667 ns |      13.793 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |      8,830.23 ns |      31.931 ns |      26.664 ns |   8,626 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |     10,319.18 ns |     173.918 ns |     135.783 ns |   4,622 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |     10,639.43 ns |      52.511 ns |      43.849 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |     11,774.70 ns |      30.696 ns |      25.633 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |     21,643.07 ns |     399.155 ns |     443.659 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |     89,974.69 ns |     326.706 ns |     255.071 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |    669,522.81 ns |   1,510.883 ns |   1,339.359 ns |  22,258 B |    3528 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |      6,703.14 ns |      28.761 ns |      26.903 ns |   6,827 B |    3120 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |     12,282.37 ns |      48.523 ns |      43.015 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |     14,886.68 ns |     296.237 ns |     231.282 ns |   8,941 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |     15,284.82 ns |     139.851 ns |     116.782 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |     17,848.44 ns |     139.955 ns |     109.268 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |     32,021.69 ns |     127.429 ns |     119.197 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |    137,995.45 ns |   1,768.340 ns |   1,380.604 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |  1,023,634.04 ns |   2,088.249 ns |   1,743.783 ns |  22,247 B |    5432 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |      7,597.20 ns |      28.261 ns |      26.436 ns |   6,799 B |    3321 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |     14,498.78 ns |     157.520 ns |     147.344 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |     17,545.25 ns |     159.707 ns |     149.390 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |     18,918.30 ns |      95.932 ns |      80.107 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |     22,177.40 ns |      87.118 ns |      77.228 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |     41,436.15 ns |     559.835 ns |     437.082 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |    180,769.10 ns |     665.141 ns |     622.173 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |  1,344,068.55 ns |   3,421.920 ns |   3,033.443 ns |  22,258 B |    7112 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |     10,979.86 ns |      38.515 ns |      32.162 ns |   6,779 B |    4194 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |     28,678.41 ns |      67.653 ns |      52.819 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |     35,021.27 ns |     391.306 ns |     326.758 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |     40,061.50 ns |     280.888 ns |     248.999 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |     42,971.31 ns |     437.802 ns |     365.584 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |     80,931.72 ns |     290.315 ns |     271.561 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |    360,501.90 ns |   1,508.163 ns |   1,259.384 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |  2,650,216.55 ns |  10,653.527 ns |   9,444.074 ns |  22,253 B |   14280 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |     19,964.65 ns |     316.342 ns |     280.429 ns |   6,782 B |    4185 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |     57,512.94 ns |     233.229 ns |     206.751 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |     69,644.48 ns |     308.535 ns |     288.604 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |     72,451.41 ns |     298.994 ns |     249.674 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |     85,959.71 ns |   1,700.800 ns |   2,088.735 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |    160,437.74 ns |     489.684 ns |     458.050 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |    720,476.31 ns |   3,162.117 ns |   2,640.511 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |  5,318,436.72 ns |  80,736.287 ns |  63,033.582 ns |  22,248 B |   28616 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |     34,098.08 ns |     667.282 ns |     956.997 ns |   6,773 B |    4024 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |    110,928.34 ns |     507.532 ns |     396.248 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |    135,104.25 ns |     850.604 ns |     795.656 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |    138,413.67 ns |     453.970 ns |     424.644 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |    158,865.48 ns |     683.084 ns |     533.307 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |    305,332.17 ns |   1,429.661 ns |   1,193.832 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |  1,377,271.66 ns |   3,806.550 ns |   3,178.641 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |  9,772,858.04 ns |  41,255.204 ns |  36,571.664 ns |  22,248 B |   54656 B |
|                                               |              |                  |                |                |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |    325,355.66 ns |   1,602.394 ns |   1,338.071 ns |   6,774 B |    4055 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |  1,111,375.27 ns |   5,383.989 ns |   4,495.875 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |  1,379,466.87 ns |  10,476.036 ns |  10,288.869 ns |   8,894 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |  1,411,170.67 ns |  20,129.129 ns |  15,715.500 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |  1,600,541.09 ns |   5,999.565 ns |   5,318.458 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |  3,056,335.51 ns |  27,791.744 ns |  21,697.966 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         | 13,774,955.47 ns |  50,451.651 ns |  44,724.074 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 98,590,501.19 ns | 370,066.709 ns | 328,054.499 ns |  21,268 B |  546840 B |