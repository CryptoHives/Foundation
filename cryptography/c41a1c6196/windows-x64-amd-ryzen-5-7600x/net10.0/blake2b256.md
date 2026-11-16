| Description                                       | TestDataSize | Mean             | Error          | StdDev           | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|-----------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 4B           |         96.95 ns |       0.069 ns |         0.065 ns |   5,563 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |        105.75 ns |       0.171 ns |         0.152 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        113.58 ns |       0.179 ns |         0.167 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |        153.46 ns |       0.332 ns |         0.311 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        608.15 ns |       2.012 ns |         1.784 ns |   8,649 B |     1000 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64B          |         89.61 ns |       0.116 ns |         0.103 ns |   5,553 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |        108.97 ns |       0.578 ns |         0.512 ns |   6,239 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        117.80 ns |       2.358 ns |         3.940 ns |   7,264 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |        151.67 ns |       0.407 ns |         0.340 ns |   8,168 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        592.62 ns |       9.818 ns |         9.183 ns |   8,638 B |     1056 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 65B          |         95.47 ns |       0.077 ns |         0.064 ns |   5,591 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |        107.02 ns |       0.359 ns |         0.336 ns |   6,244 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        114.72 ns |       0.132 ns |         0.124 ns |   7,262 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |        152.58 ns |       0.679 ns |         0.635 ns |   8,180 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        577.29 ns |       1.541 ns |         1.441 ns |   8,662 B |     1064 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128B         |         89.43 ns |       0.350 ns |         0.328 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |        109.53 ns |       1.668 ns |         2.497 ns |   6,280 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        117.59 ns |       0.173 ns |         0.162 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |        148.23 ns |       2.321 ns |         2.058 ns |   8,175 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        559.67 ns |       1.113 ns |         0.869 ns |   8,634 B |     1120 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 129B         |        182.56 ns |       0.859 ns |         0.717 ns |   5,557 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        197.92 ns |       3.586 ns |         2.995 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        209.33 ns |       0.220 ns |         0.195 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        298.65 ns |       5.667 ns |         6.299 ns |   8,172 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,040.55 ns |       2.627 ns |         2.194 ns |   9,433 B |     1128 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1KB          |        687.80 ns |       5.772 ns |         5.117 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        721.26 ns |       1.242 ns |         1.101 ns |   6,274 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        788.81 ns |       4.651 ns |         3.883 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |      1,134.37 ns |       7.453 ns |         5.819 ns |   8,182 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      3,644.96 ns |      72.399 ns |        94.139 ns |   9,363 B |     2016 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1025B        |        786.62 ns |      14.993 ns |        14.025 ns |   5,571 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        812.50 ns |       0.740 ns |         0.692 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        885.46 ns |       2.431 ns |         2.274 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |      1,309.69 ns |      13.122 ns |        12.274 ns |   8,183 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      4,072.51 ns |      35.719 ns |        33.411 ns |   9,388 B |     2024 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,622.48 ns |       6.439 ns |         6.023 ns |   6,519 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 8KB          |      6,095.18 ns |       3.982 ns |         3.530 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,183.11 ns |       3.096 ns |         2.896 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      8,977.84 ns |      13.771 ns |        12.882 ns |   8,186 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     26,986.36 ns |      54.043 ns |        47.908 ns |   9,388 B |     9184 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 64KB         |     43,358.27 ns |      39.855 ns |        37.280 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     44,952.89 ns |      31.402 ns |        27.837 ns |   6,516 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     49,244.38 ns |      15.221 ns |        14.238 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     72,054.07 ns |      72.113 ns |        63.926 ns |   8,418 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    214,307.37 ns |     926.917 ns |       821.688 ns |   9,371 B |    66528 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     90,148.60 ns |      85.230 ns |        75.555 ns |   6,516 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 128KB        |     96,830.76 ns |      84.960 ns |        70.945 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |     98,517.26 ns |      47.672 ns |        42.260 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |    143,695.34 ns |     258.627 ns |       229.266 ns |   8,418 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    461,372.48 ns |     753.064 ns |       667.572 ns |   9,393 B |   132078 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 1MB          |    662,923.22 ns |     654.430 ns |       612.155 ns |   5,547 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    684,322.60 ns |     287.493 ns |       268.921 ns |   6,227 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    758,576.19 ns |   2,325.059 ns |     2,061.104 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |  1,106,039.12 ns |  19,362.907 ns |    24,487.880 ns |   8,169 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,283,625.00 ns |  11,423.395 ns |    10,685.451 ns |   9,413 B |  1001823 B |
|                                                   |              |                  |                |                  |           |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-AVX2   | 10MB         |  6,805,589.06 ns |   5,276.146 ns |     4,935.310 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,867,934.22 ns |   4,167.282 ns |     3,898.079 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  7,526,320.19 ns |   3,254.840 ns |     2,717.939 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         | 10,959,686.56 ns |   9,637.148 ns |     9,014.595 ns |   8,425 B |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 38,190,341.00 ns | 836,508.251 ns | 2,466,463.632 ns |   9,408 B | 10001090 B |