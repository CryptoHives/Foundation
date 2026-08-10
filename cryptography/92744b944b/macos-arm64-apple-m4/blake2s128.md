| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     140.6 ns |     0.63 ns |   0.55 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     154.3 ns |     0.45 ns |   0.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     196.7 ns |     0.22 ns |   0.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |     383.9 ns |     4.88 ns |   4.56 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     207.9 ns |     0.30 ns |   0.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     230.6 ns |     0.56 ns |   0.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     284.5 ns |     0.63 ns |   0.49 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |     590.6 ns |     7.38 ns |   6.16 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,080.0 ns |     4.06 ns |   3.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,223.7 ns |    19.91 ns |  16.63 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,451.3 ns |     1.44 ns |   1.12 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |   3,221.1 ns |     4.21 ns |   3.94 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,146.3 ns |     5.41 ns |   4.22 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,295.7 ns |     4.94 ns |   4.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,539.9 ns |     1.91 ns |   1.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |   3,429.5 ns |    10.13 ns |   8.46 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,587.0 ns |    38.03 ns |  35.58 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,699.9 ns |    29.68 ns |  27.76 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,455.3 ns |    15.77 ns |  13.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |  25,915.5 ns |    19.26 ns |  16.08 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 136,672.0 ns |   656.60 ns | 582.06 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 155,274.1 ns |   969.16 ns | 906.55 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 183,352.4 ns |   250.65 ns | 222.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 415,383.0 ns | 1,089.13 ns | 909.47 ns |         - |