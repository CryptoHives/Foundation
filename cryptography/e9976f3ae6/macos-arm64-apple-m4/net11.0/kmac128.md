| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     488.0 ns |   1.29 ns |   1.21 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,047.2 ns |   4.20 ns |   3.93 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     489.5 ns |   1.33 ns |   1.24 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,024.8 ns |   3.86 ns |   3.61 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,397.0 ns |   4.96 ns |   4.39 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   1,930.0 ns |   7.22 ns |   6.75 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,390.1 ns |   5.07 ns |   4.74 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   1,944.1 ns |   8.97 ns |   8.39 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |   7,692.5 ns |  34.73 ns |  32.49 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |   8,422.8 ns |  29.84 ns |  27.91 ns |     256 B |
|                                                |              |              |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 118,290.3 ns | 368.98 ns | 327.09 ns |         - |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 121,094.4 ns | 805.02 ns | 713.63 ns |     256 B |