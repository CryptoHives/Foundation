| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128B         |     156.9 ns |     0.24 ns |     0.21 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     157.0 ns |     1.32 ns |     1.24 ns |   7,660 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     157.7 ns |     0.86 ns |     0.76 ns |   8,717 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128B         |     157.9 ns |     0.68 ns |     0.63 ns |   5,124 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128B         |     160.5 ns |     0.24 ns |     0.23 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     161.0 ns |     0.37 ns |     0.31 ns |   8,785 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     229.2 ns |     1.36 ns |     1.27 ns |   7,633 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 137B         |     235.6 ns |     0.15 ns |     0.14 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     236.1 ns |     1.96 ns |     1.83 ns |   8,782 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     236.8 ns |     2.42 ns |     2.27 ns |   8,702 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 137B         |     238.3 ns |     1.00 ns |     0.93 ns |   5,121 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 137B         |     240.5 ns |     0.23 ns |     0.21 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,156.7 ns |    16.17 ns |    14.33 ns |   7,644 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,206.5 ns |     9.73 ns |     8.63 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1KB          |   1,219.3 ns |     1.86 ns |     1.74 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1KB          |   1,229.9 ns |     3.33 ns |     3.11 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,233.3 ns |    11.09 ns |    10.37 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1KB          |   1,243.5 ns |     1.88 ns |     1.76 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,221.7 ns |    11.43 ns |    10.69 ns |   7,618 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,290.7 ns |     6.19 ns |     5.17 ns |   8,708 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 1025B        |   1,297.3 ns |     1.53 ns |     1.36 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 1025B        |   1,312.2 ns |     7.83 ns |     7.32 ns |   5,123 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,312.6 ns |    14.37 ns |    13.44 ns |   8,794 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 1025B        |   1,322.7 ns |     1.92 ns |     1.80 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   9,066.9 ns |    75.51 ns |    70.63 ns |   7,887 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,562.3 ns |    56.73 ns |    50.29 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 8KB          |   9,717.6 ns |    19.68 ns |    18.41 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |   9,735.9 ns |    87.03 ns |    72.68 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 8KB          |   9,831.4 ns |    68.45 ns |    64.03 ns |   5,128 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 8KB          |   9,900.7 ns |    19.71 ns |    18.44 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 145,198.5 ns | 1,759.64 ns | 1,559.87 ns |   7,889 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 152,915.1 ns |   816.95 ns |   724.20 ns |   8,719 B |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 155,091.9 ns | 1,322.35 ns | 1,236.93 ns |   8,785 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Ssse3  | 128KB        | 155,341.5 ns |   269.29 ns |   251.89 ns |        NA |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-AVX2   | 128KB        | 157,012.1 ns |   749.48 ns |   664.40 ns |   5,134 B |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Sse2   | 128KB        | 158,298.4 ns |   135.70 ns |   120.29 ns |        NA |         - |