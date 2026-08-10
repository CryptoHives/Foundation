| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128B         |     153.7 ns |   0.36 ns |   0.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128B         |     154.3 ns |   0.16 ns |   0.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     154.6 ns |   0.61 ns |   0.54 ns |         - |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     156.4 ns |   0.30 ns |   0.26 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128B         |     157.8 ns |   0.19 ns |   0.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     159.7 ns |   1.71 ns |   1.51 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     225.3 ns |   0.37 ns |   0.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 137B         |     232.2 ns |   0.38 ns |   0.34 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     233.3 ns |   0.93 ns |   0.83 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 137B         |     234.3 ns |   0.29 ns |   0.27 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 137B         |     239.4 ns |   0.21 ns |   0.19 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     240.9 ns |   1.02 ns |   0.95 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,133.9 ns |   4.35 ns |   4.07 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,180.9 ns |   2.30 ns |   2.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1KB          |   1,201.5 ns |   3.62 ns |   3.21 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1KB          |   1,217.9 ns |   3.01 ns |   2.82 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,232.1 ns |  24.04 ns |  35.24 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1KB          |   1,240.2 ns |   1.47 ns |   1.37 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,204.6 ns |   3.37 ns |   3.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,268.5 ns |   2.79 ns |   2.47 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 1025B        |   1,284.1 ns |   3.21 ns |   2.84 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,292.4 ns |   3.64 ns |   3.22 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 1025B        |   1,293.2 ns |   1.48 ns |   1.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 1025B        |   1,320.8 ns |   1.88 ns |   1.76 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,933.0 ns |  28.70 ns |  23.97 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,500.9 ns |  28.12 ns |  26.31 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 8KB          |   9,621.7 ns |  15.59 ns |  13.02 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |   9,625.0 ns |  52.34 ns |  43.70 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 8KB          |   9,687.1 ns |  15.12 ns |  13.40 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 8KB          |   9,893.4 ns |  17.26 ns |  16.14 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 142,762.6 ns | 527.86 ns | 467.93 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 150,485.6 ns | 497.35 ns | 465.23 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 152,554.1 ns | 489.75 ns | 458.11 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-AVX2   | 128KB        | 153,668.1 ns | 346.55 ns | 324.16 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Ssse3  | 128KB        | 155,376.1 ns | 850.01 ns | 709.80 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Sse2   | 128KB        | 158,099.0 ns | 192.69 ns | 180.24 ns |         - |