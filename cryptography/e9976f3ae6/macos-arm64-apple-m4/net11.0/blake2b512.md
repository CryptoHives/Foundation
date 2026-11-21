| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |         92.73 ns |       0.219 ns |       0.205 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |         97.24 ns |       0.209 ns |       0.185 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        120.05 ns |       0.208 ns |       0.195 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 4B           |        162.36 ns |       0.510 ns |       0.477 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        735.85 ns |       2.651 ns |       2.480 ns |     1088 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |         92.77 ns |       0.148 ns |       0.139 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |         96.87 ns |       0.344 ns |       0.322 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        118.46 ns |       0.116 ns |       0.103 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64B          |        171.38 ns |       0.655 ns |       0.613 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        703.64 ns |       1.728 ns |       1.532 ns |     1144 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |         92.80 ns |       0.126 ns |       0.105 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |         96.50 ns |       0.279 ns |       0.261 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        120.73 ns |       0.156 ns |       0.146 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 65B          |        162.74 ns |       0.478 ns |       0.448 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        702.58 ns |       2.798 ns |       2.617 ns |     1152 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |         92.51 ns |       0.141 ns |       0.132 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |         94.49 ns |       0.213 ns |       0.189 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        122.81 ns |       0.159 ns |       0.148 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |        161.95 ns |       0.141 ns |       0.125 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        674.11 ns |       2.534 ns |       2.370 ns |     1208 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        170.78 ns |       0.562 ns |       0.525 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        187.65 ns |       0.770 ns |       0.720 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        224.17 ns |       0.249 ns |       0.233 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 129B         |        326.24 ns |       0.461 ns |       0.432 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,259.17 ns |       4.955 ns |       4.393 ns |     1216 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        653.24 ns |       1.667 ns |       1.478 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |        738.86 ns |       2.009 ns |       1.781 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        850.49 ns |       1.934 ns |       1.615 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |      1,316.68 ns |       1.006 ns |       0.941 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      4,288.83 ns |      22.936 ns |      21.455 ns |     2104 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        733.68 ns |       1.345 ns |       1.193 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |        834.56 ns |       2.360 ns |       2.208 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        955.36 ns |       1.135 ns |       0.947 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |      1,487.03 ns |       1.299 ns |       1.085 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,902.89 ns |      28.193 ns |      26.372 ns |     2112 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,144.09 ns |      16.976 ns |      15.879 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      5,838.33 ns |      23.371 ns |      21.861 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,695.02 ns |      21.007 ns |      19.650 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |     10,462.82 ns |       9.936 ns |       9.295 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     33,227.20 ns |     251.418 ns |     235.177 ns |     9272 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     41,138.89 ns |     222.713 ns |     208.326 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     46,742.05 ns |      57.694 ns |      53.967 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     53,028.70 ns |      42.987 ns |      40.210 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64KB         |     83,698.80 ns |      65.460 ns |      61.231 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    263,470.60 ns |   1,182.870 ns |   1,106.457 ns |    66616 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     82,496.64 ns |     331.429 ns |     310.019 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |     93,955.21 ns |     459.228 ns |     429.562 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    106,325.95 ns |     217.592 ns |     192.890 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        |    168,056.29 ns |     530.110 ns |     495.865 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    537,846.72 ns |   3,614.739 ns |   3,381.229 ns |   132178 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    628,711.36 ns |   3,000.411 ns |   2,806.586 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |    716,234.36 ns |   2,638.006 ns |   2,467.592 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    807,433.85 ns |   2,091.092 ns |   1,746.156 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1MB          |  1,283,861.76 ns |   4,325.317 ns |   4,045.904 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  4,023,692.27 ns |  35,476.262 ns |  33,184.517 ns |  1002642 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,286,874.28 ns |  12,978.435 ns |  11,505.045 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         |  7,169,862.30 ns |  24,645.237 ns |  23,053.170 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  8,080,245.53 ns |   4,989.344 ns |   4,667.035 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 10MB         | 12,824,961.59 ns |   9,854.445 ns |   9,217.854 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 40,593,836.97 ns | 248,143.192 ns | 232,113.296 ns | 10001647 B |