| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     155.2 ns |   0.17 ns |   0.14 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     156.5 ns |   0.46 ns |   0.43 ns |   7,658 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     157.9 ns |   0.73 ns |   0.65 ns |   5,124 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     158.5 ns |   1.00 ns |   0.94 ns |   8,725 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     158.8 ns |   0.23 ns |   0.21 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     158.8 ns |   0.47 ns |   0.44 ns |   8,072 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     230.6 ns |   1.71 ns |   1.43 ns |   7,633 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     237.4 ns |   4.09 ns |   3.82 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     240.3 ns |   4.14 ns |   3.46 ns |   5,115 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     240.5 ns |   1.53 ns |   1.43 ns |   8,706 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     241.3 ns |   4.69 ns |   4.16 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     245.1 ns |   0.75 ns |   0.70 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,149.0 ns |   4.46 ns |   4.17 ns |   7,887 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,229.7 ns |   2.27 ns |   2.12 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,234.3 ns |  21.36 ns |  17.83 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,238.2 ns |   7.47 ns |   6.24 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,250.4 ns |   4.52 ns |   4.23 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,256.1 ns |   6.19 ns |   5.17 ns |   5,134 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,234.6 ns |  24.56 ns |  21.77 ns |   7,619 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,308.0 ns |   4.10 ns |   3.64 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,310.4 ns |   4.77 ns |   4.46 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,312.0 ns |   5.08 ns |   4.50 ns |   8,708 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,329.5 ns |   2.92 ns |   2.28 ns |   5,117 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,338.9 ns |   3.20 ns |   2.99 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   9,083.6 ns |  31.21 ns |  26.06 ns |   7,888 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,707.3 ns |  35.45 ns |  27.68 ns |   8,715 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,765.8 ns |  17.78 ns |  16.63 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,765.9 ns |  34.91 ns |  29.15 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |  10,002.3 ns |  75.73 ns |  63.24 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |  10,023.5 ns |  18.47 ns |  16.38 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 145,122.8 ns | 604.48 ns | 565.43 ns |   7,886 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 155,333.3 ns | 699.42 ns | 654.24 ns |   8,725 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 156,407.6 ns | 444.91 ns | 394.40 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 156,571.4 ns | 672.03 ns | 524.67 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 158,732.9 ns | 660.24 ns | 551.33 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 160,455.1 ns | 496.16 ns | 464.10 ns |        NA |         - |