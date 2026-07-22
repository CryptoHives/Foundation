| Description                                   | TestDataSize | Mean        | Error     | StdDev    | Median      | Code Size | Allocated |
|---------------------------------------------- |------------- |------------:|----------:|----------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 4B           |    56.89 ns |  0.760 ns |  0.711 ns |    56.51 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 4B           |    60.94 ns |  0.347 ns |  0.308 ns |    60.83 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 4B           |    61.54 ns |  0.383 ns |  0.359 ns |    61.49 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 4B           |    61.82 ns |  0.823 ns |  0.770 ns |    61.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 4B           |    61.89 ns |  1.134 ns |  1.005 ns |    61.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 4B           |    76.01 ns |  0.771 ns |  0.721 ns |    75.83 ns |   5,115 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 4B           |   302.08 ns |  1.745 ns |  1.457 ns |   301.95 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 100B         |   103.52 ns |  2.029 ns |  2.639 ns |   102.93 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 100B         |   104.33 ns |  1.343 ns |  1.256 ns |   104.16 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 100B         |   107.69 ns |  1.241 ns |  1.100 ns |   107.72 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 100B         |   108.35 ns |  0.722 ns |  0.563 ns |   108.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 100B         |   108.44 ns |  0.984 ns |  0.872 ns |   108.19 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 100B         |   123.65 ns |  1.878 ns |  1.757 ns |   123.19 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 100B         |   600.68 ns |  9.797 ns |  8.685 ns |   597.37 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 128B         |    94.74 ns |  1.417 ns |  1.256 ns |    94.17 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 128B         |   104.73 ns |  0.777 ns |  0.727 ns |   104.55 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 128B         |   108.20 ns |  1.138 ns |  1.064 ns |   108.10 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 128B         |   108.59 ns |  2.083 ns |  1.948 ns |   108.42 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 128B         |   109.00 ns |  1.776 ns |  1.661 ns |   108.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 128B         |   118.59 ns |  1.553 ns |  1.377 ns |   118.24 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 128B         |   602.93 ns | 12.067 ns | 10.077 ns |   600.65 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 137B         |   157.60 ns |  3.163 ns |  5.197 ns |   157.41 ns |   3,529 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 137B         |   161.44 ns |  0.938 ns |  0.878 ns |   161.26 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 137B         |   164.80 ns |  2.535 ns |  2.117 ns |   165.28 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 137B         |   167.09 ns |  3.363 ns |  5.711 ns |   165.37 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 137B         |   168.01 ns |  3.319 ns |  5.265 ns |   166.50 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 137B         |   169.40 ns |  1.627 ns |  1.271 ns |   169.65 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 137B         |   906.00 ns | 16.622 ns | 24.364 ns |   896.31 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 256B         |   204.15 ns |  4.014 ns |  4.462 ns |   203.27 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 256B         |   204.71 ns |  3.986 ns |  5.322 ns |   203.72 ns |   3,520 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 256B         |   216.53 ns |  3.973 ns |  3.716 ns |   216.64 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 256B         |   222.53 ns |  4.457 ns |  6.533 ns |   222.23 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 256B         |   222.94 ns |  4.400 ns |  5.721 ns |   220.75 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 256B         |   225.82 ns |  4.391 ns |  6.436 ns |   225.11 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 256B         | 1,196.76 ns | 19.309 ns | 20.660 ns | 1,193.45 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1000B        |   766.91 ns | 10.056 ns |  7.851 ns |   769.06 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1000B        |   790.33 ns | 10.031 ns |  9.383 ns |   790.28 ns |   5,362 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1000B        |   821.35 ns |  3.309 ns |  3.095 ns |   820.60 ns |   3,522 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1000B        |   871.15 ns | 16.420 ns | 13.712 ns |   869.79 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1000B        |   876.42 ns | 17.384 ns | 33.493 ns |   875.54 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1000B        |   879.53 ns | 17.232 ns | 19.844 ns |   881.07 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1000B        | 4,687.24 ns | 93.694 ns | 87.642 ns | 4,669.15 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1KB          |   753.55 ns |  2.548 ns |  2.384 ns |   753.59 ns |     988 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1KB          |   786.57 ns |  9.473 ns |  8.861 ns |   782.02 ns |   5,360 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1KB          |   818.17 ns |  2.942 ns |  2.752 ns |   818.58 ns |   3,532 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1KB          |   841.30 ns |  3.004 ns |  2.810 ns |   840.91 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1KB          |   846.30 ns | 10.857 ns |  9.066 ns |   844.32 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1KB          |   855.57 ns | 14.635 ns | 12.974 ns |   856.40 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1KB          | 4,593.01 ns | 30.502 ns | 27.039 ns | 4,591.21 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 1025B        |   836.00 ns |  3.216 ns |  2.851 ns |   836.24 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 1025B        |   953.85 ns |  4.788 ns |  4.479 ns |   953.20 ns |   4,879 B |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 1025B        |   959.29 ns |  7.083 ns |  6.625 ns |   957.60 ns |  11,359 B |      56 B |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 1025B        |   977.08 ns |  3.728 ns |  3.305 ns |   976.70 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 1025B        |   978.86 ns |  5.377 ns |  4.767 ns |   978.67 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 1025B        |   981.05 ns |  5.469 ns |  5.115 ns |   981.65 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 1025B        | 5,195.76 ns | 27.701 ns | 25.912 ns | 5,193.43 ns |        NA |         - |
|                                               |              |             |           |           |             |           |           |
| TryComputeHash · BLAKE3 · Blake3.NET-Native   | 2KB          |   781.84 ns |  3.989 ns |  3.731 ns |   781.65 ns |     989 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX512F | 2KB          | 1,343.51 ns | 31.178 ns | 91.930 ns | 1,297.39 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-AVX2    | 2KB          | 1,557.57 ns | 30.650 ns | 51.208 ns | 1,554.25 ns |        NA |         - |
| TryComputeHash · BLAKE3 · Blake3.Managed      | 2KB          | 1,666.73 ns |  4.819 ns |  4.272 ns | 1,666.02 ns |  11,378 B |      56 B |
| TryComputeHash · BLAKE3 · Blake3.NET-Managed  | 2KB          | 1,758.76 ns | 32.266 ns | 28.603 ns | 1,748.18 ns |   4,873 B |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Ssse3   | 2KB          | 1,841.94 ns | 35.737 ns | 56.683 ns | 1,834.59 ns |        NA |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar  | 2KB          | 9,501.94 ns | 65.633 ns | 51.242 ns | 9,491.85 ns |        NA |         - |