| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     435.4 ns |     1.28 ns |     1.20 ns |   5,625 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128B         |     546.8 ns |     2.46 ns |     2.30 ns |   5,378 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     612.0 ns |     2.59 ns |     2.16 ns |   5,903 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128B         |     846.3 ns |     3.43 ns |     3.04 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     837.8 ns |     2.75 ns |     2.58 ns |   5,588 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 137B         |   1,062.5 ns |     4.77 ns |     4.46 ns |   5,365 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |   1,142.8 ns |     0.91 ns |     0.85 ns |   7,250 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 137B         |   1,372.4 ns |     8.30 ns |     6.93 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   3,316.6 ns |    10.49 ns |     9.81 ns |   5,593 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1KB          |   4,367.2 ns |    17.61 ns |    16.47 ns |   5,366 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   4,454.3 ns |     6.14 ns |     5.75 ns |   7,221 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1KB          |   4,718.6 ns |    30.47 ns |    28.50 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   3,317.5 ns |    10.49 ns |     9.81 ns |   5,593 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 1025B        |   4,316.8 ns |     9.78 ns |     9.14 ns |   5,366 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   4,464.4 ns |     5.81 ns |     5.15 ns |   7,249 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 1025B        |   4,695.8 ns |     2.60 ns |     2.30 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |  24,659.6 ns |    68.69 ns |    60.89 ns |   5,590 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 8KB          |  31,675.9 ns |   157.64 ns |   147.45 ns |   5,363 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |  33,611.6 ns |    27.72 ns |    24.58 ns |   7,220 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 8KB          |  34,272.2 ns |   283.91 ns |   265.57 ns |   1,536 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 389,722.0 ns | 1,356.31 ns | 1,268.69 ns |   5,591 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2   | 128KB        | 529,810.6 ns | 2,490.41 ns | 2,329.53 ns |   5,364 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 529,859.3 ns |   588.54 ns |   550.52 ns |   7,246 B |         - |
| TryComputeHash · SHAKE256 · OS Native          | 128KB        | 536,079.4 ns | 5,086.97 ns | 4,758.35 ns |   1,536 B |         - |