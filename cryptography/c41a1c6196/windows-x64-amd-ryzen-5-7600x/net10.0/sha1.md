| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     267.0 ns |   0.52 ns |   0.44 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     497.8 ns |   2.29 ns |   2.03 ns |   2,727 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     508.1 ns |   1.76 ns |   1.47 ns |   5,097 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     265.3 ns |   0.40 ns |   0.36 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     493.3 ns |   0.42 ns |   0.37 ns |   2,737 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     512.6 ns |   0.87 ns |   0.82 ns |   5,105 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,283.1 ns |   2.98 ns |   2.64 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,663.0 ns |  11.27 ns |   9.99 ns |   2,729 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,820.4 ns |   5.02 ns |   4.19 ns |   5,122 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,279.9 ns |   1.25 ns |   1.05 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,744.5 ns |   6.94 ns |   5.79 ns |   2,739 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,821.8 ns |   2.82 ns |   2.50 ns |   5,118 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   9,392.8 ns |  14.59 ns |  12.18 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  19,993.5 ns |  32.68 ns |  27.29 ns |   2,729 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  21,285.0 ns |  46.38 ns |  38.73 ns |   5,130 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 148,705.7 ns | 257.14 ns | 227.95 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 317,596.2 ns | 626.98 ns | 555.81 ns |   2,750 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 337,751.6 ns | 738.28 ns | 616.50 ns |   5,072 B |         - |