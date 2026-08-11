| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     143.4 ns |     2.52 ns |     2.36 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     159.9 ns |     2.34 ns |     2.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     196.4 ns |     3.31 ns |     3.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |     383.3 ns |     4.95 ns |     4.63 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     213.1 ns |     2.57 ns |     2.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     237.9 ns |     2.62 ns |     2.45 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     283.4 ns |     0.77 ns |     0.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |     587.8 ns |     3.82 ns |     2.98 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,107.6 ns |    19.76 ns |    18.48 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,261.0 ns |    18.91 ns |    17.69 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,467.7 ns |    23.21 ns |    21.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |   3,247.9 ns |    37.66 ns |    35.23 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,175.6 ns |    20.96 ns |    19.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,341.9 ns |    18.42 ns |    17.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,562.9 ns |    24.73 ns |    23.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |   3,453.4 ns |    36.47 ns |    34.11 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,783.1 ns |   140.06 ns |   131.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |  10,065.1 ns |   152.01 ns |   142.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,611.0 ns |   173.91 ns |   162.68 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |  26,178.0 ns |   302.02 ns |   282.51 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 138,955.1 ns |   122.82 ns |    95.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 161,274.0 ns | 2,279.60 ns | 2,132.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 185,640.8 ns | 2,967.72 ns | 2,776.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 419,340.9 ns | 4,359.12 ns | 4,077.53 ns |         - |