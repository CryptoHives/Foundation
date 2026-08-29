| Description                                       | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     155.3 ns |     0.47 ns |     0.41 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     157.2 ns |     0.28 ns |     0.26 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     157.4 ns |     0.73 ns |     0.61 ns |   5,125 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     157.7 ns |     0.59 ns |     0.55 ns |   7,658 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     158.1 ns |     0.30 ns |     0.28 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     158.5 ns |     1.13 ns |     1.05 ns |   8,717 B |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     228.4 ns |     0.38 ns |     0.35 ns |   7,631 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     235.3 ns |     4.59 ns |     4.29 ns |   8,059 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     235.7 ns |     0.28 ns |     0.25 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     237.5 ns |     0.97 ns |     0.81 ns |   5,113 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     238.1 ns |     3.88 ns |     3.24 ns |   8,703 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     240.8 ns |     0.17 ns |     0.15 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,143.0 ns |     8.42 ns |     7.47 ns |   7,642 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,212.5 ns |     5.07 ns |     4.24 ns |   8,723 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,213.2 ns |     1.48 ns |     1.39 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,232.2 ns |     5.77 ns |     5.40 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,233.2 ns |    16.75 ns |    14.85 ns |   5,132 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,249.7 ns |     1.73 ns |     1.62 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,214.2 ns |     2.85 ns |     2.66 ns |   7,615 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,290.9 ns |    10.60 ns |     9.40 ns |   8,704 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,297.9 ns |     2.82 ns |     2.64 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,303.5 ns |     4.96 ns |     4.14 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,313.4 ns |     7.15 ns |     6.69 ns |   5,109 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,318.7 ns |     1.50 ns |     1.40 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   9,027.6 ns |    24.40 ns |    21.63 ns |   7,642 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,673.9 ns |    28.26 ns |    23.60 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,674.6 ns |    48.58 ns |    43.06 ns |   8,730 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,686.9 ns |    14.06 ns |    13.15 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |   9,848.7 ns |    42.78 ns |    37.92 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |   9,869.3 ns |    20.80 ns |    17.37 ns |        NA |         - |
|                                                   |              |              |             |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 145,616.8 ns | 2,033.62 ns | 1,698.16 ns |   7,880 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 153,980.2 ns |   469.91 ns |   439.55 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 155,372.0 ns |   170.18 ns |   159.19 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 155,859.8 ns | 2,452.27 ns | 2,047.76 ns |   8,713 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 156,815.8 ns |   778.23 ns |   727.96 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 157,959.8 ns |   187.55 ns |   166.26 ns |        NA |         - |