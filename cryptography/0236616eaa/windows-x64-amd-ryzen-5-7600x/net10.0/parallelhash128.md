| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     778.4 ns |     1.37 ns |     1.15 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  16,428.4 ns |    37.11 ns |    32.89 ns |  16,097 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     783.7 ns |     1.67 ns |     1.39 ns |        NA |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  16,364.2 ns |    32.30 ns |    28.63 ns |  16,103 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,083.2 ns |    12.16 ns |    11.37 ns |        NA |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  18,826.3 ns |    45.16 ns |    40.03 ns |  16,115 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,075.9 ns |    13.51 ns |    11.98 ns |        NA |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  18,579.4 ns |    44.88 ns |    37.48 ns |  16,116 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,350.9 ns |    48.64 ns |    43.12 ns |        NA |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  35,787.5 ns |   124.32 ns |    97.06 ns |  18,069 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 226,154.9 ns | 3,410.93 ns | 3,023.70 ns |        NA |  263308 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 329,581.9 ns |   385.20 ns |   321.66 ns |  18,702 B |     128 B |