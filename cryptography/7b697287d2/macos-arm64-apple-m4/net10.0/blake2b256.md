| Description                                       | TestDataSize | Mean             | Error          | StdDev         | Allocated  |
|-------------------------------------------------- |------------- |-----------------:|---------------:|---------------:|-----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 4B           |         90.71 ns |       0.338 ns |       0.316 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 4B           |         93.19 ns |       0.384 ns |       0.359 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 4B           |        121.72 ns |       0.503 ns |       0.470 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 4B           |        159.02 ns |       0.477 ns |       0.446 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 4B           |        686.93 ns |       4.225 ns |       3.952 ns |     1000 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64B          |         90.20 ns |       0.175 ns |       0.146 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64B          |         92.68 ns |       0.260 ns |       0.231 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64B          |        122.40 ns |       0.118 ns |       0.111 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64B          |        159.17 ns |       0.558 ns |       0.522 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64B          |        663.74 ns |       3.995 ns |       3.737 ns |     1056 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 65B          |         90.62 ns |       0.092 ns |       0.086 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 65B          |         92.17 ns |       0.314 ns |       0.293 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 65B          |        123.44 ns |       0.196 ns |       0.153 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 65B          |        158.16 ns |       0.088 ns |       0.073 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 65B          |        666.05 ns |       1.958 ns |       1.832 ns |     1064 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |         89.62 ns |       0.362 ns |       0.339 ns |          - |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |         90.35 ns |       0.183 ns |       0.171 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |        123.16 ns |       0.113 ns |       0.101 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |        158.81 ns |       0.085 ns |       0.080 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |        638.23 ns |       4.169 ns |       3.900 ns |     1120 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 129B         |        168.59 ns |       0.780 ns |       0.730 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 129B         |        181.73 ns |       0.590 ns |       0.552 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 129B         |        227.49 ns |       0.136 ns |       0.127 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 129B         |        320.18 ns |       0.092 ns |       0.086 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 129B         |      1,204.71 ns |       6.645 ns |       6.216 ns |     1128 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |        645.85 ns |       2.556 ns |       2.391 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |        718.78 ns |       3.477 ns |       3.253 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |        870.29 ns |       2.266 ns |       2.009 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |      1,296.12 ns |       4.882 ns |       4.567 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |      4,169.79 ns |      20.509 ns |      18.181 ns |     2016 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |        720.05 ns |       1.673 ns |       1.565 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |        807.15 ns |       1.607 ns |       1.425 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |        970.82 ns |       0.808 ns |       0.756 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |      1,454.87 ns |       0.392 ns |       0.347 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |      4,728.37 ns |      22.245 ns |      20.808 ns |     2024 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |      5,062.74 ns |      20.720 ns |      19.381 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |      5,713.85 ns |      21.358 ns |      19.978 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |      6,789.36 ns |       4.202 ns |       3.930 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |     10,350.95 ns |       3.341 ns |       3.125 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |     32,225.03 ns |     130.403 ns |     108.893 ns |     9184 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 64KB         |     40,677.56 ns |     228.318 ns |     213.569 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 64KB         |     45,774.72 ns |     138.376 ns |     129.437 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 64KB         |     54,137.76 ns |      28.999 ns |      27.126 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 64KB         |     82,765.61 ns |       7.161 ns |       5.980 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 64KB         |    256,467.26 ns |   1,279.030 ns |   1,196.406 ns |    66528 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |     82,050.12 ns |     228.588 ns |     213.822 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |     92,427.78 ns |     322.816 ns |     286.168 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        |    108,459.11 ns |     124.151 ns |     110.056 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        |    166,103.35 ns |     519.553 ns |     460.570 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        |    528,977.71 ns |   6,245.498 ns |   5,215.274 ns |   132092 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1MB          |    624,746.48 ns |   1,622.960 ns |   1,518.118 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1MB          |    706,129.56 ns |   2,746.919 ns |   2,435.072 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1MB          |    828,360.22 ns |     345.341 ns |     269.620 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1MB          |  1,266,507.88 ns |     336.410 ns |     280.917 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1MB          |  3,917,059.13 ns |  19,548.348 ns |  17,329.101 ns |  1002675 B |
|                                                   |              |                  |                |                |            |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 10MB         |  6,283,247.00 ns |  26,039.675 ns |  24,357.528 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 10MB         |  7,112,061.84 ns |  24,022.495 ns |  22,470.656 ns |          - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 10MB         |  8,313,756.56 ns |  35,826.028 ns |  33,511.689 ns |          - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 10MB         | 12,666,393.99 ns |   6,361.670 ns |   5,312.283 ns |          - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 10MB         | 40,007,279.99 ns | 142,675.573 ns | 126,478.180 ns | 10001193 B |