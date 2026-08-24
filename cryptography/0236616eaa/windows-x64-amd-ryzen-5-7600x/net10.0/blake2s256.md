| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     156.4 ns |   0.21 ns |   0.20 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     156.8 ns |   2.78 ns |   2.32 ns |   7,658 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     158.7 ns |   0.37 ns |   0.33 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     159.2 ns |   0.28 ns |   0.25 ns |   5,134 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     159.5 ns |   0.32 ns |   0.30 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     160.4 ns |   0.15 ns |   0.14 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     229.6 ns |   0.68 ns |   0.63 ns |   7,633 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     236.4 ns |   0.25 ns |   0.23 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     237.0 ns |   0.60 ns |   0.53 ns |   8,706 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     241.0 ns |   3.07 ns |   2.39 ns |   5,115 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     242.5 ns |   0.37 ns |   0.33 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     244.0 ns |   1.02 ns |   0.90 ns |   8,072 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,145.2 ns |   3.10 ns |   2.58 ns |   7,645 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,213.5 ns |   2.14 ns |   1.90 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,223.8 ns |   2.00 ns |   1.88 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,233.6 ns |   3.93 ns |   3.67 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,246.6 ns |   1.63 ns |   1.53 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,250.9 ns |   7.51 ns |   6.66 ns |   5,124 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,213.9 ns |   2.62 ns |   2.32 ns |   7,618 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,286.9 ns |   1.88 ns |   1.66 ns |   8,708 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,302.9 ns |   1.45 ns |   1.29 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,304.4 ns |   3.41 ns |   2.85 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,318.6 ns |   2.48 ns |   2.20 ns |   5,113 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,328.0 ns |   1.50 ns |   1.33 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   9,094.8 ns | 104.49 ns |  87.25 ns |   7,644 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,662.1 ns |  32.00 ns |  26.72 ns |   8,715 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,679.0 ns |  29.90 ns |  27.97 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,754.9 ns |  13.27 ns |  11.76 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |   9,876.6 ns |  28.28 ns |  25.07 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |   9,948.5 ns |  24.62 ns |  19.22 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 144,356.7 ns | 333.66 ns | 312.11 ns |   7,886 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 154,404.8 ns | 280.01 ns | 233.82 ns |   8,729 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 155,252.6 ns | 437.20 ns | 387.56 ns |   8,072 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 156,090.1 ns | 227.84 ns | 201.98 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 157,586.9 ns | 292.41 ns | 273.52 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 159,351.1 ns | 133.07 ns | 124.47 ns |        NA |         - |