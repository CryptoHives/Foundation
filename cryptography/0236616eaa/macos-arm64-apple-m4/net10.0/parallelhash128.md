| Description                                           | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|------------------------------------------------------ |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |       623.2 ns |      0.43 ns |      0.38 ns |       623.2 ns |    1392 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |    30,700.7 ns |    605.69 ns |  1,195.57 ns |    31,182.7 ns |     128 B |
|                                                       |              |                |              |              |                |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |       623.9 ns |      0.35 ns |      0.31 ns |       623.8 ns |    1424 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |    30,865.3 ns |    600.17 ns |  1,002.76 ns |    31,204.6 ns |     128 B |
|                                                       |              |                |              |              |                |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |     1,909.1 ns |     43.26 ns |    127.56 ns |     1,954.4 ns |    3184 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |   135,775.4 ns | 17,815.07 ns | 52,528.15 ns |   163,680.5 ns |     128 B |
|                                                       |              |                |              |              |                |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |     7,533.9 ns |      6.00 ns |      5.01 ns |     7,534.4 ns |    3200 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |   160,849.2 ns |  3,553.67 ns | 10,253.15 ns |   163,906.2 ns |     128 B |
|                                                       |              |                |              |              |                |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |    39,908.5 ns |     58.11 ns |     51.52 ns |    39,896.8 ns |   17520 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |   210,027.5 ns |  4,244.72 ns | 11,691.18 ns |   214,180.3 ns |     128 B |
|                                                       |              |                |              |              |                |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        |   657,829.5 ns |  2,364.60 ns |  2,211.85 ns |   657,227.6 ns |  263336 B |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 1,085,415.0 ns | 10,018.89 ns |  9,371.68 ns | 1,084,715.8 ns |     128 B |