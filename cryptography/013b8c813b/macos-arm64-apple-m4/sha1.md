| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     270.6 ns |   2.42 ns |   2.26 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     482.5 ns |   0.88 ns |   0.82 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     530.8 ns |   5.38 ns |   4.77 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     253.9 ns |   2.39 ns |   2.23 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     484.0 ns |   0.55 ns |   0.51 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     523.4 ns |   0.66 ns |   0.61 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |     523.5 ns |   0.91 ns |   0.80 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,699.4 ns |   1.80 ns |   1.59 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,855.5 ns |   9.05 ns |   7.56 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |     525.4 ns |   0.95 ns |   0.89 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,705.6 ns |   1.16 ns |   1.09 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,876.2 ns |  30.36 ns |  28.40 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   2,630.2 ns |   0.68 ns |   0.57 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  20,419.2 ns |   7.57 ns |   7.08 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  21,468.3 ns |  57.29 ns |  50.79 ns |         - |
|                                             |              |              |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        |  38,756.5 ns |   4.10 ns |   3.63 ns |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 324,766.7 ns | 182.96 ns | 171.14 ns |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 339,798.6 ns | 878.04 ns | 778.36 ns |         - |