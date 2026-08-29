| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     625.9 ns |     8.46 ns |     7.07 ns |     622.6 ns |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  25,122.2 ns | 1,141.60 ns | 3,366.03 ns |  25,734.7 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     780.8 ns |     0.76 ns |     0.71 ns |     780.5 ns |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  26,359.3 ns |   869.82 ns | 2,564.68 ns |  26,970.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,769.8 ns |     1.37 ns |     1.14 ns |   1,769.3 ns |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  28,081.2 ns |   896.55 ns | 2,643.51 ns |  29,030.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,748.5 ns |     1.90 ns |     1.58 ns |   1,747.8 ns |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  28,712.9 ns |   775.69 ns | 2,287.15 ns |  29,263.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  10,259.5 ns |    23.99 ns |    21.27 ns |  10,253.9 ns |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  39,306.3 ns | 1,053.99 ns | 3,107.72 ns |  39,889.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 169,357.7 ns | 1,273.82 ns | 1,191.53 ns | 169,653.2 ns |  263304 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 253,405.4 ns | 2,267.03 ns | 2,120.58 ns | 253,011.2 ns |     128 B |