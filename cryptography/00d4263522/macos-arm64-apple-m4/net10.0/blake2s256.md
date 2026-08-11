| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     142.8 ns |     0.34 ns |     0.26 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     159.3 ns |     2.26 ns |     2.11 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     199.3 ns |     3.04 ns |     2.84 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |     388.7 ns |     6.71 ns |     6.28 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     213.6 ns |     2.41 ns |     2.25 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     238.1 ns |     2.66 ns |     2.48 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     289.7 ns |     5.72 ns |     5.35 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |     583.3 ns |     3.22 ns |     2.51 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,097.9 ns |     0.68 ns |     0.53 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,261.7 ns |    19.18 ns |    17.94 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,471.2 ns |    23.92 ns |    22.38 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |   3,255.8 ns |    35.68 ns |    33.37 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,165.7 ns |     0.47 ns |     0.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,341.0 ns |    19.77 ns |    18.50 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,564.7 ns |    22.89 ns |    21.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |   3,453.5 ns |    35.10 ns |    32.83 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,698.0 ns |    21.85 ns |    17.06 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |  10,061.8 ns |   135.10 ns |   119.77 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,653.7 ns |   196.04 ns |   183.37 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  26,179.0 ns |   274.00 ns |   256.30 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 138,967.6 ns |   520.54 ns |   406.41 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 161,121.4 ns | 2,231.69 ns | 1,978.34 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 185,385.2 ns | 2,836.14 ns | 2,652.93 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 418,972.2 ns | 3,978.13 ns | 3,721.14 ns |         - |