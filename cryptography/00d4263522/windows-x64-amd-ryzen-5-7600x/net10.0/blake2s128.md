| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     157.6 ns |   0.33 ns |   0.31 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     158.5 ns |   0.39 ns |   0.34 ns |   8,059 B |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     159.6 ns |   3.15 ns |   3.99 ns |   7,658 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     160.5 ns |   0.30 ns |   0.26 ns |   8,723 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     160.8 ns |   0.61 ns |   0.57 ns |   5,136 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     161.1 ns |   0.14 ns |   0.11 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     229.3 ns |   0.79 ns |   0.74 ns |   7,631 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     238.4 ns |   0.47 ns |   0.39 ns |   8,703 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     240.4 ns |   0.40 ns |   0.38 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     241.4 ns |   1.92 ns |   1.60 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     242.6 ns |   0.36 ns |   0.32 ns |   5,113 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     245.8 ns |   0.50 ns |   0.47 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,150.1 ns |   6.92 ns |   6.48 ns |   7,885 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,233.4 ns |   2.52 ns |   2.11 ns |   8,726 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,238.6 ns |   6.57 ns |   6.14 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,238.9 ns |   2.66 ns |   2.49 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,255.0 ns |   1.90 ns |   1.68 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,265.7 ns |   2.39 ns |   2.24 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,224.5 ns |   5.61 ns |   4.38 ns |   7,615 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,310.2 ns |   5.76 ns |   5.10 ns |   8,704 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,311.7 ns |   5.26 ns |   4.92 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,318.5 ns |   2.99 ns |   2.50 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,335.8 ns |   1.15 ns |   0.96 ns |   5,120 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,351.1 ns |   2.44 ns |   2.17 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   9,100.8 ns |  33.91 ns |  31.72 ns |   7,886 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,749.6 ns |  65.16 ns |  57.76 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,783.0 ns |  42.10 ns |  35.16 ns |   8,716 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,906.4 ns |  18.06 ns |  16.01 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |  10,034.3 ns |  17.72 ns |  15.71 ns |   5,136 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |  10,161.1 ns |  19.67 ns |  18.40 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 145,292.7 ns | 797.99 ns | 707.40 ns |   7,887 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 155,208.8 ns | 725.02 ns | 678.18 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 156,233.0 ns | 725.67 ns | 605.97 ns |   8,717 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 158,154.4 ns | 342.89 ns | 320.74 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 160,623.0 ns | 224.09 ns | 187.13 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 162,437.4 ns | 267.25 ns | 249.99 ns |        NA |         - |