| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128B         |     139.7 ns |     0.39 ns |   0.37 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128B         |     155.3 ns |     0.59 ns |   0.55 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128B         |     196.6 ns |     0.21 ns |   0.18 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128B         |     389.3 ns |     6.76 ns |   6.32 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 137B         |     207.3 ns |     0.69 ns |   0.64 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 137B         |     230.2 ns |     0.65 ns |   0.61 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 137B         |     284.5 ns |     1.37 ns |   1.07 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 137B         |     591.7 ns |     5.89 ns |   5.50 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1KB          |   1,086.1 ns |     5.77 ns |   5.40 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1KB          |   1,215.4 ns |     6.48 ns |   6.07 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1KB          |   1,470.1 ns |     2.63 ns |   2.46 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1KB          |   3,225.5 ns |     2.89 ns |   2.41 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 1025B        |   1,151.3 ns |     5.50 ns |   5.15 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 1025B        |   1,300.5 ns |     6.18 ns |   5.78 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 1025B        |   1,556.2 ns |     4.99 ns |   4.67 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 1025B        |   3,469.4 ns |     9.10 ns |   7.60 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 8KB          |   8,585.2 ns |    52.71 ns |  49.30 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 8KB          |   9,755.4 ns |    48.32 ns |  45.20 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 8KB          |  11,616.9 ns |    19.73 ns |  18.45 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 8KB          |  26,318.5 ns |    19.93 ns |  18.65 ns |         - |
|                                                   |              |              |             |           |           |
| TryComputeHash · BLAKE2s-128 · Blake2Fast         | 128KB        | 137,050.7 ns |   576.60 ns | 539.35 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Scalar | 128KB        | 155,887.7 ns |   868.04 ns | 811.97 ns |         - |
| TryComputeHash · BLAKE2s-128 · BouncyCastle       | 128KB        | 185,352.5 ns |   348.15 ns | 325.66 ns |         - |
| TryComputeHash · BLAKE2s-128 · CryptoHives-Neon   | 128KB        | 420,691.3 ns | 1,019.57 ns | 953.70 ns |         - |