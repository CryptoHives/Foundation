| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     142.5 ns |   2.61 ns |   2.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     154.9 ns |   0.76 ns |   0.71 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     196.5 ns |   0.42 ns |   0.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |     383.0 ns |   3.19 ns |   2.98 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     208.7 ns |   0.55 ns |   0.51 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     231.2 ns |   0.71 ns |   0.66 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     285.9 ns |   0.54 ns |   0.51 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |     588.3 ns |   6.64 ns |   6.21 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,078.0 ns |   6.87 ns |   5.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,215.1 ns |   6.81 ns |   6.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,451.1 ns |   1.60 ns |   1.42 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |   3,225.0 ns |   4.37 ns |   3.87 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,143.5 ns |   5.65 ns |   5.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,291.2 ns |   6.36 ns |   5.64 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,539.7 ns |   0.84 ns |   0.75 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |   3,424.1 ns |   5.68 ns |   5.03 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,523.8 ns |  44.68 ns |  41.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,668.0 ns |  41.35 ns |  38.68 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,456.1 ns |  10.92 ns |   9.68 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  25,905.4 ns |   6.57 ns |   6.14 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 136,164.5 ns | 613.20 ns | 573.58 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 154,474.2 ns | 660.16 ns | 617.51 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 182,927.8 ns | 244.39 ns | 228.60 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 414,732.6 ns |  27.53 ns |  22.99 ns |         - |