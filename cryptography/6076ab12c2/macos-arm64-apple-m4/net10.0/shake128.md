| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     163.3 ns |   0.25 ns |   0.21 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     171.4 ns |   0.19 ns |   0.17 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     176.5 ns |   1.53 ns |   1.44 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     164.3 ns |   0.16 ns |   0.14 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     171.5 ns |   0.36 ns |   0.34 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     176.3 ns |   0.95 ns |   0.89 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,051.6 ns |   1.24 ns |   1.10 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,088.8 ns |   4.66 ns |   3.64 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,138.0 ns |   3.59 ns |   3.36 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,051.8 ns |   0.92 ns |   0.86 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,101.2 ns |   0.54 ns |   0.43 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,137.1 ns |   2.42 ns |   2.26 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,413.1 ns |   5.27 ns |   4.67 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,582.4 ns |  10.94 ns |   8.54 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,992.9 ns |  10.46 ns |   9.27 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 118,583.4 ns | 153.60 ns | 143.68 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 121,267.5 ns | 375.29 ns | 332.69 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 127,635.3 ns | 224.14 ns | 209.66 ns |         - |