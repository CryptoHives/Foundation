| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     177.8 ns |     1.13 ns |     1.00 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     249.7 ns |     3.81 ns |     3.56 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     326.8 ns |     1.21 ns |     1.13 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     608.2 ns |     4.86 ns |     4.54 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,265.8 ns |     6.64 ns |     5.88 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,440.2 ns |     6.76 ns |     5.99 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,265.1 ns |     4.61 ns |     4.09 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,436.1 ns |     5.11 ns |     4.78 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,445.8 ns |    37.22 ns |    32.99 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,977.7 ns |     9.19 ns |     7.67 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 150,434.6 ns | 1,378.54 ns | 1,289.49 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 154,855.2 ns | 1,075.21 ns |   953.15 ns |         - |