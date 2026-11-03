| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     266.4 ns |   1.15 ns |   1.07 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     500.0 ns |   2.15 ns |   2.01 ns |   2,727 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     510.2 ns |   1.58 ns |   1.47 ns |   5,106 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     267.0 ns |   0.59 ns |   0.53 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     496.6 ns |   0.96 ns |   0.90 ns |   2,737 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     510.0 ns |   2.01 ns |   1.88 ns |   5,105 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,283.5 ns |   3.24 ns |   3.03 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,663.9 ns |   8.11 ns |   7.19 ns |   2,729 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,822.1 ns |   4.79 ns |   4.00 ns |   5,122 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,291.0 ns |   2.59 ns |   2.42 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,661.6 ns |   5.91 ns |   5.53 ns |   2,739 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,820.2 ns |   6.48 ns |   5.75 ns |   5,118 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   9,403.3 ns |  21.10 ns |  19.74 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  19,952.5 ns |  51.25 ns |  47.94 ns |   2,729 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  21,279.7 ns |  22.58 ns |  18.86 ns |   5,130 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 148,673.3 ns | 303.32 ns | 283.72 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 315,479.4 ns | 577.07 ns | 511.56 ns |   2,750 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 338,114.2 ns | 720.29 ns | 673.76 ns |   5,072 B |         - |