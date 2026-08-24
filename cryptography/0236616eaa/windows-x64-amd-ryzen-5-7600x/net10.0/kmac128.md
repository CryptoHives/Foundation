| Description                                    | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     662.9 ns |     0.70 ns |   0.58 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,024.0 ns |     3.03 ns |   2.69 ns |   8,461 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,015.1 ns |     6.97 ns |   6.52 ns |  19,446 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     658.4 ns |     1.23 ns |   1.15 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,027.5 ns |     1.77 ns |   1.57 ns |   8,445 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,028.4 ns |     3.65 ns |   3.24 ns |  19,455 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,885.6 ns |     3.30 ns |   2.58 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,553.2 ns |     5.10 ns |   4.26 ns |   8,519 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,874.2 ns |     4.81 ns |   4.50 ns |  19,497 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,882.2 ns |     3.86 ns |   3.42 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,549.2 ns |     7.23 ns |   6.41 ns |   8,525 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,867.0 ns |     9.29 ns |   8.24 ns |  18,873 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,479.1 ns |    60.16 ns |  53.33 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  13,260.0 ns |    42.15 ns |  37.36 ns |   8,765 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  16,972.7 ns |    25.43 ns |  21.23 ns |  22,620 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 160,190.4 ns | 1,158.26 ns | 904.29 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 229,815.1 ns |   719.92 ns | 601.16 ns |   8,481 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 243,632.2 ns |   389.65 ns | 364.48 ns |  22,774 B |     256 B |