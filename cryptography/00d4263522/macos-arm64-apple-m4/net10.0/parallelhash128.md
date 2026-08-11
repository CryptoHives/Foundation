| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     631.8 ns |    12.11 ns |    11.33 ns |     625.4 ns |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  28,568.8 ns | 1,061.81 ns | 3,130.76 ns |  29,474.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     631.3 ns |    11.14 ns |    10.42 ns |     625.4 ns |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  29,041.0 ns |   853.21 ns | 2,515.71 ns |  30,169.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,629.1 ns |    23.04 ns |    21.55 ns |   1,614.3 ns |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  30,488.4 ns |   755.91 ns | 2,228.82 ns |  31,448.4 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,620.7 ns |    23.11 ns |    21.62 ns |   1,606.8 ns |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  30,185.5 ns | 1,211.51 ns | 3,572.16 ns |  32,554.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   8,492.3 ns |    12.20 ns |     9.52 ns |   8,492.0 ns |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,268.1 ns |   818.25 ns | 1,863.58 ns |  42,612.7 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 141,233.0 ns |   321.09 ns |   250.68 ns | 141,174.6 ns |  263336 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 229,349.1 ns | 2,224.15 ns | 2,080.47 ns | 228,441.7 ns |     128 B |