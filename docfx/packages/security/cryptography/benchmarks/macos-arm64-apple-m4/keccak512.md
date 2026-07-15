| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     297.9 ns |     0.59 ns |     0.49 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     318.5 ns |     0.68 ns |     0.60 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     325.3 ns |     1.53 ns |     1.28 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     297.9 ns |     0.13 ns |     0.10 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     318.0 ns |     0.33 ns |     0.29 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     324.2 ns |     1.27 ns |     1.13 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,234.3 ns |     1.68 ns |     1.58 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,317.4 ns |     9.92 ns |     8.79 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,356.1 ns |     2.49 ns |     2.08 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,224.5 ns |     2.06 ns |     1.83 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,296.3 ns |     5.14 ns |     4.55 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,360.7 ns |     3.62 ns |     3.21 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  16,995.6 ns |    12.61 ns |    11.18 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,316.4 ns |    52.71 ns |    44.01 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  17,875.3 ns |    23.08 ns |    20.46 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 271,416.7 ns |   279.45 ns |   261.40 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 277,299.2 ns | 1,550.37 ns | 1,374.36 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 285,156.0 ns |   235.44 ns |   183.82 ns |         - |