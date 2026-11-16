| Description                                    | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     880.8 ns |     3.14 ns |   2.93 ns |   8,374 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,165.5 ns |     5.33 ns |   4.72 ns |   7,257 B |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,299.9 ns |     3.80 ns |   2.97 ns |  16,555 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     963.2 ns |     2.23 ns |   1.97 ns |   8,357 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,446.0 ns |     4.49 ns |   4.20 ns |   7,258 B |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,587.5 ns |     7.83 ns |   7.33 ns |  16,623 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,351.7 ns |    31.90 ns |  26.64 ns |   8,376 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   3,157.9 ns |    12.97 ns |  11.50 ns |   7,552 B |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,748.5 ns |    58.57 ns |  48.90 ns |  16,615 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,342.7 ns |     8.12 ns |   7.20 ns |   8,376 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   3,137.7 ns |    11.04 ns |   9.78 ns |   7,270 B |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,709.5 ns |     8.04 ns |   7.13 ns |  16,621 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  14,471.8 ns |    68.79 ns |  64.34 ns |   8,362 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  18,320.9 ns |    90.44 ns |  75.52 ns |   7,459 B |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  23,307.1 ns |    70.20 ns |  58.62 ns |  19,910 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 221,698.1 ns |   846.23 ns | 791.56 ns |   8,362 B |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 310,156.6 ns | 1,105.86 ns | 923.44 ns |   7,814 B |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 342,664.7 ns |   586.53 ns | 519.94 ns |  20,036 B |     256 B |