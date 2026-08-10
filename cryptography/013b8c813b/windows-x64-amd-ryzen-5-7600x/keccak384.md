| Description                                       | TestDataSize | Mean         | Error       | StdDev    | Median       | Allocated |
|-------------------------------------------------- |------------- |-------------:|------------:|----------:|-------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128B         |     414.6 ns |     0.85 ns |   0.75 ns |     414.4 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128B         |     553.3 ns |     1.49 ns |   1.32 ns |     552.9 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128B         |     571.5 ns |     1.26 ns |   1.12 ns |     571.3 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128B         |     644.7 ns |     0.79 ns |   0.66 ns |     644.9 ns |         - |
|                                                   |              |              |             |           |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 137B         |     416.3 ns |     0.73 ns |   0.69 ns |     416.3 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 137B         |     553.0 ns |     1.58 ns |   1.32 ns |     552.6 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 137B         |     572.4 ns |     1.35 ns |   1.13 ns |     572.0 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 137B         |     645.6 ns |     0.83 ns |   0.78 ns |     645.7 ns |         - |
|                                                   |              |              |             |           |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1KB          |   2,094.6 ns |    47.60 ns | 131.89 ns |   2,032.6 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1KB          |   2,723.4 ns |     9.77 ns |   8.16 ns |   2,720.1 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1KB          |   2,789.0 ns |     8.34 ns |   7.80 ns |   2,787.6 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1KB          |   3,144.5 ns |     6.28 ns |   5.57 ns |   3,143.2 ns |         - |
|                                                   |              |              |             |           |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 1025B        |   2,031.2 ns |     4.33 ns |   3.84 ns |   2,031.6 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 1025B        |   2,726.8 ns |     9.15 ns |   7.64 ns |   2,727.2 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 1025B        |   2,793.1 ns |    12.67 ns |  11.23 ns |   2,792.7 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 1025B        |   3,152.3 ns |     3.33 ns |   2.78 ns |   3,152.7 ns |         - |
|                                                   |              |              |             |           |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 8KB          |  16,037.6 ns |    32.25 ns |  30.17 ns |  16,034.8 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 8KB          |  21,398.8 ns |    68.13 ns |  63.73 ns |  21,403.5 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 8KB          |  21,969.0 ns |    62.92 ns |  52.54 ns |  21,989.9 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 8KB          |  24,642.1 ns |    29.30 ns |  27.41 ns |  24,643.1 ns |         - |
|                                                   |              |              |             |           |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar  | 128KB        | 255,172.8 ns |   891.12 ns | 789.96 ns | 255,142.4 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX2    | 128KB        | 341,441.3 ns | 1,096.51 ns | 856.08 ns | 341,475.2 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-AVX512F | 128KB        | 349,867.0 ns |   927.04 ns | 867.15 ns | 349,866.3 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle        | 128KB        | 394,682.3 ns |   564.83 ns | 500.71 ns | 394,696.8 ns |         - |