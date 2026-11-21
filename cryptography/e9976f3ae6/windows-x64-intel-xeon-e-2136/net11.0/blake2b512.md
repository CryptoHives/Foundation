| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Code Size | Allocated  |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |        137.1 ns |      0.35 ns |      0.33 ns |  15,303 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        153.0 ns |      0.60 ns |      0.56 ns |   8,292 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        160.5 ns |      0.29 ns |      0.24 ns |  16,214 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        216.9 ns |      1.42 ns |      1.33 ns |  17,148 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |      1,287.5 ns |      1.90 ns |      1.69 ns |  13,714 B |     1088 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |        131.8 ns |      0.25 ns |      0.24 ns |  15,295 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        151.0 ns |      0.60 ns |      0.56 ns |   8,284 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        163.1 ns |      0.33 ns |      0.31 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        216.5 ns |      0.25 ns |      0.23 ns |  17,140 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |      1,165.4 ns |      2.68 ns |      2.38 ns |  14,124 B |     1144 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |        136.6 ns |      0.29 ns |      0.27 ns |   8,770 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        151.8 ns |      0.83 ns |      0.78 ns |  14,619 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        161.6 ns |      0.41 ns |      0.39 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        216.9 ns |      0.56 ns |      0.52 ns |  17,140 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |      1,144.0 ns |      1.49 ns |      1.32 ns |  17,489 B |     1152 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |        128.7 ns |      0.47 ns |      0.44 ns |  15,551 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        149.8 ns |      0.49 ns |      0.46 ns |  14,899 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        162.0 ns |      0.16 ns |      0.15 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        209.7 ns |      0.26 ns |      0.24 ns |  17,396 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |      1,033.2 ns |      1.59 ns |      1.49 ns |  52,242 B |     1208 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        256.1 ns |      1.34 ns |      1.26 ns |  15,122 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        270.4 ns |      1.03 ns |      0.96 ns |   8,292 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        279.7 ns |      0.98 ns |      0.92 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        417.4 ns |      1.14 ns |      1.07 ns |  17,157 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,996.4 ns |      7.55 ns |      6.69 ns |  20,897 B |     1216 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        919.5 ns |      4.49 ns |      4.20 ns |  15,355 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        946.2 ns |      1.96 ns |      1.83 ns |  14,893 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        976.2 ns |      5.04 ns |      4.71 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,643.3 ns |      1.96 ns |      1.83 ns |  17,580 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      5,920.4 ns |      6.41 ns |      6.00 ns |  17,439 B |     2104 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |      1,044.3 ns |      3.31 ns |      3.10 ns |  15,312 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |      1,058.4 ns |      6.13 ns |      5.73 ns |  14,811 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |      1,102.1 ns |      3.90 ns |      3.65 ns |  16,214 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,845.1 ns |      1.65 ns |      1.46 ns |  17,157 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      6,941.1 ns |     11.34 ns |     10.61 ns |  14,395 B |     2112 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      7,291.1 ns |     23.27 ns |     21.76 ns |  15,083 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      7,334.2 ns |     27.10 ns |     25.35 ns |  15,545 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      7,556.1 ns |      8.37 ns |      7.83 ns |  16,214 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |     12,684.6 ns |     27.41 ns |     24.30 ns |  11,055 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     44,868.7 ns |     39.68 ns |     35.17 ns |  20,853 B |     9272 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     58,161.3 ns |    139.91 ns |    130.87 ns |  14,893 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     58,621.6 ns |    131.04 ns |    122.58 ns |  15,559 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     60,773.9 ns |    146.72 ns |    137.25 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |    102,005.2 ns |     58.45 ns |     51.81 ns |  11,069 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    356,916.9 ns |    529.79 ns |    495.57 ns |  14,919 B |    66616 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |    116,077.9 ns |    562.39 ns |    526.06 ns |  16,463 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    120,169.8 ns |     54.49 ns |     45.50 ns |  16,214 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |    120,853.5 ns |    401.24 ns |    375.32 ns |   9,034 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    202,594.2 ns |    334.10 ns |    312.52 ns |  17,404 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    784,926.2 ns |    702.56 ns |    657.17 ns |  14,357 B |   132205 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    888,386.4 ns |  1,889.64 ns |  1,767.57 ns |   8,282 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    902,759.8 ns |  1,274.00 ns |  1,191.70 ns |  15,121 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    937,580.9 ns |  1,237.22 ns |  1,157.30 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,548,978.3 ns |  2,754.75 ns |  2,576.80 ns |  17,156 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  5,523,599.4 ns |  2,969.75 ns |  2,777.91 ns |  14,547 B |  1002128 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  8,964,536.8 ns | 47,945.12 ns | 44,847.90 ns |  10,130 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  9,207,592.6 ns | 34,520.16 ns | 32,290.18 ns |   9,027 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  9,289,397.1 ns |  8,074.90 ns |  6,304.35 ns |  16,026 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 15,627,178.8 ns | 15,962.08 ns | 14,930.94 ns |  11,062 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 55,718,246.7 ns | 41,432.49 ns | 38,755.97 ns |  21,718 B | 10001363 B |