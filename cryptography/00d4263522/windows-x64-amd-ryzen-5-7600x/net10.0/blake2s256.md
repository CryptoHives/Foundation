| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     157.1 ns |   0.59 ns |   0.55 ns |   7,659 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     159.1 ns |   0.21 ns |   0.20 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     160.5 ns |   0.29 ns |   0.26 ns |   8,717 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     162.2 ns |   0.47 ns |   0.42 ns |   5,127 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     162.8 ns |   0.35 ns |   0.29 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     163.0 ns |   0.20 ns |   0.19 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     235.6 ns |   4.62 ns |   5.32 ns |   7,633 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     240.2 ns |   2.05 ns |   1.82 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     240.5 ns |   0.77 ns |   0.69 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     242.5 ns |   0.61 ns |   0.54 ns |   8,706 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     244.2 ns |   0.55 ns |   0.52 ns |   5,115 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     246.8 ns |   0.53 ns |   0.44 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,161.8 ns |   9.28 ns |   7.75 ns |   7,645 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,232.9 ns |   3.07 ns |   2.87 ns |   8,723 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,241.3 ns |   2.06 ns |   1.92 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,251.3 ns |  16.27 ns |  16.71 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,264.4 ns |   3.30 ns |   2.76 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,275.3 ns |   3.26 ns |   3.05 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,226.0 ns |   6.61 ns |   6.19 ns |   7,619 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,309.1 ns |   4.01 ns |   3.56 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,313.2 ns |   3.15 ns |   2.63 ns |   8,721 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,323.4 ns |   2.56 ns |   2.27 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,341.5 ns |   2.78 ns |   2.60 ns |   5,117 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,359.6 ns |   2.90 ns |   2.71 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   9,233.0 ns | 147.90 ns | 138.35 ns |   7,887 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,785.2 ns |  46.46 ns |  43.46 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,862.4 ns | 187.52 ns | 175.41 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,923.6 ns |  29.37 ns |  27.47 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |  10,061.0 ns |  21.91 ns |  19.43 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |  10,162.6 ns |  18.65 ns |  17.44 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 145,573.2 ns | 910.66 ns | 760.44 ns |   7,882 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 156,630.0 ns | 813.63 ns | 679.42 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 157,141.4 ns | 562.23 ns | 438.95 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 158,933.8 ns | 291.21 ns | 272.40 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 160,957.5 ns | 226.48 ns | 189.12 ns |   5,138 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 163,164.5 ns | 402.44 ns | 376.44 ns |        NA |         - |