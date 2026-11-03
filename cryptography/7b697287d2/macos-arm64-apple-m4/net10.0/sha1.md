| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     228.2 ns |     0.13 ns |     0.12 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     259.5 ns |     1.28 ns |     1.19 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     483.2 ns |     1.81 ns |     1.78 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     487.0 ns |     2.77 ns |     2.60 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     216.5 ns |     0.15 ns |     0.14 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     247.9 ns |     1.28 ns |     1.20 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     480.8 ns |     2.74 ns |     2.56 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     487.5 ns |     2.72 ns |     2.54 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     523.0 ns |     0.53 ns |     0.47 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,216.9 ns |     1.53 ns |     1.36 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,585.2 ns |    12.75 ns |    10.65 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,744.4 ns |     9.82 ns |     9.19 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     522.2 ns |     0.92 ns |     0.86 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,214.3 ns |     0.16 ns |     0.13 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,570.7 ns |    10.47 ns |     9.29 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,738.1 ns |     8.02 ns |     7.50 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,629.8 ns |     0.33 ns |     0.28 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,134.2 ns |     1.77 ns |     1.57 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  19,287.3 ns |   104.24 ns |    87.04 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,625.8 ns |    80.70 ns |    75.49 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  38,763.0 ns |     9.26 ns |     7.23 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 144,930.2 ns |    19.18 ns |    16.01 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 305,588.9 ns | 1,579.72 ns | 1,233.34 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 332,260.6 ns | 2,016.76 ns | 1,886.47 ns |         - |