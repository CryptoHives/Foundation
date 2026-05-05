| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     154.2 ns |   0.35 ns |   0.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     154.3 ns |   0.30 ns |   0.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     154.5 ns |   0.26 ns |   0.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     156.3 ns |   1.14 ns |   1.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     157.9 ns |   0.20 ns |   0.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     158.3 ns |   0.79 ns |   0.74 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     226.7 ns |   0.39 ns |   0.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     232.5 ns |   0.50 ns |   0.44 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     232.7 ns |   2.02 ns |   1.79 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     234.8 ns |   0.26 ns |   0.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     240.9 ns |   0.29 ns |   0.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     243.3 ns |   0.57 ns |   0.50 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,140.3 ns |   2.48 ns |   2.32 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,198.9 ns |   3.96 ns |   3.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,204.9 ns |   3.53 ns |   2.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,217.5 ns |   1.85 ns |   1.64 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,232.8 ns |   2.11 ns |   1.76 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,238.4 ns |   1.74 ns |   1.63 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,209.7 ns |   4.48 ns |   4.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,270.8 ns |   2.65 ns |   2.35 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,285.5 ns |   6.16 ns |   5.76 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,298.5 ns |   2.02 ns |   1.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,304.3 ns |   3.94 ns |   3.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,322.8 ns |   2.30 ns |   2.15 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,997.8 ns |  34.02 ns |  28.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,545.7 ns |  41.42 ns |  36.72 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,625.6 ns |  26.36 ns |  24.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |   9,664.6 ns |  41.97 ns |  39.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,723.9 ns |  30.40 ns |  26.95 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |   9,906.8 ns |  11.56 ns |  10.81 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 143,963.1 ns | 504.80 ns | 421.53 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 151,036.0 ns | 877.52 ns | 777.90 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 153,887.3 ns | 325.87 ns | 272.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 154,442.2 ns | 637.63 ns | 532.45 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 155,460.5 ns | 235.08 ns | 219.90 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 158,448.0 ns | 186.15 ns | 174.12 ns |         - |