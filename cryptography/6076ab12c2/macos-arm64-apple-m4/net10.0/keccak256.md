| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     161.5 ns |   0.08 ns |   0.07 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     168.9 ns |   1.27 ns |   1.19 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     169.9 ns |   2.23 ns |   1.98 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     306.0 ns |   0.22 ns |   0.19 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     318.8 ns |   3.22 ns |   3.01 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     329.2 ns |   0.71 ns |   0.67 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,208.5 ns |   0.93 ns |   0.87 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,234.8 ns |   5.63 ns |   4.99 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,295.2 ns |   3.10 ns |   2.90 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,207.1 ns |   0.89 ns |   0.79 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,237.9 ns |   9.70 ns |   8.60 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,293.7 ns |   2.28 ns |   2.13 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,139.6 ns |  10.05 ns |   9.40 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,160.6 ns |  20.47 ns |  17.10 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,747.8 ns |  15.03 ns |  13.32 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 145,191.1 ns | 282.99 ns | 264.71 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 145,838.6 ns | 748.86 ns | 663.84 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 154,237.2 ns | 330.11 ns | 308.78 ns |         - |