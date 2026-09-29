| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |         97.79 ns |       0.121 ns |       0.108 ns |   5,573 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        107.29 ns |       0.476 ns |       0.446 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        113.53 ns |       0.737 ns |       0.689 ns |   7,264 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        153.27 ns |       0.942 ns |       0.882 ns |   8,188 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        617.67 ns |       5.385 ns |       5.037 ns |   8,652 B |     1000 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |         91.14 ns |       0.270 ns |       0.252 ns |   5,563 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        114.25 ns |       0.552 ns |       0.517 ns |   7,262 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        115.80 ns |       0.420 ns |       0.393 ns |   6,239 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        152.40 ns |       0.947 ns |       0.885 ns |   8,185 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        597.50 ns |       6.474 ns |       6.055 ns |   8,641 B |     1056 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |         96.84 ns |       0.162 ns |       0.151 ns |   5,568 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        107.56 ns |       0.449 ns |       0.420 ns |   6,242 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        113.18 ns |       0.826 ns |       0.773 ns |   7,264 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        152.52 ns |       0.823 ns |       0.770 ns |   8,181 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        597.49 ns |       5.180 ns |       4.845 ns |   8,652 B |     1064 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |         91.18 ns |       0.178 ns |       0.167 ns |   5,582 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        106.37 ns |       0.410 ns |       0.384 ns |   6,282 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        112.62 ns |       0.709 ns |       0.663 ns |   7,264 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        149.95 ns |       1.199 ns |       1.122 ns |   8,197 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        567.99 ns |       6.202 ns |       5.801 ns |   8,679 B |     1120 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        181.84 ns |       0.322 ns |       0.301 ns |   5,555 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        196.21 ns |       0.533 ns |       0.499 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        208.79 ns |       0.586 ns |       0.548 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        294.36 ns |       1.087 ns |       1.017 ns |   8,170 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,053.21 ns |      14.177 ns |      13.261 ns |   9,446 B |     1128 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        683.59 ns |       1.188 ns |       0.992 ns |   5,570 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        732.75 ns |       0.670 ns |       0.594 ns |   6,273 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        785.50 ns |       0.930 ns |       0.870 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,126.24 ns |       7.598 ns |       7.107 ns |   8,429 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      3,544.21 ns |      37.256 ns |      34.849 ns |   9,354 B |     2016 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |        775.71 ns |       1.066 ns |       0.997 ns |   5,566 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        812.37 ns |       0.397 ns |       0.352 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        881.57 ns |       0.532 ns |       0.498 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,267.93 ns |       8.486 ns |       7.938 ns |   8,181 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      3,992.76 ns |      31.813 ns |      24.838 ns |   9,391 B |     2024 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      5,436.39 ns |       8.739 ns |       8.174 ns |   5,818 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,626.67 ns |       6.060 ns |       5.668 ns |   6,517 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,180.04 ns |       6.012 ns |       5.330 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      8,869.95 ns |      68.090 ns |      63.692 ns |   8,443 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     27,111.54 ns |     246.148 ns |     230.247 ns |   9,374 B |     9184 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     43,413.81 ns |      50.850 ns |      47.565 ns |   5,818 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     44,895.90 ns |      29.531 ns |      27.623 ns |   6,516 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     49,453.71 ns |      28.056 ns |      26.244 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     71,395.99 ns |     518.267 ns |     484.787 ns |   8,440 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    215,782.61 ns |   1,823.276 ns |   1,705.493 ns |   9,389 B |    66528 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |     86,848.30 ns |     107.054 ns |     100.139 ns |   5,818 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     89,719.47 ns |      83.963 ns |      78.539 ns |   6,516 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |     98,769.38 ns |      97.856 ns |      91.534 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    142,493.31 ns |   1,171.728 ns |   1,096.035 ns |   8,422 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    464,627.17 ns |   3,992.961 ns |   3,735.018 ns |   9,409 B |   132078 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    663,665.81 ns |     873.923 ns |     817.468 ns |   5,545 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    687,209.04 ns |     538.359 ns |     503.581 ns |   6,228 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    752,983.79 ns |     519.731 ns |     486.157 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,087,742.62 ns |   8,610.018 ns |   8,053.816 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,361,713.90 ns |  12,339.879 ns |  10,938.981 ns |   9,416 B |  1001804 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  6,636,471.56 ns |   9,529.918 ns |   8,914.291 ns |   5,825 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,869,052.86 ns |   4,647.299 ns |   4,347.087 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  7,560,075.36 ns |   4,758.643 ns |   4,451.237 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 10,901,601.35 ns |  87,126.084 ns |  81,497.793 ns |   8,451 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 33,593,367.11 ns | 339,235.334 ns | 317,320.942 ns |   9,411 B | 10001096 B |