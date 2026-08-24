| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     241.6 ns |     2.16 ns |     2.02 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     270.6 ns |     2.18 ns |     2.04 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     492.6 ns |     1.54 ns |     1.44 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     519.3 ns |     3.29 ns |     2.92 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     216.5 ns |     0.15 ns |     0.12 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     249.9 ns |     2.53 ns |     2.37 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     494.5 ns |     0.93 ns |     0.87 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     524.6 ns |     0.81 ns |     0.68 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     523.7 ns |     0.76 ns |     0.68 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,212.4 ns |     1.98 ns |     1.66 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,779.4 ns |     1.00 ns |     0.94 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,882.7 ns |    39.38 ns |    32.88 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     525.5 ns |     2.79 ns |     2.61 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,249.7 ns |     0.35 ns |     0.31 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,786.7 ns |     0.78 ns |     0.69 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,870.8 ns |     8.55 ns |     7.58 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,636.1 ns |     5.49 ns |     5.13 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,447.8 ns |     1.16 ns |     1.03 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  21,040.3 ns |     6.08 ns |     5.39 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  21,566.3 ns |    63.17 ns |    49.32 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  39,622.8 ns |   311.52 ns |   291.39 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 150,252.3 ns |   390.65 ns |   326.21 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 318,262.2 ns | 5,919.04 ns | 5,813.29 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 341,358.7 ns | 1,275.04 ns |   995.47 ns |         - |