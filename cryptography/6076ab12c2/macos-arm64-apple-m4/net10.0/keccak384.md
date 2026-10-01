| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     306.1 ns |   0.20 ns |   0.19 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     323.4 ns |   3.63 ns |   3.40 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     326.5 ns |   0.71 ns |   0.66 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     306.0 ns |   0.32 ns |   0.27 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     321.3 ns |   1.14 ns |   1.01 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     326.4 ns |   0.52 ns |   0.48 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,505.7 ns |   1.12 ns |   1.00 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,534.8 ns |   2.79 ns |   2.33 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,606.3 ns |   3.36 ns |   2.98 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,506.1 ns |   1.13 ns |   1.05 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,550.3 ns |  13.26 ns |  12.40 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,607.2 ns |   3.51 ns |   2.93 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,858.4 ns |   6.46 ns |   6.05 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  12,023.8 ns | 114.84 ns | 101.80 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,584.9 ns |  22.31 ns |  20.87 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 190,896.2 ns | 106.13 ns |  88.62 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 191,228.0 ns | 975.35 ns | 912.34 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 200,944.3 ns | 301.09 ns | 281.64 ns |         - |