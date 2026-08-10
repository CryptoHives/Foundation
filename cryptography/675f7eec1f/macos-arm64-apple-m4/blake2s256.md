| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     142.7 ns |     0.42 ns |   0.40 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     158.8 ns |     0.29 ns |   0.27 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     198.5 ns |     0.50 ns |   0.47 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |     382.4 ns |     1.87 ns |   1.56 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     211.7 ns |     0.41 ns |   0.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     237.1 ns |     0.27 ns |   0.25 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     288.8 ns |     0.38 ns |   0.36 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |     583.4 ns |     0.92 ns |   0.81 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,100.3 ns |     0.62 ns |   0.55 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,252.9 ns |     3.67 ns |   3.43 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,462.7 ns |     3.91 ns |   3.66 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |   3,241.0 ns |     6.73 ns |   6.30 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,168.8 ns |     0.53 ns |   0.49 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,333.1 ns |     2.99 ns |   2.80 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,552.3 ns |     2.59 ns |   2.42 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |   3,439.1 ns |     1.52 ns |   1.35 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,730.1 ns |     3.83 ns |   3.58 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |  10,015.0 ns |    19.02 ns |  17.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,562.1 ns |    14.80 ns |  13.85 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  26,066.6 ns |    41.75 ns |  37.01 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 139,135.5 ns |   298.14 ns | 278.88 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 160,313.7 ns |   130.16 ns | 115.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 184,428.5 ns |   259.42 ns | 242.66 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 417,265.3 ns | 1,061.41 ns | 992.84 ns |         - |