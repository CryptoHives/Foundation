| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     268.6 ns |     0.70 ns |     0.59 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     507.8 ns |     2.44 ns |     2.16 ns |   5,112 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     519.9 ns |     2.97 ns |     2.78 ns |   2,762 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     267.5 ns |     1.18 ns |     1.10 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     516.0 ns |     2.34 ns |     2.08 ns |   2,770 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     516.9 ns |     2.18 ns |     2.04 ns |   5,105 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,292.0 ns |     4.03 ns |     3.77 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,771.0 ns |    15.34 ns |    14.35 ns |   2,764 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,841.9 ns |    10.34 ns |     9.67 ns |   5,122 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,292.9 ns |     4.47 ns |     4.18 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,763.0 ns |     9.88 ns |     8.76 ns |   2,772 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,837.2 ns |     5.75 ns |     5.10 ns |   5,118 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   9,459.3 ns |    31.69 ns |    29.64 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  20,820.2 ns |   112.57 ns |   105.30 ns |   2,764 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  21,441.9 ns |    72.14 ns |    67.48 ns |   5,130 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 149,194.9 ns |   325.70 ns |   288.73 ns |   4,441 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 328,323.9 ns | 1,166.91 ns | 1,034.44 ns |   2,786 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 339,476.3 ns | 1,682.08 ns | 1,573.42 ns |   5,072 B |         - |