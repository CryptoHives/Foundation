| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     301.7 ns |   0.21 ns |   0.19 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     323.6 ns |   1.50 ns |   1.33 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     324.9 ns |   1.00 ns |   0.88 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     302.2 ns |   0.13 ns |   0.11 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     322.4 ns |   0.73 ns |   0.65 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     325.5 ns |   0.63 ns |   0.59 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,500.8 ns |   1.02 ns |   0.96 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,565.6 ns |   6.50 ns |   5.43 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,597.7 ns |   3.64 ns |   3.23 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,501.1 ns |   1.09 ns |   1.02 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,563.4 ns |   4.94 ns |   4.13 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,591.1 ns |   3.09 ns |   2.74 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,860.1 ns |   9.19 ns |   8.15 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,151.9 ns |  43.04 ns |  35.94 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,577.9 ns |  31.40 ns |  29.37 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 190,561.3 ns | 166.90 ns | 156.12 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 194,608.1 ns | 647.67 ns | 540.84 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 200,871.9 ns | 579.37 ns | 541.95 ns |         - |