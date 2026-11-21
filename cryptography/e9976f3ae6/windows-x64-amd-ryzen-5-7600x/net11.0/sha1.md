| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     267.2 ns |   1.00 ns |   0.88 ns |  14,421 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     503.7 ns |   1.46 ns |   1.22 ns |  11,624 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     517.5 ns |   1.47 ns |   1.30 ns |   5,132 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     265.9 ns |   0.98 ns |   0.92 ns |  14,021 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     498.2 ns |   1.50 ns |   1.33 ns |   5,297 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     517.5 ns |   0.93 ns |   0.78 ns |   5,133 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,287.9 ns |   5.66 ns |   5.30 ns |  14,021 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,714.2 ns |   8.71 ns |   7.27 ns |  11,816 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,842.6 ns |  11.59 ns |   9.68 ns |   5,142 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,288.5 ns |   2.40 ns |   2.12 ns |  13,830 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,669.2 ns |   5.21 ns |   4.35 ns |   5,299 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,830.6 ns |   4.51 ns |   3.76 ns |   5,143 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   9,433.6 ns |  19.19 ns |  14.98 ns |  13,831 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  20,123.1 ns |  57.15 ns |  47.72 ns |  11,816 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  21,430.6 ns |  78.21 ns |  69.33 ns |   5,154 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 149,093.8 ns | 258.17 ns | 215.58 ns |  14,421 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 317,469.1 ns | 810.37 ns | 676.69 ns |  11,644 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 339,724.8 ns | 752.28 ns | 587.33 ns |   5,507 B |         - |