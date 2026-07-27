| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     272.0 ns |   1.98 ns |   1.86 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     489.2 ns |   0.87 ns |   0.81 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     531.5 ns |   2.14 ns |   1.79 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     260.3 ns |   1.91 ns |   1.79 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     488.1 ns |   0.46 ns |   0.41 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     528.3 ns |   0.65 ns |   0.61 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     527.9 ns |   1.88 ns |   1.76 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,721.6 ns |   1.89 ns |   1.77 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,877.7 ns |   8.24 ns |   7.71 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     526.6 ns |   2.15 ns |   2.01 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,727.0 ns |   2.76 ns |   2.59 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,886.0 ns |   5.26 ns |   4.92 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,648.1 ns |   1.13 ns |   1.06 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,561.6 ns |  37.36 ns |  34.94 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  21,668.5 ns |  44.72 ns |  39.65 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  39,012.4 ns |  67.46 ns |  63.11 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 327,011.0 ns | 561.57 ns | 525.29 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 342,490.3 ns | 781.50 ns | 731.02 ns |         - |