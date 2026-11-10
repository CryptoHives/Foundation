| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     429.5 ns |     0.41 ns |     0.36 ns |   5,605 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128B         |     547.0 ns |     2.09 ns |     1.96 ns |   5,378 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     609.1 ns |     1.51 ns |     1.42 ns |   5,903 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128B         |     836.3 ns |     1.26 ns |     1.18 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     835.5 ns |     1.00 ns |     0.89 ns |   5,588 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 137B         |   1,064.0 ns |     3.73 ns |     3.31 ns |   5,365 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |   1,148.4 ns |     1.17 ns |     1.09 ns |   7,256 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 137B         |   1,366.8 ns |     4.97 ns |     4.41 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   3,315.4 ns |     3.31 ns |     2.93 ns |   5,593 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1KB          |   4,194.8 ns |    14.24 ns |    13.32 ns |   5,386 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   4,466.2 ns |     6.13 ns |     5.73 ns |   7,260 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1KB          |   4,703.8 ns |    11.11 ns |     9.85 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   3,312.4 ns |     2.92 ns |     2.59 ns |   5,615 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1025B        |   4,200.2 ns |    11.10 ns |    10.38 ns |   5,366 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   4,458.1 ns |     4.88 ns |     4.33 ns |   7,226 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1025B        |   4,698.7 ns |    10.71 ns |    10.02 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |  24,648.7 ns |    47.25 ns |    41.89 ns |   5,592 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 8KB          |  31,761.2 ns |   161.80 ns |   151.35 ns |   5,363 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |  33,600.2 ns |    14.83 ns |    12.39 ns |   7,220 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 8KB          |  34,011.9 ns |    77.82 ns |    68.99 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 387,954.6 ns |   329.55 ns |   292.14 ns |   5,591 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128KB        | 502,000.0 ns | 1,260.47 ns | 1,179.05 ns |   5,364 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 529,695.2 ns |   626.35 ns |   585.89 ns |   7,245 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128KB        | 533,183.6 ns | 1,039.82 ns |   921.77 ns |   1,536 B |         - |