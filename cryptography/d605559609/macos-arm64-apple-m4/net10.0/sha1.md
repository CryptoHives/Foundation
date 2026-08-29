| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     234.3 ns |     1.04 ns |     0.92 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     275.1 ns |     2.89 ns |     2.70 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     498.8 ns |     0.30 ns |     0.27 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     503.9 ns |     1.55 ns |     1.38 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     219.4 ns |     0.95 ns |     0.79 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     261.7 ns |     1.91 ns |     1.69 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     499.8 ns |     0.45 ns |     0.37 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     502.5 ns |     3.28 ns |     2.74 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     525.8 ns |     2.56 ns |     2.14 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,249.8 ns |     0.30 ns |     0.23 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,730.5 ns |    17.69 ns |    15.68 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,794.1 ns |     1.20 ns |     1.00 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     526.7 ns |     4.87 ns |     4.55 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,214.4 ns |     0.65 ns |     0.54 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,730.5 ns |    16.59 ns |    13.85 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,782.5 ns |     1.55 ns |     1.21 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,633.8 ns |     0.65 ns |     0.51 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,453.6 ns |     3.61 ns |     3.01 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  20,535.3 ns |   263.55 ns |   205.76 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  21,021.4 ns |     9.43 ns |     7.88 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  39,073.6 ns |   398.98 ns |   373.21 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 144,996.2 ns |    65.71 ns |    54.87 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 326,281.4 ns | 2,323.31 ns | 1,940.07 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 333,796.9 ns | 4,694.88 ns | 4,391.60 ns |         - |