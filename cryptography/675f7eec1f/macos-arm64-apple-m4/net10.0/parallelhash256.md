| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     618.9 ns |     0.53 ns |     0.47 ns |     619.0 ns |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  28,605.2 ns |   565.93 ns | 1,311.62 ns |  29,216.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     773.3 ns |     2.07 ns |     1.84 ns |     773.9 ns |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  28,715.4 ns |   572.75 ns | 1,245.11 ns |  29,355.4 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,753.4 ns |     1.61 ns |     1.50 ns |   1,753.6 ns |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  30,438.9 ns |   826.11 ns | 2,435.79 ns |  29,865.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,753.7 ns |     3.91 ns |     3.65 ns |   1,754.9 ns |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  30,069.3 ns |   594.33 ns | 1,173.15 ns |  30,609.9 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  10,292.5 ns |    20.46 ns |    19.14 ns |  10,301.2 ns |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  42,650.6 ns |   816.37 ns |   940.13 ns |  43,085.7 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 170,178.8 ns |   140.88 ns |   131.78 ns | 170,192.9 ns |  263304 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 257,527.4 ns | 2,733.81 ns | 2,557.21 ns | 258,120.4 ns |     128 B |