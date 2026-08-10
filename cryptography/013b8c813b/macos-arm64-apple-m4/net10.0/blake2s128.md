| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     141.2 ns |   0.09 ns |   0.08 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     157.0 ns |   0.09 ns |   0.08 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     196.4 ns |   0.10 ns |   0.10 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |     385.5 ns |   5.26 ns |   4.92 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     209.8 ns |   0.19 ns |   0.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     234.1 ns |   0.34 ns |   0.32 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     284.9 ns |   0.27 ns |   0.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |     589.2 ns |   5.74 ns |   5.37 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,090.5 ns |   1.27 ns |   1.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,238.7 ns |   4.91 ns |   4.59 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,450.5 ns |   1.06 ns |   0.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |   3,225.1 ns |   7.11 ns |   6.65 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,158.1 ns |   1.06 ns |   0.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,315.1 ns |   4.04 ns |   3.78 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,541.1 ns |   1.51 ns |   1.41 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |   3,428.7 ns |   6.77 ns |   6.33 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,651.1 ns |   7.63 ns |   7.14 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,869.8 ns |  28.20 ns |  26.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,489.6 ns |  10.28 ns |   9.62 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |  25,901.9 ns |   9.05 ns |   7.56 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 138,039.7 ns | 206.60 ns | 193.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 158,131.6 ns | 432.87 ns | 404.90 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 183,245.7 ns | 173.48 ns | 162.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 414,679.2 ns |  74.05 ns |  61.83 ns |         - |