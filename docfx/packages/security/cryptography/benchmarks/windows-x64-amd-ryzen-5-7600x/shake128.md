| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     211.5 ns |     0.77 ns |     0.68 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     284.3 ns |     0.87 ns |     0.77 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     295.4 ns |     1.09 ns |     0.96 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     334.7 ns |     2.04 ns |     1.90 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     372.0 ns |     2.15 ns |     1.90 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     212.5 ns |     0.83 ns |     0.74 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     283.9 ns |     0.78 ns |     0.73 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     294.8 ns |     0.60 ns |     0.57 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     334.9 ns |     1.67 ns |     1.39 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     358.3 ns |     1.48 ns |     1.31 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,409.0 ns |     8.41 ns |     7.46 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   1,784.6 ns |    10.11 ns |     8.44 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   1,911.5 ns |     4.55 ns |     4.26 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   1,959.1 ns |     5.34 ns |     5.00 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,174.9 ns |    13.93 ns |    13.03 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,412.8 ns |    12.84 ns |    11.38 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   1,778.9 ns |     9.43 ns |     8.36 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   1,911.1 ns |     7.77 ns |     6.88 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   1,959.2 ns |     7.52 ns |     7.04 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,181.5 ns |    10.44 ns |     8.72 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |   9,781.8 ns |    74.87 ns |    62.52 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  11,786.7 ns |    60.14 ns |    50.22 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  13,256.4 ns |    34.45 ns |    30.54 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  13,580.8 ns |    24.95 ns |    23.34 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  15,162.3 ns |    60.70 ns |    56.78 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 155,749.8 ns |   653.10 ns |   578.96 ns |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 186,698.5 ns | 1,246.04 ns | 1,165.55 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 211,225.6 ns |   346.73 ns |   289.53 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 216,516.2 ns |   330.58 ns |   276.05 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 240,626.1 ns | 1,277.01 ns | 1,066.36 ns |         - |