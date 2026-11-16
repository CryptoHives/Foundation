| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     758.1 ns |     1.21 ns |     1.13 ns |  10,107 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  18,649.8 ns |    60.17 ns |    53.34 ns |  13,072 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     986.8 ns |     3.60 ns |     2.81 ns |  10,094 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  19,286.7 ns |    36.70 ns |    32.53 ns |  13,062 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,357.0 ns |     7.30 ns |     6.47 ns |  10,087 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  21,364.0 ns |    42.20 ns |    37.41 ns |  13,096 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,352.4 ns |     3.96 ns |     3.31 ns |  10,084 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  21,737.2 ns |    18.53 ns |    15.47 ns |  13,108 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  14,430.2 ns |    20.12 ns |    16.80 ns |  10,088 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  44,758.6 ns |    89.80 ns |    74.99 ns |  15,416 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 220,629.0 ns |   535.13 ns |   417.79 ns |  10,086 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 434,142.6 ns | 2,168.80 ns | 1,811.05 ns |  16,150 B |     128 B |