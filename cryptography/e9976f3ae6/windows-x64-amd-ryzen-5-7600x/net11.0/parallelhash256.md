| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     760.9 ns |     2.36 ns |     2.09 ns |  20,130 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  19,115.6 ns |    41.00 ns |    38.35 ns |  23,234 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     988.6 ns |     4.00 ns |     3.34 ns |  20,139 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  19,676.5 ns |    31.44 ns |    27.87 ns |  16,794 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,379.8 ns |    20.36 ns |    18.05 ns |  13,795 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  21,796.0 ns |    50.32 ns |    42.02 ns |  23,333 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,374.7 ns |     7.04 ns |     6.58 ns |  20,121 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  22,691.1 ns |    56.25 ns |    49.87 ns |  23,143 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  14,561.0 ns |    37.65 ns |    35.22 ns |  20,322 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  45,301.0 ns |    74.39 ns |    58.08 ns |  26,420 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 221,995.1 ns |   379.32 ns |   316.75 ns |  20,132 B |         - |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 436,341.2 ns | 1,878.18 ns | 1,756.85 ns |  26,489 B |     128 B |