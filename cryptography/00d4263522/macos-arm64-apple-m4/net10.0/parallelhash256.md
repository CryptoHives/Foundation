| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128B         |     627.9 ns |    11.59 ns |    10.84 ns |     622.0 ns |    1360 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128B         |  28,949.4 ns |   883.48 ns | 2,604.97 ns |  29,934.1 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 137B         |     780.4 ns |    11.82 ns |    11.06 ns |     773.1 ns |    1392 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 137B         |  28,933.6 ns |   886.71 ns | 2,614.49 ns |  29,632.5 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1KB          |   1,767.9 ns |    23.88 ns |    22.34 ns |   1,753.8 ns |    3152 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1KB          |  30,592.2 ns | 1,141.86 ns | 3,366.79 ns |  32,771.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 1025B        |   1,765.4 ns |    24.76 ns |    23.16 ns |   1,750.6 ns |    3168 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 1025B        |  30,686.8 ns | 1,150.61 ns | 3,392.60 ns |  32,748.0 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 8KB          |  10,387.5 ns |   174.75 ns |   154.91 ns |  10,311.8 ns |   17488 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 8KB          |  43,407.1 ns |   867.66 ns | 1,732.80 ns |  43,885.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash256 · CryptoHives-Scalar | 128KB        | 170,914.1 ns | 2,486.79 ns | 2,326.14 ns | 169,532.3 ns |  263304 B |
| TryComputeHash · ParallelHash256 · BouncyCastle       | 128KB        | 255,692.4 ns | 2,406.10 ns | 2,009.20 ns | 256,606.0 ns |     128 B |