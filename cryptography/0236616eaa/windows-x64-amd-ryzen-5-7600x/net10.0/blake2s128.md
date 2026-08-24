| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     155.3 ns |   0.17 ns |   0.14 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     155.7 ns |   0.55 ns |   0.49 ns |   7,659 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     157.3 ns |   1.62 ns |   1.51 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     158.1 ns |   0.18 ns |   0.15 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     159.3 ns |   0.20 ns |   0.18 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     159.5 ns |   0.31 ns |   0.28 ns |   8,723 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     227.5 ns |   2.99 ns |   2.49 ns |   7,631 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     236.0 ns |   0.41 ns |   0.34 ns |   8,700 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     236.7 ns |   0.17 ns |   0.16 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     239.8 ns |   0.35 ns |   0.31 ns |   5,123 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     241.1 ns |   0.25 ns |   0.22 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     242.2 ns |   0.80 ns |   0.67 ns |   8,071 B |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,142.8 ns |   2.47 ns |   2.06 ns |   7,885 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,206.2 ns |   3.56 ns |   3.16 ns |   8,723 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,220.6 ns |   1.06 ns |   0.88 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,231.3 ns |   3.61 ns |   3.38 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,237.6 ns |   3.93 ns |   3.28 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,247.8 ns |   1.50 ns |   1.40 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,216.4 ns |   4.32 ns |   4.04 ns |   7,615 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,288.4 ns |   2.66 ns |   2.22 ns |   8,710 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,298.3 ns |   1.14 ns |   1.06 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,304.0 ns |   4.74 ns |   4.44 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,318.3 ns |   3.21 ns |   2.85 ns |   5,113 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,389.6 ns |   1.39 ns |   1.16 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   9,046.1 ns |  25.02 ns |  22.18 ns |   7,643 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,715.2 ns |  33.38 ns |  27.87 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,748.2 ns |   8.34 ns |   7.80 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,817.9 ns |  18.05 ns |  15.07 ns |   8,723 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |   9,886.6 ns |  38.55 ns |  34.17 ns |   5,132 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |   9,991.6 ns |   6.76 ns |   5.99 ns |        NA |         - |
|                                                   |              |              |           |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 144,476.1 ns | 456.46 ns | 404.64 ns |   7,880 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 153,377.7 ns | 426.37 ns | 377.97 ns |   8,717 B |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 155,995.8 ns | 831.17 ns | 736.81 ns |   8,071 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 156,103.4 ns | 292.74 ns | 273.83 ns |        NA |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 157,944.2 ns | 251.31 ns | 222.78 ns |   5,126 B |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 159,424.0 ns | 190.81 ns | 178.49 ns |        NA |         - |