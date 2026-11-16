| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128B         |     231.4 ns |     0.61 ns |     0.57 ns |     231.3 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 128B         |     267.7 ns |     1.20 ns |     1.13 ns |     267.6 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     488.1 ns |     4.04 ns |     3.78 ns |     487.2 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     491.5 ns |     9.27 ns |     7.74 ns |     490.4 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 137B         |     219.7 ns |     0.56 ns |     0.52 ns |     219.6 ns |         - |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     254.5 ns |     1.47 ns |     1.37 ns |     254.2 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     488.9 ns |     3.23 ns |     2.70 ns |     488.7 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     489.9 ns |     4.34 ns |     4.06 ns |     488.2 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     532.7 ns |     1.55 ns |     1.45 ns |     533.3 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1KB          |   1,234.0 ns |     2.66 ns |     2.49 ns |   1,234.9 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,600.0 ns |    13.40 ns |    11.19 ns |   2,604.7 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,738.2 ns |    16.93 ns |    14.14 ns |   2,739.7 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     530.8 ns |     2.04 ns |     1.91 ns |     530.4 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 1025B        |   1,230.5 ns |     5.12 ns |     4.78 ns |   1,231.4 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,666.7 ns |    51.82 ns |    69.17 ns |   2,625.6 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,749.4 ns |    10.85 ns |     9.61 ns |   2,746.7 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,666.9 ns |    10.29 ns |     9.63 ns |   2,670.2 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 8KB          |   9,275.7 ns |    29.90 ns |    27.97 ns |   9,284.7 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  19,584.7 ns |   170.96 ns |   142.76 ns |  19,604.4 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,768.8 ns |   118.44 ns |   110.79 ns |  20,809.2 ns |         - |
|                                             |              |              |             |             |              |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  39,312.1 ns |    85.99 ns |    80.44 ns |  39,296.6 ns |         - |
| TryComputeHash · SHA-1 · SHA-1 (ArmSha1)    | 128KB        | 146,937.9 ns |   744.96 ns |   696.84 ns | 147,155.5 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 309,792.9 ns | 2,923.79 ns | 2,734.91 ns | 309,454.0 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 332,279.9 ns | 2,330.44 ns | 2,179.89 ns | 332,691.4 ns |         - |