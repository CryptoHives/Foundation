| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     229.5 ns |     2.64 ns |     2.34 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     439.1 ns |     2.54 ns |     2.38 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     457.1 ns |     3.13 ns |     2.93 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     229.6 ns |     1.49 ns |     1.32 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     443.6 ns |     5.37 ns |     4.76 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     454.5 ns |     2.75 ns |     2.57 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,097.0 ns |     6.77 ns |     6.00 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,428.5 ns |     9.24 ns |     8.64 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,450.6 ns |    17.82 ns |    16.67 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,098.0 ns |     7.59 ns |     5.93 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,423.7 ns |     7.96 ns |     7.44 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,448.9 ns |     9.26 ns |     8.67 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,039.6 ns |    25.24 ns |    21.08 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,327.4 ns |    92.63 ns |    86.65 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  18,341.0 ns |    55.50 ns |    49.20 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 127,568.2 ns |   906.92 ns |   803.96 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 290,098.5 ns | 1,690.71 ns | 1,498.77 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 291,079.8 ns | 1,104.77 ns |   979.35 ns |         - |