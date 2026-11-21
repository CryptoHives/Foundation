| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     161.3 ns |     0.24 ns |     0.23 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     173.2 ns |     0.18 ns |     0.14 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     176.1 ns |     0.87 ns |     0.81 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     307.4 ns |     0.32 ns |     0.30 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     328.9 ns |     1.54 ns |     1.44 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     334.3 ns |     0.54 ns |     0.51 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,219.9 ns |     1.30 ns |     1.21 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,238.8 ns |     4.30 ns |     3.59 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,309.8 ns |     1.77 ns |     1.65 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,202.6 ns |     1.60 ns |     1.50 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,239.5 ns |     3.78 ns |     3.53 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,305.1 ns |     1.49 ns |     1.25 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,193.2 ns |    27.07 ns |    24.00 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,344.3 ns |    76.08 ns |    71.17 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,847.7 ns |    16.68 ns |    15.60 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 146,836.0 ns |   189.21 ns |   176.99 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 147,838.2 ns | 1,147.21 ns | 1,016.98 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 155,581.5 ns |   263.32 ns |   233.42 ns |         - |