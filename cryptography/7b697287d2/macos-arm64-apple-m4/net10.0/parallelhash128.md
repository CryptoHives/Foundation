| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128B         |     517.8 ns |     0.97 ns |     0.91 ns |     518.2 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128B         |  30,172.2 ns |   601.12 ns | 1,705.28 ns |  31,243.1 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 137B         |     514.9 ns |     1.25 ns |     1.11 ns |     515.2 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 137B         |  30,314.1 ns |   604.78 ns | 1,571.90 ns |  31,241.8 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1KB          |   1,413.4 ns |     3.35 ns |     3.13 ns |   1,413.6 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1KB          |  31,522.5 ns |   628.16 ns | 1,792.17 ns |  32,549.3 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 1025B        |   1,416.4 ns |     5.00 ns |     4.68 ns |   1,416.2 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 1025B        |  31,295.2 ns |   750.26 ns | 2,212.17 ns |  32,533.4 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 8KB          |   7,698.4 ns |    35.64 ns |    33.33 ns |   7,698.8 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 8KB          |  41,024.9 ns |   818.43 ns | 1,517.01 ns |  41,989.6 ns |     128 B |
|                                                       |              |              |             |             |              |           |
| TryComputeHash · ParallelHash128 · CryptoHives-Scalar | 128KB        | 117,959.5 ns |   448.45 ns |   419.48 ns | 117,968.8 ns |         - |
| TryComputeHash · ParallelHash128 · BouncyCastle       | 128KB        | 228,705.1 ns | 2,200.69 ns | 2,058.53 ns | 229,381.4 ns |     128 B |