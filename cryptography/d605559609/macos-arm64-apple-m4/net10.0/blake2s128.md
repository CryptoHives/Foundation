| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     141.5 ns |     0.53 ns |     0.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     158.1 ns |     1.18 ns |     0.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     194.7 ns |     1.07 ns |     0.95 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |     384.7 ns |     4.38 ns |     4.10 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     210.2 ns |     0.22 ns |     0.21 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     235.8 ns |     0.49 ns |     0.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     283.9 ns |     0.88 ns |     0.78 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |     594.8 ns |     8.50 ns |     7.53 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,093.8 ns |     0.35 ns |     0.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,248.1 ns |     0.34 ns |     0.28 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,449.9 ns |     1.35 ns |     1.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |   3,236.0 ns |    24.15 ns |    22.59 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,161.3 ns |     0.28 ns |     0.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,326.2 ns |     0.24 ns |     0.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,542.5 ns |     2.54 ns |     2.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |   3,439.6 ns |    24.93 ns |    23.32 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,682.1 ns |     2.96 ns |     2.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,965.6 ns |     3.73 ns |     3.11 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,487.1 ns |    13.21 ns |    11.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |  25,913.9 ns |    15.91 ns |    12.42 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 138,451.6 ns |    96.53 ns |    80.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 159,587.9 ns |    50.82 ns |    42.44 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 183,313.8 ns |   270.11 ns |   210.89 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 416,518.6 ns | 2,974.65 ns | 2,782.49 ns |         - |