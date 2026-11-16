| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |         92.50 ns |       0.294 ns |       0.275 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |         95.53 ns |       0.345 ns |       0.323 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        125.43 ns |       0.353 ns |       0.331 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 4B           |        161.13 ns |       0.381 ns |       0.357 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        730.43 ns |       2.253 ns |       2.107 ns |     1096 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |         91.85 ns |       0.344 ns |       0.322 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |         94.93 ns |       0.404 ns |       0.378 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        126.59 ns |       0.395 ns |       0.350 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64B          |        161.16 ns |       0.434 ns |       0.406 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        706.04 ns |       2.278 ns |       2.131 ns |     1152 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |         92.35 ns |       0.253 ns |       0.237 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |         94.85 ns |       0.351 ns |       0.293 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        127.89 ns |       0.267 ns |       0.250 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 65B          |        161.05 ns |       0.686 ns |       0.641 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        707.55 ns |       2.999 ns |       2.805 ns |     1160 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |         91.50 ns |       0.331 ns |       0.310 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |         92.39 ns |       0.283 ns |       0.264 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        127.17 ns |       0.473 ns |       0.443 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128B         |        161.32 ns |       0.494 ns |       0.462 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        687.29 ns |       2.883 ns |       2.697 ns |     1216 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        171.06 ns |       0.592 ns |       0.554 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        186.54 ns |       0.525 ns |       0.491 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        233.28 ns |       0.606 ns |       0.567 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 129B         |        325.79 ns |       0.967 ns |       0.905 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,266.10 ns |       4.454 ns |       4.166 ns |     1224 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        653.96 ns |       2.552 ns |       2.387 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |        733.53 ns |       3.397 ns |       3.178 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        880.26 ns |       2.140 ns |       2.002 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1KB          |      1,321.47 ns |       4.662 ns |       4.361 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      4,282.99 ns |      24.277 ns |      22.709 ns |     2112 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        742.20 ns |       1.956 ns |       1.830 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |        827.46 ns |       3.992 ns |       3.734 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        983.24 ns |       3.497 ns |       3.271 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1025B        |      1,477.90 ns |       3.251 ns |       3.041 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      4,883.62 ns |      24.027 ns |      22.475 ns |     2120 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,168.27 ns |      20.119 ns |      18.820 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      5,849.53 ns |      15.623 ns |      14.613 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,868.78 ns |      23.082 ns |      21.591 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 8KB          |     10,526.85 ns |      27.946 ns |      26.141 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     33,346.10 ns |     190.100 ns |     177.820 ns |     9280 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     41,229.31 ns |     177.432 ns |     165.970 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     46,763.93 ns |     170.072 ns |     150.765 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     54,777.18 ns |     136.951 ns |     128.104 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 64KB         |     84,168.61 ns |     231.237 ns |     216.299 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    263,461.03 ns |   1,323.753 ns |   1,238.240 ns |    66624 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     82,447.96 ns |     329.368 ns |     308.091 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |     93,791.56 ns |     396.013 ns |     370.431 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |    109,634.86 ns |     276.811 ns |     258.929 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 128KB        |    168,520.37 ns |     416.044 ns |     389.168 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    534,975.17 ns |   2,509.461 ns |   2,347.351 ns |   132188 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    628,910.32 ns |   2,863.795 ns |   2,678.796 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |    715,076.29 ns |   3,741.564 ns |   3,499.861 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    837,030.37 ns |   1,675.257 ns |   1,567.036 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 1MB          |  1,286,797.43 ns |   3,197.587 ns |   2,991.024 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  3,970,913.37 ns |  14,737.232 ns |  13,785.216 ns |  1002727 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,312,854.84 ns |  22,471.654 ns |  21,019.999 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         |  7,180,476.32 ns |  21,325.198 ns |  19,947.603 ns |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  8,366,314.97 ns |  25,884.840 ns |  24,212.695 ns |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Neon   | 10MB         | 12,852,255.45 ns |  46,099.488 ns |  43,121.490 ns |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 40,424,307.70 ns | 225,238.911 ns | 210,688.617 ns | 10001289 B |