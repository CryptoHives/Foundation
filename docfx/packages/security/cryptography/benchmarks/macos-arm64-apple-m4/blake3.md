| Description                                  | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE3 · Blake3Native       | 128B         |     100.9 ns |     0.03 ns |     0.03 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128B         |     243.5 ns |     0.05 ns |     0.04 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128B         |     525.3 ns |     0.62 ns |     0.55 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128B         |     728.8 ns |     1.45 ns |     1.28 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 137B         |     147.3 ns |     0.06 ns |     0.05 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 137B         |     366.4 ns |     0.06 ns |     0.05 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 137B         |     775.9 ns |     3.23 ns |     3.03 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 137B         |   1,076.8 ns |     4.59 ns |     4.29 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1KB          |     774.2 ns |     0.36 ns |     0.30 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1KB          |   1,962.8 ns |     0.56 ns |     0.47 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1KB          |   3,989.8 ns |    25.63 ns |    22.72 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1KB          |   5,386.2 ns |    11.73 ns |    10.40 ns |         - |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 1025B        |     883.2 ns |     0.43 ns |     0.38 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 1025B        |   2,202.6 ns |     0.21 ns |     0.17 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 1025B        |   4,624.9 ns |    26.72 ns |    24.99 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 1025B        |   6,134.7 ns |    17.03 ns |    15.93 ns |      56 B |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 8KB          |   3,358.2 ns |     9.70 ns |     9.08 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 8KB          |  17,274.7 ns |    12.04 ns |    11.26 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 8KB          |  34,620.2 ns |   153.81 ns |   143.87 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 8KB          |  45,280.7 ns |   145.44 ns |   136.05 ns |     392 B |
|                                              |              |              |             |             |           |
| TryComputeHash · BLAKE3 · Blake3Native       | 128KB        |  52,975.0 ns |   210.08 ns |   196.50 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Neon   | 128KB        | 282,003.9 ns |    15.34 ns |    13.60 ns |         - |
| TryComputeHash · BLAKE3 · CryptoHives-Scalar | 128KB        | 559,868.7 ns | 2,537.33 ns | 2,373.42 ns |         - |
| TryComputeHash · BLAKE3 · BouncyCastle       | 128KB        | 727,077.2 ns | 2,156.76 ns | 2,017.43 ns |    7112 B |