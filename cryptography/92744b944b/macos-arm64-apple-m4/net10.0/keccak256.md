| Description                                      | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     175.6 ns |   0.19 ns |   0.17 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     179.4 ns |   0.75 ns |   0.67 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     325.2 ns |   1.14 ns |   0.95 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     541.5 ns |   9.19 ns |   8.60 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,275.3 ns |   5.47 ns |   4.85 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,378.2 ns |  10.59 ns |   8.84 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,264.6 ns |   5.69 ns |   4.44 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,371.8 ns |   3.51 ns |   3.29 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,513.4 ns |  26.32 ns |  21.98 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,944.7 ns |  59.76 ns |  52.97 ns |         - |
|                                                  |              |              |           |           |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 149,685.7 ns | 526.60 ns | 466.82 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 153,761.7 ns | 210.88 ns | 186.94 ns |         - |