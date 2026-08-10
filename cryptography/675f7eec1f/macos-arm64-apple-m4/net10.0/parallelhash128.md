| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     625.0 ns |     0.91 ns |     0.85 ns |     625.0 ns |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  28,401.7 ns |   585.59 ns | 1,726.62 ns |  29,230.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     625.5 ns |     0.60 ns |     0.56 ns |     625.7 ns |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  28,619.8 ns |   568.68 ns | 1,122.51 ns |  29,144.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,603.6 ns |     1.89 ns |     1.77 ns |   1,603.7 ns |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  30,067.4 ns |   596.02 ns | 1,244.12 ns |  30,741.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,604.9 ns |     1.70 ns |     1.59 ns |   1,604.7 ns |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  30,056.6 ns |   593.33 ns | 1,114.41 ns |  30,510.7 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   8,477.2 ns |    16.84 ns |    15.75 ns |   8,483.4 ns |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,069.5 ns |   814.06 ns | 1,467.92 ns |  40,980.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 141,379.3 ns |   257.15 ns |   227.95 ns | 141,405.4 ns |  263336 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 231,189.6 ns | 1,832.21 ns | 1,713.85 ns | 231,317.4 ns |     128 B |