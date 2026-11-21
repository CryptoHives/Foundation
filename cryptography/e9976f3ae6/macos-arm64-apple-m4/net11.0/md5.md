| Description                               | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · MD5 · BouncyCastle       | 128B         |     336.0 ns |     1.09 ns |     1.02 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128B         |     363.7 ns |     1.30 ns |     1.15 ns |         - |
| TryComputeHash · MD5 · OS Native          | 128B         |     902.2 ns |     2.29 ns |     2.03 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 137B         |     337.2 ns |     1.25 ns |     1.16 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 137B         |     363.9 ns |     1.17 ns |     1.04 ns |         - |
| TryComputeHash · MD5 · OS Native          | 137B         |     891.1 ns |     2.55 ns |     2.39 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 1KB          |   1,887.8 ns |     5.67 ns |     5.30 ns |         - |
| TryComputeHash · MD5 · OS Native          | 1KB          |   1,929.4 ns |     9.10 ns |     7.60 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1KB          |   2,084.0 ns |    16.34 ns |    15.28 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · BouncyCastle       | 1025B        |   1,902.9 ns |    35.38 ns |    33.09 ns |         - |
| TryComputeHash · MD5 · OS Native          | 1025B        |   1,932.1 ns |    17.09 ns |    15.98 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 1025B        |   2,079.9 ns |    12.10 ns |    11.32 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 8KB          |   9,911.9 ns |    35.80 ns |    31.74 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 8KB          |  14,280.0 ns |    42.67 ns |    39.91 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 8KB          |  15,848.4 ns |    92.55 ns |    82.04 ns |         - |
|                                           |              |              |             |             |           |
| TryComputeHash · MD5 · OS Native          | 128KB        | 146,068.1 ns |   650.49 ns |   608.47 ns |         - |
| TryComputeHash · MD5 · BouncyCastle       | 128KB        | 226,593.4 ns |   774.99 ns |   724.92 ns |         - |
| TryComputeHash · MD5 · CryptoHives-Scalar | 128KB        | 251,939.9 ns | 2,095.60 ns | 1,960.22 ns |         - |