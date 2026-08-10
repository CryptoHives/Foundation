| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     774.9 ns |     6.26 ns |     5.86 ns |        NA |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  16,380.5 ns |    97.96 ns |    86.84 ns |  16,199 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     977.4 ns |    10.36 ns |     9.18 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  16,771.8 ns |   117.61 ns |   104.26 ns |  16,191 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,285.2 ns |    23.41 ns |    21.89 ns |        NA |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  19,444.5 ns |    79.17 ns |    66.11 ns |  16,470 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,280.7 ns |    18.32 ns |    16.24 ns |        NA |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  19,014.7 ns |    81.34 ns |    67.93 ns |  16,462 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  13,734.1 ns |    86.24 ns |    76.45 ns |        NA |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  39,405.3 ns |   354.63 ns |   331.72 ns |  16,465 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 264,281.9 ns | 5,003.70 ns | 4,435.65 ns |        NA |  263276 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 389,171.4 ns | 2,711.70 ns | 2,264.39 ns |  17,966 B |     128 B |