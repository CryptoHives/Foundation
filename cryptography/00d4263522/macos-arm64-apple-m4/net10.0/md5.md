| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     346.7 ns |     4.27 ns |     3.99 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     368.2 ns |     3.16 ns |     2.96 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     429.2 ns |     3.91 ns |     3.66 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     346.7 ns |     3.42 ns |     3.20 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     367.8 ns |     3.25 ns |     2.88 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     416.6 ns |     3.69 ns |     3.45 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,461.5 ns |    13.16 ns |    12.31 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,934.9 ns |    16.19 ns |    13.52 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,132.2 ns |     3.25 ns |     2.54 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,455.4 ns |    12.40 ns |    11.60 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,930.6 ns |     9.26 ns |     7.23 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,129.0 ns |     7.52 ns |     5.87 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,646.4 ns |    91.59 ns |    85.67 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,688.8 ns |   137.64 ns |   128.75 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  16,211.2 ns |    46.95 ns |    36.66 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 149,604.1 ns | 1,168.16 ns | 1,092.70 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 233,070.3 ns | 2,055.21 ns | 1,922.45 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 257,802.4 ns |   642.92 ns |   501.95 ns |         - |