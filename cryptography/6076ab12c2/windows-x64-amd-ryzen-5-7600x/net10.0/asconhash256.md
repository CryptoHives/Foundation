| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     661.1 ns |     1.75 ns |     1.64 ns |   3,988 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     898.9 ns |     1.13 ns |     1.00 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     698.2 ns |     2.44 ns |     2.04 ns |   3,996 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     949.5 ns |    11.12 ns |    10.40 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,360.1 ns |    53.79 ns |    50.31 ns |   3,988 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,861.7 ns |    31.71 ns |    29.66 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,356.1 ns |    52.34 ns |    48.96 ns |   3,996 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,867.4 ns |    62.11 ns |    58.10 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  33,747.9 ns |   462.11 ns |   432.25 ns |   4,004 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  45,675.9 ns |   384.31 ns |   359.48 ns |   5,071 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 539,057.4 ns | 6,562.66 ns | 6,138.72 ns |   3,955 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 725,925.3 ns | 5,872.53 ns | 5,493.17 ns |   5,059 B |         - |