| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128B         |     303.5 ns |     0.20 ns |     0.18 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     322.6 ns |     4.10 ns |     3.83 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |     324.2 ns |     0.60 ns |     0.57 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 137B         |     301.6 ns |     0.21 ns |     0.19 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     321.4 ns |     3.07 ns |     2.87 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |     324.2 ns |     0.60 ns |     0.50 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1KB          |   2,235.0 ns |     4.55 ns |     3.80 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |   2,258.6 ns |    14.11 ns |    11.78 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |   2,385.3 ns |     7.36 ns |     6.88 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 1025B        |   2,232.7 ns |     2.14 ns |     1.79 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |   2,272.8 ns |    27.83 ns |    26.03 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |   2,383.8 ns |     7.39 ns |     6.91 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 8KB          |  16,943.4 ns |    17.23 ns |    15.27 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |  17,059.6 ns |   102.09 ns |    90.50 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |  17,999.4 ns |    26.44 ns |    20.65 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-512 · CryptoHives-Arm64  | 128KB        | 271,506.9 ns |   284.64 ns |   252.32 ns |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 273,755.0 ns | 3,692.33 ns | 3,453.81 ns |         - |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        | 288,411.1 ns |   971.75 ns |   908.97 ns |         - |