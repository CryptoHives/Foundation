| Description                                   | TestDataSize | Mean              | Error          | StdDev         | Median            | Code Size | Allocated |
|---------------------------------------------- |------------- |------------------:|---------------:|---------------:|------------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |          56.62 ns |       0.121 ns |       0.107 ns |          56.62 ns |   4,008 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |          57.16 ns |       0.112 ns |       0.105 ns |          57.14 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |          61.85 ns |       0.393 ns |       0.349 ns |          61.85 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |          62.44 ns |       0.147 ns |       0.131 ns |          62.41 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |          62.82 ns |       0.450 ns |       0.421 ns |          62.63 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |          62.86 ns |       0.227 ns |       0.213 ns |          62.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |          83.35 ns |       0.288 ns |       0.269 ns |          83.35 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4B           |         611.38 ns |       1.352 ns |       1.265 ns |         611.24 ns |  21,324 B |         - |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |          97.88 ns |       0.638 ns |       0.566 ns |          97.70 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |         103.23 ns |       0.175 ns |       0.155 ns |         103.19 ns |   4,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |         106.27 ns |       1.080 ns |       0.902 ns |         105.98 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |         119.64 ns |       1.715 ns |       1.520 ns |         119.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |         119.66 ns |       1.939 ns |       1.514 ns |         119.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |         119.89 ns |       2.330 ns |       2.493 ns |         118.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |         171.67 ns |       0.631 ns |       0.560 ns |         171.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100B         |       1,358.54 ns |       2.575 ns |       2.282 ns |       1,358.01 ns |  21,991 B |         - |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |          95.49 ns |       0.765 ns |       0.639 ns |          95.47 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |          99.65 ns |       0.420 ns |       0.393 ns |          99.68 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |         105.74 ns |       0.444 ns |       0.371 ns |         105.73 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |         118.27 ns |       0.803 ns |       0.670 ns |         118.27 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |         118.63 ns |       0.624 ns |       0.521 ns |         118.76 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |         118.85 ns |       0.483 ns |       0.403 ns |         118.84 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |         174.85 ns |       2.433 ns |       2.031 ns |         174.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128B         |       1,342.24 ns |       5.786 ns |       5.129 ns |       1,341.58 ns |  21,985 B |         - |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |         151.34 ns |       0.459 ns |       0.407 ns |         151.36 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |         155.59 ns |       3.098 ns |       6.186 ns |         152.88 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |         165.11 ns |       3.184 ns |       2.823 ns |         163.68 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |         173.05 ns |       1.940 ns |       1.720 ns |         172.72 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |         173.22 ns |       1.662 ns |       1.555 ns |         172.95 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |         175.46 ns |       2.671 ns |       2.498 ns |         175.06 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |         253.14 ns |       1.127 ns |       0.999 ns |         252.90 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 137B         |       1,984.65 ns |       4.747 ns |       4.208 ns |       1,983.29 ns |  21,984 B |         - |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |         757.48 ns |       3.288 ns |       2.745 ns |         757.00 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |         791.04 ns |       4.621 ns |       4.097 ns |         791.59 ns |   4,246 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |         825.15 ns |       4.069 ns |       3.607 ns |         824.02 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |         853.38 ns |       3.978 ns |       3.526 ns |         852.56 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |         854.54 ns |       2.912 ns |       2.273 ns |         854.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |         855.93 ns |       5.128 ns |       4.797 ns |         857.16 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        |       1,314.61 ns |       6.210 ns |       5.186 ns |       1,313.62 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1000B        |      10,516.42 ns |      37.085 ns |      32.875 ns |      10,514.62 ns |  22,003 B |         - |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |         756.84 ns |       4.361 ns |       3.405 ns |         756.48 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |         791.38 ns |       5.226 ns |       4.889 ns |         789.60 ns |   4,244 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |         819.82 ns |       2.554 ns |       2.264 ns |         819.38 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |         853.50 ns |       2.830 ns |       2.509 ns |         852.54 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |         853.79 ns |       2.924 ns |       2.592 ns |         853.85 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |         856.49 ns |       5.015 ns |       4.446 ns |         855.12 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          |       1,309.81 ns |       3.388 ns |       3.169 ns |       1,309.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1KB          |      10,018.25 ns |      45.547 ns |      38.034 ns |      10,009.67 ns |  22,012 B |         - |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |         864.71 ns |       5.073 ns |       4.236 ns |         863.46 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |         908.03 ns |       3.850 ns |       3.601 ns |         908.16 ns |   3,466 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |         961.79 ns |       5.842 ns |       4.878 ns |         961.45 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |         983.60 ns |       6.968 ns |       5.818 ns |         983.47 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |         985.40 ns |       4.608 ns |       3.848 ns |         985.58 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |         985.45 ns |       6.782 ns |       6.012 ns |         984.28 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        |       1,519.07 ns |       7.779 ns |       6.896 ns |       1,517.08 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1025B        |      11,258.09 ns |      28.179 ns |      24.980 ns |      11,255.03 ns |  22,313 B |      56 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |         793.37 ns |       3.943 ns |       3.292 ns |         793.26 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          |       1,228.46 ns |       7.108 ns |       5.549 ns |       1,228.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          |       1,231.52 ns |       8.478 ns |       7.930 ns |       1,230.19 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          |       1,643.90 ns |      12.043 ns |      10.676 ns |       1,644.91 ns |   3,465 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          |       1,760.69 ns |      27.807 ns |      24.650 ns |       1,748.24 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          |       1,782.80 ns |       7.499 ns |       6.648 ns |       1,782.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          |       2,743.09 ns |       4.720 ns |       4.184 ns |       2,742.99 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 2KB          |      20,425.93 ns |      43.542 ns |      38.599 ns |      20,422.93 ns |  22,232 B |      56 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4KB          |       1,043.57 ns |      18.783 ns |      38.791 ns |       1,025.30 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4KB          |       1,227.29 ns |      11.457 ns |      10.717 ns |       1,224.37 ns |   4,379 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4KB          |       1,337.06 ns |       9.059 ns |       8.031 ns |       1,334.51 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4KB          |       1,351.05 ns |       5.925 ns |       5.542 ns |       1,351.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4KB          |       3,528.60 ns |      20.190 ns |      17.898 ns |       3,527.26 ns |   6,558 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4KB          |       3,641.32 ns |      32.000 ns |      29.933 ns |       3,633.21 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4KB          |       5,588.79 ns |       6.295 ns |       5.889 ns |       5,587.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 4KB          |      42,189.72 ns |     131.102 ns |     116.218 ns |      42,169.85 ns |  22,230 B |     168 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 6KB          |       1,447.45 ns |      12.569 ns |      11.142 ns |       1,442.30 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 6KB          |       1,456.37 ns |      13.684 ns |      12.800 ns |       1,453.36 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 6KB          |       1,841.83 ns |      22.550 ns |      18.830 ns |       1,836.77 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 6KB          |       2,874.22 ns |      23.693 ns |      19.785 ns |       2,867.46 ns |   4,386 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 6KB          |       5,348.83 ns |      68.532 ns |      64.105 ns |       5,320.95 ns |   7,585 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 6KB          |       5,457.17 ns |      51.976 ns |      46.076 ns |       5,442.55 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 6KB          |       8,475.19 ns |      32.629 ns |      27.247 ns |       8,469.31 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 6KB          |      63,382.65 ns |     333.969 ns |     296.055 ns |      63,237.76 ns |  22,255 B |     280 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 8KB          |       1,189.20 ns |      18.363 ns |      16.278 ns |       1,183.77 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 8KB          |       1,422.68 ns |      10.207 ns |       8.523 ns |       1,424.68 ns |   4,372 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 8KB          |       1,450.52 ns |      10.319 ns |       8.057 ns |       1,447.80 ns |   6,418 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 8KB          |       1,555.41 ns |       9.364 ns |       7.820 ns |       1,552.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 8KB          |       1,563.86 ns |      19.826 ns |      17.575 ns |       1,563.24 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 8KB          |       7,294.55 ns |      74.452 ns |      66.000 ns |       7,266.95 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 8KB          |      11,328.53 ns |      36.867 ns |      32.682 ns |      11,332.17 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 8KB          |      83,660.04 ns |     274.547 ns |     243.378 ns |      83,561.40 ns |  22,255 B |     392 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10000B       |       2,615.69 ns |      37.111 ns |      32.898 ns |       2,607.34 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10000B       |       2,934.64 ns |      11.899 ns |       9.936 ns |       2,934.50 ns |   3,900 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10000B       |       3,035.02 ns |       8.711 ns |       6.801 ns |       3,034.47 ns |   7,768 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10000B       |       3,095.47 ns |      31.281 ns |      26.121 ns |       3,082.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10000B       |       3,212.97 ns |      58.710 ns |      80.363 ns |       3,174.92 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10000B       |       8,915.03 ns |      64.853 ns |      54.155 ns |       8,906.63 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10000B       |      13,831.75 ns |      25.020 ns |      20.893 ns |      13,824.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10000B       |     102,115.42 ns |     217.855 ns |     193.123 ns |     102,124.01 ns |  22,267 B |     504 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 64KB         |       7,266.89 ns |      38.435 ns |      35.952 ns |       7,257.03 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 64KB         |       8,791.32 ns |      51.465 ns |      42.975 ns |       8,800.29 ns |   8,628 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 64KB         |       9,869.44 ns |      50.825 ns |      45.055 ns |       9,870.64 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 64KB         |      10,370.17 ns |      65.944 ns |      61.684 ns |      10,364.37 ns |   4,622 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 64KB         |      11,752.37 ns |      80.633 ns |      75.424 ns |      11,754.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 64KB         |      58,240.61 ns |     165.724 ns |     138.387 ns |      58,242.00 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 64KB         |      90,727.95 ns |     262.595 ns |     219.279 ns |      90,643.46 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 64KB         |     662,599.42 ns |   2,255.335 ns |   2,109.641 ns |     661,733.79 ns |  22,258 B |    3528 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100000B      |       7,023.11 ns |      41.568 ns |      36.849 ns |       7,018.65 ns |   6,842 B |    3094 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100000B      |      12,326.73 ns |      37.078 ns |      30.962 ns |      12,334.48 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100000B      |      14,820.45 ns |      33.748 ns |      28.181 ns |      14,833.54 ns |   8,912 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100000B      |      17,208.09 ns |     167.360 ns |     139.754 ns |      17,177.86 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100000B      |      17,860.70 ns |      63.084 ns |      52.678 ns |      17,868.98 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100000B      |      89,006.35 ns |     698.264 ns |     583.082 ns |      88,859.33 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100000B      |     138,730.71 ns |     354.965 ns |     332.034 ns |     138,668.63 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 100000B      |   1,038,403.16 ns |   2,064.219 ns |   1,723.716 ns |   1,038,081.93 ns |  22,247 B |    5432 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128KB        |       8,008.11 ns |      65.231 ns |      61.017 ns |       7,992.56 ns |   6,793 B |    3284 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128KB        |      14,434.13 ns |      70.144 ns |      58.573 ns |      14,438.23 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128KB        |      18,821.39 ns |     155.242 ns |     145.214 ns |      18,790.48 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128KB        |      20,292.91 ns |      93.182 ns |      87.163 ns |      20,286.79 ns |   8,614 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128KB        |      22,102.59 ns |      76.827 ns |      71.864 ns |      22,105.92 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128KB        |     116,444.07 ns |     345.501 ns |     288.509 ns |     116,499.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128KB        |     181,398.30 ns |     789.482 ns |     699.855 ns |     181,066.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 128KB        |   1,358,816.93 ns |   2,231.923 ns |   1,863.757 ns |   1,358,442.38 ns |  22,258 B |    7112 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256KB        |      11,499.42 ns |      96.870 ns |      90.612 ns |      11,505.19 ns |   6,775 B |    4143 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256KB        |      28,649.90 ns |     109.709 ns |      85.653 ns |      28,651.55 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256KB        |      38,757.09 ns |     168.678 ns |     140.854 ns |      38,795.35 ns |   8,612 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256KB        |      40,261.67 ns |     279.937 ns |     261.854 ns |      40,207.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256KB        |      42,836.80 ns |     325.704 ns |     304.664 ns |      42,741.05 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256KB        |     233,744.37 ns |     473.690 ns |     395.553 ns |     233,752.95 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256KB        |     362,373.84 ns |     604.290 ns |     504.610 ns |     362,257.57 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 256KB        |   2,704,278.07 ns |   4,575.871 ns |   4,280.273 ns |   2,702,892.19 ns |  22,258 B |   14280 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 512KB        |      20,565.09 ns |     190.526 ns |     178.218 ns |      20,597.62 ns |   6,791 B |    4162 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 512KB        |      56,957.04 ns |     186.673 ns |     165.481 ns |      56,967.36 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 512KB        |      77,667.81 ns |     411.510 ns |     364.793 ns |      77,574.52 ns |   8,616 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 512KB        |      79,485.40 ns |     285.338 ns |     238.270 ns |      79,450.81 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 512KB        |      83,724.34 ns |     470.231 ns |     416.847 ns |      83,650.01 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 512KB        |     467,028.76 ns |   1,815.933 ns |   1,609.778 ns |     466,475.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 512KB        |     728,462.47 ns |   2,055.539 ns |   1,822.182 ns |     728,034.52 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 512KB        |   5,394,794.87 ns |  10,842.496 ns |   9,611.590 ns |   5,390,606.25 ns |  22,257 B |   28616 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1MB          |      32,352.08 ns |     261.278 ns |     218.179 ns |      32,265.50 ns |   6,792 B |    4015 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1MB          |     110,983.51 ns |     673.853 ns |     597.353 ns |     111,114.86 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1MB          |     136,654.51 ns |   1,751.246 ns |   1,462.370 ns |     136,250.10 ns |   8,949 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1MB          |     140,451.58 ns |     744.913 ns |     696.792 ns |     140,333.92 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1MB          |     160,708.57 ns |     734.887 ns |     613.664 ns |     160,639.15 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1MB          |     888,900.44 ns |   2,626.438 ns |   2,328.269 ns |     888,357.18 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1MB          |   1,384,474.19 ns |   1,903.706 ns |   1,589.681 ns |   1,384,276.17 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 1MB          |   9,946,324.58 ns |  41,270.283 ns |  38,604.248 ns |   9,932,407.81 ns |  22,253 B |   54656 B |
|                                               |              |                   |                |                |                   |           |           |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 10MB         |     323,594.78 ns |   2,242.339 ns |   1,987.775 ns |     323,466.94 ns |   6,774 B |    4056 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 10MB         |   1,107,243.15 ns |   3,312.488 ns |   2,766.077 ns |   1,107,860.94 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 10MB         |   1,362,036.12 ns |   4,697.104 ns |   4,163.860 ns |   1,362,123.05 ns |   8,894 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 10MB         |   1,397,729.04 ns |   5,150.204 ns |   4,817.504 ns |   1,397,000.78 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 10MB         |   1,593,730.65 ns |   5,568.662 ns |   4,650.085 ns |   1,593,075.20 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 10MB         |   8,882,630.73 ns |  30,296.259 ns |  28,339.140 ns |   8,881,398.44 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 10MB         |  13,852,218.10 ns |  20,095.123 ns |  15,688.950 ns |  13,854,337.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · BouncyCastle        | 10MB         | 100,764,978.57 ns | 278,518.288 ns | 246,899.208 ns | 100,668,650.00 ns |  22,366 B |  546840 B |