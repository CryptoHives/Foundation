| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     625.4 ns |     0.84 ns |     0.70 ns |     625.4 ns |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  27,889.6 ns |   684.13 ns | 2,017.16 ns |  28,985.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     777.8 ns |     0.71 ns |     0.66 ns |     777.6 ns |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  28,232.4 ns |   562.00 ns | 1,420.26 ns |  29,019.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,750.8 ns |     1.37 ns |     1.28 ns |   1,750.7 ns |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  29,707.4 ns |   589.71 ns | 1,653.61 ns |  30,604.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,753.3 ns |     1.14 ns |     1.01 ns |   1,753.5 ns |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  29,575.4 ns |   586.93 ns | 1,300.59 ns |  30,195.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  10,256.5 ns |     7.46 ns |     6.61 ns |  10,256.3 ns |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  42,031.2 ns |   826.18 ns | 1,571.89 ns |  42,223.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 168,309.5 ns |   219.95 ns |   194.98 ns | 168,260.7 ns |  263304 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 253,460.6 ns | 1,604.52 ns | 1,500.87 ns | 253,382.6 ns |     128 B |