| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |        108.44 ns |       1.552 ns |       1.452 ns |   6,263 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        114.09 ns |       1.871 ns |       1.750 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        130.66 ns |       0.997 ns |       0.932 ns |   6,975 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        166.07 ns |       2.458 ns |       2.299 ns |   8,236 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        971.04 ns |      15.683 ns |      14.670 ns |   8,774 B |     1096 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |        105.83 ns |       1.415 ns |       1.324 ns |   6,253 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        110.81 ns |       0.085 ns |       0.075 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        129.16 ns |       2.245 ns |       2.100 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        162.02 ns |       2.519 ns |       2.356 ns |   8,219 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        839.13 ns |       3.811 ns |       2.976 ns |   8,745 B |     1152 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |        103.22 ns |       0.162 ns |       0.135 ns |   6,274 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        111.20 ns |       0.288 ns |       0.269 ns |   5,884 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        126.09 ns |       0.220 ns |       0.195 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        158.61 ns |       0.349 ns |       0.310 ns |   8,240 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        837.09 ns |       1.342 ns |       1.256 ns |   8,716 B |     1160 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |         97.46 ns |       0.243 ns |       0.216 ns |   6,245 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        110.43 ns |       0.609 ns |       0.509 ns |   5,916 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        126.30 ns |       0.247 ns |       0.219 ns |   6,973 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        156.05 ns |       0.140 ns |       0.117 ns |   8,211 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        754.12 ns |       1.341 ns |       1.120 ns |   8,726 B |     1216 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        195.96 ns |       0.644 ns |       0.571 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        200.24 ns |       0.251 ns |       0.210 ns |   5,897 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        219.77 ns |       0.476 ns |       0.445 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        306.82 ns |       0.488 ns |       0.457 ns |   8,223 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,481.57 ns |       6.209 ns |       5.504 ns |   9,565 B |     1224 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        702.14 ns |       1.281 ns |       1.135 ns |   5,910 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        716.56 ns |       1.110 ns |       0.927 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        781.79 ns |       0.672 ns |       0.596 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,232.19 ns |       2.833 ns |       2.512 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      4,378.18 ns |      10.039 ns |       8.899 ns |   9,432 B |     2112 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |        812.10 ns |       0.923 ns |       0.819 ns |   6,257 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        812.11 ns |      10.151 ns |       9.496 ns |   5,891 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        882.10 ns |       1.007 ns |       0.841 ns |   6,987 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,379.53 ns |       2.374 ns |       1.982 ns |   8,234 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      5,073.05 ns |       8.328 ns |       7.383 ns |   9,497 B |     2120 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,583.68 ns |      93.423 ns |      87.388 ns |   6,159 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      5,950.52 ns |      89.716 ns |      83.920 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,220.00 ns |      70.986 ns |      66.400 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      9,683.18 ns |     146.834 ns |     137.349 ns |   8,220 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     34,576.18 ns |     525.927 ns |     491.952 ns |   9,497 B |     9280 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     44,606.12 ns |     686.083 ns |     641.762 ns |   6,159 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     48,071.99 ns |     356.777 ns |     333.729 ns |   6,510 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     49,861.43 ns |     900.902 ns |     842.705 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     77,361.87 ns |   1,451.065 ns |   1,357.327 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    274,216.09 ns |   4,545.615 ns |   4,251.971 ns |   9,489 B |    66624 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     89,044.41 ns |   1,215.478 ns |   1,136.959 ns |   6,158 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |     95,618.49 ns |   1,145.499 ns |   1,071.500 ns |   6,503 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    100,621.00 ns |   1,696.741 ns |   1,587.133 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    155,783.27 ns |   1,598.748 ns |   1,495.470 ns |   8,469 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    592,377.36 ns |  11,079.542 ns |  10,363.810 ns |   9,481 B |   132174 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    679,677.79 ns |  10,627.630 ns |   9,941.092 ns |   5,873 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    732,298.35 ns |  12,592.425 ns |  11,778.963 ns |   6,254 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    767,142.24 ns |  10,614.037 ns |   9,928.377 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,183,765.89 ns |  16,610.417 ns |  15,537.394 ns |   8,213 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  4,216,713.90 ns |  41,781.631 ns |  37,038.327 ns |   9,501 B |  1001849 B |
|                                                   |              |                  |                |                |           |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,896,401.41 ns | 115,029.884 ns | 107,599.025 ns |   6,160 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  7,418,210.62 ns | 126,661.365 ns | 118,479.120 ns |   6,533 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  7,799,771.67 ns | 138,438.219 ns | 129,495.196 ns |   6,985 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 11,985,611.04 ns | 121,570.429 ns | 113,717.055 ns |   8,478 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 42,909,857.78 ns | 713,459.084 ns | 667,370.070 ns |   9,496 B | 10001192 B |