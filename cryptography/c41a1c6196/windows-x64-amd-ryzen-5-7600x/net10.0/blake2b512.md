| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Median           | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |         97.36 ns |       0.080 ns |       0.075 ns |         97.36 ns |   5,570 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        116.00 ns |       0.092 ns |       0.082 ns |        116.01 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        124.32 ns |       0.276 ns |       0.231 ns |        124.35 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        152.00 ns |       0.652 ns |       0.578 ns |        151.72 ns |   8,211 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        639.29 ns |       3.166 ns |       2.962 ns |        638.28 ns |   8,698 B |     1096 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |         91.52 ns |       1.678 ns |       1.570 ns |         91.08 ns |   5,553 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        108.50 ns |       0.148 ns |       0.131 ns |        108.51 ns |   6,241 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        114.48 ns |       0.168 ns |       0.157 ns |        114.48 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        152.12 ns |       0.272 ns |       0.227 ns |        152.09 ns |   8,168 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        611.28 ns |       4.249 ns |       3.767 ns |        610.91 ns |   8,662 B |     1152 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |         95.74 ns |       0.046 ns |       0.040 ns |         95.74 ns |   5,584 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        108.48 ns |       0.147 ns |       0.138 ns |        108.48 ns |   6,244 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        115.26 ns |       0.106 ns |       0.094 ns |        115.25 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        152.34 ns |       0.263 ns |       0.246 ns |        152.30 ns |   8,173 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        612.12 ns |       2.364 ns |       2.095 ns |        611.95 ns |   8,670 B |     1160 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |         90.07 ns |       0.132 ns |       0.124 ns |         90.03 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        111.40 ns |       2.093 ns |       2.865 ns |        111.00 ns |   6,530 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        121.47 ns |       2.387 ns |       3.103 ns |        121.58 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        156.15 ns |       3.134 ns |       5.322 ns |        154.62 ns |   8,175 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        693.97 ns |      32.650 ns |      96.269 ns |        661.14 ns |   8,656 B |     1216 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        181.33 ns |       3.574 ns |       4.648 ns |        179.37 ns |   5,557 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        197.34 ns |       2.515 ns |       2.230 ns |        197.33 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        211.04 ns |       2.166 ns |       1.920 ns |        210.82 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        300.86 ns |       5.211 ns |       6.591 ns |        300.63 ns |   8,179 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,118.14 ns |      29.151 ns |      83.640 ns |      1,070.67 ns |   9,405 B |     1224 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        684.41 ns |       4.246 ns |       3.972 ns |        681.76 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        721.32 ns |       0.686 ns |       0.642 ns |        721.40 ns |   6,519 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        822.43 ns |       0.242 ns |       0.226 ns |        822.40 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,167.65 ns |      23.194 ns |      46.853 ns |      1,144.12 ns |   8,175 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      3,519.59 ns |       4.340 ns |       3.624 ns |      3,519.60 ns |   9,342 B |     2112 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |        772.36 ns |       1.431 ns |       1.195 ns |        771.91 ns |   5,564 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        817.65 ns |       9.470 ns |       8.858 ns |        819.38 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        889.02 ns |       1.044 ns |       0.976 ns |        888.91 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,285.26 ns |      16.627 ns |      13.884 ns |      1,279.35 ns |   8,179 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,031.23 ns |       4.951 ns |       3.866 ns |      4,030.30 ns |   9,400 B |     2120 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      5,550.65 ns |      48.889 ns |      45.731 ns |      5,574.09 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,742.80 ns |       3.485 ns |       3.089 ns |      5,742.50 ns |   6,519 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,203.84 ns |       2.452 ns |       2.174 ns |      6,203.70 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      9,099.84 ns |      27.372 ns |      25.604 ns |      9,102.06 ns |   8,186 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     27,197.61 ns |      76.168 ns |      63.604 ns |     27,192.14 ns |   9,394 B |     9280 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     43,379.34 ns |      40.131 ns |      35.575 ns |     43,388.89 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     44,832.28 ns |      22.856 ns |      17.844 ns |     44,830.56 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     49,509.45 ns |     110.901 ns |      86.584 ns |     49,478.19 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     71,916.54 ns |     212.700 ns |     188.553 ns |     71,848.38 ns |   8,418 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    287,342.72 ns |  15,598.812 ns |  45,993.453 ns |    292,164.53 ns |   9,423 B |    66624 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |     88,771.72 ns |      69.876 ns |      65.362 ns |     88,745.28 ns |   5,812 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     90,031.13 ns |      65.960 ns |      61.699 ns |     90,017.32 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |     99,267.85 ns |      47.639 ns |      44.562 ns |     99,248.10 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    143,445.43 ns |     149.152 ns |     124.549 ns |    143,481.91 ns |   8,418 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    462,169.42 ns |   1,145.314 ns |   1,015.291 ns |    461,834.59 ns |   9,419 B |   132174 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    661,776.75 ns |     379.557 ns |     316.947 ns |    661,623.63 ns |   5,547 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    687,559.61 ns |     526.777 ns |     492.748 ns |    687,689.94 ns |   6,227 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    755,426.65 ns |     293.521 ns |     260.199 ns |    755,427.78 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,096,093.86 ns |   7,501.433 ns |   6,264.036 ns |  1,093,941.80 ns |   8,169 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  3,341,255.81 ns |  59,158.605 ns | 105,154.368 ns |  3,294,150.00 ns |   9,413 B |  1001882 B |
|                                                   |              |                  |                |                |                  |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  6,728,557.24 ns | 106,502.276 ns |  99,622.295 ns |  6,714,899.22 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,879,369.87 ns |   2,167.640 ns |   1,921.556 ns |  6,878,958.98 ns |   6,520 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  7,619,988.95 ns |  21,258.857 ns |  18,845.423 ns |  7,621,797.27 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 14,595,971.15 ns |  72,941.403 ns |  68,229.434 ns | 14,615,737.50 ns |   8,436 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 33,222,250.00 ns | 180,068.222 ns | 150,365.121 ns | 33,180,650.00 ns |   9,408 B | 10002415 B |