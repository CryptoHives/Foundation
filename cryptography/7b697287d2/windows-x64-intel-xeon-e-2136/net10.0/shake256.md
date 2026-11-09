| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     317.8 ns |   1.28 ns |   1.20 ns |   5,605 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128B         |     404.2 ns |   0.69 ns |   0.64 ns |   5,378 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     448.7 ns |   0.84 ns |   0.74 ns |   5,903 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128B         |     629.3 ns |  10.37 ns |   9.70 ns |   1,536 B |         - |
|                                                |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     616.8 ns |   1.95 ns |   1.73 ns |   5,592 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 137B         |     790.7 ns |   2.20 ns |   2.06 ns |   5,365 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     847.8 ns |   1.53 ns |   1.43 ns |   7,282 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 137B         |   1,012.7 ns |   2.76 ns |   2.45 ns |   1,536 B |         - |
|                                                |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   2,456.4 ns |   6.56 ns |   6.13 ns |   5,593 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1KB          |   3,124.5 ns |   4.78 ns |   4.47 ns |   5,366 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   3,294.2 ns |   6.46 ns |   6.05 ns |   7,226 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1KB          |   3,475.9 ns |   7.71 ns |   7.22 ns |   1,536 B |         - |
|                                                |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   2,455.7 ns |   4.08 ns |   3.62 ns |   5,593 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1025B        |   3,120.3 ns |   6.17 ns |   5.47 ns |   5,386 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   3,342.3 ns |   4.90 ns |   4.34 ns |   7,237 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1025B        |   3,482.2 ns |   7.55 ns |   5.89 ns |   1,536 B |         - |
|                                                |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |  18,201.4 ns |  25.75 ns |  22.82 ns |   5,592 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 8KB          |  23,660.1 ns |  76.09 ns |  71.18 ns |   5,363 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |  24,862.4 ns |  66.69 ns |  59.12 ns |   7,220 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 8KB          |  25,126.3 ns |  49.71 ns |  46.50 ns |   1,536 B |         - |
|                                                |              |              |           |           |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 286,552.2 ns | 632.27 ns | 527.98 ns |   5,591 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128KB        | 373,577.5 ns | 834.70 ns | 739.94 ns |   5,364 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 392,602.7 ns | 735.17 ns | 687.68 ns |   7,224 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128KB        | 393,211.6 ns | 621.08 ns | 550.57 ns |   1,536 B |         - |