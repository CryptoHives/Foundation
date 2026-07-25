| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     155.1 ns |   0.34 ns |   0.32 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     155.7 ns |   0.31 ns |   0.29 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     158.0 ns |   0.19 ns |   0.17 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     158.7 ns |   0.34 ns |   0.28 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     158.7 ns |   0.25 ns |   0.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     159.3 ns |   0.27 ns |   0.24 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     228.9 ns |   0.59 ns |   0.52 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     235.1 ns |   0.26 ns |   0.21 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     235.6 ns |   0.15 ns |   0.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     239.4 ns |   0.45 ns |   0.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     241.7 ns |   0.45 ns |   0.42 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     242.7 ns |   3.62 ns |   3.39 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,150.4 ns |   4.94 ns |   4.38 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,208.5 ns |   1.92 ns |   1.60 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,222.2 ns |   2.53 ns |   2.25 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,235.5 ns |   1.67 ns |   1.48 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,239.1 ns |   4.66 ns |   4.13 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,245.6 ns |   0.88 ns |   0.73 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,217.4 ns |   3.58 ns |   2.99 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,286.7 ns |   3.29 ns |   2.92 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,302.7 ns |   2.74 ns |   2.14 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,314.7 ns |   4.31 ns |   3.82 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,319.0 ns |   2.17 ns |   2.03 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,329.5 ns |   1.67 ns |   1.56 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   9,086.6 ns |  26.71 ns |  22.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,642.5 ns |  10.14 ns |   8.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,747.2 ns |  25.57 ns |  22.67 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,786.2 ns |  23.45 ns |  21.93 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |   9,870.7 ns |  14.38 ns |  12.75 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |   9,950.4 ns |  12.16 ns |  10.16 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 144,694.6 ns | 491.98 ns | 460.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 154,016.6 ns | 232.20 ns | 217.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 154,860.9 ns | 521.13 ns | 487.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 156,541.4 ns | 353.87 ns | 331.01 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 158,376.2 ns | 322.33 ns | 285.74 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 159,316.4 ns | 312.84 ns | 292.63 ns |         - |