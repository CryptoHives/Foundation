| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     155.6 ns |     0.20 ns |     0.18 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     156.8 ns |     1.01 ns |     0.90 ns |   7,659 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     157.5 ns |     1.22 ns |     1.14 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     157.5 ns |     1.07 ns |     1.00 ns |   8,717 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     157.6 ns |     0.44 ns |     0.41 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     158.3 ns |     0.36 ns |     0.32 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     229.3 ns |     1.43 ns |     1.34 ns |   7,631 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     235.6 ns |     1.41 ns |     1.32 ns |   8,704 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     236.1 ns |     0.37 ns |     0.34 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     236.5 ns |     2.60 ns |     2.43 ns |   8,782 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     237.4 ns |     1.72 ns |     1.53 ns |   5,112 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     239.7 ns |     0.38 ns |     0.36 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,147.2 ns |    10.26 ns |     9.09 ns |   7,885 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,207.6 ns |     6.27 ns |     5.87 ns |   8,713 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,216.3 ns |     1.31 ns |     1.16 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,228.2 ns |     6.80 ns |     6.36 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,230.4 ns |    10.56 ns |     9.87 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,241.3 ns |     2.68 ns |     2.51 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,220.9 ns |    12.22 ns |    11.43 ns |   7,614 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,281.7 ns |     6.29 ns |     5.58 ns |   8,704 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,296.8 ns |     2.11 ns |     1.97 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,306.0 ns |     9.96 ns |     9.32 ns |   8,794 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,309.6 ns |     4.37 ns |     3.87 ns |   5,113 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,321.1 ns |     2.26 ns |     2.11 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   9,060.1 ns |    68.12 ns |    56.88 ns |   7,642 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,704.5 ns |    73.64 ns |    68.89 ns |   8,716 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,713.2 ns |     9.71 ns |     9.08 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |   9,786.9 ns |    36.48 ns |    30.46 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,796.4 ns |   109.48 ns |    97.05 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |   9,895.4 ns |    26.18 ns |    24.49 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 145,108.6 ns | 1,790.13 ns | 1,494.84 ns |   7,885 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 152,996.9 ns |   596.69 ns |   498.26 ns |   8,717 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 154,358.3 ns | 1,089.85 ns |   966.12 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 155,306.6 ns |   216.46 ns |   202.48 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 156,652.7 ns |   952.71 ns |   795.55 ns |   5,132 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 158,361.3 ns |   334.45 ns |   312.84 ns |        NA |         - |