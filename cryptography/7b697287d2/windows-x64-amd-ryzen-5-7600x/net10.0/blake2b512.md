| Description                                       | TestDataSize | Mean             | Error          | StdDev        | Code Size | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|--------------:|----------:|-----------:|
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 4B           |         96.28 ns |       0.320 ns |      0.299 ns |   5,563 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 4B           |        107.58 ns |       0.478 ns |      0.447 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 4B           |        115.39 ns |       0.607 ns |      0.568 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 4B           |        153.47 ns |       0.671 ns |      0.628 ns |   8,178 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 4B           |        646.45 ns |       8.004 ns |      7.487 ns |   8,680 B |     1096 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64B          |         91.29 ns |       0.219 ns |      0.194 ns |   5,553 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64B          |        106.69 ns |       0.320 ns |      0.300 ns |   6,239 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64B          |        115.50 ns |       0.586 ns |      0.520 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64B          |        153.52 ns |       0.592 ns |      0.554 ns |   8,168 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64B          |        619.14 ns |       8.493 ns |      7.945 ns |   8,662 B |     1152 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 65B          |         96.62 ns |       0.224 ns |      0.210 ns |   5,558 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 65B          |        114.45 ns |       0.388 ns |      0.363 ns |   6,244 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 65B          |        116.92 ns |       0.492 ns |      0.461 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 65B          |        151.84 ns |       0.683 ns |      0.639 ns |   8,173 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 65B          |        629.40 ns |       5.173 ns |      4.586 ns |   8,670 B |     1160 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128B         |         91.20 ns |       0.280 ns |      0.262 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128B         |        107.07 ns |       0.337 ns |      0.315 ns |   6,282 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128B         |        116.51 ns |       0.373 ns |      0.349 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128B         |        150.24 ns |       0.728 ns |      0.681 ns |   8,182 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128B         |        586.39 ns |       5.436 ns |      5.085 ns |   8,656 B |     1216 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 129B         |        179.79 ns |       0.295 ns |      0.276 ns |   5,557 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 129B         |        196.04 ns |       0.399 ns |      0.373 ns |   6,249 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 129B         |        212.26 ns |       0.336 ns |      0.298 ns |   7,276 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 129B         |        295.66 ns |       1.683 ns |      1.574 ns |   8,172 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 129B         |      1,086.38 ns |      10.222 ns |      9.562 ns |   9,477 B |     1224 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1KB          |        685.86 ns |       1.110 ns |      1.038 ns |   5,560 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1KB          |        719.91 ns |       1.035 ns |      0.968 ns |   6,276 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1KB          |        790.89 ns |       0.718 ns |      0.671 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1KB          |      1,131.06 ns |       6.050 ns |      5.363 ns |   8,189 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1KB          |      3,567.51 ns |      23.703 ns |     21.012 ns |   9,335 B |     2112 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1025B        |        774.92 ns |       0.492 ns |      0.460 ns |   5,557 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1025B        |        816.59 ns |       0.537 ns |      0.476 ns |   6,243 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1025B        |        885.91 ns |       0.757 ns |      0.708 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1025B        |      1,261.94 ns |       2.802 ns |      2.340 ns |   8,183 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1025B        |      3,986.63 ns |      18.655 ns |     17.450 ns |   9,388 B |     2120 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 8KB          |      5,423.86 ns |       2.620 ns |      2.451 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 8KB          |      5,647.42 ns |       2.979 ns |      2.326 ns |   6,519 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 8KB          |      6,204.22 ns |       7.535 ns |      6.680 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 8KB          |      8,796.25 ns |      19.346 ns |     17.150 ns |   8,175 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 8KB          |     26,936.76 ns |      87.738 ns |     77.778 ns |   9,371 B |     9280 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 64KB         |     43,347.03 ns |      27.333 ns |     24.230 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 64KB         |     44,896.29 ns |      47.741 ns |     42.321 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 64KB         |     49,445.97 ns |      38.291 ns |     33.944 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 64KB         |     70,362.27 ns |      95.518 ns |     74.574 ns |   8,418 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 64KB         |    213,900.36 ns |     347.803 ns |    308.319 ns |   9,423 B |    66624 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 128KB        |     86,650.02 ns |      54.458 ns |     45.475 ns |   5,803 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 128KB        |     89,659.75 ns |      60.649 ns |     56.731 ns |   6,518 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 128KB        |     98,972.83 ns |      89.949 ns |     84.139 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 128KB        |    142,754.63 ns |     387.104 ns |    343.158 ns |   8,432 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 128KB        |    460,624.10 ns |   2,023.080 ns |  1,892.390 ns |   9,419 B |   132174 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 1MB          |    661,433.57 ns |     402.380 ns |    356.699 ns |   5,554 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 1MB          |    684,569.51 ns |     785.566 ns |    734.819 ns |   6,227 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 1MB          |    753,206.43 ns |     554.489 ns |    463.023 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 1MB          |  1,076,845.54 ns |   2,274.367 ns |  2,016.167 ns |   8,169 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 1MB          |  3,315,729.01 ns |   8,345.335 ns |  7,806.232 ns |   9,413 B |  1001939 B |
|                                                   |              |                  |                |               |           |            |
| TryComputeHash · BLAKE2b-512 · CryptoHives-AVX2   | 10MB         |  6,625,578.49 ns |   4,169.237 ns |  3,899.907 ns |   5,810 B |          - |
| TryComputeHash · BLAKE2b-512 · Blake2Fast         | 10MB         |  6,844,691.29 ns |   3,119.718 ns |  2,605.106 ns |   6,520 B |          - |
| TryComputeHash · BLAKE2b-512 · BouncyCastle       | 10MB         |  7,615,175.06 ns |   8,872.611 ns |  7,865.338 ns |   7,274 B |          - |
| TryComputeHash · BLAKE2b-512 · CryptoHives-Scalar | 10MB         | 10,761,623.77 ns |  11,611.329 ns | 10,293.141 ns |   8,436 B |          - |
| TryComputeHash · BLAKE2b-512 · Konscious          | 10MB         | 33,232,489.56 ns | 110,758.045 ns | 98,184.122 ns |   9,408 B | 10001184 B |