| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     228.1 ns |     0.10 ns |     0.09 ns |     228.1 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     261.6 ns |     0.82 ns |     0.68 ns |     261.6 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     491.7 ns |     1.94 ns |     1.82 ns |     491.4 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     502.5 ns |     3.25 ns |     2.54 ns |     502.4 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     216.7 ns |     0.12 ns |     0.10 ns |     216.7 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     250.3 ns |     1.91 ns |     1.78 ns |     250.5 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     495.3 ns |     1.87 ns |     1.75 ns |     494.7 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     498.2 ns |     3.41 ns |     2.85 ns |     498.5 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     523.3 ns |     0.83 ns |     0.74 ns |     523.1 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,224.4 ns |    15.44 ns |    14.44 ns |   1,217.2 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,763.7 ns |     3.69 ns |     3.45 ns |   2,763.7 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,773.0 ns |    53.16 ns |   103.68 ns |   2,726.6 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     523.0 ns |     0.82 ns |     0.73 ns |     522.9 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,217.3 ns |     0.53 ns |     0.47 ns |   1,217.2 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,690.8 ns |    23.10 ns |    18.04 ns |   2,689.0 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,757.2 ns |     5.45 ns |     4.83 ns |   2,757.3 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,631.6 ns |     1.29 ns |     1.07 ns |   2,631.4 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,137.6 ns |     2.96 ns |     2.62 ns |   9,137.5 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  20,615.9 ns |   404.88 ns |   653.80 ns |  20,252.6 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,799.1 ns |    53.85 ns |    50.37 ns |  20,791.2 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  38,779.2 ns |    12.26 ns |    11.47 ns |  38,781.3 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 145,005.1 ns |    70.56 ns |    62.55 ns | 144,998.1 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 321,093.5 ns | 3,434.10 ns | 2,867.63 ns | 321,066.8 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 332,356.2 ns | 2,460.65 ns | 2,301.69 ns | 333,450.4 ns |         - |