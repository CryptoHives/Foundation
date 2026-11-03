| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |         97.67 ns |       0.225 ns |       0.199 ns |         97.64 ns |   5,576 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        107.44 ns |       0.358 ns |       0.318 ns |        107.35 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        113.71 ns |       0.643 ns |       0.602 ns |        113.36 ns |   7,264 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        153.62 ns |       0.759 ns |       0.710 ns |        153.36 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        617.23 ns |       8.113 ns |       7.589 ns |        614.65 ns |   8,649 B |     1000 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |         89.83 ns |       0.338 ns |       0.317 ns |         89.76 ns |   5,553 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        106.21 ns |       0.551 ns |       0.515 ns |        106.10 ns |   6,239 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        113.07 ns |       0.489 ns |       0.457 ns |        112.98 ns |   7,262 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        150.80 ns |       0.881 ns |       0.824 ns |        150.58 ns |   8,168 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        609.53 ns |       5.611 ns |       5.248 ns |        611.88 ns |   8,638 B |     1056 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |         95.35 ns |       0.211 ns |       0.197 ns |         95.28 ns |   5,558 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        108.17 ns |       1.222 ns |       1.143 ns |        107.87 ns |   6,242 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        114.31 ns |       1.299 ns |       1.215 ns |        114.07 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        157.26 ns |       3.161 ns |       7.813 ns |        153.91 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        602.70 ns |       6.647 ns |       6.217 ns |        602.78 ns |   8,662 B |     1064 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |         90.48 ns |       0.742 ns |       0.658 ns |         90.37 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        106.78 ns |       0.447 ns |       0.418 ns |        106.74 ns |   6,282 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        115.00 ns |       1.273 ns |       1.128 ns |        114.78 ns |   7,262 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        151.92 ns |       1.761 ns |       1.561 ns |        151.93 ns |   8,175 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        575.03 ns |       8.703 ns |       8.141 ns |        575.27 ns |   8,635 B |     1120 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        182.98 ns |       0.849 ns |       0.794 ns |        182.86 ns |   5,564 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        195.69 ns |       0.478 ns |       0.447 ns |        195.72 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        209.22 ns |       0.431 ns |       0.403 ns |        209.28 ns |   7,264 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        297.30 ns |       2.608 ns |       2.440 ns |        297.10 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,119.12 ns |       8.371 ns |       7.830 ns |      1,119.55 ns |   9,490 B |     1128 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        685.59 ns |       1.166 ns |       1.090 ns |        685.25 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        720.14 ns |       1.006 ns |       0.941 ns |        719.88 ns |   6,274 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        785.86 ns |       1.298 ns |       1.215 ns |        785.44 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,125.21 ns |       8.056 ns |       7.535 ns |      1,123.47 ns |   8,175 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      3,568.20 ns |      14.505 ns |      11.325 ns |      3,564.53 ns |   9,347 B |     2016 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |        774.19 ns |       1.116 ns |       0.989 ns |        774.63 ns |   5,564 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        815.62 ns |       5.117 ns |       4.787 ns |        813.05 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        889.85 ns |       1.218 ns |       1.079 ns |        889.87 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,284.59 ns |      16.247 ns |      14.402 ns |      1,281.21 ns |   8,172 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      4,116.71 ns |      70.553 ns |      65.995 ns |      4,100.65 ns |   9,384 B |     2024 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      5,432.80 ns |       3.632 ns |       3.220 ns |      5,432.70 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,640.75 ns |       5.593 ns |       5.232 ns |      5,638.74 ns |   6,517 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,180.63 ns |       6.885 ns |       6.441 ns |      6,180.11 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      8,894.87 ns |      64.226 ns |      60.077 ns |      8,897.19 ns |   8,182 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     27,319.83 ns |     161.117 ns |     150.709 ns |     27,305.31 ns |   9,394 B |     9184 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     43,418.54 ns |      55.171 ns |      51.607 ns |     43,414.11 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     44,871.94 ns |      43.258 ns |      40.464 ns |     44,879.23 ns |   6,516 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     49,482.22 ns |      30.376 ns |      28.414 ns |     49,483.11 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     70,983.04 ns |     402.740 ns |     376.723 ns |     70,867.58 ns |   8,429 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    217,523.89 ns |     920.430 ns |     860.970 ns |    217,251.20 ns |   9,385 B |    66528 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |     86,763.35 ns |      91.798 ns |      81.376 ns |     86,770.37 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     89,654.24 ns |      82.374 ns |      73.022 ns |     89,656.88 ns |   6,516 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |     98,972.80 ns |     110.214 ns |      97.701 ns |     98,941.12 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    142,395.55 ns |     657.809 ns |     615.315 ns |    142,395.04 ns |   8,418 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    502,398.07 ns |   3,768.720 ns |   3,525.263 ns |    501,531.05 ns |   9,366 B |   132078 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    664,008.03 ns |     849.163 ns |     794.308 ns |    663,943.26 ns |   5,547 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    684,141.63 ns |     644.451 ns |     602.819 ns |    683,942.09 ns |   6,237 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    755,551.06 ns |     839.850 ns |     744.505 ns |    755,310.30 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,088,358.62 ns |   5,739.437 ns |   5,368.673 ns |  1,085,483.98 ns |   8,169 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,353,097.03 ns |  17,582.609 ns |  16,446.783 ns |  3,353,630.86 ns |   9,413 B |  1001823 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  6,628,242.69 ns |   7,373.902 ns |   6,536.772 ns |  6,626,816.41 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,847,976.95 ns |   2,476.826 ns |   1,933.743 ns |  6,848,284.77 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  7,555,604.74 ns |   3,962.785 ns |   3,512.906 ns |  7,555,540.23 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 10,874,689.58 ns |  56,833.466 ns |  53,162.060 ns | 10,848,467.19 ns |   8,436 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 33,449,526.67 ns | 283,268.399 ns | 264,969.437 ns | 33,360,946.67 ns |   9,408 B | 10001096 B |