| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     653.3 ns |   0.52 ns |   0.43 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,073.7 ns |   1.40 ns |   1.25 ns |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   2,023.9 ns |   5.18 ns |   4.60 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     855.9 ns |   2.79 ns |   2.61 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,323.7 ns |   2.85 ns |   2.22 ns |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,312.1 ns |   3.17 ns |   2.65 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,101.1 ns |  41.46 ns |  34.62 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,826.1 ns |   8.09 ns |   6.32 ns |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,222.8 ns |   6.43 ns |   5.37 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,074.2 ns |   5.45 ns |   4.84 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,828.8 ns |   9.30 ns |   8.25 ns |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,231.5 ns |  10.98 ns |  10.27 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,856.1 ns |  32.97 ns |  30.84 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  16,167.0 ns |  41.95 ns |  35.03 ns |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,830.8 ns |  44.05 ns |  41.20 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 196,542.6 ns | 321.75 ns | 285.23 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 272,750.6 ns | 928.16 ns | 775.06 ns |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 305,181.7 ns | 434.09 ns | 384.81 ns |     256 B |