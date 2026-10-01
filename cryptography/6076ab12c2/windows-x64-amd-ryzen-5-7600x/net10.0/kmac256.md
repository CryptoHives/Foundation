| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     732.4 ns |     1.78 ns |     1.67 ns |   8,168 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,155.1 ns |     4.94 ns |     4.62 ns |   7,255 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,239.0 ns |     5.25 ns |     4.91 ns |  16,587 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     959.5 ns |     1.47 ns |     1.30 ns |   8,154 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,423.5 ns |     3.32 ns |     3.11 ns |   7,252 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,578.0 ns |     3.20 ns |     2.99 ns |  16,623 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,325.4 ns |     5.65 ns |     5.28 ns |   8,153 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   3,111.1 ns |    10.25 ns |     9.59 ns |   7,249 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,687.9 ns |     8.25 ns |     6.89 ns |  16,634 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,331.0 ns |     7.69 ns |     7.20 ns |   8,167 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   3,112.5 ns |     9.41 ns |     8.80 ns |   7,251 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,783.5 ns |    12.14 ns |    10.13 ns |  16,628 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  14,437.5 ns |    20.28 ns |    18.97 ns |   8,155 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  17,950.8 ns |    37.20 ns |    31.07 ns |   7,462 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  23,225.2 ns |    33.26 ns |    31.12 ns |  19,915 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 220,597.5 ns |   429.12 ns |   380.41 ns |   8,153 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 306,362.0 ns | 1,202.09 ns | 1,065.62 ns |   7,812 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 337,500.6 ns |   440.83 ns |   368.11 ns |  20,030 B |     256 B |