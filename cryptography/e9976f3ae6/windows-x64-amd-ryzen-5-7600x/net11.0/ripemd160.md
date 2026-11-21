| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     755.1 ns |     1.10 ns |     0.86 ns |   9,396 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     816.7 ns |     4.27 ns |     4.00 ns |  13,150 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     756.1 ns |     2.88 ns |     2.55 ns |   9,397 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     822.1 ns |     2.12 ns |     1.77 ns |   6,803 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   4,190.1 ns |    14.11 ns |    12.51 ns |   9,397 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,567.1 ns |    14.47 ns |    12.83 ns |  13,340 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   4,195.6 ns |    13.20 ns |    11.70 ns |   9,398 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,586.0 ns |    32.48 ns |    30.38 ns |   6,806 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  31,573.5 ns |    36.47 ns |    30.45 ns |   9,409 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  34,475.8 ns |   107.00 ns |    89.35 ns |  13,150 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 501,293.9 ns |   771.41 ns |   644.16 ns |   9,619 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 549,571.8 ns | 1,542.73 ns | 1,367.59 ns |   6,825 B |         - |