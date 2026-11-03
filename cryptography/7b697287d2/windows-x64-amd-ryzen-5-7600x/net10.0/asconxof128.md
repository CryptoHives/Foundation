| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     660.2 ns |     1.33 ns |     1.18 ns |   3,998 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     885.9 ns |     1.28 ns |     1.00 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     696.3 ns |     1.74 ns |     1.54 ns |   4,010 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     932.1 ns |     1.55 ns |     1.45 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   4,268.8 ns |    13.74 ns |    12.85 ns |   3,998 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,714.9 ns |     6.42 ns |     5.69 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   4,273.4 ns |     9.90 ns |     9.26 ns |   4,010 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,714.9 ns |    10.77 ns |     9.55 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  33,158.3 ns |   123.38 ns |   109.37 ns |   4,010 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  44,354.6 ns |    64.92 ns |    60.73 ns |   4,920 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 527,960.2 ns | 1,276.93 ns | 1,194.44 ns |   3,957 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 708,179.5 ns |   794.64 ns |   743.31 ns |   4,910 B |         - |