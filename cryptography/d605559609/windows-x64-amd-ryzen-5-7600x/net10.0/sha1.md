| Description                                 | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     235.8 ns |     0.85 ns |     0.79 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     445.1 ns |     2.33 ns |     1.82 ns |   7,021 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     456.6 ns |     2.01 ns |     1.78 ns |   4,620 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     234.8 ns |     1.20 ns |     1.12 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     451.7 ns |     1.34 ns |     1.25 ns |   7,027 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     454.8 ns |     4.67 ns |     3.90 ns |   4,628 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,128.2 ns |     3.49 ns |     3.27 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,422.2 ns |    14.26 ns |    12.64 ns |   4,617 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,503.1 ns |    26.13 ns |    25.66 ns |   7,064 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,129.1 ns |     4.34 ns |     3.85 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,431.7 ns |    17.91 ns |    14.96 ns |   4,625 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,492.4 ns |     9.46 ns |     7.38 ns |   7,061 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,254.9 ns |    36.00 ns |    33.68 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  18,192.5 ns |    56.92 ns |    50.46 ns |   4,617 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,800.5 ns |   109.55 ns |    97.11 ns |   7,078 B |         - |
|                                             |              |              |             |             |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 130,774.6 ns |   637.99 ns |   596.78 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 289,172.9 ns | 1,222.72 ns | 1,143.74 ns |   4,645 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 298,696.1 ns | 1,017.36 ns |   901.86 ns |   7,019 B |         - |