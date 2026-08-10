| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     229.0 ns |     0.78 ns |     0.69 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     434.3 ns |     1.70 ns |     1.59 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     455.1 ns |     2.96 ns |     2.63 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     229.7 ns |     1.01 ns |     0.95 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     435.8 ns |     1.55 ns |     1.38 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     452.2 ns |     2.07 ns |     1.61 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,096.1 ns |     2.12 ns |     1.66 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,420.6 ns |     7.26 ns |     6.44 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,457.2 ns |    14.34 ns |    13.41 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,098.1 ns |     3.65 ns |     3.23 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,416.6 ns |     7.45 ns |     5.82 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,449.5 ns |    12.44 ns |    11.63 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,037.1 ns |    28.62 ns |    23.90 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,224.4 ns |    66.77 ns |    59.19 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  18,364.5 ns |    60.05 ns |    50.14 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 127,098.6 ns |   155.43 ns |   129.79 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 289,536.6 ns | 1,181.97 ns | 1,047.78 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 291,638.8 ns | 1,352.95 ns | 1,265.55 ns |         - |