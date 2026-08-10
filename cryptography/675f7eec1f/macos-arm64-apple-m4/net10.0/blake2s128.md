| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     142.7 ns |   0.27 ns |   0.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     158.2 ns |   0.37 ns |   0.35 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     197.1 ns |   0.19 ns |   0.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |     382.3 ns |   2.30 ns |   1.92 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     211.7 ns |   0.29 ns |   0.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     236.8 ns |   0.33 ns |   0.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     287.4 ns |   0.29 ns |   0.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |     586.6 ns |   2.61 ns |   2.44 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,098.9 ns |   3.32 ns |   3.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,255.4 ns |   0.92 ns |   0.86 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,463.1 ns |   2.90 ns |   2.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |   3,235.0 ns |   7.02 ns |   6.57 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,168.1 ns |   1.11 ns |   1.04 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,334.9 ns |   0.78 ns |   0.69 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,551.2 ns |   4.27 ns |   3.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |   3,442.3 ns |   3.87 ns |   3.62 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,729.1 ns |   5.66 ns |   5.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |  10,013.0 ns |  29.35 ns |  27.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,558.9 ns |  16.18 ns |  15.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |  26,048.9 ns |  70.58 ns |  66.02 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 139,207.8 ns | 138.57 ns | 129.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 160,128.6 ns | 425.65 ns | 398.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 184,178.6 ns | 296.64 ns | 277.48 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 417,441.0 ns | 553.83 ns | 518.05 ns |         - |