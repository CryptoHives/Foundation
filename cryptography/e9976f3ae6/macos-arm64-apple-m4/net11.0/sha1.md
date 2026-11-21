| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     233.8 ns |     0.62 ns |     0.58 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     494.9 ns |     2.86 ns |     2.38 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     500.3 ns |     2.80 ns |     2.62 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     774.4 ns |     2.68 ns |     2.50 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     235.2 ns |     0.54 ns |     0.50 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     491.0 ns |     2.54 ns |     2.25 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     501.0 ns |     3.44 ns |     3.22 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     773.8 ns |     2.93 ns |     2.74 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,030.3 ns |     5.96 ns |     5.58 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,232.2 ns |     4.87 ns |     4.56 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,659.4 ns |    12.65 ns |    11.83 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,789.1 ns |    10.93 ns |    10.23 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,032.7 ns |     5.99 ns |     5.60 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,230.2 ns |     5.84 ns |     5.47 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,664.1 ns |    26.02 ns |    21.72 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,769.6 ns |     9.27 ns |     7.74 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   3,146.0 ns |     9.96 ns |     9.32 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,270.6 ns |    16.49 ns |    14.62 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  20,069.0 ns |   113.90 ns |   100.97 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,923.9 ns |    90.20 ns |    84.38 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  39,710.3 ns |    83.17 ns |    77.80 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 147,128.9 ns |   562.50 ns |   526.16 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 317,432.6 ns | 3,080.20 ns | 2,404.81 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 332,568.1 ns |   949.31 ns |   792.71 ns |         - |