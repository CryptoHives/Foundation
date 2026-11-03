| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |         92.30 ns |       0.412 ns |       0.385 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |         95.18 ns |       0.208 ns |       0.195 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        124.68 ns |       0.480 ns |       0.449 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 4B           |        159.28 ns |       0.709 ns |       0.663 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        721.25 ns |       3.457 ns |       3.233 ns |     1096 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |         91.81 ns |       0.319 ns |       0.299 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |         94.03 ns |       0.401 ns |       0.375 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        125.57 ns |       0.452 ns |       0.423 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64B          |        159.11 ns |       0.566 ns |       0.502 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        696.59 ns |       2.928 ns |       2.739 ns |     1152 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |         92.35 ns |       0.318 ns |       0.297 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |         94.75 ns |       0.218 ns |       0.204 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        127.00 ns |       0.459 ns |       0.430 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 65B          |        159.38 ns |       0.747 ns |       0.699 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        700.13 ns |       3.105 ns |       2.905 ns |     1160 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |         91.26 ns |       0.406 ns |       0.380 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |         92.06 ns |       0.503 ns |       0.471 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        127.49 ns |       0.442 ns |       0.414 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |        159.53 ns |       0.771 ns |       0.721 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        671.07 ns |       3.746 ns |       3.504 ns |     1216 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        169.99 ns |       0.553 ns |       0.517 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        184.91 ns |       0.710 ns |       0.665 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        231.17 ns |       0.888 ns |       0.830 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 129B         |        321.57 ns |       1.437 ns |       1.345 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,238.01 ns |       4.427 ns |       3.697 ns |     1224 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        652.13 ns |       2.646 ns |       2.209 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |        724.97 ns |       3.522 ns |       3.295 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        873.51 ns |       3.100 ns |       2.899 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |      1,299.04 ns |       4.841 ns |       4.528 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      4,216.61 ns |      32.625 ns |      30.518 ns |     2112 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        729.32 ns |       3.613 ns |       3.380 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |        817.00 ns |       2.942 ns |       2.752 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        978.69 ns |       3.264 ns |       3.053 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |      1,460.60 ns |       5.809 ns |       5.434 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,789.69 ns |      22.873 ns |      21.395 ns |     2120 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,106.53 ns |      25.483 ns |      23.837 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      5,769.53 ns |      27.928 ns |      26.124 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,829.28 ns |      22.070 ns |      20.644 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |     10,400.28 ns |      27.602 ns |      25.819 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     32,529.36 ns |     197.231 ns |     184.490 ns |     9280 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     40,762.16 ns |     163.875 ns |     145.271 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     46,116.46 ns |     225.965 ns |     211.367 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     54,402.03 ns |     160.015 ns |     149.678 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64KB         |     83,148.50 ns |     321.538 ns |     300.767 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    258,085.21 ns |   1,055.087 ns |     881.045 ns |    66624 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     81,299.72 ns |     393.861 ns |     368.417 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |     92,299.63 ns |     419.668 ns |     392.558 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    108,390.06 ns |      89.065 ns |      83.311 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        |    166,267.44 ns |     531.839 ns |     497.482 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    523,860.93 ns |   2,321.158 ns |   2,171.212 ns |   132188 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    621,313.38 ns |   3,137.599 ns |   2,934.912 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |    700,484.22 ns |   2,121.673 ns |   1,984.614 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    827,392.20 ns |     562.617 ns |     498.745 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1MB          |  1,265,620.37 ns |     239.197 ns |     223.745 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  3,885,656.23 ns |   9,562.282 ns |   8,476.714 ns |  1002773 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,212,161.26 ns |  20,042.398 ns |  18,747.672 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         |  7,026,352.26 ns |  17,635.781 ns |  16,496.521 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  8,274,982.34 ns |   5,294.387 ns |   4,952.373 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 10MB         | 12,660,042.87 ns |   5,720.989 ns |   5,351.417 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 39,598,876.15 ns | 151,902.139 ns | 134,657.290 ns | 10001289 B |