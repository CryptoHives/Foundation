| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     794.6 ns |     4.50 ns |     4.21 ns |        NA |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  17,204.1 ns |   179.06 ns |   149.52 ns |  16,114 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     794.4 ns |     2.70 ns |     2.26 ns |        NA |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  16,460.3 ns |    34.79 ns |    29.05 ns |  16,105 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   2,121.9 ns |    26.62 ns |    22.22 ns |        NA |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  18,280.4 ns |    60.45 ns |    53.59 ns |  16,111 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   2,107.4 ns |    19.15 ns |    16.97 ns |        NA |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  18,816.9 ns |    65.48 ns |    58.05 ns |  16,116 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |  11,584.1 ns |    63.64 ns |    53.14 ns |        NA |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  35,961.3 ns |   112.00 ns |    93.52 ns |  18,069 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 231,540.8 ns | 4,473.32 ns | 3,735.43 ns |        NA |  263308 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 332,484.9 ns | 1,323.54 ns | 1,105.22 ns |  18,663 B |     128 B |