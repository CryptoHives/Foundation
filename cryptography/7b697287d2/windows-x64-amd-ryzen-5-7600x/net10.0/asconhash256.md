| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     660.0 ns |     1.95 ns |     1.82 ns |   3,988 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     887.5 ns |     0.68 ns |     0.60 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     696.9 ns |     1.33 ns |     1.18 ns |   3,996 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     935.9 ns |     0.73 ns |     0.65 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   4,269.3 ns |     7.95 ns |     7.05 ns |   3,988 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,780.5 ns |    11.56 ns |    10.81 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   4,270.9 ns |    10.17 ns |     8.49 ns |   3,996 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,778.4 ns |     6.79 ns |     6.35 ns |   5,062 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  33,114.4 ns |    67.66 ns |    63.29 ns |   4,004 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  44,859.7 ns |    88.33 ns |    82.62 ns |   5,071 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 528,063.2 ns | 1,983.87 ns | 1,855.71 ns |   3,955 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 715,358.4 ns | 1,340.98 ns | 1,188.75 ns |   5,060 B |         - |