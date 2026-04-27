| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     154.5 ns |     0.70 ns |     0.62 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     154.7 ns |     0.36 ns |     0.30 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     154.9 ns |     0.17 ns |     0.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     157.6 ns |     0.35 ns |     0.31 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     159.9 ns |     0.22 ns |     0.20 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     161.6 ns |     0.51 ns |     0.48 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     233.4 ns |     0.84 ns |     0.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     234.0 ns |     0.79 ns |     0.70 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     234.8 ns |     0.14 ns |     0.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     240.3 ns |     0.32 ns |     0.30 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     245.1 ns |     1.31 ns |     1.23 ns |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     250.8 ns |     0.58 ns |     0.54 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,141.2 ns |     3.56 ns |     3.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,191.5 ns |    12.54 ns |    11.12 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,207.3 ns |     6.18 ns |     5.48 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,219.7 ns |     1.76 ns |     1.65 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,233.9 ns |     3.43 ns |     2.86 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,238.4 ns |     1.25 ns |     1.04 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,210.1 ns |     3.16 ns |     2.80 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,274.9 ns |     5.81 ns |     5.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,291.2 ns |     5.66 ns |     5.29 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,297.6 ns |     2.69 ns |     2.51 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,309.2 ns |     3.40 ns |     3.01 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,320.1 ns |     1.97 ns |     1.84 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   9,009.9 ns |    24.42 ns |    21.64 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,438.0 ns |    31.32 ns |    26.15 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,632.5 ns |    30.54 ns |    28.57 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |   9,648.3 ns |    41.08 ns |    38.42 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,714.1 ns |    24.31 ns |    22.74 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |   9,899.8 ns |     9.15 ns |     7.14 ns |         - |
|                                                   |              |              |             |             |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 143,803.8 ns |   337.48 ns |   281.81 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 151,225.6 ns |   585.27 ns |   547.46 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 153,660.5 ns |   440.59 ns |   412.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 154,723.6 ns | 1,340.80 ns | 1,188.59 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 154,973.5 ns |   268.47 ns |   251.13 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 158,363.6 ns |   389.87 ns |   364.69 ns |         - |