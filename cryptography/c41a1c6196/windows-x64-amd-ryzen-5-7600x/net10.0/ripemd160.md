| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     748.8 ns |     1.12 ns |     0.88 ns |   9,481 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     810.5 ns |     1.39 ns |     1.16 ns |   4,291 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     749.0 ns |     0.84 ns |     0.70 ns |   9,489 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     814.8 ns |     1.77 ns |     1.38 ns |   4,279 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   4,150.7 ns |     8.94 ns |     7.47 ns |   9,497 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,536.1 ns |    10.87 ns |     9.08 ns |   4,291 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   4,156.4 ns |     7.17 ns |     5.99 ns |   9,494 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,539.5 ns |    15.25 ns |    12.73 ns |   4,284 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  31,388.0 ns |    62.29 ns |    52.02 ns |   9,343 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  34,271.8 ns |    55.38 ns |    49.09 ns |   4,291 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 499,125.7 ns | 1,220.94 ns | 1,082.33 ns |   9,456 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 544,777.5 ns |   691.70 ns |   577.60 ns |   4,301 B |         - |