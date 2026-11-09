| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     319.9 ns |     0.72 ns |     0.64 ns |   5,610 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128B         |     405.4 ns |     0.53 ns |     0.47 ns |   5,383 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     448.4 ns |     0.43 ns |     0.36 ns |   5,915 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128B         |     619.5 ns |     1.36 ns |     1.21 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     320.6 ns |     0.65 ns |     0.61 ns |   5,629 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 137B         |     405.6 ns |     0.82 ns |     0.69 ns |   5,402 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     447.0 ns |     0.78 ns |     0.73 ns |   5,910 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 137B         |     621.3 ns |     1.80 ns |     1.68 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   2,247.7 ns |    16.83 ns |    15.74 ns |   5,592 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1KB          |   2,816.5 ns |    46.13 ns |    43.15 ns |   5,365 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   3,020.1 ns |    42.19 ns |    39.47 ns |   8,208 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1KB          |   3,093.6 ns |     6.30 ns |     5.89 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   2,235.6 ns |    33.81 ns |    31.62 ns |   5,594 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1025B        |   2,826.7 ns |    31.19 ns |    29.18 ns |   5,367 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   3,025.7 ns |    38.10 ns |    35.64 ns |   8,228 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1025B        |   3,180.0 ns |    44.79 ns |    41.89 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |  15,145.2 ns |   235.03 ns |   219.85 ns |   5,598 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 8KB          |  19,603.3 ns |   262.92 ns |   245.94 ns |   5,392 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |  20,999.0 ns |   296.71 ns |   277.54 ns |   8,210 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 8KB          |  21,052.3 ns |   359.96 ns |   336.71 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 240,822.3 ns | 3,417.06 ns | 3,196.32 ns |   5,592 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128KB        | 312,052.7 ns | 5,326.50 ns | 4,982.41 ns |   5,365 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128KB        | 334,558.3 ns | 1,841.48 ns | 1,722.52 ns |   1,532 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 335,796.3 ns | 4,209.76 ns | 3,937.81 ns |   8,210 B |         - |