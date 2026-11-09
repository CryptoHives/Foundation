| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     776.5 ns |     1.97 ns |     1.84 ns |   9,487 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |   1,260.9 ns |     2.90 ns |     2.71 ns |   4,309 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     774.0 ns |     1.62 ns |     1.51 ns |   9,503 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |   1,267.3 ns |     4.51 ns |     4.22 ns |   4,297 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   4,397.6 ns |    13.05 ns |    12.21 ns |   9,499 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   6,850.4 ns |    25.08 ns |    23.46 ns |   4,309 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   4,400.8 ns |    12.47 ns |    11.66 ns |   9,504 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   6,850.9 ns |    25.00 ns |    22.16 ns |   4,302 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  32,907.0 ns |    73.41 ns |    61.30 ns |   9,511 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  51,396.9 ns |   109.41 ns |    96.99 ns |   4,309 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 515,413.0 ns | 1,980.56 ns | 1,852.62 ns |   9,462 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 813,623.3 ns | 2,767.48 ns | 2,160.67 ns |   4,309 B |         - |