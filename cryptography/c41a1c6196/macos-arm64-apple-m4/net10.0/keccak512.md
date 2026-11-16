| Description                                      | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     306.2 ns |     1.01 ns |   0.94 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     323.6 ns |     1.28 ns |   1.14 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     328.6 ns |     0.98 ns |   0.91 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     307.0 ns |     0.46 ns |   0.43 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     324.6 ns |     1.13 ns |   1.05 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     327.6 ns |     0.78 ns |   0.73 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,261.2 ns |     5.99 ns |   5.61 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,349.7 ns |     9.75 ns |   8.64 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,409.6 ns |     5.05 ns |   4.73 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,262.9 ns |     6.54 ns |   6.12 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,282.2 ns |     4.74 ns |   3.70 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,406.8 ns |     6.57 ns |   6.15 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  17,142.2 ns |    31.08 ns |  29.07 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,253.1 ns |    75.81 ns |  70.91 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  18,200.6 ns |    55.37 ns |  51.79 ns |         - |
|                                                  |              |              |             |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 274,658.2 ns |   527.77 ns | 467.86 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 275,900.0 ns | 1,126.36 ns | 998.49 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 291,110.1 ns |   793.93 ns | 703.80 ns |         - |