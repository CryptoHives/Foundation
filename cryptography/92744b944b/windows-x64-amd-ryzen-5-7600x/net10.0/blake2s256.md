| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     153.9 ns |     0.25 ns |   0.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     154.3 ns |     0.48 ns |   0.42 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     155.0 ns |     0.44 ns |   0.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     156.4 ns |     0.16 ns |   0.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     158.3 ns |     0.14 ns |   0.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     161.0 ns |     0.19 ns |   0.16 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     226.1 ns |     0.42 ns |   0.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     229.5 ns |     0.68 ns |   0.64 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     233.4 ns |     1.41 ns |   1.25 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     234.5 ns |     0.09 ns |   0.08 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     239.8 ns |     0.26 ns |   0.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     243.1 ns |     0.77 ns |   0.72 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,135.3 ns |     3.63 ns |   3.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,181.5 ns |     2.40 ns |   2.00 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,202.3 ns |     2.71 ns |   2.40 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,214.1 ns |     0.99 ns |   0.83 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,219.5 ns |     2.52 ns |   2.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,243.0 ns |     1.53 ns |   1.43 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,202.5 ns |     2.30 ns |   1.92 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,277.0 ns |     3.43 ns |   3.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,282.7 ns |     2.33 ns |   2.18 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,294.9 ns |     1.33 ns |   1.11 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,298.0 ns |     2.45 ns |   2.17 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,320.4 ns |     1.84 ns |   1.72 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,942.3 ns |    16.41 ns |  15.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,395.0 ns |    26.76 ns |  25.03 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |   9,590.7 ns |    21.63 ns |  19.18 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,617.0 ns |    36.94 ns |  30.84 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,690.7 ns |    12.17 ns |  10.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |   9,912.7 ns |    11.88 ns |  10.53 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 142,677.4 ns |   433.49 ns | 405.49 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 150,481.1 ns |   394.21 ns | 368.75 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 152,703.2 ns |   625.80 ns | 554.75 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 153,850.7 ns |   508.93 ns | 424.98 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 155,375.7 ns | 1,114.46 ns | 987.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 158,152.3 ns |   207.46 ns | 183.91 ns |         - |