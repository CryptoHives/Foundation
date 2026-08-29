| Description                                       | TestDataSize | Mean          | Error        | StdDev       | Median        | Allocated |
|-------------------------------------------------- |------------- |--------------:|-------------:|-------------:|--------------:|----------:|
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128B         |      91.51 ns |     1.084 ns |     1.014 ns |      90.97 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128B         |      96.85 ns |     0.152 ns |     0.119 ns |      96.81 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128B         |     125.48 ns |     1.970 ns |     1.746 ns |     124.94 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128B         |     184.70 ns |     0.857 ns |     0.760 ns |     184.89 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128B         |     677.44 ns |     8.169 ns |     7.641 ns |     674.11 ns |    1120 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 137B         |     169.67 ns |     0.465 ns |     0.412 ns |     169.47 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 137B         |     188.08 ns |     0.423 ns |     0.395 ns |     187.89 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 137B         |     228.60 ns |     0.815 ns |     0.680 ns |     228.25 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 137B         |     374.83 ns |     2.434 ns |     2.277 ns |     374.23 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 137B         |   1,270.93 ns |     2.534 ns |     1.978 ns |   1,270.44 ns |    1136 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1KB          |     654.87 ns |     2.942 ns |     2.457 ns |     654.18 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1KB          |     748.06 ns |     9.651 ns |     8.555 ns |     744.26 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1KB          |     869.21 ns |     1.848 ns |     1.442 ns |     868.72 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1KB          |   1,516.13 ns |    22.185 ns |    26.409 ns |   1,506.46 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1KB          |   4,430.11 ns |    26.149 ns |    21.835 ns |   4,421.85 ns |    2016 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 1025B        |     737.31 ns |     4.157 ns |     3.471 ns |     735.84 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 1025B        |     836.49 ns |     1.688 ns |     1.318 ns |     836.13 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 1025B        |     973.37 ns |     1.740 ns |     1.358 ns |     973.02 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 1025B        |   1,691.80 ns |    13.832 ns |    12.262 ns |   1,690.89 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 1025B        |   5,028.76 ns |    20.077 ns |    15.675 ns |   5,025.28 ns |    2024 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 8KB          |   5,173.51 ns |     6.691 ns |     5.587 ns |   5,171.35 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 8KB          |   5,921.79 ns |    14.340 ns |    11.975 ns |   5,914.66 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 8KB          |   6,813.51 ns |    18.170 ns |    15.173 ns |   6,819.28 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 8KB          |  12,310.48 ns |   116.753 ns |   103.498 ns |  12,288.95 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 8KB          |  34,838.15 ns |   646.349 ns |   884.730 ns |  34,284.96 ns |    9184 B |
|                                                   |              |               |              |              |               |           |
| TryComputeHash · BLAKE2b-256 · Blake2Fast         | 128KB        |  82,584.86 ns |    25.192 ns |    21.036 ns |  82,587.50 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Scalar | 128KB        |  94,597.96 ns |    18.583 ns |    15.517 ns |  94,599.33 ns |         - |
| TryComputeHash · BLAKE2b-256 · BouncyCastle       | 128KB        | 108,562.16 ns |   137.796 ns |   107.582 ns | 108,529.16 ns |         - |
| TryComputeHash · BLAKE2b-256 · CryptoHives-Neon   | 128KB        | 196,495.88 ns | 1,153.127 ns | 1,078.636 ns | 196,544.09 ns |         - |
| TryComputeHash · BLAKE2b-256 · Konscious          | 128KB        | 553,596.33 ns |   670.690 ns |   627.363 ns | 553,584.47 ns |  132092 B |