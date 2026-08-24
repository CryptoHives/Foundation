| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     233.8 ns |   0.41 ns |   0.34 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     443.1 ns |   0.91 ns |   0.71 ns |   7,052 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     466.8 ns |   1.17 ns |   0.98 ns |   4,826 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     233.7 ns |   1.70 ns |   1.42 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     447.6 ns |   0.53 ns |   0.45 ns |   7,034 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     464.1 ns |   0.99 ns |   0.78 ns |   4,834 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,116.1 ns |   2.71 ns |   2.40 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,466.7 ns |   5.37 ns |   4.76 ns |   7,058 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,500.2 ns |   3.99 ns |   3.33 ns |   4,823 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,117.6 ns |   2.09 ns |   1.85 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,462.4 ns |   2.56 ns |   2.27 ns |   7,063 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,498.7 ns |   5.10 ns |   3.98 ns |   4,831 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,174.1 ns |  11.38 ns |   9.50 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,603.0 ns |  19.18 ns |  14.97 ns |   7,078 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  18,731.8 ns |  32.28 ns |  30.20 ns |   4,823 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 129,534.3 ns | 315.03 ns | 279.26 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 295,699.1 ns | 746.10 ns | 697.90 ns |   7,019 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 297,309.7 ns | 681.82 ns | 569.35 ns |   4,844 B |         - |