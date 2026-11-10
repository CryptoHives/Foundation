| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     427.7 ns |     0.25 ns |     0.21 ns |   5,476 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128B         |     541.6 ns |     0.63 ns |     0.56 ns |   5,249 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     603.1 ns |     0.70 ns |     0.66 ns |   6,303 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     830.1 ns |     0.98 ns |     0.92 ns |   5,458 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 137B         |   1,057.1 ns |     3.07 ns |     2.72 ns |   5,229 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |   1,138.4 ns |     0.98 ns |     0.87 ns |   7,701 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   3,308.2 ns |     2.43 ns |     2.15 ns |   5,464 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1KB          |   4,184.1 ns |     7.96 ns |     7.45 ns |   5,237 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   4,465.8 ns |     4.79 ns |     4.48 ns |   7,674 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   3,310.1 ns |     2.54 ns |     2.25 ns |   5,464 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 1025B        |   4,195.1 ns |     8.67 ns |     8.11 ns |   5,237 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   4,465.1 ns |     2.99 ns |     2.79 ns |   7,704 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |  24,699.5 ns |    56.43 ns |    50.02 ns |   5,460 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 8KB          |  31,696.0 ns |    58.85 ns |    55.05 ns |   5,231 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |  33,597.5 ns |    29.86 ns |    24.93 ns |   7,700 B |         - |
|                                                  |              |              |             |             |           |           |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 388,200.7 ns |   384.59 ns |   340.93 ns |   5,462 B |         - |
| TryComputeHash · Keccak-256 · CryptoHives-AVX2   | 128KB        | 499,711.2 ns | 1,383.31 ns | 1,293.95 ns |   5,235 B |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 530,100.4 ns |   584.94 ns |   547.15 ns |   7,706 B |         - |