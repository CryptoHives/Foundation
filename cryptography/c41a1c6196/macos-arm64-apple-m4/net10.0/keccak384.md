| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     307.9 ns |   0.49 ns |   0.46 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     326.7 ns |   1.46 ns |   1.29 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     330.2 ns |   0.97 ns |   0.90 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     307.3 ns |   0.42 ns |   0.37 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     327.6 ns |   2.14 ns |   2.00 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     330.5 ns |   0.77 ns |   0.68 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,516.0 ns |   5.72 ns |   5.35 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,554.5 ns |   4.87 ns |   4.55 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,624.9 ns |   3.07 ns |   2.72 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,526.9 ns |   4.27 ns |   4.00 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,597.8 ns |   5.80 ns |   5.14 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,620.8 ns |   3.49 ns |   3.27 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,941.8 ns |  20.82 ns |  19.48 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,094.4 ns |  66.84 ns |  62.52 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,736.2 ns |  39.02 ns |  36.50 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 191,965.2 ns | 893.87 ns | 836.13 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 193,400.0 ns | 660.38 ns | 585.41 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 203,469.4 ns | 410.62 ns | 384.09 ns |         - |