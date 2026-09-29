| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     249.9 ns |     0.69 ns |     0.61 ns |   5,590 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     319.7 ns |     0.67 ns |     0.62 ns |   5,099 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     331.0 ns |     0.90 ns |     0.84 ns |   4,094 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     383.2 ns |     1.05 ns |     0.98 ns |   5,865 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     421.2 ns |     2.12 ns |     1.98 ns |   1,486 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     249.6 ns |     1.30 ns |     1.22 ns |   5,590 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     319.4 ns |     0.84 ns |     0.74 ns |   5,115 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     330.7 ns |     1.04 ns |     0.97 ns |   4,094 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     382.6 ns |     1.52 ns |     1.42 ns |   5,856 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     423.0 ns |     1.27 ns |     1.12 ns |   1,486 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,648.2 ns |     5.61 ns |     5.25 ns |   5,572 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   2,082.2 ns |    14.10 ns |    13.19 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   2,136.5 ns |     6.82 ns |     6.38 ns |   5,081 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   2,190.2 ns |     7.28 ns |     6.81 ns |   4,076 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,535.5 ns |     9.87 ns |     9.23 ns |   8,164 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,649.9 ns |     7.30 ns |     6.83 ns |   5,574 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   2,102.8 ns |     8.89 ns |     8.31 ns |   1,486 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   2,138.3 ns |     6.74 ns |     6.31 ns |   5,083 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   2,194.1 ns |     7.19 ns |     6.72 ns |   4,078 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,546.6 ns |    10.68 ns |     9.99 ns |   8,166 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  11,407.6 ns |    46.88 ns |    39.15 ns |   5,578 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  13,695.9 ns |    44.87 ns |    41.97 ns |   1,501 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  14,873.6 ns |    26.50 ns |    24.79 ns |   5,087 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  15,179.6 ns |    50.93 ns |    47.64 ns |   4,082 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  17,527.0 ns |    42.98 ns |    38.10 ns |   8,170 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 182,012.4 ns |   651.61 ns |   609.52 ns |   5,572 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 217,035.7 ns |   723.55 ns |   641.41 ns |   1,511 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 236,726.1 ns |   381.20 ns |   356.58 ns |   5,081 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 242,023.9 ns |   392.55 ns |   367.20 ns |   4,076 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 282,355.5 ns | 1,105.39 ns | 1,033.99 ns |   8,178 B |         - |