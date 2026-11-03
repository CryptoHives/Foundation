| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     158.7 ns |   0.54 ns |   0.51 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     169.6 ns |   0.60 ns |   0.56 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     172.6 ns |   2.16 ns |   2.02 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     307.1 ns |   0.99 ns |   0.92 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     316.9 ns |   1.24 ns |   1.10 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     329.2 ns |   0.87 ns |   0.82 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,205.2 ns |   0.97 ns |   0.91 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,239.3 ns |  12.88 ns |  12.05 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,292.7 ns |   2.83 ns |   2.51 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,204.9 ns |   1.38 ns |   1.23 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,237.1 ns |  16.02 ns |  14.98 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,292.7 ns |   2.51 ns |   2.34 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,117.3 ns |  15.61 ns |  14.60 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,211.6 ns |  66.34 ns |  58.81 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,763.9 ns |  22.44 ns |  20.99 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 144,896.2 ns | 114.04 ns | 106.68 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 145,929.5 ns | 707.67 ns | 627.33 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 154,484.3 ns | 586.04 ns | 548.18 ns |         - |