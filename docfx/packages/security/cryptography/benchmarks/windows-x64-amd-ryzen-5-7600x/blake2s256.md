| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     156.8 ns |   0.25 ns |   0.21 ns |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     157.6 ns |   0.44 ns |   0.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     158.2 ns |   0.28 ns |   0.23 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     159.2 ns |   0.21 ns |   0.19 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     160.4 ns |   0.18 ns |   0.14 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     162.5 ns |   0.69 ns |   0.61 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     230.9 ns |   0.44 ns |   0.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     237.0 ns |   0.42 ns |   0.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     237.2 ns |   0.25 ns |   0.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     238.8 ns |   2.63 ns |   2.33 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     240.5 ns |   0.21 ns |   0.18 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     242.2 ns |   0.45 ns |   0.42 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,181.0 ns |   4.49 ns |   3.98 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,211.6 ns |   1.97 ns |   1.74 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,220.9 ns |   1.22 ns |   1.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,238.0 ns |   2.23 ns |   2.09 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,244.1 ns |   7.33 ns |   6.12 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,248.9 ns |   2.67 ns |   2.50 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,219.2 ns |   2.74 ns |   2.14 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,286.0 ns |   2.06 ns |   1.83 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,301.4 ns |   0.93 ns |   0.82 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,317.3 ns |   1.25 ns |   1.11 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,318.2 ns |   2.89 ns |   2.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,330.5 ns |   2.07 ns |   1.84 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   9,072.8 ns |  54.25 ns |  45.30 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,656.4 ns |  26.58 ns |  23.56 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,688.5 ns |  28.66 ns |  23.93 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,744.9 ns |  14.27 ns |  12.65 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |   9,873.8 ns |  23.20 ns |  20.57 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |   9,956.5 ns |  14.94 ns |  13.97 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 144,524.3 ns | 266.62 ns | 236.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 154,003.4 ns | 335.59 ns | 297.50 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 154,697.9 ns | 460.89 ns | 384.87 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 155,914.4 ns | 211.14 ns | 197.50 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 158,257.4 ns | 192.10 ns | 160.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 159,368.1 ns | 362.47 ns | 321.32 ns |         - |