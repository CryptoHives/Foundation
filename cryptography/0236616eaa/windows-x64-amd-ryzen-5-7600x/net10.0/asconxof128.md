| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     573.1 ns |     1.55 ns |     1.37 ns |   5,782 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     783.6 ns |     3.10 ns |     2.59 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     602.7 ns |     1.14 ns |     1.01 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     818.1 ns |     1.49 ns |     1.40 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |   3,691.0 ns |     7.86 ns |     6.97 ns |   5,760 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |   5,025.8 ns |    10.73 ns |     8.38 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |   3,691.1 ns |     6.55 ns |     5.81 ns |   5,768 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |   5,024.1 ns |     6.04 ns |     5.35 ns |   6,655 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |  28,622.7 ns |    49.23 ns |    43.64 ns |   5,796 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |  39,007.3 ns |    57.82 ns |    48.28 ns |   6,664 B |         - |
|                                                    |              |              |             |             |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        | 457,586.4 ns |   550.76 ns |   459.91 ns |   5,731 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 623,144.1 ns | 1,409.57 ns | 1,177.06 ns |   6,654 B |         - |