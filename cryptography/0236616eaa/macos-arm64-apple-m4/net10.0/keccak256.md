| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     171.1 ns |     3.46 ns |     6.32 ns |     173.4 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     183.7 ns |     1.50 ns |     1.40 ns |     183.1 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     186.8 ns |     3.21 ns |     3.00 ns |     186.9 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     363.9 ns |     7.18 ns |    10.53 ns |     363.9 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     386.1 ns |     7.56 ns |     9.00 ns |     386.0 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     391.7 ns |     7.82 ns |    17.66 ns |     392.3 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,522.2 ns |    30.25 ns |    36.01 ns |   1,523.4 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,594.5 ns |    12.00 ns |    11.23 ns |   1,598.4 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   5,216.8 ns |   538.99 ns | 1,520.22 ns |   5,810.8 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,233.9 ns |    12.25 ns |    10.86 ns |   1,229.6 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,265.0 ns |    48.97 ns |   133.23 ns |   1,202.5 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,293.2 ns |     2.46 ns |     2.18 ns |   1,293.0 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |   9,185.4 ns |    73.14 ns |    68.42 ns |   9,168.8 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |   9,246.6 ns |   153.88 ns |   136.41 ns |   9,180.8 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |   9,791.2 ns |    31.63 ns |    29.58 ns |   9,803.0 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 145,481.2 ns | 1,319.08 ns | 1,233.87 ns | 144,813.3 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 149,105.6 ns |   511.03 ns |   453.01 ns | 148,959.1 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 154,164.1 ns |   438.80 ns |   410.46 ns | 154,015.1 ns |         - |