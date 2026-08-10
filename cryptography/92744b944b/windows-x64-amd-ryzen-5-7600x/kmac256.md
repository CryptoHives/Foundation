| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     664.9 ns |     1.26 ns |     0.98 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,003.7 ns |     4.39 ns |     4.10 ns |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,943.8 ns |     5.95 ns |     5.57 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     909.5 ns |     1.47 ns |     1.31 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,252.5 ns |     5.27 ns |     4.93 ns |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,243.1 ns |     9.81 ns |     9.18 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,066.0 ns |     5.75 ns |     4.80 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,703.7 ns |    12.64 ns |    11.82 ns |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,082.9 ns |     6.86 ns |     6.08 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,066.2 ns |     4.91 ns |     4.60 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,684.8 ns |    16.50 ns |    15.43 ns |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,076.9 ns |    21.02 ns |    19.66 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,529.6 ns |    20.19 ns |    17.90 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  15,591.3 ns |    77.34 ns |    68.56 ns |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,205.7 ns |    35.71 ns |    33.40 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 190,123.7 ns |   374.20 ns |   331.72 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 263,794.1 ns | 1,310.26 ns | 1,225.61 ns |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 294,678.9 ns | 1,025.68 ns |   959.43 ns |     256 B |