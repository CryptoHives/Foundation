| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128B         |     141.6 ns |   0.59 ns |   0.55 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128B         |     155.6 ns |   0.59 ns |   0.55 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128B         |     199.3 ns |   0.84 ns |   0.79 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128B         |     383.4 ns |   1.12 ns |   0.93 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 137B         |     209.6 ns |   0.50 ns |   0.44 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 137B         |     231.3 ns |   0.63 ns |   0.59 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 137B         |     288.8 ns |   1.35 ns |   1.26 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 137B         |     589.6 ns |   1.44 ns |   1.35 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1KB          |   1,084.8 ns |   4.62 ns |   4.32 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1KB          |   1,224.5 ns |   5.10 ns |   4.77 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1KB          |   1,470.2 ns |   3.94 ns |   3.69 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1KB          |   3,264.7 ns |   7.58 ns |   7.09 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 1025B        |   1,150.9 ns |   5.55 ns |   5.20 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 1025B        |   1,300.6 ns |   4.77 ns |   4.46 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 1025B        |   1,561.8 ns |   2.69 ns |   2.52 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 1025B        |   3,468.8 ns |  12.54 ns |  11.73 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 8KB          |   8,582.3 ns |  29.55 ns |  26.19 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 8KB          |   9,752.9 ns |  26.48 ns |  22.11 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 8KB          |  11,597.5 ns |  46.22 ns |  43.23 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 8KB          |  26,304.4 ns |  61.47 ns |  57.50 ns |         - |
|                                                   |              |              |           |           |           |
| TryComputeHash · BLAKE2s-256 · Blake2Fast         | 128KB        | 136,875.3 ns | 502.88 ns | 470.39 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Scalar | 128KB        | 156,048.7 ns | 718.24 ns | 671.84 ns |         - |
| TryComputeHash · BLAKE2s-256 · BouncyCastle       | 128KB        | 185,106.1 ns | 375.00 ns | 332.43 ns |         - |
| TryComputeHash · BLAKE2s-256 · CryptoHives-Neon   | 128KB        | 421,315.6 ns | 506.18 ns | 448.72 ns |         - |