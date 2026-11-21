| Description                                       | TestDataSize | Mean            | Error        | StdDev       | Code Size | Allocated  |
|-------------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |        136.4 ns |      0.52 ns |      0.48 ns |  15,113 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        152.7 ns |      0.78 ns |      0.73 ns |  14,817 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        155.9 ns |      0.37 ns |      0.33 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        215.5 ns |      0.51 ns |      0.48 ns |  10,813 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |      1,249.9 ns |      2.40 ns |      2.13 ns |  20,174 B |      992 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |        131.5 ns |      0.65 ns |      0.61 ns |   8,770 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        151.6 ns |      0.54 ns |      0.50 ns |  14,619 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        156.2 ns |      0.41 ns |      0.39 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        215.7 ns |      0.61 ns |      0.57 ns |  10,805 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |      1,109.1 ns |      4.35 ns |      3.40 ns |  19,846 B |     1048 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |        134.9 ns |      0.52 ns |      0.48 ns |  15,105 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        151.8 ns |      0.40 ns |      0.38 ns |  14,619 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        156.3 ns |      0.34 ns |      0.32 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        215.6 ns |      0.50 ns |      0.47 ns |  17,140 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |      1,105.3 ns |      3.41 ns |      3.19 ns |  18,329 B |     1056 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |        126.6 ns |      0.36 ns |      0.34 ns |  15,361 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        149.7 ns |      0.62 ns |      0.58 ns |   8,564 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        157.9 ns |      0.31 ns |      0.29 ns |  16,214 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        210.2 ns |      0.49 ns |      0.46 ns |  11,061 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        990.2 ns |      0.70 ns |      0.59 ns |  20,061 B |     1112 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        254.6 ns |      0.47 ns |      0.44 ns |  15,122 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        270.5 ns |      1.14 ns |      1.06 ns |   8,292 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        274.9 ns |      0.78 ns |      0.73 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        415.2 ns |      0.51 ns |      0.48 ns |  17,157 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,956.9 ns |      2.39 ns |      2.12 ns |  14,433 B |     1120 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        930.4 ns |      1.78 ns |      1.67 ns |  15,355 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        948.2 ns |      5.47 ns |      5.12 ns |  15,083 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        985.9 ns |      3.99 ns |      3.73 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,641.6 ns |      3.16 ns |      2.96 ns |  17,580 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      5,925.2 ns |      3.97 ns |      3.71 ns |  20,816 B |     2008 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |      1,057.6 ns |      6.16 ns |      5.76 ns |  14,811 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |      1,070.9 ns |      5.39 ns |      5.04 ns |  15,312 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |      1,087.2 ns |      3.28 ns |      3.07 ns |  16,214 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,844.3 ns |      4.16 ns |      3.89 ns |  10,822 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      6,831.0 ns |      4.89 ns |      4.34 ns |  14,291 B |     2016 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      7,262.8 ns |     20.89 ns |     19.54 ns |   8,558 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      7,322.2 ns |     12.13 ns |     11.35 ns |  15,355 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      7,506.8 ns |      8.48 ns |      7.93 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |     12,686.9 ns |     17.45 ns |     16.32 ns |  17,580 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     45,055.4 ns |     40.61 ns |     36.00 ns |  21,727 B |     9176 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     58,040.6 ns |    179.56 ns |    167.96 ns |  14,893 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     59,023.8 ns |    135.95 ns |    127.16 ns |  15,369 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     60,802.9 ns |     75.45 ns |     70.57 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |    101,435.2 ns |     95.72 ns |     89.54 ns |  11,069 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    356,304.3 ns |    152.78 ns |    119.28 ns |  22,375 B |    66520 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |    115,816.7 ns |    475.10 ns |    444.41 ns |  14,893 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |    119,242.1 ns |    567.03 ns |    530.40 ns |  15,369 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    122,269.5 ns |    150.30 ns |    140.59 ns |  16,024 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    202,489.4 ns |    535.12 ns |    500.55 ns |  11,069 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    782,557.7 ns |    402.92 ns |    336.46 ns |  21,055 B |   132109 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    884,543.3 ns |  1,593.52 ns |  1,490.58 ns |  14,618 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    903,619.3 ns |    955.91 ns |    894.15 ns |  15,121 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    937,149.1 ns |  1,256.27 ns |  1,113.65 ns |   9,689 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,557,200.5 ns |  2,987.67 ns |  2,794.67 ns |  17,156 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  5,553,649.2 ns |  3,371.14 ns |  3,153.36 ns |  21,106 B |  1001725 B |
|                                                   |              |                 |              |              |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  8,958,982.4 ns | 63,047.29 ns | 58,974.48 ns |  15,085 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  9,188,518.8 ns | 53,040.80 ns | 49,614.40 ns |  15,362 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  9,472,577.9 ns | 17,768.26 ns | 16,620.44 ns |  16,026 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 15,604,932.5 ns | 68,491.33 ns | 64,066.84 ns |  11,062 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 55,522,193.7 ns | 27,696.88 ns | 24,552.57 ns |  20,784 B | 10001267 B |