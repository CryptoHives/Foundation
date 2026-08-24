| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |       141.0 ns |     0.02 ns |     0.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |       157.4 ns |     0.02 ns |     0.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |       194.0 ns |     0.21 ns |     0.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |       380.2 ns |     2.95 ns |     2.46 ns |         - |
|                                                   |              |                |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |       210.0 ns |     0.09 ns |     0.08 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |       235.2 ns |     0.03 ns |     0.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |       283.1 ns |     0.47 ns |     0.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |       591.5 ns |     4.20 ns |     3.93 ns |         - |
|                                                   |              |                |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |     1,093.2 ns |     0.42 ns |     0.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |     1,247.4 ns |     0.21 ns |     0.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |     1,449.9 ns |     1.44 ns |     1.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |     3,247.6 ns |    18.33 ns |    17.15 ns |         - |
|                                                   |              |                |             |             |           |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |     1,326.0 ns |     0.25 ns |     0.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |     1,736.6 ns |    37.42 ns |   104.32 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |     3,501.4 ns |    15.47 ns |    13.71 ns |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |     5,478.7 ns |     3.61 ns |     3.20 ns |         - |
|                                                   |              |                |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |    40,920.0 ns |    21.28 ns |    17.77 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |    47,050.8 ns |    79.35 ns |    66.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |    54,106.9 ns |    92.35 ns |    81.87 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |   134,826.6 ns |    72.08 ns |    63.90 ns |         - |
|                                                   |              |                |             |             |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        |   653,071.3 ns |   515.11 ns |   430.14 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        |   753,029.8 ns |   458.74 ns |   406.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        |   864,398.2 ns | 2,712.93 ns | 2,404.94 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 2,158,806.5 ns | 1,537.59 ns | 1,283.96 ns |         - |