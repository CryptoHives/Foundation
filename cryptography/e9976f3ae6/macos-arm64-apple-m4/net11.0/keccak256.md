| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     160.4 ns |     0.87 ns |     0.82 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     171.6 ns |     0.33 ns |     0.31 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     173.6 ns |     0.91 ns |     0.76 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     315.4 ns |     1.16 ns |     1.08 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     328.2 ns |     2.50 ns |     2.34 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     334.7 ns |     1.39 ns |     1.30 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,225.8 ns |     3.19 ns |     2.99 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,279.5 ns |     5.72 ns |     5.35 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,309.2 ns |     3.77 ns |     3.52 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,224.5 ns |     3.09 ns |     2.89 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,247.5 ns |     6.74 ns |     6.31 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,311.7 ns |     3.27 ns |     3.06 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,286.4 ns |    34.30 ns |    32.08 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,309.9 ns |    28.13 ns |    26.32 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,895.8 ns |    20.62 ns |    18.28 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 147,415.3 ns | 1,203.79 ns | 1,126.02 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 148,367.1 ns |   379.13 ns |   354.64 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 156,557.1 ns |   239.01 ns |   211.88 ns |         - |