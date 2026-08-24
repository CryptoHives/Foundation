| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |     304.4 ns |     0.27 ns |     0.25 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     316.2 ns |     2.29 ns |     2.03 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     325.8 ns |     0.82 ns |     0.77 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     302.7 ns |     0.29 ns |     0.27 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     318.0 ns |     3.26 ns |     3.05 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     324.9 ns |     0.44 ns |     0.37 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,497.4 ns |    15.00 ns |    11.71 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,706.3 ns |    30.43 ns |    44.60 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,791.2 ns |    35.13 ns |    93.16 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   1,819.9 ns |    35.46 ns |    44.84 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,840.2 ns |    36.06 ns |    50.55 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,966.5 ns |    30.17 ns |    26.75 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  14,237.8 ns |   172.69 ns |   153.09 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  15,298.9 ns |   144.37 ns |   135.04 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  15,422.4 ns |   297.91 ns |   376.76 ns |         - |
|                                                  |              |              |             |             |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 903,124.2 ns | 3,065.28 ns | 2,717.29 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 914,224.0 ns | 8,275.10 ns | 6,910.09 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 947,706.6 ns | 2,281.70 ns | 1,905.33 ns |         - |