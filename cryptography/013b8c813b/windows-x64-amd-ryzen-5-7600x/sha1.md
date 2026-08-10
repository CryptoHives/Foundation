| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     235.2 ns |     0.45 ns |     0.40 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     444.1 ns |     0.86 ns |     0.76 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     465.1 ns |     0.74 ns |     0.62 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     233.9 ns |     0.55 ns |     0.52 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     443.6 ns |     0.73 ns |     0.65 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     462.7 ns |     0.82 ns |     0.64 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,119.3 ns |     3.81 ns |     3.56 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,494.7 ns |    29.29 ns |    24.46 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,495.4 ns |     9.20 ns |     8.16 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,118.7 ns |    18.43 ns |    17.24 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,446.4 ns |    23.94 ns |    19.99 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,506.0 ns |    37.05 ns |    34.66 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,129.3 ns |    58.37 ns |    45.57 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,500.0 ns |   180.85 ns |   151.02 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  18,803.8 ns |   276.96 ns |   259.07 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 129,498.4 ns | 1,750.33 ns | 1,637.26 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 296,502.0 ns | 5,470.56 ns | 5,117.16 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 296,921.7 ns | 4,082.49 ns | 3,619.03 ns |         - |