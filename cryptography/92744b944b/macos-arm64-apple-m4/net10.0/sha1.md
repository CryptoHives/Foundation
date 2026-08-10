| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     269.9 ns |     1.92 ns |     1.80 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     482.1 ns |     0.57 ns |     0.54 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     534.0 ns |     7.51 ns |     6.27 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     258.5 ns |     2.29 ns |     2.14 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     485.4 ns |     0.57 ns |     0.48 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     527.3 ns |     3.69 ns |     3.08 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     525.8 ns |     1.29 ns |     1.20 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,704.2 ns |     2.13 ns |     1.78 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,862.7 ns |     5.31 ns |     4.44 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     525.1 ns |     2.12 ns |     1.77 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,726.1 ns |    30.70 ns |    27.21 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,884.0 ns |    22.51 ns |    19.96 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,657.3 ns |    28.73 ns |    25.47 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  19,284.4 ns |    65.89 ns |    51.44 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  21,628.5 ns |   134.34 ns |   112.18 ns |         - |
|                                             |              |              |             |             |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  38,818.5 ns |    52.16 ns |    43.56 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 325,737.9 ns |   558.92 ns |   466.72 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 341,828.4 ns | 1,323.97 ns | 1,105.58 ns |         - |