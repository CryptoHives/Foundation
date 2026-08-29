| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     141.2 ns |   0.05 ns |   0.04 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     157.6 ns |   0.03 ns |   0.02 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     197.5 ns |   0.31 ns |   0.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |     385.1 ns |   3.49 ns |   3.10 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     210.3 ns |   0.04 ns |   0.03 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     236.0 ns |   0.11 ns |   0.09 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     286.0 ns |   0.52 ns |   0.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |     583.5 ns |   5.16 ns |   4.58 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,095.3 ns |   0.77 ns |   0.64 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,248.4 ns |   0.64 ns |   0.53 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,455.5 ns |   1.43 ns |   1.12 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |   3,232.0 ns |  19.23 ns |  17.05 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,162.8 ns |   1.68 ns |   1.49 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,326.2 ns |   0.36 ns |   0.30 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,544.2 ns |   1.20 ns |   0.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |   3,421.8 ns |   7.93 ns |   6.19 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,647.6 ns |  13.66 ns |  12.11 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,974.8 ns |   5.95 ns |   4.97 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,597.7 ns |  85.01 ns |  70.99 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  25,915.0 ns |  14.87 ns |  11.61 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 138,403.4 ns |  69.87 ns |  65.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 159,416.4 ns | 124.01 ns | 109.93 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 183,132.1 ns | 163.03 ns | 136.14 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 414,679.0 ns | 102.88 ns |  91.20 ns |         - |