| Description                                           | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     757.9 ns |   1.47 ns |   1.38 ns |  10,093 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  19,050.7 ns |  44.12 ns |  39.11 ns |  13,060 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     986.2 ns |   3.68 ns |   3.44 ns |  10,094 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  19,897.6 ns |  38.57 ns |  36.08 ns |  13,074 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,356.5 ns |   3.11 ns |   2.43 ns |  10,087 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  21,816.0 ns |  43.23 ns |  40.44 ns |  13,102 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,357.3 ns |   5.37 ns |   5.02 ns |  10,084 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  21,775.5 ns |  43.88 ns |  41.05 ns |  13,101 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  14,457.7 ns |  41.96 ns |  39.25 ns |  10,099 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  45,311.6 ns |  54.53 ns |  51.01 ns |  15,416 B |     128 B |
|                                                       |              |              |           |           |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 220,475.4 ns | 579.58 ns | 483.97 ns |  10,086 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 433,813.4 ns | 542.81 ns | 453.27 ns |  16,150 B |     128 B |