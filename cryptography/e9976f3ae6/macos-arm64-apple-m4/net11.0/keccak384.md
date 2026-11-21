| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     309.1 ns |     1.07 ns |   1.00 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     321.3 ns |     2.12 ns |   1.98 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     330.4 ns |     1.20 ns |   1.12 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     308.1 ns |     0.94 ns |   0.88 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     324.1 ns |     2.20 ns |   2.06 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     333.4 ns |     0.94 ns |   0.88 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,520.8 ns |     3.92 ns |   3.67 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,545.8 ns |     6.28 ns |   5.24 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,629.2 ns |     5.12 ns |   4.79 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,524.2 ns |     4.34 ns |   4.06 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,545.2 ns |     7.02 ns |   6.22 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,625.8 ns |     3.95 ns |   3.70 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,932.3 ns |    64.03 ns |  59.89 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,002.3 ns |    61.03 ns |  54.10 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,750.5 ns |    30.35 ns |  28.39 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 191,488.4 ns |   723.79 ns | 677.04 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 191,978.7 ns | 1,012.53 ns | 947.12 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 203,658.7 ns |   628.76 ns | 525.04 ns |         - |