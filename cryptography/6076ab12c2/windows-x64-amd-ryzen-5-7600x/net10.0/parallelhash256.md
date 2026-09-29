| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     923.6 ns |     3.64 ns |     3.40 ns |  18,084 B |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  19,283.4 ns |    65.32 ns |    61.10 ns |  13,072 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |   1,143.2 ns |    10.37 ns |     9.70 ns |  20,741 B |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  19,475.0 ns |    53.82 ns |    44.94 ns |  13,082 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   2,608.9 ns |    21.97 ns |    20.55 ns |  21,313 B |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  21,877.0 ns |    84.52 ns |    79.06 ns |  13,102 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   2,623.9 ns |    19.75 ns |    18.47 ns |  17,715 B |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  21,813.8 ns |    70.69 ns |    66.12 ns |  13,109 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  15,663.7 ns |   217.77 ns |   203.70 ns |  17,539 B |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  44,630.9 ns |   174.75 ns |   154.91 ns |  15,421 B |     128 B |
|                                                       |              |              |             |             |           |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 299,120.7 ns | 1,148.91 ns |   959.39 ns |  18,731 B |  263276 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 435,855.5 ns | 1,414.18 ns | 1,322.83 ns |  16,150 B |     128 B |