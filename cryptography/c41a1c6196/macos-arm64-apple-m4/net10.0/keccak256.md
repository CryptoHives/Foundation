| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     159.7 ns |   0.65 ns |   0.60 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     170.0 ns |   0.46 ns |   0.43 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     173.6 ns |   1.03 ns |   0.97 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     309.8 ns |   0.73 ns |   0.68 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     323.1 ns |   1.88 ns |   1.76 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     332.7 ns |   1.22 ns |   1.14 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,220.9 ns |   3.25 ns |   3.04 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,247.2 ns |   5.50 ns |   4.88 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,305.5 ns |   4.09 ns |   3.83 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,221.3 ns |   3.89 ns |   3.64 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,247.2 ns |   7.91 ns |   7.40 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,308.7 ns |   3.24 ns |   3.03 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,235.4 ns |  27.49 ns |  25.71 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,359.6 ns |  42.77 ns |  40.01 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,880.7 ns |  38.36 ns |  35.88 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 146,611.3 ns | 374.69 ns | 350.49 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 147,934.2 ns | 387.30 ns | 343.33 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 155,789.0 ns | 580.31 ns | 542.82 ns |         - |