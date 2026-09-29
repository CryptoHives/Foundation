| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128B         |     753.5 ns |     2.27 ns |     2.12 ns |   9,485 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128B         |     814.2 ns |     2.61 ns |     2.31 ns |   4,270 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 137B         |     755.0 ns |     1.84 ns |     1.72 ns |   9,489 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 137B         |     820.0 ns |     2.89 ns |     2.57 ns |   4,258 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1KB          |   4,174.1 ns |    15.11 ns |    13.40 ns |   9,493 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1KB          |   4,551.8 ns |    15.02 ns |    12.54 ns |   4,270 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 1025B        |   4,183.6 ns |    23.00 ns |    21.51 ns |   9,494 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 1025B        |   4,561.6 ns |    27.33 ns |    25.56 ns |   4,263 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 8KB          |  31,528.7 ns |   180.79 ns |   169.12 ns |   9,343 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 8KB          |  34,436.7 ns |    89.70 ns |    79.52 ns |   4,270 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle       | 128KB        | 500,695.1 ns | 1,599.39 ns | 1,335.56 ns |   9,456 B |         - |
| TryComputeHash · RIPEMD-160 · CryptoHives-Scalar | 128KB        | 548,645.8 ns | 4,010.68 ns | 3,751.59 ns |   4,280 B |         - |