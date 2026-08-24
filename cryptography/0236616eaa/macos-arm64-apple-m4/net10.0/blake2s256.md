| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     665.7 ns |   0.47 ns |   0.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     744.6 ns |   0.19 ns |   0.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     927.8 ns |   4.77 ns |   4.23 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |   1,973.2 ns |  26.87 ns |  22.44 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     993.0 ns |   0.23 ns |   0.19 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |   1,112.4 ns |   0.94 ns |   0.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |   1,348.7 ns |   0.94 ns |   0.83 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |   3,022.7 ns |  11.86 ns |  10.51 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   5,165.9 ns |   3.37 ns |   3.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   5,888.0 ns |   3.24 ns |   2.87 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   6,862.2 ns |  11.45 ns |  10.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |  16,755.6 ns |  47.73 ns |  42.31 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,159.4 ns |   1.63 ns |   1.53 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,327.4 ns |  16.93 ns |  28.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,541.1 ns |   0.75 ns |   0.66 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |  17,783.7 ns |  10.51 ns |   8.78 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,671.8 ns |   1.79 ns |   1.58 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,951.2 ns |   5.24 ns |   4.90 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,472.2 ns |  17.05 ns |  14.24 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  25,901.3 ns |   6.63 ns |   6.20 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 138,422.4 ns |  63.64 ns |  59.53 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 159,572.6 ns |  47.81 ns |  44.72 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 183,331.1 ns | 251.84 ns | 235.57 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 414,634.9 ns |  63.32 ns |  52.87 ns |         - |