| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     433.2 ns |     0.36 ns |     0.32 ns |   5,610 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128B         |     548.2 ns |     1.79 ns |     1.67 ns |   5,383 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     605.0 ns |     0.48 ns |     0.43 ns |   5,906 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128B         |     829.6 ns |     1.13 ns |     1.05 ns |   1,509 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     432.8 ns |     0.57 ns |     0.53 ns |   5,610 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 137B         |     547.7 ns |     1.53 ns |     1.36 ns |   5,383 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     610.9 ns |     1.85 ns |     1.64 ns |   5,898 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 137B         |     834.1 ns |     1.14 ns |     1.06 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   2,928.0 ns |     2.06 ns |     1.61 ns |   5,592 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1KB          |   3,700.7 ns |     5.33 ns |     4.72 ns |   5,365 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   3,967.2 ns |     4.37 ns |     3.87 ns |   8,210 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1KB          |   4,180.7 ns |     8.44 ns |     7.04 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   2,926.3 ns |     1.53 ns |     1.27 ns |   5,594 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 1025B        |   3,712.7 ns |     8.94 ns |     8.36 ns |   5,367 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   3,966.4 ns |     2.30 ns |     2.04 ns |   8,229 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 1025B        |   4,186.0 ns |    13.73 ns |    12.17 ns |   1,507 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |  19,962.9 ns |    33.62 ns |    29.80 ns |   5,598 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 8KB          |  25,684.1 ns |    77.17 ns |    72.19 ns |   5,371 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |  27,526.5 ns |    18.32 ns |    17.14 ns |   8,225 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 8KB          |  27,794.9 ns |   149.74 ns |   132.74 ns |   1,532 B |         - |
|                                                |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 316,160.7 ns |   385.13 ns |   321.60 ns |   5,592 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2   | 128KB        | 410,110.2 ns | 1,410.68 ns | 1,319.55 ns |   5,365 B |         - |
| TryComputeHash · SHAKE128 · OS Native          | 128KB        | 437,793.5 ns |   557.44 ns |   465.49 ns |   1,507 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 438,955.5 ns |   127.29 ns |   106.29 ns |   8,210 B |         - |